using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using KWorks.License.Setting.Program.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace KWorks.License.Setting.Program.Views.subViews
{
    public partial class ucStep1 : DevExpress.XtraEditors.XtraUserControl
    {
        //
        NavigationFrame pNavigationFrame;
        NavigationPage pNavigationPage;
        StepProgressBarItem pStepProgressBarItem;
        ucStep2 pUcStep2;

        public ucStep1()
        {
            InitializeComponent();
        }

        public ucStep1(NavigationFrame _NavigationFrame, NavigationPage _NavigationPage, StepProgressBarItem _StepProgressBarItem, ucStep2 _ucStep2)
        {
            pNavigationFrame = _NavigationFrame;
            pNavigationPage = _NavigationPage;
            pStepProgressBarItem = _StepProgressBarItem;
            pUcStep2 = _ucStep2;

            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                labNotice.Visible = false;
                this.btnConnect.Enabled = false;

                if (string.IsNullOrEmpty(this.txtHost.Text))
                {
                    XtraMessageBox.Show("서버명(Host)을 입력하세요.", "Message", MessageBoxButtons.OK);
                    this.txtHost.Focus();
                    this.btnConnect.Enabled = true;
                    return;
                }
                if (string.IsNullOrEmpty(this.txtId.Text))
                {
                    XtraMessageBox.Show("사용자이름(ID)을 입력하세요.", "Message", MessageBoxButtons.OK);
                    this.txtId.Focus();
                    this.btnConnect.Enabled = true;
                    return;
                }
                if (string.IsNullOrEmpty(this.txtPwd.Text))
                {
                    XtraMessageBox.Show("패스워드(Password)을 입력하세요.", "Message", MessageBoxButtons.OK);
                    this.txtPwd.Focus();
                    this.btnConnect.Enabled = true;
                    return;
                }
                if (string.IsNullOrEmpty(this.txtPort.Text))
                {
                    XtraMessageBox.Show("포트(Port)를 입력하세요.", "Message", MessageBoxButtons.OK);
                    this.txtPort.Focus();
                    this.btnConnect.Enabled = true;
                    return;
                }

                var value =
                  "host=" + this.txtHost.Text +
                  "; port=" + this.txtPort.Text +
                  //"; database=" + KConfig.DefaultDatabaseName +
                  "; user id=" + this.txtId.Text +
                  "; password=" + this.txtPwd.Text;

                splashScreenManager1.ShowWaitForm();

                if (SqlHelper.SettingConnectDb(value))
                {
                    this.btnConnect.Enabled = true;
                    labNotice.Visible = false;
                    splashScreenManager1.CloseWaitForm();
                    //
                    var pHost = this.pUcStep2.Controls.Find("txtHost", true)[0] as TextEdit;
                    var pId = this.pUcStep2.Controls.Find("txtId", true)[0] as TextEdit;
                    var pPwd = this.pUcStep2.Controls.Find("txtPwd", true)[0] as TextEdit;
                    var port = this.pUcStep2.Controls.Find("txtPort", true)[0] as TextEdit;
                    pHost.Text = this.txtHost.Text;
                    pId.Text = this.txtId.Text;
                    pPwd.Text = this.txtPwd.Text;
                    port.Text = this.txtPort.Text;
                    //
                    pNavigationFrame.SelectedPage = pNavigationPage;
                    pStepProgressBarItem.State = StepProgressBarItemState.Active;
                }
                else
                {
                    this.btnConnect.Enabled = true;
                    labNotice.Visible = true;
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception _ex)
            {
                XtraMessageBox.Show("오류가 발생하였습니다." +  System.Environment.NewLine + "관리자에게 문의하시기 바랍니다.", "Message", MessageBoxButtons.OK);
                splashScreenManager1.CloseWaitForm();
                this.btnConnect.Enabled = true;
                labNotice.Visible = false;
            }
         
        }
    }
}
