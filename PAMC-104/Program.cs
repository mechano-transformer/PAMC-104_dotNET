using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAMC_104
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // アプリ名などのメタ情報を取得
            AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();
            //ミューテックス作成
            Mutex app_mutex = new Mutex(false, assembly.Name);

            //ミューテックスの所有権を要求する
            if (app_mutex.WaitOne(0, false) == false)
            {
                MessageBox.Show("This application cannot be launched multiple times.");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
