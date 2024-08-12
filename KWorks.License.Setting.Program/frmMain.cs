using DevExpress.XtraEditors;
using KWorks.License.Setting.Program.Common;
using KWorks.License.Setting.Program.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWorks.License.Setting.Program
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        bool On;
        Point Pos;

        public frmMain()
        {
            InitializeComponent();

            this.pcTop.MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { On = true; Pos = e.Location; } };
            this.pcTop.MouseMove += (o, e) => { if (On) Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y)); };
            this.pcTop.MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { On = false; Pos = e.Location; } };

            var myControl = new ucDBInstall();
            this.pcMain.Controls.Add(myControl);
        }














        private void Menu_Click(object sender, EventArgs e)
        {
            var menu = (sender as LabelControl).Tag.ToString();

            if (this.pcMain.Controls.Count > 0)
                this.pcMain.Controls.RemoveAt(0);

            ClearForeColor();
            var color = System.Drawing.Color.FromArgb(38, 164, 221);

            if (menu == "DBInstall")
            {
                var myControl = new ucDBInstall();
                this.pcMain.Controls.Add(myControl);
                this.btnDBInstall.Appearance.ForeColor = color;
            }
            else if (menu == "DBSchemaCreate")
            {
                var myControl = new ucDBSchemaCreate();
                this.pcMain.Controls.Add(myControl);
                this.btnDBSchemaCreate.Appearance.ForeColor = color;
            }
            else if (menu == "ProgramInstall")  
            {
                var myControl = new ucProgramInstall();
                this.pcMain.Controls.Add(myControl);
                this.btnProgramInstall.Appearance.ForeColor = color;
            }
        }

        private void ClearForeColor()
        {
            var color = System.Drawing.Color.Silver;

            this.btnDBInstall.Appearance.ForeColor = color;
            this.btnDBSchemaCreate.Appearance.ForeColor = color;
            this.btnProgramInstall.Appearance.ForeColor = color;
        }

     









        private void btnClose_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("        프로그램을 종료하시겠습니까?        ", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            string address = "http://www.ksolution.kr/";
            System.Diagnostics.Process.Start(address);
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}