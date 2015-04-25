using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BothezatConfig.Serial
{
	public class Page
	{
		public const int MAX_RESOURCES_PER_PAGE = 32;

		public class Resource
		{
			public enum Type
			{
				ORIENTATION 			= 0x01,
				ACCEL_ORIENTATION 		= 0x02,

				INVALID_RESOURCE 		= 0xff,
			};

			public Type type;

			public byte[] data;

			public Resource()
			{
                type = Type.INVALID_RESOURCE;
                data = new byte[0];
			}

			public void Serialize(Buffer buffer) 
			{
				buffer.writer.Write((byte) type);
                buffer.writer.Write((UInt32)data.Length);
                buffer.writer.Write(data);
			}

            public bool Deserialize(Buffer buffer)
            {
                if (buffer.Available() < sizeof(byte) + sizeof(UInt32))
                    return false;

                type = (Type) buffer.reader.ReadByte();

                UInt32 length = buffer.reader.ReadUInt32();

                if (buffer.Available() < length)
                    return false;

                data = new byte[length];
                int bytesRead = buffer.reader.Read(data, 0, (int) length);

                if (bytesRead != length)
                    throw new InvalidOperationException("Not enough bytes read!");

                return true;
            }

			public int SerializedSize
			{
                get
                {
                    //         Type         Length        Payload
                    return sizeof(byte) + sizeof(UInt32) + data.Length;
                }
			}
		};

		public class RequestMessage
		{
			public Resource.Type[] resourceTypes;

            public RequestMessage()
            {
            }

            public void Serialize(Buffer buffer)
            {
                buffer.writer.Write((UInt32) resourceTypes.Length);

                for (int resourceTypeIdx = 0; resourceTypeIdx < resourceTypes.Length; ++resourceTypeIdx)
                    buffer.writer.Write((byte) resourceTypes[resourceTypeIdx]);
            }

			public bool Deserialize(Buffer buffer)
			{
				// Make sure there is enough data to start in the stream
				if (buffer.Available() < sizeof(UInt32))
					return false;

                UInt32 numResources = buffer.reader.ReadUInt32();

                resourceTypes = new Resource.Type[numResources];

				// Make sure there is enough data to read all resource types
                if (buffer.Available() < numResources)
					return false;

				// Read all resource types
				for (int resourceIdx = 0; resourceIdx < numResources; ++resourceIdx)
					resourceTypes[resourceIdx] = (Resource.Type) buffer.reader.ReadByte();

				return true;
			}

            public int SerializedSize
            {
                get
                {
                    return sizeof(UInt32) + sizeof(byte) * resourceTypes.Length;
                }
            }
		};

		public class ResponseMessage
		{
			public Resource[] resources;

            public ResponseMessage()
            {
            }

			public void Serialize(Buffer buffer)
			{
				buffer.writer.Write((UInt32) resources.Length);

				// Serialize all the resources to the stream
				for (int resourceIdx = 0; resourceIdx < resources.Length; ++resourceIdx)
					resources[resourceIdx].Serialize(buffer);
			}

            public bool Deserialize(Buffer buffer)
            {
                if (buffer.Available() < sizeof(UInt32))
                    return false;

                UInt32 numResources = buffer.reader.ReadUInt32();

                resources = new Resource[numResources];

                for (int resourceIdx = 0; resourceIdx < numResources; ++resourceIdx)
                {
                    Resource resource = new Resource();
                    if (!resource.Deserialize(buffer))
                        return false;

                    resources[resourceIdx] = resource;
                }

                return true;
            }

			public int SerializedSize
			{
                get
                {
				    int size = sizeof(UInt32);

				    for (int resourceIdx = 0; resourceIdx < resources.Length; ++resourceIdx)
					    size += resources[resourceIdx].SerializedSize;

				    return size;
                }
			}
		};

        public Resource[] resources;

        public Page()
        {

        }

	};
}
