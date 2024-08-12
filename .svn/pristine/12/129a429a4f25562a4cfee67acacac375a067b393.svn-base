using FC_WFM.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FC_WFM
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            SettingInformantion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //#0. 파라미터 셋팅
                var lic = txtLicense.Text;    //라이선스키
                var macId = txtMacID.Text;    //맥아이디
                var exIP = txtExIP.Text;      //외부아이피
                var inIP = txtInIp.Text;      //내부아이피
                var serial = txtSireal.Text;  //시리얼번호
                var user = txtUser.Text;      //PC_유저이름
                var device = txtDevice.Text;  //PC_디바이스이름


                //#1. 전송값 [타입:Post , 파라미터: #0. 파라미터 셋팅, UTF8인코딩]
                StringBuilder postParams = new StringBuilder();
                postParams.Append("id=" + lic);
                postParams.Append("&macId=" + macId);
                postParams.Append("&externalIP=" + exIP);
                postParams.Append("&internalIP=" + inIP);
                postParams.Append("&serial=" + serial);
                postParams.Append("&pcUserName=" + user);
                postParams.Append("&pcDeviceName=" + device);

                Encoding encoding = Encoding.UTF8;
                byte[] result = encoding.GetBytes(postParams.ToString());

                string Url = "http://localhost:40806/Register/"; // 대상URL
                //string Url = "http://license.ksolution.kr/Register/"; // 대상URL

                HttpWebRequest wReqFirst = (HttpWebRequest)WebRequest.Create(Url);

                wReqFirst.Method = "POST";
                wReqFirst.ContentType = "application/x-www-form-urlencoded";
                wReqFirst.ContentLength = result.Length;

                Stream postDataStream = wReqFirst.GetRequestStream();
                postDataStream.Write(result, 0, result.Length);
                postDataStream.Close();

            
                HttpWebResponse wRespFirst = (HttpWebResponse)wReqFirst.GetResponse();
                Stream respPostStream = wRespFirst.GetResponseStream();
                StreamReader readerPost = new StreamReader(respPostStream, Encoding.UTF8, true);

                //#2. 결과값
                string resultPost = readerPost.ReadToEnd();
                txtContents.Text = resultPost;








                //#3. 결과값 Json 파싱
                JObject obj = JObject.Parse(resultPost);
                if (obj.Count > 0)
                {
                    var success = bool.Parse(obj["success"].ToString());
                    var message = obj["message"].ToString();
                    var machineCnt = int.Parse(obj["machineCnt"].ToString());

                    if (success)
                    {
                        txtObj.Text = success + " // " + message + " // " + machineCnt;
                    }
                    else
                    {
                        txtObj.Text = success + " // " +  message + " // " + machineCnt;
                        return;
                    }
                }
                else
                {
                    txtObj.Text = "라이선스 등록중 오류가 발생하였습니다.\n관리자에게 문의하시기 바랍니다.";
                    return;
                }

            }
            catch (WebException we)
            {
                var weCode = (int)((HttpWebResponse)we.Response).StatusCode;
                var str = "라이선스 서버에 응답할 수 없습니다. {" + weCode + "} \n관리자에게 문의하시기 바랍니다.";
                txtContents.Text = str;
            }
        }

        private void SettingInformantion()
        {
            txtMacID.Text = DeviceInfo.GetMacAddress(";");
            txtExIP.Text = DeviceInfo.GetExternalIPAddress();
            txtInIp.Text = DeviceInfo.GetInternalIPAddress(";");
            txtSireal.Text = DeviceInfo.GetAllSerialNoList()[0]; 
            txtUser.Text = Environment.UserName;
            txtDevice.Text = Environment.MachineName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
