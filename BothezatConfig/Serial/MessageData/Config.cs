using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace BothezatConfig.Serial.MessageData
{
    
    public class Config : Observable, ResourceParser
    {	
	    public struct Constants
	    {
		    /*
		     *	Radio receiver
		     */
		    public const byte RX_PWM_AMOUNT = 4;

		    public const byte RX_MAX_CHANNELS = 8;

		    /*
		     * Motor controller
		     */
		    public const byte MC_MOTOR_AMOUNT = 4;

	    };

	    public class ChannelCalibration : Observable
	    {
		    public UInt16 min, max, mid, deadband;

		    public ChannelCalibration()
		    {
			    min = 1050;
			    mid = 1500;
			    max = 1950;
			    deadband = 30;
		    }

		    public void Serialize(BinaryWriter stream)
		    {
			    stream.Write(min);
			    stream.Write(max);
			    stream.Write(mid);
			    stream.Write(deadband);
		    }

		    public bool Deserialize(BinaryReader stream)
		    {
			    min = stream.ReadUInt16();
			    max = stream.ReadUInt16();
			    mid = stream.ReadUInt16();
			    deadband = stream.ReadUInt16();

                Notify();

			    return true;
		    }

		    public int SerializedSize
		    {
                get { return ChannelCalibration.Size; }
		    }

		    public static int Size
		    {
                get { return sizeof(UInt16) * 4; }
		    }
	    };

        public class PidConfiguration : Observable
	    {
		    public float kp, ki, kd;
		
		    public PidConfiguration()
		    {
                kp = 0.0f;
                ki = 0.0f;
                kd = 0.0f;
		    }

		    public PidConfiguration(float kp, float ki, float kd)
		    {
                this.kp = kp;
                this.ki = ki;
                this.kd = kd;
		    }

		    public void Serialize(BinaryWriter stream)
		    {
			    stream.Write(kp);
			    stream.Write(ki);
			    stream.Write(kd);
		    }

		    public bool Deserialize(BinaryReader stream)
		    {
			    kp = stream.ReadSingle();
			    ki = stream.ReadSingle();
			    kd = stream.ReadSingle();

                Notify();

			    return true;
		    }

		    public int SerializedSize
		    {
                get { return PidConfiguration.Size; }
		    }

		    public static int Size
		    {
                get { return sizeof(float) * 3; }
		    }

	    };

	    const UInt32 CONFIG_MAGIC = 0xDEADBEEF;

	    const UInt16 LATEST_VERSION = 0x01;

	    /*
	     * Config management
	     */
	    public UInt32 MAGIC;

	    public UInt16 VERSION;

	    /*
	     * System
	     */
	    public UInt16 SYS_LOOP_TIME;

	    /*
	     * Serial interface
	     */
	    public UInt32 SR_BAUD_RATE;

	    public ChannelCalibration[] RX_CHANNEL_CALIBRATION;

	    /*
	     * Motion sensor
	     */
	    public byte MS_CALIBRATION_SAMPLES;

	    public UInt16 MS_CALIBRATION_INTERVAL;

	    public float MS_GYRO_FILTER_RC;
	
	    public float MS_ACCEL_CORRECTION_RC;

	    public float MS_ACCEL_MAX;

	    /*
	     * Flight system
	     */

	    public Vector3 FS_MAN_ANGULAR_VELOCITY;

	    public float FS_ATTI_MAX_PITCH;

	    public float FS_ATTI_MAX_ROLL;

	    /*
	     * Motor controller
	     */
	    public UInt32 MC_PWM_FREQUENCY;

	    public UInt16 MC_PWM_PERIOD;

	    public UInt16 MC_PWM_MIN_COMMAND;

	    public UInt16 MC_PWM_MIN_OUTPUT;

	    public UInt16 MC_PWM_MAX_COMMAND;

	    public PidConfiguration[] MC_PID_CONFIGURATION;

        public Config()
        {
            RX_CHANNEL_CALIBRATION = new ChannelCalibration[Constants.RX_MAX_CHANNELS];
            MC_PID_CONFIGURATION = new PidConfiguration[3];

            for (int channel = 0; channel < Constants.RX_MAX_CHANNELS; ++channel)
                RX_CHANNEL_CALIBRATION[channel] = new ChannelCalibration();

            for (int axis = 0; axis < 3; ++axis)
                MC_PID_CONFIGURATION[axis] = new PidConfiguration();
        }
        
        public void Serialize(BinaryWriter stream)
        {
	        /*
	         * Config management
	         */
	        stream.Write(MAGIC);
	        stream.Write(VERSION);

	        /*
	         * System
	         */
	        stream.Write(SYS_LOOP_TIME);

	        /*
	         * Serial interface
	         */
	        stream.Write(SR_BAUD_RATE);

	        /*
	         * Radio receiver 
	         */
	        for (int channel = 0; channel < Constants.RX_MAX_CHANNELS; ++channel)
		        RX_CHANNEL_CALIBRATION[channel].Serialize(stream);

	        /*
	         * Motion sensor
	         */
	        stream.Write(MS_CALIBRATION_SAMPLES);
	        stream.Write(MS_CALIBRATION_INTERVAL);
	        stream.Write(MS_GYRO_FILTER_RC);	
	        stream.Write(MS_ACCEL_CORRECTION_RC);
	        stream.Write(MS_ACCEL_MAX);

	        /*
	         * Flight system
	         */
	        FS_MAN_ANGULAR_VELOCITY.Serialize(stream);

	        stream.Write(FS_ATTI_MAX_PITCH);
	        stream.Write(FS_ATTI_MAX_ROLL);

	        /*
	         * Motor controller
	         */
	        stream.Write(MC_PWM_FREQUENCY);
	        stream.Write(MC_PWM_PERIOD);
	        stream.Write(MC_PWM_MIN_COMMAND);
	        stream.Write(MC_PWM_MIN_OUTPUT);
	        stream.Write(MC_PWM_MAX_COMMAND);

	        for (int axis = 0; axis < 3; ++axis)
		        MC_PID_CONFIGURATION[axis].Serialize(stream);
        }

        public bool Deserialize(BinaryReader stream)
        {
	        /*
	         * Config management
	         */
	        MAGIC = stream.ReadUInt32();

	        if (MAGIC != CONFIG_MAGIC)
		        return false;

	        VERSION = stream.ReadUInt16();

	        if (VERSION != LATEST_VERSION)
		        return false;

	        /*
	         * System
	         */
	        SYS_LOOP_TIME               = stream.ReadUInt16();

	        /*
	         * Serial interface
	         */
	        SR_BAUD_RATE                = stream.ReadUInt32();

	        for (int channel = 0; channel < Constants.RX_MAX_CHANNELS; ++channel)
		        RX_CHANNEL_CALIBRATION[channel].Deserialize(stream);

	        /*
	         * Motion sensor
	         */
	        MS_CALIBRATION_SAMPLES      = stream.ReadByte();
	        MS_CALIBRATION_INTERVAL     = stream.ReadUInt16();
	        MS_GYRO_FILTER_RC           = stream.ReadSingle();
	        MS_ACCEL_CORRECTION_RC      = stream.ReadSingle();
	        MS_ACCEL_MAX                = stream.ReadSingle();

	        /*
	         * Flight system
	         */

            FS_MAN_ANGULAR_VELOCITY     = OpenTKExtensions.DeserializeVector3(stream);

	        FS_ATTI_MAX_PITCH           = stream.ReadSingle();
	        FS_ATTI_MAX_ROLL            = stream.ReadSingle();

	        /*
	         * Motor controller
	         */
	        MC_PWM_FREQUENCY            = stream.ReadUInt32();
	        MC_PWM_PERIOD               = stream.ReadUInt16();
	        MC_PWM_MIN_COMMAND          = stream.ReadUInt16();
	        MC_PWM_MIN_OUTPUT           = stream.ReadUInt16();
	        MC_PWM_MAX_COMMAND          = stream.ReadUInt16();

	        for (int axis = 0; axis < 3; ++axis)
		        MC_PID_CONFIGURATION[axis].Deserialize(stream);

            Notify();

            return true;
        }

        private void ParseConfig(Page.Resource.Type type, BinaryReader reader)
        {
            if (!Deserialize(reader))
                Console.WriteLine("[Config]: Failed to deserialize config!");
        }

        public ParseFunction[] RetrieveParsers()
        {
            return new ParseFunction[]
            {
                new ParseFunction(Page.Resource.Type.CONFIG, ParseConfig)
            };
        }

        public int SerializedSize
        {
            get { return Config.Size; }
        }
        public static int Size
        {
            get
            {
                return
                    sizeof(UInt32) + // MAGIC;

                    sizeof(UInt16) + // VERSION;

                    /*
                     * System
                     */
                    sizeof(UInt16) + // SYS_LOOP_TIME;

                    /*
                     * Serial interface
                     */
                    sizeof(UInt32) + // SR_BAUD_RATE;

                    ChannelCalibration.Size * Constants.RX_MAX_CHANNELS + // RX_CHANNEL_CALIBRATION[Constants.RX_MAX_CHANNELS];

                    /*
                     * Motion sensor
                     */
                    sizeof(byte) + // MS_CALIBRATION_SAMPLES;

                    sizeof(UInt16) + // MS_CALIBRATION_INTERVAL;

                    sizeof(float) + // MS_GYRO_FILTER_RC;

                    sizeof(float) + // MS_ACCEL_CORRECTION_RC;

                    sizeof(float) + // MS_ACCEL_MAX;

                    /*
                     * Flight system
                     */

                    OpenTKExtensions.Vector3Size + // FS_MAN_ANGULAR_VELOCITY;

                    sizeof(float) + // FS_ATTI_MAX_PITCH;

                    sizeof(float) + // FS_ATTI_MAX_ROLL;

                    /*
                     * Motor controller
                     */
                    sizeof(UInt32) + // MC_PWM_FREQUENCY;

                    sizeof(UInt16) + // MC_PWM_PERIOD;

                    sizeof(UInt16) + // MC_PWM_MIN_COMMAND;

                    sizeof(UInt16) + // MC_PWM_MIN_OUTPUT;

                    sizeof(UInt16) + // MC_PWM_MAX_COMMAND;

                    PidConfiguration.Size * 3 + // MC_PID_CONFIGURATION[3];
                0;
            }
        }
    }
}
