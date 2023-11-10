namespace SafeControl
{
    partial class f8SendAPI_Email_FileAttachDialog
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
            this.components = new System.ComponentModel.Container();
            this.mLabel1 = new SafeControl.MComponent.MLabel(this.components);
            this.file_name = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.mllChon = new SafeControl.MComponent.MLinkLabel(this.components);
            this.file_byte64 = new SafeControl.MComponent.MRichTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).BeginInit();
            this.msc_Context.Panel2.SuspendLayout();
            this.msc_Context.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpBottom
            // 
            this.mpBottom.Location = new System.Drawing.Point(0, 121);
            this.mpBottom.Size = new System.Drawing.Size(424, 28);
            // 
            // msc_Context
            // 
            // 
            // msc_Context.Panel2
            // 
            this.msc_Context.Panel2.Controls.Add(this.file_byte64);
            this.msc_Context.Panel2.Controls.Add(this.mllChon);
            this.msc_Context.Panel2.Controls.Add(this.mLabel2);
            this.msc_Context.Panel2.Controls.Add(this.file_name);
            this.msc_Context.Panel2.Controls.Add(this.mLabel1);
            this.msc_Context.Size = new System.Drawing.Size(424, 121);
            // 
            // mLabel1
            // 
            this.mLabel1.Location = new System.Drawing.Point(12, 12);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.sColumnName = null;
            this.mLabel1.Size = new System.Drawing.Size(57, 23);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "file_name";
            this.mLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // file_name
            // 
            this.file_name.Location = new System.Drawing.Point(86, 12);
            this.file_name.Name = "file_name";
            this.file_name.sColumnName = null;
            this.file_name.Size = new System.Drawing.Size(292, 22);
            this.file_name.TabIndex = 1;
            // 
            // mLabel2
            // 
            this.mLabel2.Location = new System.Drawing.Point(12, 40);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(68, 23);
            this.mLabel2.TabIndex = 2;
            this.mLabel2.Text = "file_byte64";
            this.mLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mllChon
            // 
            this.mllChon.Location = new System.Drawing.Point(384, 12);
            this.mllChon.Name = "mllChon";
            this.mllChon.sColumnName = null;
            this.mllChon.Size = new System.Drawing.Size(34, 23);
            this.mllChon.TabIndex = 4;
            this.mllChon.TabStop = true;
            this.mllChon.Text = "chọn";
            this.mllChon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // file_byte64
            // 
            this.file_byte64.AcceptsTab = true;
            this.file_byte64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file_byte64.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.file_byte64.HideSelection = false;
            this.file_byte64.Location = new System.Drawing.Point(86, 40);
            this.file_byte64.Name = "file_byte64";
            this.file_byte64.sColumnName = null;
            this.file_byte64.Size = new System.Drawing.Size(292, 22);
            this.file_byte64.TabIndex = 5;
            this.file_byte64.Text = "";
            // 
            // f8SendAPI_Email_FileAttachDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 149);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "f8SendAPI_Email_FileAttachDialog";
            this.Text = "File đính kèm API_Email";
            this.msc_Context.Panel2.ResumeLayout(false);
            this.msc_Context.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).EndInit();
            this.msc_Context.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MLabel mLabel1;
        private MComponent.MLinkLabel mllChon;
        private MComponent.MLabel mLabel2;
        private MComponent.MTextBox file_name;
        private MComponent.MRichTextBox file_byte64;
    }
}