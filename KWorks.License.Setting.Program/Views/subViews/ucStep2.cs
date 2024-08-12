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
    public partial class ucStep2 : DevExpress.XtraEditors.XtraUserControl
    {
        NavigationFrame pNavigationFrame;
        NavigationPage pNavigationPage;
        StepProgressBarItem pStepProgressBarItem;

        public ucStep2()
        {
            InitializeComponent();
        }

        public ucStep2(NavigationFrame _NavigationFrame, NavigationPage _NavigationPage, StepProgressBarItem _StepProgressBarItem)
        {
            pNavigationFrame = _NavigationFrame;
            pNavigationPage = _NavigationPage;
            pStepProgressBarItem = _StepProgressBarItem;

            InitializeComponent();
        }


        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnCreateDB.Enabled = false;

                var value =
                "host=" + this.txtHost.Text +
                "; port=" + this.txtPort.Text +
                //"; database=" + KConfig.DefaultDatabaseName +
                "; user id=" + this.txtId.Text +
                "; password=" + this.txtPwd.Text;

                splashScreenManager2.ShowWaitForm();

                if (!SqlHelper.SettingConnectDb(value))
                {
                    this.btnCreateDB.Enabled = true;
                    labNotice.Visible = true;
                    splashScreenManager2.CloseWaitForm();
                    return;
                }

                bool errorChk = false;
                dynamic rc;
                ClearLog();

                AddLog("-------------------");
                AddLog("1. MariaDB config 설정 변경 : ", false);
                rc = SetMariaDBConfigFile();
                if (!rc.success) errorChk = true;
                AddLog(rc.success ? "성공" : "실패 => " + rc.message);

                AddLog("-------------------");
                AddLog("2. 방화벽 Open : ", false);
                rc = OpenFirewall();
                if (!rc.success) errorChk = true;
                AddLog(rc.success ? "성공" : "실패 => " + rc.message);

                AddLog("-------------------");
                AddLog("3. MariaDB 재시작 : ", false);
                rc = RestartService(KCustomControl.serviceInfo("MARIADB").ServiceName, 60000);
                if (!rc.success) errorChk = true;
                AddLog(rc.success ? "성공" : "실패 => " + rc.message);

                AddLog("-------------------");
                AddLog("4. DB 생성 : ", false);
                rc = CreateDatabase(txtDataBase.Text);
                if (!rc.success) errorChk = true;
                AddLog(rc.success ? "성공" : "실패 => " + rc.message);


                AddLog("-------------------");
                AddLog("5. Table 생성 : ", false);
                rc = CreateTable();
                if (!rc.success) errorChk = true;
                AddLog(rc.success ? "성공" : "실패 => " + rc.message);

                this.btnCreateDB.Enabled = true;
                splashScreenManager2.CloseWaitForm();

                if (!errorChk)
                {
                    pNavigationFrame.SelectedPage = pNavigationPage;
                    pStepProgressBarItem.State = StepProgressBarItemState.Active;
                }
            }
            catch (Exception ex)
            {
                this.btnCreateDB.Enabled = true;
                splashScreenManager2.CloseWaitForm();
            }
        }



        /// <summary>
        /// my.ini 수정
        /// my.ini파일은 MariaDB 설치폴더 내부에 존재합니다.
        /// </summary>
        private dynamic SetMariaDBConfigFile()
        {
            try
            {
                string confFileName = GetDefaultMariaDBPath().Trim() + "\\my.ini";

                if (!File.Exists(confFileName))
                {
                    throw new FileNotFoundException($"File not found: {confFileName}");
                }


                StreamReader sr = new StreamReader(confFileName);
                string line = "";
                string previousLine = null;
                StringBuilder sb = new StringBuilder();

                do
                {
                    line = sr.ReadLine();

                    sb.AppendLine(line);

                    // Check and add settings under innodb_buffer_pool_size
                    if (line.Contains("innodb_buffer_pool_size"))
                    {
                        if(sr.Peek() > 0)
                        {
                            previousLine = line;
                            line = sr.ReadLine();

                            if (!line.Contains("character-set-server=utf8"))
                            {
                                sb.AppendLine("character-set-server=utf8");
                                sb.AppendLine("collation-server=utf8_general_ci");
                                sb.AppendLine("init_connect=\"SET collation_connection=utf8_general_ci\"");
                                sb.AppendLine("init_connect=\"SET NAMES utf8\"");
                                sb.AppendLine(line);
                            }
                            else
                            {
                                sb.AppendLine(line);
                            }
                        }
                    }
                    // Check and add settings under client section
                    else if (line.Contains("plugin-dir=C:\\Program Files\\MariaDB 11.4/lib/plugin"))
                    {
                        if (sr.Peek() > 0)
                        {
                            previousLine = line;
                            line = sr.ReadLine();

                            if (!line.Contains("default-character-set=utf8"))
                            {
                                sb.AppendLine("default-character-set=utf8");
                            }
                            else
                            {
                                sb.AppendLine(line);
                            }
                        }
                        else
                        {
                            sb.AppendLine("default-character-set=utf8");
                        }
                    }

                } while (sr.Peek() >= 0);

                sr.Close();

                StreamWriter sw = new StreamWriter(confFileName);
                sw.Write(sb.ToString());
                sw.Close();

                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, message = ex.Message };
            }
        }


        /// <summary>
        /// pg_hba.conf 수정
        /// pg_hba.conf파일은 pgsql 설치폴더의 data폴더 내부에 존재합니다.
        /// </summary>
        private dynamic SetConfigFile()
        {
            try
            {
                string confFileName = GetDefaultPostgresQLPath().Trim() + "\\pg_hba.conf";
                StreamReader sr = new StreamReader(confFileName);
                string line = "";
                StringBuilder sb = new StringBuilder();
                do
                {
                    line = sr.ReadLine();

                    if (line.Contains("# IPv4 local connections:"))
                    {
                        sb.AppendLine(line);
                        sb.AppendLine("host    all             all             0.0.0.0/0            md5");
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }

                } while (sr.Peek() >= 0);

                sr.Close();

                StreamWriter sw = new StreamWriter(confFileName);
                sw.Write(sb.ToString());
                sw.Close();

                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, message = ex.Message };
            }
        }

        /// <summary>
        /// pg_hba.conf 경로검색
        /// </summary>
        private string GetDefaultPostgresQLPath()
        {
            string path = @"C:\Program Files\PostgreSQL";

            if (Directory.Exists(path + "\\9.4"))
                path = path + "\\9.4";
            else if (Directory.Exists(path + "\\9.5"))
                path = path + "\\9.5";
            else if (Directory.Exists(path + "\\9.6"))
                path = path + "\\9.6";
            else if (Directory.Exists(path + "\\10"))
                path = path + "\\10";
            else if (Directory.Exists(path + "\\11"))
                path = path + "\\11";
            else if (Directory.Exists(path + "\\12"))
                path = path + "\\12";

            return path + "\\Data";
        }

        /// <summary>
        /// pg_hba.conf 경로검색
        /// </summary>
        private string GetDefaultMariaDBPath()
        {
            //string path = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\MariaDB 11.4 (x64)";

            string path = @"C:\Program Files\MariaDB 11.4\data";

            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}");
            }

            return path;
        }

        /// <summary>
        /// 포트개방
        /// </summary>
        private dynamic OpenFirewall()
        {
            try
            {
                HFirewall objFirewall = new HFirewall();
                objFirewall.OpenFirewallPort(int.Parse(this.txtPort.Text.ToString()), KCustomControl.serviceInfo("MARIADB").ServiceName);

                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, message = ex.Message };
            }
        }

        /// <summary> 
        /// 서비스 프로그램 재실행 함수
        /// </summary>
        private dynamic RestartService(string pServiceName, int pTimeoutMilliseconds)
        {
            ServiceController service = new ServiceController(pServiceName);

            try
            {
                //// Start Service
                //TimeSpan timeout = TimeSpan.FromMilliseconds(pTimeoutMilliseconds);
                //service.Start();
                //service.WaitForStatus(ServiceControllerStatus.Running, timeout);

                //// Stop Service
                //TimeSpan timeout = TimeSpan.FromMilliseconds(pTimeoutMilliseconds);
                //service.Stop();
                //service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                // Restart Service
                int millisec1 = Environment.TickCount;
                TimeSpan timeout = TimeSpan.FromMilliseconds(pTimeoutMilliseconds);

                if (service.Status == ServiceControllerStatus.StartPending)
                {
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    Thread.Sleep(1000);
                }
                else if (service.Status == ServiceControllerStatus.PausePending)
                {
                    service.WaitForStatus(ServiceControllerStatus.Paused, timeout);
                    Thread.Sleep(1000);
                }
                else if (service.Status == ServiceControllerStatus.ContinuePending)
                {
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    Thread.Sleep(1000);
                }

                if (service.Status == ServiceControllerStatus.StopPending)
                {
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    Thread.Sleep(1000);
                }
                else if (service.Status != ServiceControllerStatus.Stopped)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    Thread.Sleep(1000);
                }

                // count the rest of the timeout
                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(pTimeoutMilliseconds - (millisec2 - millisec1));

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);

                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, message = ex.Message };
            }
        }

        /// <summary> 
        /// 데이터베이스 생성
        /// </summary>
        private dynamic CreateDatabase()
        {
            try
            {
                SqlHelperConnection.ConnectionString = $"Server={this.txtHost.Text.Trim()}; Port={this.txtPort.Text.Trim()}; User Id={this.txtId.Text.Trim()}; Password={this.txtPwd.Text.Trim()};";
                CreateDBObject("Scripts\\ScriptDatabase.xml");

                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, message = ex.Message };
            }
        }

        /// <summary> 
        /// 데이터베이스 생성 - 사용자 입력
        /// </summary>
        private dynamic CreateDatabase(string dbName)
        {
            try
            {
                SqlHelperConnection.ConnectionString = $"Server={this.txtHost.Text.Trim()}; Port={this.txtPort.Text.Trim()}; User Id={this.txtId.Text.Trim()}; Password={this.txtPwd.Text.Trim()};";
                CreateDBObject("Scripts\\ScriptDatabase.xml", dbName);

                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, message = ex.Message };
            }
        }

        /// <summary> 
        /// 데이터베이스 생성 [상세]
        /// </summary>
        private void CreateDBObject(string pScriptFileName)
        {
            try
            {
                string fileName = Application.StartupPath + "\\" + pScriptFileName;
                string temp = "";
                XmlDocument xml = new XmlDocument();
                xml.Load(fileName);

                XmlNodeList xmlList = xml.SelectNodes("/mapper");
                if (xmlList.Count == 1)
                {
                    foreach (XmlNode xnl in xmlList[0].ChildNodes)
                    {
                        if (xnl.NodeType == XmlNodeType.Element)
                        {
                            if (xnl.Attributes["exeType"] != null)
                            {
                                temp = xnl.InnerText;

                                switch (xnl.Attributes["exeType"].Value)
                                {
                                    case "package":
                                        SqlHelper.ExecuteNonQuery(SqlHelperConnection.ConnectionString, CommandType.Text, temp);
                                        break;
                                    case "line":
                                        string[] queryArr = temp.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                                        foreach (string query in queryArr)
                                        {
                                            if (query.Trim().Length > 0)
                                            {
                                                SqlHelper.ExecuteNonQuery(SqlHelperConnection.ConnectionString, CommandType.Text, query);
                                            }
                                        }

                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary> 
        /// 데이터베이스 생성 - 사용자 입력
        /// </summary>
        private void CreateDBObject(string pScriptFileName, string dbName)
        {
            try
            {
                string fileName = Application.StartupPath + "\\" + pScriptFileName;
                string temp = "";
                XmlDocument xml = new XmlDocument();
                xml.Load(fileName);

                foreach (XmlNode node in xml.SelectNodes("//text()"))
                {
                    if (node.Value.Contains("@DB@"))
                    {
                        node.Value = node.Value.Replace("@DB@", dbName);
                    }
                }

                XmlNodeList xmlList = xml.SelectNodes("/mapper");
                if (xmlList.Count == 1)
                {
                    foreach (XmlNode xnl in xmlList[0].ChildNodes)
                    {
                        if (xnl.NodeType == XmlNodeType.Element)
                        {
                            if (xnl.Attributes["exeType"] != null)
                            {
                                temp = xnl.InnerText;

                                switch (xnl.Attributes["exeType"].Value)
                                {
                                    case "package":
                                        SqlHelper.ExecuteNonQuery(SqlHelperConnection.ConnectionString, CommandType.Text, temp);
                                        break;
                                    case "line":
                                        string[] queryArr = temp.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                                        foreach (string query in queryArr)
                                        {
                                            if (query.Trim().Length > 0)
                                            {
                                                SqlHelper.ExecuteNonQuery(SqlHelperConnection.ConnectionString, CommandType.Text, query);
                                            }
                                        }

                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary> 
        /// 테이블스키마 생성
        /// </summary>
        private dynamic CreateTable()
        {
            try
            {
                SqlHelperConnection.ConnectionString = $"Server={this.txtHost.Text.Trim()}; Port={this.txtPort.Text}; User Id={this.txtId.Text.Trim()}; Password={this.txtPwd.Text.Trim()}; Database={this.txtDataBase.Text.Trim()}";
                CreateDBObject("Scripts\\Scripts.xml");

                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, message = ex.Message };
            }
        }












        private void AddLog(string pText, bool pNewLine = true)
        {
            if (pNewLine)
                this.txtLog.Text += pText + System.Environment.NewLine;
            else
                this.txtLog.Text += pText;
        }

        private void ClearLog()
        {
            this.txtLog.Text = "";
        }
    }
}
