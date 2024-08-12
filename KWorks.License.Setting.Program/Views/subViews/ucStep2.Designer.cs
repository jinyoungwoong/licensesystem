
namespace KWorks.License.Setting.Program.Views.subViews
{
    partial class ucStep2
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
            this.splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::KWorks.License.Setting.Program.Views.subViews.WaitForm2), true, true, typeof(System.Windows.Forms.UserControl));
            this.labNotice = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtLog = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnCreateDB = new DevExpress.XtraEditors.SimpleButton();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDataBase = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtHost = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager2
            // 
            this.splashScreenManager2.ClosingDelay = 500;
            // 
            // labNotice
            // 
            this.labNotice.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNotice.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labNotice.Appearance.Options.UseFont = true;
            this.labNotice.Appearance.Options.UseForeColor = true;
            this.labNotice.Appearance.Options.UseTextOptions = true;
            this.labNotice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labNotice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labNotice.Location = new System.Drawing.Point(27, 469);
            this.labNotice.Name = "labNotice";
            this.labNotice.Size = new System.Drawing.Size(259, 18);
            this.labNotice.TabIndex = 29;
            this.labNotice.Text = "서버에 연결할 수 없습니다.";
            this.labNotice.Visible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(323, 85);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(54, 15);
            this.labelControl7.TabIndex = 28;
            this.labelControl7.Text = "로그정보 :";
            // 
            // txtLog
            // 
            this.txtLog.EditValue = "";
            this.txtLog.Location = new System.Drawing.Point(323, 109);
            this.txtLog.Name = "txtLog";
            this.txtLog.Properties.AllowFocused = false;
            this.txtLog.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Properties.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLog.Properties.Appearance.Options.UseFont = true;
            this.txtLog.Properties.Appearance.Options.UseForeColor = true;
            this.txtLog.Properties.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(544, 298);
            this.txtLog.TabIndex = 27;
            this.txtLog.TabStop = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(75, 341);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(210, 13);
            this.labelControl6.TabIndex = 26;
            this.labelControl6.Text = "※동일 이름의 데이터베이스는 자동 삭제됨";
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.AllowFocus = false;
            this.btnCreateDB.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnCreateDB.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCreateDB.Appearance.Options.UseBackColor = true;
            this.btnCreateDB.Appearance.Options.UseFont = true;
            this.btnCreateDB.Location = new System.Drawing.Point(170, 427);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(115, 36);
            this.btnCreateDB.TabIndex = 25;
            this.btnCreateDB.Text = "데이터베이스 생성";
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // txtPort
            // 
            this.txtPort.EditValue = "3306";
            this.txtPort.Location = new System.Drawing.Point(27, 385);
            this.txtPort.Name = "txtPort";
            this.txtPort.Properties.AllowFocused = false;
            this.txtPort.Properties.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(258, 22);
            this.txtPort.TabIndex = 24;
            this.txtPort.TabStop = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(28, 360);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 15);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "포트정보 :";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(27, 248);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.AllowFocused = false;
            this.txtPwd.Properties.ReadOnly = true;
            this.txtPwd.Properties.UseSystemPasswordChar = true;
            this.txtPwd.Size = new System.Drawing.Size(258, 22);
            this.txtPwd.TabIndex = 22;
            this.txtPwd.TabStop = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(28, 223);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 15);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "패스워드 :";
            // 
            // txtId
            // 
            this.txtId.EditValue = "";
            this.txtId.Location = new System.Drawing.Point(27, 180);
            this.txtId.Name = "txtId";
            this.txtId.Properties.AllowFocused = false;
            this.txtId.Properties.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(258, 22);
            this.txtId.TabIndex = 20;
            this.txtId.TabStop = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(28, 155);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 15);
            this.labelControl3.TabIndex = 19;
            this.labelControl3.Text = "사용자 이름 :";
            // 
            // txtDataBase
            // 
            this.txtDataBase.EditValue = "NCMS";
            this.txtDataBase.Location = new System.Drawing.Point(27, 314);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Properties.AllowFocused = false;
            this.txtDataBase.Size = new System.Drawing.Size(258, 22);
            this.txtDataBase.TabIndex = 18;
            this.txtDataBase.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(28, 289);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(105, 15);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "데이터베이스 이름 :";
            // 
            // txtHost
            // 
            this.txtHost.EditValue = "";
            this.txtHost.Location = new System.Drawing.Point(27, 109);
            this.txtHost.Name = "txtHost";
            this.txtHost.Properties.AllowFocused = false;
            this.txtHost.Properties.ReadOnly = true;
            this.txtHost.Size = new System.Drawing.Size(258, 22);
            this.txtHost.TabIndex = 16;
            this.txtHost.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(28, 84);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 15);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "서버명 :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Location = new System.Drawing.Point(27, 48);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(708, 25);
            this.labelControl8.TabIndex = 31;
            this.labelControl8.Text = "서버정보 확인 후 데이터베이스 생성 버튼을 클릭하시기 바랍니다.";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.Appearance.Options.UseTextOptions = true;
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.Location = new System.Drawing.Point(27, 21);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(708, 28);
            this.labelControl9.TabIndex = 30;
            this.labelControl9.Text = "데이터베이스 및 테이블 스키마를 생성합니다.";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Appearance.Options.UseTextOptions = true;
            this.labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.Location = new System.Drawing.Point(130, 48);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(110, 25);
            this.labelControl10.TabIndex = 32;
            this.labelControl10.Text = "데이터베이스 생성";
            // 
            // ucStep2
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labNotice);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.btnCreateDB);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.labelControl1);
            this.Name = "ucStep2";
            this.Size = new System.Drawing.Size(904, 512);
            ((System.ComponentModel.ISupportInitialize)(this.txtLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labNotice;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.MemoEdit txtLog;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnCreateDB;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDataBase;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtHost;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
    }
}
