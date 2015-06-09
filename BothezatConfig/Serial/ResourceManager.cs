using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BothezatConfig.Serial.MessageData;

namespace BothezatConfig.Serial
{
    public class ResourceManager
    {
        public Config config;

        public MotionSensor motionSensor;

        public Receiver receiver;

        private SerialInterface serialInterface;

        private Dictionary<Page.Resource.Type, ParseFunction.Callback> parsers;

        private List<Page.Resource.Type> autoUpdateTypes;

        public ResourceManager(SerialInterface serialInterface)
        {
            this.serialInterface = serialInterface;

            config          = new Config();
            motionSensor    = new MotionSensor();
            receiver        = new Receiver();

            parsers = new Dictionary<Page.Resource.Type, ParseFunction.Callback>();
            autoUpdateTypes = new List<Page.Resource.Type>();

            RegisterParser(config, false);
            RegisterParser(motionSensor, true);
            RegisterParser(receiver, true);
        }

        public void RegisterParser(ResourceParser provider, bool updateAutomatically)
        {
            foreach (ParseFunction parser in provider.RetrieveParsers())
            {
                parsers[parser.type] = parser.callback;

                if (updateAutomatically)
                    autoUpdateTypes.Add(parser.type);
            }

        }

        public void UpdateAllResources()
        {
            if (!serialInterface.IsOpen)
                return;

            serialInterface.RequestPage(autoUpdateTypes.ToArray(), PageReceivedCallback);
        }

        public void UpdateConfig()
        {
            if (!serialInterface.IsOpen)
                return;

            serialInterface.RequestPage(new Page.Resource.Type[] { Page.Resource.Type.CONFIG }, PageReceivedCallback);
        }

        public void SaveConfig()
        {
            if (!serialInterface.IsOpen)
                return;

            // Create a buffer to hold the serialized config
            Buffer buffer = new Buffer();
            buffer.Allocate(config.SerializedSize);

            // Serialize the config to the buffer
            config.Serialize(buffer.writer);

            // Send the save config command
            serialInterface.SendCommand(Command.Type.SAVE_CONFIG, buffer.GetData(), delegate(Command.ResponseMessage response)
            {
                switch (response.state)
                {
                    case Command.State.COMMAND_OK:
                        Console.WriteLine("[ResourceManager]: Config written!");
                        break;

                    case Command.State.COMMAND_ERROR:
                        Console.WriteLine("[ResourceManager]: Error while writing config!");
                        break;
                }
            });

        }

        private void PageReceivedCallback(Page page)
        {
            foreach (Page.Resource resource in page.resources)
            {
                ParseFunction.Callback callback;

                if (!parsers.TryGetValue(resource.type, out callback))
                {
                    Console.WriteLine("[ResourceManager]: Unknown resource type: {0}", resource.type);
                    continue;
                }

                MemoryStream stream = new MemoryStream(resource.data);
                BinaryReader reader = new BinaryReader(stream);

                callback(resource.type, reader);
            }
        }


    }
}
