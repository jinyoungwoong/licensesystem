using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.ServiceProcess;

namespace KWorks.License.Setting.Program.Common
{
    public class KCustomControl
    {
        public static bool serviceExists(string ServiceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.ToUpper().Contains(ServiceName));
        }

        public static ServiceController serviceInfo(string ServiceName)
        {
            return ServiceController.GetServices().FirstOrDefault(serviceController => serviceController.ServiceName.ToUpper().Contains(ServiceName));
        }

    }
}
