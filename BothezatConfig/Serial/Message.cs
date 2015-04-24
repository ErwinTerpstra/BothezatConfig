using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BothezatConfig.Serial
{
    public class Message
    {
        public const UInt32 MESSAGE_MAGIC = 0xB074E6A7;

        // The size of a complete message, with a zero length payload
        public const UInt32 HEADER_SIZE = 16;

        public const UInt32 MAX_PAYLOAD_LENGTH = 1024 * 4;

        public enum Phase
        {
            PHASE_REQUEST = 0x00,
            PHASE_RESPONSE = 0x01
        };

        public enum Type
        {
            TYPE_PAGE = 0x01,
            TYPE_COMMAND = 0x02,
            TYPE_LOG = 0x03
        };

        // A magic number used to sync the stream to the start of a message, should have the value in MESSAGE_MAGIC
        public UInt32 magic;

        // The phase for this message, this is used to distinguish between request and response messages
        public Phase phase;

        // The message type
        public Type type;

        // The unique ID for this message, for response message this should be the ID of the corresponding request message
        public UInt32 id;

        // The total length of the payload, in bytes
        public UInt16 payloadLength;

        // The CRC over the message header, includes all the fields in the message struct up until this
        public UInt32 crc;

        public byte[] payload;

        public Message()
        {
            magic = MESSAGE_MAGIC;
            payload = null;
            crc = 0;
        }

        public void Deserialize(BinaryReader reader)
        {
            magic           = reader.ReadUInt32();
            phase           = (Phase)reader.ReadUInt32();
            type            = (Type)reader.ReadUInt32();
            id              = reader.ReadUInt32();
            payloadLength   = reader.ReadUInt16();
            crc             = reader.ReadUInt32();
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(magic);
            writer.Write((UInt32)phase);
            writer.Write((UInt32)type);
            writer.Write(id);
            writer.Write(payloadLength);
            writer.Write(crc);
        }

        public int SerializedSize
        {
            //           Magic            Phase            Type             ID               Payload length   CRC
            get { return sizeof(UInt32) + sizeof(UInt32) + sizeof(UInt32) + sizeof(UInt32) + sizeof(UInt16) + sizeof(UInt32); }
        }
    }
}
