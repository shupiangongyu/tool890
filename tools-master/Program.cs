using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Tools
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
		static void Main(string[] args)
		{
			Process[] process = Process.GetProcessesByName("Tools");
			if (process.Length > 1) {
				
				return;
			}
			//Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MainWindow m = new MainWindow();
			if (args.Length > 0)
			{
				if (args[0].EndsWith(".gba") && File.Exists(args[0]))
					m.LoadEveryThing(args[0]);
				if (args.Length > 1)
				{
					m.script_offset.Text = args[1];
					m.button6_Click(null, null);
				}
			}
			else
			{
				string file_name = PokeConfig.of("rom.ini").Get("last_open","last_open");
				m.init(file_name);
			}

			//订阅ThreadException事件，处理UI线程异常，处理方法为 Application_ThreadException，关于事件的相关知识就不在这叙述了  

			//Application.ThreadException += (sender, e)=> { MessageBox.Show(e.Exception.StackTrace); };

			//订阅UnhandledException事件，处理非UI线程异常 ，处理方法为 CurrentDomain_UnhandledException  

			//AppDomain.CurrentDomain.UnhandledException += (sender, e) => { MessageBox.Show(e.ExceptionObject.ToString()); };
			Application.Run(m);
		}
	}
}
