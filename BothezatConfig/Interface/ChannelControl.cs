using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BothezatConfig.Interface
{
    public partial class ChannelControl : UserControl
    {
        private string channelName;

        private int channelIdx;

        public ChannelControl()
        {
            InitializeComponent();
        }

        public int ChannelIdx
        {
            get { return channelIdx; }
            set
            {
                channelIdx = value;
            }
        }

        public string ChannelName
        {
            get { return channelName; }
            set
            {
                channelName = value;
                channelLabel.Text = channelName + ":";
            }
        }
    }
}
