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

        public ResourceManager(SerialInterface serialInterface)
        {
            this.serialInterface = serialInterface;

            config          = new Config();
            motionSensor    = new MotionSensor();
            receiver        = new Receiver();

            parsers = new Dictionary<Page.Resource.Type, ParseFunction.Callback>();

            RegisterParser(config);
            RegisterParser(motionSensor);
            RegisterParser(receiver);
        }

        public void RegisterParser(ResourceParser provider)
        {
            foreach (ParseFunction parser in provider.RetrieveParsers())
                parsers[parser.type] = parser.callback;

        }

        public void UpdateAllResources()
        {
            List<Page.Resource.Type> types = new List<Page.Resource.Type>();
            types.AddRange(motionSensor.RetrieveParsers().Select(x => x.type));
            types.AddRange(receiver.RetrieveParsers().Select(x => x.type));

            serialInterface.RequestPage(types.ToArray(), PageReceivedCallback);

            serialInterface.RequestPage(new Page.Resource.Type[] { Page.Resource.Type.CONFIG }, PageReceivedCallback);
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
