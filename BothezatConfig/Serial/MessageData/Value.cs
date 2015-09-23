using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BothezatConfig.Serial.MessageData
{

    public abstract class Value : Observable
    {

        public abstract bool FromString(string s);

    }

    public abstract class GenericValue<T> : Value
    {

        private T value;

        public override string ToString()
        {
            return value.ToString();
        }

        public T Value
        {
            get { return value; }
            set { this.value = value; Notify(); }
        }

    }

    public class FloatValue : GenericValue<float>
    {

        public override bool FromString(string s)
        {
            float f;

            if (float.TryParse(s, out f))
            {
                Value = f;
                return true;
            }

            return false;
        }

    }

    public class Int32Value : GenericValue<Int32>
    {

        public override bool FromString(string s)
        {
            Int32 i;

            if (Int32.TryParse(s, out i))
            {
                Value = i;
                return true;
            }

            return false;
        }
    }

    public class Int16Value : GenericValue<Int16>
    {

        public override bool FromString(string s)
        {
            Int16 i;

            if (Int16.TryParse(s, out i))
            {
                Value = i;
                return true;
            }

            return false;
        }
    }

    public class UInt32Value : GenericValue<UInt32>
    {

        public override bool FromString(string s)
        {
            UInt32 i;

            if (UInt32.TryParse(s, out i))
            {
                Value = i;
                return true;
            }

            return false;
        }
    }

    public class UInt16Value : GenericValue<UInt16>
    {

        public override bool FromString(string s)
        {
            UInt16 i;

            if (UInt16.TryParse(s, out i))
            {
                Value = i;
                return true;
            }

            return false;
        }
    }

    public class ByteValue : GenericValue<byte>
    {

        public override bool FromString(string s)
        {
            Byte b;

            if (Byte.TryParse(s, out b))
            {
                Value = b;
                return true;
            }

            return false;
        }
    }

    public abstract class ValueFactory
    {

        public abstract Value CreateValue();

    }

    public class GenericValueFactory<T> : ValueFactory
        where T : Value, new()
    {
        public override Value CreateValue()
        {
            return new T();
        }
    }


    public static class ValueMapper
    {
        private static Dictionary<Type, ValueFactory> factories;

        static ValueMapper()
        {
            factories = new Dictionary<Type, ValueFactory>();

            factories[typeof(float)]    = new GenericValueFactory<FloatValue>();
            factories[typeof(Int32)]    = new GenericValueFactory<Int32Value>();
            factories[typeof(Int16)]    = new GenericValueFactory<Int16Value>();
            factories[typeof(UInt32)]   = new GenericValueFactory<UInt32Value>();
            factories[typeof(UInt16)]   = new GenericValueFactory<UInt16Value>();
            factories[typeof(byte)]     = new GenericValueFactory<ByteValue>();
        }

        public static Value CreateValue(Type type)
        {
            ValueFactory factory;

            if (!factories.TryGetValue(type, out factory))
                throw new ArgumentException("Argument not of known type.");

            return factory.CreateValue();
        }

        public static Value CreateValue<T>(T initialValue)
        {
            Type type = initialValue.GetType();
            GenericValue<T> value = CreateValue(type) as GenericValue<T>;
            value.Value = initialValue;

            return value;
        }


    }


}
