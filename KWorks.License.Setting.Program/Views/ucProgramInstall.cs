﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWorks.License.Setting.Program.Views
{
    public partial class ucProgramInstall : DevExpress.XtraEditors.XtraUserControl
    {
        public ucProgramInstall()
        {
            InitializeComponent();
        }

        private async void btnDownLoadServer_Click(object sender, EventArgs e)
        {
            try
            {
                btnDownLoadServer.Enabled = false;

                //string path = Application.StartupPath + "\\DownLoad\\Server\\NCMS.application";
                //Process.Start(path);

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //var uri = new Uri("http://ncms.ksolution.kr/Focas/Download/Server_V2/NCMS.application");  -- 케이솔루션즈
                    var uri = new Uri("http://125.133.198.70:5004/NCMS.application");                           /*-- 미러웍스*/
                    var targetPath = folderBrowserDialog.SelectedPath + "\\NCMS.application";

                    await DownloadFileAsync(uri, targetPath);
                }

                btnDownLoadServer.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("오류가 발생하였습니다." + System.Environment.NewLine + "관리자에게 문의하시기 바랍니다.", "Message", MessageBoxButtons.OK);
            }
        }

        private async void btnDownLoadClient_Click(object sender, EventArgs e)
        {
            try
            {
                btnDownLoadClient.Enabled = false;

                //string path = Application.StartupPath + "\\DownLoad\\Client\\NCMSClient.application";

                //string path = "http://kworks.ksolution.kr/Focas/Download/Client_V2/NCMSClient.application";
                //Process.Start(path);

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //var uri = new Uri("http://ncms.ksolution.kr/Focas/Download/Client_V2/NCMSClient.application");    -- 케이솔루션즈
                    var uri = new Uri("http://125.133.198.70:5005/NCMSClient.application");      /*-- 미러웍스*/
                    var targetPath = folderBrowserDialog.SelectedPath + "\\NCMSClient.application";

                    await DownloadFileAsync(uri, targetPath);
                }

                btnDownLoadClient.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("오류가 발생하였습니다." + System.Environment.NewLine + "관리자에게 문의하시기 바랍니다.", "Message", MessageBoxButtons.OK);
            }
        }

        private async Task DownloadFileAsync(Uri uri, string path)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    await webClient.DownloadFileTaskAsync(uri, path);
                    Process.Start(path);
                }
            }
            catch (Exception _ex)
            {
                XtraMessageBox.Show("오류가 발생하였습니다." + System.Environment.NewLine + "관리자에게 문의하시기 바랍니다.", "Message", MessageBoxButtons.OK);
            }
        }
    }
}
