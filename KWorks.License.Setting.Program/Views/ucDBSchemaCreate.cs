using DevExpress.XtraEditors;
using KWorks.License.Setting.Program.Views.subViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWorks.License.Setting.Program.Views
{
    public partial class ucDBSchemaCreate : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDBSchemaCreate()
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
            var step3 = new ucStep3();
            var step2 = new ucStep2(this.navigationFrame1, this.navigationPage3, this.stepProgressBarItem3);
            var step1 = new ucStep1(this.navigationFrame1, this.navigationPage2, this.stepProgressBarItem2, step2);

            step1.Dock = step2.Dock = step3.Dock = System.Windows.Forms.DockStyle.Fill;

            this.navigationPage1.Controls.Add(step1);
            this.navigationPage2.Controls.Add(step2);
            this.navigationPage3.Controls.Add(step3);
        }

        private void InitData()
        {

        }


    }
}
