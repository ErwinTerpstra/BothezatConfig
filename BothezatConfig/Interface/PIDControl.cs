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
    public partial class PIDControl : UserControl
    {
        private Config.PidConfiguration config;

        public PIDControl()
        {
            InitializeComponent();
        }

        public void UpdateFields()
        {
            if (config == null)
                return;

            pField.Value = (decimal) config.kp;
            iField.Value = (decimal) config.ki;
            dField.Value = (decimal) config.kd;
        }

        public Config.PidConfiguration Config
        {
            get { return config; }
            set
            {
                config = value;
                UpdateFields(); 
            }
        }

        private void field_ValueChanged(object sender, EventArgs e)
        {
            if (config == null)
                return;

            config.kp = (float) pField.Value;
            config.ki = (float) iField.Value;
            config.kd = (float) dField.Value;
        }
    }
}
