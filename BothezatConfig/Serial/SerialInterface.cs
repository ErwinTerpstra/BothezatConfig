using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace BothezatConfig.Serial
{
    public class SerialInterface
    {
        private const int READ_CHUNK_SIZE = 16;

        private const int MESSAGE_BUFFER_SIZE = 1024;

        private const int PAYLOAD_BUFFER_SIZE = 1024 * 16;

        public delegate void LogHandler(string log);

        public delegate void PageResponseHandler(Page page);

        public delegate void CommandResponseHandler(Command.ResponseMessage response);

        public LogHandler logHandler;
        
        private Dictionary<UInt32, PageResponseHandler> pageResponseHandlers;
        
        private Dictionary<UInt32, CommandResponseHandler> commandResponseHandlers;

        private Buffer crcBuffer;

        private SerialPort serialPort;

		private Thread messageThread;

        private bool disposed;

        private byte[] readChunk;

        private Buffer messageBuffer;

        private Buffer payloadBuffer;

        private BinaryWriter writer;

        private bool headersRead;

        private Message currentlyReadingMessage;

        private Random random;

		public SerialInterface()
        {
            random = new Random();

            pageResponseHandlers = new Dictionary<uint, PageResponseHandler>();
            commandResponseHandlers = new Dictionary<uint, CommandResponseHandler>();
        }

        public void Initialize()
        {
            serialPort = new SerialPort();

            headersRead = false;
            currentlyReadingMessage = new Message();

            readChunk = new byte[READ_CHUNK_SIZE];

            // Create a buffer to hold the read message data
            messageBuffer = new Buffer();
            messageBuffer.Allocate(MESSAGE_BUFFER_SIZE);
            
            // Create a buffer to hold the serialized message data
            payloadBuffer = new Buffer();
            payloadBuffer.Allocate(PAYLOAD_BUFFER_SIZE);

            crcBuffer = new Buffer();
            crcBuffer.Allocate(currentlyReadingMessage.SerializedSize);
            
            messageThread = new Thread(MessageRoutine);
			messageThread.Name = "SerialInterface message thread";
			messageThread.Start();
        }

        public bool OpenFirstAvailable(int baudRate)
        {
            foreach (string portName in SerialPort.GetPortNames())
            {
                Configure(portName, baudRate);

                if (Open())
                    return true;
            }

            return false;
        }

        public void Configure(string portName, int baudRate)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
        }

		public bool Open()
        {
            try
            {
                Console.WriteLine("[SerialInterface]: Opening {0}...", serialPort.PortName);
                serialPort.Open();
            }
            catch (IOException)
            {
                return false;
            }

            writer = new BinaryWriter(serialPort.BaseStream);

            return true;
        }

		public void Close()
        {
            serialPort.Close();
        }

        public void SendMessage(Message message)
        {
            message.id = GetNextMessageID();
            message.crc = CalculateMessageCRC(message);

            // Serialize the message headers to the serial port
            message.Serialize(writer);

            // Write the message payload to the serial port
            writer.Write(message.payload);
            
            serialPort.BaseStream.Flush();
        }

        public void RequestPage(Page.Resource.Type[] resourceTypes, PageResponseHandler handler)
        {
            if (resourceTypes.Length > Page.MAX_RESOURCES_PER_PAGE)
                throw new ArgumentOutOfRangeException("Can't request more than " + Page.MAX_RESOURCES_PER_PAGE + " resources per page");

            // Create a request message with the page data
            Page.RequestMessage requestMessage = new Page.RequestMessage();
            requestMessage.resourceTypes = resourceTypes;

            // Serialize the message into the payload buffer
            requestMessage.Serialize(payloadBuffer);

            // Construct a message to send
            Message message = new Message();
            message.type = Message.Type.TYPE_PAGE;
            message.phase = Message.Phase.PHASE_REQUEST;
            message.payload = payloadBuffer.GetData();

            payloadBuffer.Clear();

            SendMessage(message);

            // Check if there is already a handler defined for the message ID
            if (pageResponseHandlers.ContainsKey(message.id))
            {
                Console.WriteLine("[SerialInterface]: Duplicate page handler for message ID {0}!", message.id);
                return;
            }

            pageResponseHandlers[message.id] = handler;
        }

        public void SendCommand(Command.Type type, byte[] data, CommandResponseHandler handler)
        {
            // Create a request message with the command data
            Command.RequestMessage requestMessage = new Command.RequestMessage();
            requestMessage.type = type;
            requestMessage.length = (UInt32) data.Length;
            requestMessage.data = data;

            // Serialize the message into the payload buffer
            requestMessage.Serialize(payloadBuffer);

            // Construct a message to send
            Message message = new Message();
            message.type = Message.Type.TYPE_COMMAND;
            message.phase = Message.Phase.PHASE_REQUEST;
            message.payload = payloadBuffer.GetData();

            payloadBuffer.Clear();

            SendMessage(message);

            // Check if there is already a handler defined for the message ID
            if (commandResponseHandlers.ContainsKey(message.id))
            {
                Console.WriteLine("[SerialInterface]: Duplicate command handler for message ID {0}!", message.id);
                return;
            }

            commandResponseHandlers[message.id] = handler;
        }
        
		private void MessageRoutine()
        {
			while (!disposed)
            {
                if (serialPort.IsOpen)
                    ReadMessages();

                ProcessMessages();

                Thread.Sleep(50);
            }
        }

        private void ReadMessages()
        {
            while (serialPort.BytesToRead > 0)
            {
                int chunkSize = serialPort.Read(readChunk, 0, READ_CHUNK_SIZE);

                // If the message buffer is full and we can't read a message from it, there is a message larger than the buffer size
                // Ignore the culprit message by purging the buffer
                if (messageBuffer.FreeBytes() < chunkSize && ProcessMessages() == 0)
                    PurgeMessageBuffer();
                
                messageBuffer.writer.Write(readChunk, 0, chunkSize);
            }
        }

        private int ProcessMessages()
        {
            int messagesProcessed = 0;

            while (ReadMessage(currentlyReadingMessage))
            {
                ProcessMessage(currentlyReadingMessage);
                ++messagesProcessed;

                currentlyReadingMessage = new Message();
                headersRead = false;
            }

            return messagesProcessed;
        }

        private void ProcessMessage(Message message)
        {
            switch (message.phase)
            {
                case Message.Phase.PHASE_REQUEST:
                    HandleRequest(message);
                    break;

                case Message.Phase.PHASE_RESPONSE:
                    HandleResponse(message);
                    break;

                default:
                    Console.WriteLine("[SerialInterface]: Invalid message phase: {0}", message.phase);
                    break;
            }
        }
        
        private void HandleRequest(Message message)
        {

            switch (message.type)
            {
                case Message.Type.TYPE_LOG:
                    string log = Encoding.ASCII.GetString(message.payload);

                    if (logHandler != null)
                        logHandler(log);
                    
                    break;

                default:
                    Console.WriteLine("[SerialInterface]: Invalid message request type: {0}", message.type);
                    break;
            }
        }

        private void HandleResponse(Message message)
        {
            switch (message.type)
            {
                case Message.Type.TYPE_PAGE:
                    {
                        // Create a buffer to wrap the payload
                        Buffer buffer = new Buffer();
                        buffer.Wrap(message.payload);

                        // Deserialize the response message
                        Page.ResponseMessage responseMessage = new Page.ResponseMessage();
                        if (!responseMessage.Deserialize(buffer))
                        {
                            Console.WriteLine("[SerialInterface]: Failed to deserialize page response message!");
                            break;
                        }

                        // Retrieve the handler registered for this message
                        PageResponseHandler handler;

                        if (!pageResponseHandlers.TryGetValue(message.id, out handler))
                        {
                            Console.WriteLine("[SerialInterface]: Received page response with ID {0} but no handler is registered.", message.id);
                            break;
                        }

                        // Remove the handler so that each handler will only fire once
                        pageResponseHandlers.Remove(message.id);

                        // Create a page from the response message
                        Page page = new Page();
                        page.resources = responseMessage.resources;

                        // Call the page response handler
                        handler(page);

                        break;
                    }

                case Message.Type.TYPE_COMMAND:
                    {
                        // Create a buffer to wrap the payload
                        Buffer buffer = new Buffer();
                        buffer.Wrap(message.payload);

                        // Deserialize the response message
                        Command.ResponseMessage responseMessage = new Command.ResponseMessage();
                        if (!responseMessage.Deserialize(buffer))
                        {
                            Console.WriteLine("[SerialInterface]: Failed to deserialize command response message!");
                            break;
                        }

                        // Retrieve the handler registered for this message
                        CommandResponseHandler handler;

                        if (!commandResponseHandlers.TryGetValue(message.id, out handler))
                        {
                            Console.WriteLine("[SerialInterface]: Received command response with ID {0} but no handler is registered.", message.id);
                            break;
                        }

                        // Remove the handler so that each handler will only fire once
                        commandResponseHandlers.Remove(message.id);
                        
                        // Call the page response handler
                        handler(responseMessage);

                        break;
                    }


                default:
                    Console.WriteLine("[SerialInterface]: Invalid message response type: {0}", message.type);
                    break;
            }
        }

        private bool ReadMessage(Message message)
        {
            if (!headersRead && !ReadMessageHeaders(message))
                return false;

            if (messageBuffer.Available() < message.payload.Length)
                return false;

            message.payload = new byte[message.payload.Length];
            int bytesRead = messageBuffer.reader.Read(message.payload, 0, message.payload.Length);
            Debug.Assert(bytesRead == message.payload.Length);

            return true;
        }

        private bool ReadMessageHeaders(Message message)
        {
            if (!SyncMessageStream())
                return false;
            
            if (messageBuffer.Available() < message.SerializedSize)
                return false;

            message.Deserialize(messageBuffer.reader);

            UInt32 expectedCRC = CalculateMessageCRC(message);
            if (message.crc != expectedCRC & false)
            {
                Console.WriteLine("[SerialInterface]: Invalid CRC received for message! Got: 0x{0:X}; Expected: 0x{1:X}", message.crc, expectedCRC);
                return false;
            }

            headersRead = true;

            return true;
        }

        private bool SyncMessageStream()
        {
            int skippedBytes = 0;

            while (messageBuffer.Available() >= sizeof(UInt32))
            {
                UInt32 magic = messageBuffer.reader.ReadUInt32();
                messageBuffer.Seek(-sizeof(UInt32), SeekOrigin.Current);

                if (magic == Message.MESSAGE_MAGIC)
                {
                    if (skippedBytes > 0)
                        Console.WriteLine("[SerialInterface]: Synced message stream by skipping {0} bytes.", skippedBytes);

                    return true;
                }

                if (messageBuffer.Available() == 0)
                    break;

                messageBuffer.reader.ReadByte();
                ++skippedBytes;
            }

            return false;
        }

        private void PurgeMessageBuffer()
        {
            messageBuffer.Clear();
            headersRead = false;
        }

        private UInt32 CalculateMessageCRC(Message message)
        {
            crcBuffer.writer.Write(message.magic);
            crcBuffer.writer.Write((byte)message.phase);
			crcBuffer.writer.Write((byte)message.type);
            crcBuffer.writer.Write(message.id);
            crcBuffer.writer.Write((UInt16) message.payload.Length);

            UInt32 crc = Crc32.Compute(crcBuffer.GetData());

            crcBuffer.Clear();

            return crc;
        }

        public UInt32 GetNextMessageID()
        {
            return (UInt32) random.Next(int.MinValue, int.MaxValue);
        }

        public bool IsOpen
        {
            get { return serialPort.IsOpen; }
        }


    }
}
