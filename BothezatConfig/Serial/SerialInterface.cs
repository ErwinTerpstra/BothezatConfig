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

        public delegate void MessageEvent(Message message);

        public event MessageEvent OnMessageReceived;

        public event MessageEvent OnMessageRequestReceived;

        public event MessageEvent OnMessageHeaderCrcFailed;

        public event MessageEvent OnMessagePayloadCrcFailed;

        public event MessageEvent OnMessageCrcFailed;

        private Buffer crcBuffer;

        private SerialPort serialPort;

		private Thread messageThread;

        private bool disposed;

        private byte[] readChunk;

        private Buffer messageBuffer;

        private BinaryWriter writer;

        private bool headersRead;

        private Message currentlyReadingMessage;

        private Random random;

		public SerialInterface()
        {
            random = new Random();
        }

        public void Initialize()
        {
            serialPort = new SerialPort();

            headersRead = false;
            currentlyReadingMessage = new Message();

            readChunk = new byte[READ_CHUNK_SIZE];

            messageBuffer = new Buffer();
            messageBuffer.Allocate(MESSAGE_BUFFER_SIZE);

            crcBuffer = new Buffer();
            crcBuffer.Allocate(currentlyReadingMessage.SerializedSize);
            
            messageThread = new Thread(MessageRoutine);
			messageThread.Name = "SerialInterface message thread";
			messageThread.Start();
        }

        public void Configure(string portName, int baudRate)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
        }

		public void Open()
        {
            serialPort.Open();

            writer = new BinaryWriter(serialPort.BaseStream);
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
            }

            return messagesProcessed;
        }

        private void ProcessMessage(Message message)
        {
            if (OnMessageReceived != null)
                OnMessageReceived(message);

            switch (message.phase)
            {
                case Message.Phase.PHASE_REQUEST:
                    if (OnMessageRequestReceived != null)
                        OnMessageRequestReceived(message);

                    break;

                case Message.Phase.PHASE_RESPONSE:
                    HandleResponse(message);
                    break;

                default:
                    Console.WriteLine("[SerialInterface]: Invalid message phase: {0}", message.phase);
                    break;
            }
        }
        
        private void HandleResponse(Message message)
        {
            switch (message.type)
            {

            }
        }

        private bool ReadMessage(Message message)
        {
            if (!headersRead && !ReadMessageHeaders(message))
                return false;

            if (messageBuffer.Available() < message.payloadLength)
                return false;

            message.payload = new byte[message.payloadLength];
            int bytesRead = messageBuffer.reader.Read(message.payload, 0, message.payloadLength);
            Debug.Assert(bytesRead == message.payloadLength);

            return true;
        }

        private bool ReadMessageHeaders(Message message)
        {
            if (!SyncMessageStream())
                return false;
            
            if (messageBuffer.Available() < message.SerializedSize)
                return false;

            message.Deserialize(messageBuffer.reader);

            if (message.crc != CalculateMessageCRC(message) && false)
            {
                if (OnMessageHeaderCrcFailed != null)
                    OnMessageHeaderCrcFailed(message);

                if (OnMessageCrcFailed != null)
                    OnMessageCrcFailed(message);

                return false;
            }

            return true;
        }

        private bool SyncMessageStream()
        {
            while (messageBuffer.Available() >= sizeof(UInt32))
            {
                UInt32 magic = messageBuffer.reader.ReadUInt32();
                messageBuffer.Seek(-sizeof(UInt32), SeekOrigin.Current);

                if (magic == Message.MESSAGE_MAGIC)
                    return true;

                messageBuffer.reader.ReadByte();
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
            crcBuffer.writer.Write((UInt32)message.phase);
            crcBuffer.writer.Write((UInt32)message.type);
            crcBuffer.writer.Write(message.id);
            crcBuffer.writer.Write(message.payloadLength);

            UInt32 crc = Crc32.Compute(crcBuffer.GetData());

            crcBuffer.Clear();

            return crc;
        }
        public UInt32 GetNextMessageID()
        {
            return (UInt32) random.Next(int.MinValue, int.MaxValue);
        }


    }
}
