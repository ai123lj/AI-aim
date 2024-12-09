using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gprs
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //WinIOLab.Initialize(); // 注册
            Application.Run(new Form1());
            //KeyboardHook.Start();
        }
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            //WinIOLab.Shutdown(); // 用完后注销
            //KeyboardHook.Stop();
            // 在这里编写需要在程序关闭时执行的代码
            // Console.WriteLine("程序退出时的代码");

        }
    }
}
