using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyeFusen
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //2重起動防止(終了時にMutexは解放する必要がある)
            bool createdNew;
            using (Mutex mutex = new Mutex(true, Application.ProductName, out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
            }
        }
    }
}
