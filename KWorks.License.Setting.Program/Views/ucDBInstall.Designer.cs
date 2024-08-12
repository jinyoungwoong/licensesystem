
namespace KWorks.License.Setting.Program.Views
{
    partial class ucDBInstall
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDBDownload = new DevExpress.XtraEditors.SimpleButton();
            this.labCo = new DevExpress.XtraEditors.LabelControl();
            this.labNotice = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // btnDBDownload
            // 
            this.btnDBDownload.AllowFocus = false;
            this.btnDBDownload.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnDBDownload.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBDownload.Appearance.Options.UseBackColor = true;
            this.btnDBDownload.Appearance.Options.UseFont = true;
            this.btnDBDownload.AppearanceDisabled.BackColor = System.Drawing.Color.DimGray;
            this.btnDBDownload.AppearanceDisabled.Options.UseBackColor = true;
            this.btnDBDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDBDownload.Location = new System.Drawing.Point(692, 552);
            this.btnDBDownload.Name = "btnDBDownload";
            this.btnDBDownload.Size = new System.Drawing.Size(187, 41);
            this.btnDBDownload.TabIndex = 0;
            this.btnDBDownload.Text = "다운로드";
            this.btnDBDownload.Click += new System.EventHandler(this.btnDBDownload_Click);
            // 
            // labCo
            // 
            this.labCo.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCo.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labCo.Appearance.Options.UseFont = true;
            this.labCo.Appearance.Options.UseForeColor = true;
            this.labCo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCo.Location = new System.Drawing.Point(42, 65);
            this.labCo.Name = "labCo";
            this.labCo.Size = new System.Drawing.Size(837, 149);
            this.labCo.TabIndex = 1;
            this.labCo.Text = "MariaDB (mariadb-11.4.2-winx64.msi Ver.)  데이터베이스 설치를 시작합니다.\r\n\r\n프로그램 구동을 위해 운영체제 제" +
    "품군은 Windows Installers만 지원합니다.\r\n\r\n설치 프로그램은 Windows에서 MariaDB를 시작하고 실행할 수 있는 간단하고" +
    " 빠른 방법으로 설계되었습니다.";
            // 
            // labNotice
            // 
            this.labNotice.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNotice.Appearance.ForeColor = System.Drawing.Color.Green;
            this.labNotice.Appearance.Options.UseFont = true;
            this.labNotice.Appearance.Options.UseForeColor = true;
            this.labNotice.Appearance.Options.UseTextOptions = true;
            this.labNotice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labNotice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labNotice.Location = new System.Drawing.Point(335, 503);
            this.labNotice.Name = "labNotice";
            this.labNotice.Size = new System.Drawing.Size(544, 43);
            this.labNotice.TabIndex = 2;
            this.labNotice.Text = "이미 데이터베이스가 설치되어있습니다.\r\nmariadb-11.4.2 ver.";
            this.labNotice.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(42, 85);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(287, 29);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "MariaDB (mariadb-11.4.2-winx64.msi Ver.)\r\n";
            // 
            // ucDBInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labNotice);
            this.Controls.Add(this.labCo);
            this.Controls.Add(this.btnDBDownload);
            this.Name = "ucDBInstall";
            this.Size = new System.Drawing.Size(904, 619);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDBDownload;
        private DevExpress.XtraEditors.LabelControl labCo;
        private DevExpress.XtraEditors.LabelControl labNotice;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
