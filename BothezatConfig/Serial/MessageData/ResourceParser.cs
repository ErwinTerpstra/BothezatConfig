using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BothezatConfig.Serial.MessageData
{
    public interface ResourceParser
    {

        ParseFunction[] RetrieveParsers();

    }

    public struct ParseFunction
    {
        public delegate void Callback(Page.Resource.Type type, BinaryReader reader);

        public Page.Resource.Type type;

        public Callback callback;

        public ParseFunction(Page.Resource.Type type, Callback callback)
        {
            this.type = type;
            this.callback = callback;
        }
    }

}
