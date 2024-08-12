using NetFwTypeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWorks.License.Setting.Program.Common
{
    class HFirewall
    {
        private int[] portsSocket = { 777, 3306 };
        private string[] portsName = { "AsyncPort", "MySqlPort" };
        private INetFwProfile mFwProfile = null;

        protected internal void OpenFirewallPort(int pPort, string pName)
        {
            INetFwOpenPorts openPorts = null;
            INetFwOpenPort openPort = null;
            try
            {
                if (isPortFound(pPort, pName) == false)
                {
                    SetProfile();
                    openPorts = mFwProfile.GloballyOpenPorts;

                    openPort = GetInstance("INetOpenPort") as INetFwOpenPort;
                    openPort.Port = pPort;
                    openPort.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                    openPort.Name = pName;

                    openPorts.Add(openPort);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (openPorts != null) openPorts = null;
                if (openPort != null) openPort = null;
            }
        }

        protected internal void CloseFirewallPort(int pPort, string pName)
        {
            INetFwOpenPorts ports = null;
            INetFwOpenPort openPort = null;
            try
            {
                if (isPortFound(pPort, pName) == true)
                {
                    SetProfile();
                    ports = mFwProfile.GloballyOpenPorts;

                    openPort = GetInstance("INetOpenPort") as INetFwOpenPort;
                    openPort.Port = pPort;
                    openPort.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                    openPort.Name = pName;

                    ports.Remove(pPort, NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (ports != null) ports = null;
            }
        }

        protected internal bool isPortFound(int pPort, string pName)
        {
            bool boolResult = false;
            INetFwOpenPorts ports = null;
            Type progID = null;
            INetFwMgr firewall = null;
            INetFwOpenPort currentPort = null;
            try
            {
                progID = Type.GetTypeFromProgID("HNetCfg.FwMgr");
                firewall = Activator.CreateInstance(progID) as INetFwMgr;
                ports = firewall.LocalPolicy.CurrentProfile.GloballyOpenPorts;
                IEnumerator portEnumerate = ports.GetEnumerator();
                while ((portEnumerate.MoveNext()))
                {
                    currentPort = portEnumerate.Current as INetFwOpenPort;

                    if (currentPort.Name == pName && currentPort.Port == pPort)
                    {
                        boolResult = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (ports != null) ports = null;
                if (progID != null) progID = null;
                if (firewall != null) firewall = null;
                if (currentPort != null) currentPort = null;
            }
            return boolResult;
        }










        protected internal void OpenFirewall()
        {
            INetFwAuthorizedApplications authApps = null;
            INetFwAuthorizedApplication authApp = null;
            INetFwOpenPorts openPorts = null;
            INetFwOpenPort openPort = null;
            try
            {
                if (isAppFound(Application.ProductName + " Server") == false)
                {
                    SetProfile();
                    authApps = mFwProfile.AuthorizedApplications;
                    authApp = GetInstance("INetAuthApp") as INetFwAuthorizedApplication;
                    authApp.Name = Application.ProductName + " Server";
                    authApp.ProcessImageFileName = Application.ExecutablePath.Replace(".EXE", ".exe");
                    authApps.Add(authApp);
                }

                if (isPortFound(portsSocket[0]) == false)
                {
                    SetProfile();
                    openPorts = mFwProfile.GloballyOpenPorts;
                    openPort = GetInstance("INetOpenPort") as INetFwOpenPort;
                    openPort.Port = portsSocket[0];
                    openPort.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                    openPort.Name = portsName[0];
                    openPorts.Add(openPort);
                }

                if (isPortFound(portsSocket[1]) == false)
                {
                    SetProfile();
                    openPorts = mFwProfile.GloballyOpenPorts;
                    openPort = GetInstance("INetOpenPort") as INetFwOpenPort;
                    openPort.Port = portsSocket[1];
                    openPort.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                    openPort.Name = portsName[1];
                    openPorts.Add(openPort);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (authApps != null) authApps = null;
                if (authApp != null) authApp = null;
                if (openPorts != null) openPorts = null;
                if (openPort != null) openPort = null;
            }
        }

        protected internal void CloseFirewall()
        {
            INetFwAuthorizedApplications apps = null;
            INetFwOpenPorts ports = null;
            try
            {
                if (isAppFound(Application.ProductName + " Server") == true)
                {
                    SetProfile();
                    apps = mFwProfile.AuthorizedApplications;
                    apps.Remove(Application.ExecutablePath.Replace(".EXE", ".exe"));
                }

                if (isPortFound(portsSocket[0]) == true)
                {
                    SetProfile();
                    ports = mFwProfile.GloballyOpenPorts;
                    ports.Remove(portsSocket[0], NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);
                }

                if (isPortFound(portsSocket[1]) == true)
                {
                    SetProfile();
                    ports = mFwProfile.GloballyOpenPorts;
                    ports.Remove(portsSocket[1], NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (apps != null) apps = null;
                if (ports != null) ports = null;
            }
        }

        protected internal bool isAppFound(string appName)
        {
            bool boolResult = false;
            Type progID = null;
            INetFwMgr firewall = null;
            INetFwAuthorizedApplications apps = null;
            INetFwAuthorizedApplication app = null;
            try
            {
                progID = Type.GetTypeFromProgID("HNetCfg.FwMgr");
                firewall = Activator.CreateInstance(progID) as INetFwMgr;
                if (firewall.LocalPolicy.CurrentProfile.FirewallEnabled)
                {
                    apps = firewall.LocalPolicy.CurrentProfile.AuthorizedApplications;
                    IEnumerator appEnumerate = apps.GetEnumerator();
                    while ((appEnumerate.MoveNext()))
                    {
                        app = appEnumerate.Current as INetFwAuthorizedApplication;
                        if (app.Name == appName)
                        {
                            boolResult = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (progID != null) progID = null;
                if (firewall != null) firewall = null;
                if (apps != null) apps = null;
                if (app != null) app = null;
            }
            return boolResult;
        }

        protected internal bool isPortFound(int portNumber)
        {
            bool boolResult = false;
            INetFwOpenPorts ports = null;
            Type progID = null;
            INetFwMgr firewall = null;
            INetFwOpenPort currentPort = null;
            try
            {
                progID = Type.GetTypeFromProgID("HNetCfg.FwMgr");
                firewall = Activator.CreateInstance(progID) as INetFwMgr;
                ports = firewall.LocalPolicy.CurrentProfile.GloballyOpenPorts;
                IEnumerator portEnumerate = ports.GetEnumerator();
                while ((portEnumerate.MoveNext()))
                {
                    currentPort = portEnumerate.Current as INetFwOpenPort;

                    if (currentPort.Port == portNumber)
                    {
                        boolResult = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (ports != null) ports = null;
                if (progID != null) progID = null;
                if (firewall != null) firewall = null;
                if (currentPort != null) currentPort = null;
            }
            return boolResult;
        }

        protected internal void SetProfile()
        {
            INetFwMgr fwMgr = null;
            INetFwPolicy fwPolicy = null;
            try
            {
                fwMgr = GetInstance("INetFwMgr") as INetFwMgr;
                fwPolicy = fwMgr.LocalPolicy;
                mFwProfile = fwPolicy.CurrentProfile;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fwMgr != null) fwMgr = null;
                if (fwPolicy != null) fwPolicy = null;
            }
        }

        protected internal object GetInstance(string typeName)
        {
            Type tpResult = null;
            switch (typeName)
            {
                case "INetFwMgr":
                    tpResult = Type.GetTypeFromCLSID(new Guid("{304CE942-6E39-40D8-943A-B913C40C9CD4}"));
                    return Activator.CreateInstance(tpResult);
                case "INetAuthApp":
                    tpResult = Type.GetTypeFromCLSID(new Guid("{EC9846B3-2762-4A6B-A214-6ACB603462D2}"));
                    return Activator.CreateInstance(tpResult);
                case "INetOpenPort":
                    tpResult = Type.GetTypeFromCLSID(new Guid("{0CA545C6-37AD-4A6C-BF92-9F7610067EF5}"));
                    return Activator.CreateInstance(tpResult);
                default:
                    return null;
            }
        }

    }
}
