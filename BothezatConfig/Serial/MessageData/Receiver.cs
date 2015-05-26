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
            AILERON,
            ELEVATOR,
            THROTTLE,
            RUDDER,
            AUX1, AUX2,
            AUX3, AUX4,

            MAX_CHANNELS,

            // Generalization of default order
            // These are used for easy channel mapping
            CHANNEL1 = AILERON,
            CHANNEL2 = ELEVATOR,
            CHANNEL3 = THROTTLE,
            CHANNEL4 = RUDDER,
            CHANNEL5 = AUX1,
            CHANNEL6 = AUX2,
            CHANNEL7 = AUX3,
            CHANNEL8 = AUX4
        };

        public UInt16[] channels;

        public float[] normalizedChannels;

        public bool connected;

        public Receiver()
        {
            channels = new UInt16[(int) Channel.MAX_CHANNELS];
            normalizedChannels = new float[(int) Channel.MAX_CHANNELS];
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
            for (int channel = 0; channel < (int)Channel.MAX_CHANNELS; ++channel)
                channels[channel] = reader.ReadUInt16();
        }

        private void ParseNormalizedChannels(Page.Resource.Type type, BinaryReader reader)
        {
            for (int channel = 0; channel < (int) Channel.MAX_CHANNELS; ++channel)
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
