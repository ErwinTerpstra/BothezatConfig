using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BothezatConfig.Serial.MessageData
{
    public class Receiver : ResourceParser
    {
        public enum Channel : byte
        {
            // All available RC channels, if more should be read they need to be added below
            AILERON = 0x00,
            ELEVATOR = 0x01,
            THROTTLE = 0x02,
            RUDDER = 0x03,
            AUX1 = 0x04, AUX2 = 0x05,
            AUX3 = 0x06, AUX4 = 0x07,
        };

        public UInt16[] channels;

        public float[] normalizedChannels;

        public bool connected;

        public Receiver()
        {
            channels = new UInt16[(int) Config.Constants.RX_MAX_CHANNELS];
            normalizedChannels = new float[(int)Config.Constants.RX_MAX_CHANNELS];
        }

        public UInt16 GetChannel(Channel channel)
        {
            return channels[(int)channel];
        }

        public float NormalizedChannel(Channel channel)
        {
            return normalizedChannels[(int)channel];
        }

        private void ParseChannels(Page.Resource.Type type, BinaryReader reader)
        {
            for (int channel = 0; channel < (int)Config.Constants.RX_MAX_CHANNELS; ++channel)
                channels[channel] = reader.ReadUInt16();
        }

        private void ParseNormalizedChannels(Page.Resource.Type type, BinaryReader reader)
        {
            for (int channel = 0; channel < (int)Config.Constants.RX_MAX_CHANNELS; ++channel)
                normalizedChannels[channel] = reader.ReadSingle();
        }

        private void ParseConnected(Page.Resource.Type type, BinaryReader reader)
        {
            connected = reader.ReadBoolean();
        }

        public ParseFunction[] RetrieveParsers()
        {
            return new ParseFunction[]
            {
                new ParseFunction(Page.Resource.Type.RECEIVER_CHANNELS, ParseChannels),
                new ParseFunction(Page.Resource.Type.RECEIVER_NORMALIZED, ParseNormalizedChannels),
                new ParseFunction(Page.Resource.Type.RECEIVER_CONNECTED, ParseConnected),
            };
        }
    }
}
