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
    public partial class ConfigValueControl : UserControl
    {
        private Value value;

		private bool readFromValue;
		private bool writeToValue;

        public ConfigValueControl(string name, Value value)
        {
            InitializeComponent();

			this.value = value;

			nameLabel.Text = name;

			writeToValue = true;
			readFromValue = true;

			ReadFromValue();

			value.AddObserver(OnValueChanged);
		}

		private void valueBox_TextChanged(object sender, EventArgs e)
		{
			WriteToValue();
		}

		private void OnValueChanged(Observable observable)
		{
			Invoke((MethodInvoker) ReadFromValue);
		}

		private void WriteToValue()
		{
			if (!writeToValue)
				return;

			readFromValue = false;

			value.FromString(valueBox.Text);

			readFromValue = true;
		}

		private void ReadFromValue()
		{
			if (!readFromValue)
				return;

			writeToValue = false;

			valueBox.Text = value.ToString();

			writeToValue = true;
		}


	}
}
