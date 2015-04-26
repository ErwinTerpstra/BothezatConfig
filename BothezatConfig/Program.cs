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

            serialInterface.logHandler = OnLogReceived;

            serialInterface.Configure("COM4", 115200);
            serialInterface.Open();

            Thread thread = new Thread(RequestThread);
            thread.Start();

            CreateForm();

            Application.Run(mainForm);
        }

        private static void CreateForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new MainForm();
        }

        private static void RequestThread()
        {
            while (true)
            {
                serialInterface.RequestPage(new Page.Resource.Type[] { Page.Resource.Type.ORIENTATION }, OnPageReceived);
                Thread.Sleep(50);
            }
        }

        public static void OnLogReceived(string log)
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

        public static void OnPageReceived(Page page)
        {
            Page.Resource resource = page.resources[0];

            if (resource.type != Page.Resource.Type.ORIENTATION)
            {
                Console.WriteLine("[Program]: Received invalid resource!");
                return;
            }

            MemoryStream stream = new MemoryStream(resource.data);

            BinaryReader reader = new BinaryReader(stream);

            OpenTK.Quaternion quaternion = new OpenTK.Quaternion(reader.ReadSingle(), reader.ReadSingle(), -reader.ReadSingle(), reader.ReadSingle());
            quaternion.Normalize();
            mainForm.SetOrientation(quaternion);
        }
    }
}
