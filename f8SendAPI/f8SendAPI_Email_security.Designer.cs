namespace SafeControl
{
    partial class f8SendAPI_Email_security
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
            this.components = new System.ComponentModel.Container();
            this.mTabControl1 = new SafeControl.MComponent.MTabControl(this.components);
            this.security = new System.Windows.Forms.TabPage();
            this.code = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel5 = new SafeControl.MComponent.MLabel(this.components);
            this.sender = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel6 = new SafeControl.MComponent.MLabel(this.components);
            this.sign = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel7 = new SafeControl.MComponent.MLabel(this.components);
            this.mTabControl1.SuspendLayout();
            this.security.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTabControl1
            // 
            this.mTabControl1.Controls.Add(this.security);
            this.mTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTabControl1.Location = new System.Drawing.Point(0, 0);
            this.mTabControl1.Name = "mTabControl1";
            this.mTabControl1.sColumnName = null;
            this.mTabControl1.SelectedIndex = 0;
            this.mTabControl1.Size = new System.Drawing.Size(300, 116);
            this.mTabControl1.TabIndex = 10;
            // 
            // security
            // 
            this.security.AutoScroll = true;
            this.security.Controls.Add(this.code);
            this.security.Controls.Add(this.mLabel5);
            this.security.Controls.Add(this.sender);
            this.security.Controls.Add(this.mLabel6);
            this.security.Controls.Add(this.sign);
            this.security.Controls.Add(this.mLabel7);
            this.security.Location = new System.Drawing.Point(4, 22);
            this.security.Name = "security";
            this.security.Padding = new System.Windows.Forms.Padding(3);
            this.security.Size = new System.Drawing.Size(292, 90);
            this.security.TabIndex = 0;
            this.security.Text = "security";
            this.security.UseVisualStyleBackColor = true;
            // 
            // code
            // 
            this.code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.code.Location = new System.Drawing.Point(86, 60);
            this.code.Name = "code";
            this.code.sColumnName = null;
            this.code.Size = new System.Drawing.Size(187, 22);
            this.code.TabIndex = 34;
            this.code.Text = "SB2015";
            // 
            // mLabel5
            // 
            this.mLabel5.Location = new System.Drawing.Point(11, 63);
            this.mLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.sColumnName = null;
            this.mLabel5.Size = new System.Drawing.Size(70, 13);
            this.mLabel5.TabIndex = 33;
            this.mLabel5.Text = "code";
            this.mLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sender
            // 
            this.sender.Location = new System.Drawing.Point(86, 33);
            this.sender.Name = "sender";
            this.sender.sColumnName = null;
            this.sender.Size = new System.Drawing.Size(187, 22);
            this.sender.TabIndex = 32;
            this.sender.Text = "SERVICE";
            // 
            // mLabel6
            // 
            this.mLabel6.Location = new System.Drawing.Point(11, 36);
            this.mLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel6.Name = "mLabel6";
            this.mLabel6.sColumnName = null;
            this.mLabel6.Size = new System.Drawing.Size(70, 13);
            this.mLabel6.TabIndex = 31;
            this.mLabel6.Text = "sender";
            this.mLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sign
            // 
            this.sign.Location = new System.Drawing.Point(86, 6);
            this.sign.Name = "sign";
            this.sign.sColumnName = null;
            this.sign.Size = new System.Drawing.Size(187, 22);
            this.sign.TabIndex = 30;
            this.sign.Text = "Nosign";
            // 
            // mLabel7
            // 
            this.mLabel7.Location = new System.Drawing.Point(11, 9);
            this.mLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel7.Name = "mLabel7";
            this.mLabel7.sColumnName = null;
            this.mLabel7.Size = new System.Drawing.Size(70, 13);
            this.mLabel7.TabIndex = 29;
            this.mLabel7.Text = "sign";
            this.mLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // f8SendAPI_Email_security
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mTabControl1);
            this.Name = "f8SendAPI_Email_security";
            this.Size = new System.Drawing.Size(300, 116);
            this.mTabControl1.ResumeLayout(false);
            this.security.ResumeLayout(false);
            this.security.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MTabControl mTabControl1;
        private System.Windows.Forms.TabPage security;
        public MComponent.MTextBox code;
        private MComponent.MLabel mLabel5;
        public MComponent.MTextBox sender;
        private MComponent.MLabel mLabel6;
        public MComponent.MTextBox sign;
        private MComponent.MLabel mLabel7;


    }
}
