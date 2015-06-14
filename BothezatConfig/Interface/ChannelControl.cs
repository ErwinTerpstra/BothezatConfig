using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BothezatConfig.Serial.MessageData;

namespace BothezatConfig.Interface
{
    public partial class ChannelControl : UserControl
    {
        private Receiver receiver;

        private Config config;

        private Receiver.Channel channel;

        private bool writeToConfig;

        public ChannelControl()
        {
            InitializeComponent();

            writeToConfig = true;
        }

        public void Setup(Receiver receiver, Config config)
        {
            this.receiver = receiver;
            this.config = config;

            config.AddObserver(OnConfigUpdated);
        }

        public void UpdateResources()
        {
            pulseTimeLabel.Text = String.Format("{0}", receiver.channels[(int)channel]);
            channelBar.SetValue(ConvertToBarValue(receiver.NormalizedChannel(channel)));
        }

        public void UpdateConfig()
        {
            Config.ChannelCalibration channelCalibration = config.RX_CHANNEL_CALIBRATION[(int) channel];

            writeToConfig = false;
            
            minValue.Value = channelCalibration.min;
            midValue.Value = channelCalibration.mid;
            maxValue.Value = channelCalibration.max;
            
            writeToConfig = true;
        }

        public void UpdateFields()
        {
            if (!writeToConfig)
                return;

            Config.ChannelCalibration channelCalibration = config.RX_CHANNEL_CALIBRATION[(int)channel];
            channelCalibration.min = (ushort)Util.ClampPWM((int)minValue.Value);
            channelCalibration.mid = (ushort)Util.ClampPWM((int)midValue.Value);
            channelCalibration.max = (ushort)Util.ClampPWM((int)maxValue.Value);
        }

        private void OnEndPointChanged(object sender, EventArgs e)
        {
            UpdateFields();
        }

        private void OnConfigUpdated(Observable observable)
        {
            Invoke((MethodInvoker)UpdateConfig);
        }

        private int ConvertToBarValue(float input)
        {
             return Math.Min(Math.Max((int) Math.Round((input + 1.0f) * 50), 0), 100);
        }

        public Receiver.Channel Channel
        {
            get { return channel; }
            set
            {
                channel = value;
                channelLabel.Text = channel.ToString() + ":";
            }
        }

    }
}
