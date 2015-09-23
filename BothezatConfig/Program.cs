using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using BothezatConfig.Serial;
using BothezatConfig.Interface;

namespace BothezatConfig
{
    public class Program
    {
        private SerialInterface serialInterface;

        private ResourceManager resourceManager;

        private MainForm mainForm;

        public Program()
        {

        }

        public void Start()
        {
            serialInterface = new SerialInterface();
            resourceManager = new ResourceManager(serialInterface);
            mainForm = new MainForm(resourceManager);

            serialInterface.Initialize();

            serialInterface.logHandler = OnLogReceived;

            serialInterface.Configure("COM3", 115200);
            serialInterface.Open();

            Thread requestThread = new Thread(RequestThread);
            requestThread.Name = "Page request";
            requestThread.Start();

            Thread formThread = new Thread(FormThread);
            formThread.Name = "WinForm";
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();

        }

        public static void Main()
        {
            Program program = new Program();
            program.Start();
        }

        private void FormThread()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainForm);
        }

        private void RequestThread()
        {
            while (true)
            {
                resourceManager.UpdateAllResources();
                Thread.Sleep(100);
            }
        }

        public void OnLogReceived(string log)
        {
			try
			{
				if (mainForm != null && mainForm.IsHandleCreated)
					mainForm.Invoke((MethodInvoker)delegate() { mainForm.AddConsoleOutput(log); });
			}
			catch (ObjectDisposedException)
			{
				// Don't care
			}
        }

    }
}
