using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

using BothezatConfig.Serial.MessageData;

namespace BothezatConfig.Interface
{
    public partial class PIDControl : UserControl
    {
        private Config.PidConfiguration config;

        private bool writeToConfig;

        public PIDControl()
        {
            writeToConfig = true;

            InitializeComponent();
        }
        
        public void OnConfigUpdated(Observable observable)
        {
            Invoke((MethodInvoker)UpdateFields);
        }

        public void UpdateFields()
        {
            if (config == null)
                return;

            writeToConfig = false;
            pField.Value = (decimal) config.kp;
            iField.Value = (decimal) config.ki;
            dField.Value = (decimal) config.kd;
            writeToConfig = true;

            Invalidate();
        }

        public Config.PidConfiguration Config
        {
            get { return config; }
            set
            {
                if (config == value)
                    return;

                if (config != null)
                    config.RemoveObserver(OnConfigUpdated);

                config = value;

                if (config != null)
                    config.AddObserver(OnConfigUpdated);

                UpdateFields(); 
            }
        }

        private void field_ValueChanged(object sender, EventArgs e)
        {
            if (config == null || !writeToConfig)
                return;

            config.kp = (float) pField.Value;
            config.ki = (float) iField.Value;
            config.kd = (float) dField.Value;
        }
    }
}
