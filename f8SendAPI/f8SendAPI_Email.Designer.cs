namespace SafeControl
{
    partial class f8SendAPI_Email
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
            this.header = new SafeControl.f8SendAPI_Email_header();
            this.security = new SafeControl.f8SendAPI_Email_security();
            this.body = new SafeControl.f8SendAPI_Email_body();
            this.mTabControl1 = new SafeControl.MComponent.MTabControl(this.components);
            this.body.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.AutoScroll = true;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(300, 108);
            this.header.TabIndex = 0;
            // 
            // security
            // 
            this.security.AutoScroll = true;
            this.security.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.security.Location = new System.Drawing.Point(0, 316);
            this.security.Name = "security";
            this.security.Size = new System.Drawing.Size(300, 84);
            this.security.TabIndex = 2;
            // 
            // body
            // 
            this.body.AutoScroll = true;
            this.body.Controls.Add(this.mTabControl1);
            this.body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body.Location = new System.Drawing.Point(0, 108);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(300, 208);
            this.body.TabIndex = 3;
            // 
            // mTabControl1
            // 
            this.mTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTabControl1.Location = new System.Drawing.Point(0, 0);
            this.mTabControl1.Name = "mTabControl1";
            this.mTabControl1.sColumnName = null;
            this.mTabControl1.SelectedIndex = 0;
            this.mTabControl1.Size = new System.Drawing.Size(300, 208);
            this.mTabControl1.TabIndex = 10;
            // 
            // f8SendAPI_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.body);
            this.Controls.Add(this.security);
            this.Controls.Add(this.header);
            this.Name = "f8SendAPI_Email";
            this.Size = new System.Drawing.Size(300, 400);
            this.body.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public f8SendAPI_Email_header header;
        public f8SendAPI_Email_security security;
        private MComponent.MTabControl mTabControl1;
        public f8SendAPI_Email_body body;

    }
}
