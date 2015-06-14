using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BothezatConfig.Serial
{
    public class Command
    {

        public enum Type
        {
            SAVE_CONFIG = 0x01,
            RESET_CONFIG = 0x02,

            CALIBRATE_ACCELEROMETER = 0x10,

            INVALID_COMMAND = 0xFF
        }

        public enum State
        {
            COMMAND_OK = 0x00,
            COMMAND_UNKOWN = 0x01,
            COMMAND_ERROR = 0x02
        }
        
        public class RequestMessage
	    {
		    public Type type;

		    public UInt32 length;

		    public byte[] data;

		    public RequestMessage()
		    {

		    }

            public void Serialize(Buffer buffer)
            {
                buffer.writer.Write((byte)type);
                buffer.writer.Write(length);
                buffer.writer.Write(data);
            }

            public int SerializedSize
            {
                get
                {
                    return sizeof(byte) + sizeof(UInt32) + data.Length;
                }
            }
	    };

	    public class ResponseMessage
	    {
		    public State state;

		    public bool Deserialize(Buffer buffer)
            {
                if (buffer.Available() < sizeof(byte))
                    return false;

                state = (State)buffer.reader.ReadByte();

                return true;
            }
	    };
    }
}
