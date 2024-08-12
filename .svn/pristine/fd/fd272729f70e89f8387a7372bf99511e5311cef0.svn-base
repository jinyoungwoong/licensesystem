using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace KWorks.License.Setting.Program
{
    static class Program
    {
        public static string AppFileName = "KWorks.License.Setting.Program.exe";

  
        [STAThread]
        static void Main()
        {
            Program.AppFileName = Application.ExecutablePath.Replace(Application.StartupPath + "\\", "").Replace(".EXE", ".exe");
            bool bNew;
            Mutex mtx = new Mutex(true, Program.AppFileName, out bNew);

            if (bNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            else
            {
                MessageBox.Show("프로그램이 실행중입니다.");
                Application.Exit();
            }
        }
    }
}
