using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BothezatConfig.Serial.MessageData
{
    public class MotionSensor : ResourceParser
    {
        public OpenTK.Quaternion orientation;

        public OpenTK.Quaternion accelOrientation;

        public OpenTK.Vector3 acceleration;

        public OpenTK.Vector3 angularVelocity;

        public MotionSensor()
        {
            orientation = OpenTK.Quaternion.Identity;
            accelOrientation = OpenTK.Quaternion.Identity;
        }

        private void ParseOrientation(Page.Resource.Type type, BinaryReader reader)
        {
            orientation.X = reader.ReadSingle();
            orientation.Y = reader.ReadSingle();
            orientation.Z = reader.ReadSingle();
            orientation.W = reader.ReadSingle();

            orientation.Normalize();
        }

        private void ParseAccelOrientation(Page.Resource.Type type, BinaryReader reader)
        {
            accelOrientation.X = reader.ReadSingle();
            accelOrientation.Y = reader.ReadSingle();
            accelOrientation.Z = reader.ReadSingle();
            accelOrientation.W = reader.ReadSingle();

            accelOrientation.Normalize();
        }
        private void ParseAcceleration(Page.Resource.Type type, BinaryReader reader)
        {
            acceleration.X = reader.ReadSingle();
            acceleration.Y = reader.ReadSingle();
            acceleration.Z = reader.ReadSingle();
        }

        private void ParseAngularVelocity(Page.Resource.Type type, BinaryReader reader)
        {
            angularVelocity.X = reader.ReadSingle();
            angularVelocity.Y = reader.ReadSingle();
            angularVelocity.Z = reader.ReadSingle();
        }


        public ParseFunction[] RetrieveParsers()
        {
            return new ParseFunction[]
            {
                new ParseFunction(Page.Resource.Type.ORIENTATION, ParseOrientation),
                new ParseFunction(Page.Resource.Type.ACCEL_ORIENTATION, ParseAccelOrientation),
                new ParseFunction(Page.Resource.Type.ACCELERATION, ParseAcceleration),
                new ParseFunction(Page.Resource.Type.ANGULAR_VELOCITY, ParseAngularVelocity),
            };
        }
    }
}
