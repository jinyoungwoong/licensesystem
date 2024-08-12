
namespace FC_WFM
{
    partial class Form2
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMacID = new System.Windows.Forms.TextBox();
            this.txtExIP = new System.Windows.Forms.TextBox();
            this.txtInIp = new System.Windows.Forms.TextBox();
            this.txtSireal = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtObj = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // txtMacID
            // 
            this.txtMacID.Location = new System.Drawing.Point(73, 240);
            this.txtMacID.Name = "txtMacID";
            this.txtMacID.ReadOnly = true;
            this.txtMacID.Size = new System.Drawing.Size(361, 21);
            this.txtMacID.TabIndex = 1;
            // 
            // txtExIP
            // 
            this.txtExIP.Location = new System.Drawing.Point(73, 284);
            this.txtExIP.Name = "txtExIP";
            this.txtExIP.ReadOnly = true;
            this.txtExIP.Size = new System.Drawing.Size(361, 21);
            this.txtExIP.TabIndex = 2;
            // 
            // txtInIp
            // 
            this.txtInIp.Location = new System.Drawing.Point(73, 327);
            this.txtInIp.Name = "txtInIp";
            this.txtInIp.ReadOnly = true;
            this.txtInIp.Size = new System.Drawing.Size(361, 21);
            this.txtInIp.TabIndex = 3;
            // 
            // txtSireal
            // 
            this.txtSireal.Location = new System.Drawing.Point(73, 370);
            this.txtSireal.Name = "txtSireal";
            this.txtSireal.ReadOnly = true;
            this.txtSireal.Size = new System.Drawing.Size(361, 21);
            this.txtSireal.TabIndex = 4;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(73, 414);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(361, 21);
            this.txtUser.TabIndex = 5;
            // 
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(73, 458);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.ReadOnly = true;
            this.txtDevice.Size = new System.Drawing.Size(361, 21);
            this.txtDevice.TabIndex = 6;
            // 
            // txtLicense
            // 
            this.txtLicense.Location = new System.Drawing.Point(73, 69);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(361, 21);
            this.txtLicense.TabIndex = 0;
            this.txtLicense.Text = "7B302DAB-4A71-4F82-AF08-19FAF04C1A93";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.Location = new System.Drawing.Point(73, 497);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(361, 56);
            this.button1.TabIndex = 7;
            this.button1.Text = "라이선스 등록 및 유효성 체크";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtContents
            // 
            this.txtContents.BackColor = System.Drawing.SystemColors.Window;
            this.txtContents.Location = new System.Drawing.Point(454, 92);
            this.txtContents.Multiline = true;
            this.txtContents.Name = "txtContents";
            this.txtContents.Size = new System.Drawing.Size(642, 214);
            this.txtContents.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(73, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "라이선스 키 입력";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(73, 219);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "맥어드레스";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(73, 267);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 14);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "외부아이피";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(73, 311);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 14);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "내부아이피";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(73, 352);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(50, 14);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "시리얼번호";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(73, 397);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(62, 14);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "PC 유저 이름";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(73, 439);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 14);
            this.labelControl7.TabIndex = 15;
            this.labelControl7.Text = "PC 디바이스 명";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(848, 587);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(248, 34);
            this.simpleButton1.TabIndex = 16;
            this.simpleButton1.Text = "프로그램 닫기";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtObj
            // 
            this.txtObj.BackColor = System.Drawing.SystemColors.Window;
            this.txtObj.Location = new System.Drawing.Point(454, 341);
            this.txtObj.Multiline = true;
            this.txtObj.Name = "txtObj";
            this.txtObj.Size = new System.Drawing.Size(642, 214);
            this.txtObj.TabIndex = 17;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(454, 69);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(116, 14);
            this.labelControl8.TabIndex = 18;
            this.labelControl8.Text = "HTTP Reponse 결과값";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(454, 322);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(76, 14);
            this.labelControl9.TabIndex = 19;
            this.labelControl9.Text = "JObject 파싱값";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 643);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtObj);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtContents);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.txtDevice);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtSireal);
            this.Controls.Add(this.txtInIp);
            this.Controls.Add(this.txtExIP);
            this.Controls.Add(this.txtMacID);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "라이선스 API 테스트 프로그램";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMacID;
        private System.Windows.Forms.TextBox txtExIP;
        private System.Windows.Forms.TextBox txtInIp;
        private System.Windows.Forms.TextBox txtSireal;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtContents;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TextBox txtObj;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}