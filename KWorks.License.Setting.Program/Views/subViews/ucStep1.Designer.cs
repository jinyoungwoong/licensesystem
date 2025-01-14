﻿
namespace KWorks.License.Setting.Program.Views.subViews
{
    partial class ucStep1
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtHost = new DevExpress.XtraEditors.TextEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.labNotice = new DevExpress.XtraEditors.LabelControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::KWorks.License.Setting.Program.Views.subViews.WaitForm1), true, true, typeof(System.Windows.Forms.UserControl));
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(29, 97);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 15);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "서버명 :";
            // 
            // txtHost
            // 
            this.txtHost.EditValue = "localhost";
            this.txtHost.Location = new System.Drawing.Point(28, 122);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(258, 22);
            this.txtHost.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.EditValue = "root";
            this.txtId.Location = new System.Drawing.Point(28, 193);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(258, 22);
            this.txtId.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(29, 168);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 15);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "사용자 이름 :";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(28, 262);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.UseSystemPasswordChar = true;
            this.txtPwd.Size = new System.Drawing.Size(258, 22);
            this.txtPwd.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(29, 237);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 15);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "패스워드 :";
            // 
            // txtPort
            // 
            this.txtPort.EditValue = "3306";
            this.txtPort.Location = new System.Drawing.Point(28, 329);
            this.txtPort.Name = "txtPort";
            this.txtPort.Properties.AllowFocused = false;
            this.txtPort.Properties.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(258, 22);
            this.txtPort.TabIndex = 0;
            this.txtPort.TabStop = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(29, 304);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 15);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "포트정보 :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(28, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(708, 28);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "데이터베이스 서버에 연결을 진행합니다.";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(109, 357);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(177, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "※포트정보는 변경하실 수 없습니다.";
            // 
            // btnConnect
            // 
            this.btnConnect.AllowFocus = false;
            this.btnConnect.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnConnect.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConnect.Appearance.Options.UseBackColor = true;
            this.btnConnect.Appearance.Options.UseFont = true;
            this.btnConnect.Location = new System.Drawing.Point(171, 394);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(115, 36);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.TabStop = false;
            this.btnConnect.Text = "데이터베이스 연동";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
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
            this.labNotice.Location = new System.Drawing.Point(110, 438);
            this.labNotice.Name = "labNotice";
            this.labNotice.Size = new System.Drawing.Size(177, 13);
            this.labNotice.TabIndex = 0;
            this.labNotice.Text = "서버에 연결할 수 없습니다.";
            this.labNotice.Visible = false;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(28, 51);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(708, 25);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "데이터베이스 서버 연결을 위해 연결정보를 입력하시기 바랍니다.";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Location = new System.Drawing.Point(213, 51);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(54, 25);
            this.labelControl8.TabIndex = 5;
            this.labelControl8.Text = "연결정보";
            // 
            // ucStep1
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labNotice);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.labelControl1);
            this.Name = "ucStep1";
            this.Size = new System.Drawing.Size(904, 512);
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtHost;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.LabelControl labNotice;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}
