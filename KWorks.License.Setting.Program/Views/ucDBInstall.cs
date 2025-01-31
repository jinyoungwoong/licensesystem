﻿using DevExpress.XtraEditors;
using KWorks.License.Setting.Program.Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KWorks.License.Setting.Program.Views
{
    public partial class ucDBInstall : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDBInstall()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            InitDesign();
            InitData();
        }

        private void InitDesign()
        {
            CheckIsDBInstall();
        }

        private void InitData()
        {
        
        }

        private void CheckIsDBInstall()
        {
            //서비스체크
            if (KCustomControl.serviceExists("MARIADB"))
            {
                this.labNotice.Text = "이미 데이터베이스가 설치되어있습니다.\r\n" + KCustomControl.serviceInfo("MARIADB").DisplayName + " ver.";
                this.labNotice.Visible = true;
                //
                this.btnDBDownload.Enabled = false;
                this.btnDBDownload.Font = new Font("Segoe UI", 11.25F, FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                this.labNotice.Visible = false;
                //
                this.btnDBDownload.Enabled = true;
                this.btnDBDownload.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            //레지스터 체크
            //var postgres = Registry.CurrentUser.OpenSubKey(@"Software\pgAdmin III");
            //if (postgres != null)
            //{
            //    MessageBox.Show("디비 존재", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("디비 미존재", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnDBDownload_Click(object sender, EventArgs e)
        {
            try
            {   
                btnDBDownload.Enabled = false;

                //string path = Application.StartupPath + "\\DownLoad\\DataBase\\postgresql-9.5.4-1-windows-x64.exe";
                string path = Application.StartupPath + "\\DownLoad\\DataBase\\mariadb-11.4.2-winx64.msi";
                Process.Start(path);

                btnDBDownload.Enabled = true;


                //파일다운로드 Dialog
                //btnDBDownload.Enabled = false;

                //SaveFileDialog saveFileDialog = new SaveFileDialog();
                //saveFileDialog.FileName = "postgresql-9.5.4-1-windows-x64.exe";
                //saveFileDialog.Filter = "exe files (*.exe)|*.*";

                //string filePath = null;
                //if (saveFileDialog.ShowDialog() == DialogResult.OK)
                //{
                //    filePath = saveFileDialog.FileName;
                //    File.WriteAllBytes(@filePath, Properties.Resources.postgresql);

                //    //MessageBox.Show("File Successfully saved.\r\n\r\n" + filePath, "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    btnDBDownload.Enabled = true;
                //}
                //else { 
                //    btnDBDownload.Enabled = true;
                //    return;
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
