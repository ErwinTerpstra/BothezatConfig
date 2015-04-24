using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BothezatConfig.Serial
{
    public class Buffer : Stream
    {

        public BinaryReader reader;

        public BinaryWriter writer;

        private byte[] data;

        private int readOffset, writeOffset;

        private int origin;

        public Buffer()
        {
            reader = new BinaryReader(this);
            writer = new BinaryWriter(this);
        }

        public void Allocate(int size)
        {
            data = new byte[size];
            Clear();
        }

        public long FreeBytes()
        {
            return data.Length - Available();
        }

        public int Available()
        {
            return (data.Length + (writeOffset - readOffset)) % data.Length;
        }

        public void Clear()
        {
            origin = 0;

            readOffset = 0;
            writeOffset = 0;
        }

        public byte[] GetData()
        {
            int available = Available();

            byte[] data = new byte[available];
            Read(data, 0, available);

            return data;
        }
        
        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = 0;

            // Read until we caught up with the read pointer or we've read enough bytes
            while (readOffset != writeOffset && bytesRead < count)
            {
                buffer[offset++] = data[readOffset];

                ++bytesRead;

                readOffset = (readOffset + 1) % data.Length;
            }

            return bytesRead;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            // Attempt writing each byte
            while (count-- > 0)
            {
                data[writeOffset] = buffer[offset++];

                writeOffset = (writeOffset + 1) % data.Length;

                // If the write offset matches the read offset, the stream is full
                if (writeOffset == readOffset)
                    break;

                // If we overwrote the start of the stream, 
                // increase the origin pointer to mark that this part can no longer be used
                if (writeOffset == origin)
                    origin = (origin + 1) % data.Length;
            }

            // Check if all bytes have been written
            if (count > 0)
                throw new InternalBufferOverflowException("Can't write past end of stream");
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long position;
            long min, max;
            
            // Apply the seek origin to get the desired stream position
            switch (origin)
            {
                default:
                case SeekOrigin.Begin:
                    min = 0;
                    max = Length;

                    position = this.origin + offset;
                    break;

                case SeekOrigin.Current:
                    min = -Position;
                    max = Available();

                    position = readOffset + offset;
                    break;

                case SeekOrigin.End:
                    min = -Position;
                    max = 0;

                    position = writeOffset + offset;
                    break;
            }

            if (offset < min || offset > max)
                throw new EndOfStreamException("Attempting to seek to position outside stream.");

            readOffset = (int)position;
            
            readOffset = ((readOffset % data.Length) + data.Length) % data.Length;

            return position;
        }

        public override void Flush() { }

        public override void SetLength(long value)
        {
            Allocate((int) value);
        }

        public override long Position
        {
            get { return (data.Length + (readOffset - origin)) % data.Length; }
            set { Seek(value, SeekOrigin.Begin); }
        }

        public override long Length
        {
            get { return (data.Length + (writeOffset - origin)) % data.Length; }
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }
    }
}
