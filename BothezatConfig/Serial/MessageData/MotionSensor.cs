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
            orientation = OpenTKExtensions.DeserializeQuaternion(reader);
            orientation.Normalize();
        }

        private void ParseAccelOrientation(Page.Resource.Type type, BinaryReader reader)
        {
            accelOrientation = OpenTKExtensions.DeserializeQuaternion(reader);
            accelOrientation.Normalize();
        }
        private void ParseAcceleration(Page.Resource.Type type, BinaryReader reader)
        {
            acceleration = OpenTKExtensions.DeserializeVector3(reader);
        }

        private void ParseAngularVelocity(Page.Resource.Type type, BinaryReader reader)
        {
            angularVelocity = OpenTKExtensions.DeserializeVector3(reader);
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
