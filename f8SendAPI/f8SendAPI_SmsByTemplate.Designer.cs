namespace SafeControl
{
    partial class f8SendAPI_SmsByTemplate
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
            this.header = new SafeControl.f8SendAPI_SmsByTemplate_header();
            this.body = new SafeControl.f8SendAPI_SmsByTemplate_body();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.AutoScroll = true;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(300, 125);
            this.header.TabIndex = 0;
            // 
            // body
            // 
            this.body.AutoScroll = true;
            this.body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body.Location = new System.Drawing.Point(0, 125);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(300, 275);
            this.body.TabIndex = 1;
            // 
            // f8SendAPI_SmsByTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.body);
            this.Controls.Add(this.header);
            this.Name = "f8SendAPI_SmsByTemplate";
            this.Size = new System.Drawing.Size(300, 400);
            this.ResumeLayout(false);

        }

        #endregion

        public f8SendAPI_SmsByTemplate_header header;
        public f8SendAPI_SmsByTemplate_body body;

    }
}
