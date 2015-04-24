using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using BothezatConfig.Serial;
using BothezatConfig.Interface;

namespace BothezatConfig
{
    public static class Program
    {
        private static SerialInterface serialInterface;

        private static MainForm mainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            serialInterface = new SerialInterface();
            serialInterface.Initialize();

            serialInterface.OnMessageRequestReceived += OnMessageRequestReceived;

            serialInterface.Configure("COM9", 115200);
            serialInterface.Open();

            CreateForm();

                        Application.Run(mainForm);
        }

        private static void CreateForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new MainForm();
        }

        public static void OnMessageRequestReceived(BothezatConfig.Serial.Message message)
        {
            switch (message.type)
            {
                case Serial.Message.Type.TYPE_LOG:
                    string log = Encoding.ASCII.GetString(message.payload);
                    
                    if (mainForm != null && !mainForm.IsDisposed)
                        mainForm.Invoke((MethodInvoker)delegate() { mainForm.AddConsoleOutput(log); });

                    break;
            }
        }
    }
}
