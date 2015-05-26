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
        public MotionSensor motionSensor;

        public Receiver receiver;

        private SerialInterface serialInterface;

        private Dictionary<Page.Resource.Type, ParseFunction.Callback> parsers;

        public ResourceManager(SerialInterface serialInterface)
        {
            this.serialInterface = serialInterface;

            motionSensor = new MotionSensor();
            receiver = new Receiver();

            parsers = new Dictionary<Page.Resource.Type, ParseFunction.Callback>();

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
            serialInterface.RequestPage(parsers.Keys.ToArray(), PageReceivedCallback);
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
