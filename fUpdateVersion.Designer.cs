namespace SafeControl
{
    partial class fUpdateVersion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fUpdateVersion));
            this.mRichTextBox1 = new SafeControl.MComponent.MRichTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).BeginInit();
            this.msc_Context.Panel2.SuspendLayout();
            this.msc_Context.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpBottom
            // 
            this.mpBottom.Location = new System.Drawing.Point(0, 427);
            this.mpBottom.Size = new System.Drawing.Size(838, 28);
            // 
            // msc_Context
            // 
            // 
            // msc_Context.Panel2
            // 
            this.msc_Context.Panel2.Controls.Add(this.mRichTextBox1);
            this.msc_Context.Size = new System.Drawing.Size(838, 427);
            // 
            // mRichTextBox1
            // 
            this.mRichTextBox1.AcceptsTab = true;
            this.mRichTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mRichTextBox1.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.mRichTextBox1.ForeColor = System.Drawing.Color.White;
            this.mRichTextBox1.HideSelection = false;
            this.mRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.mRichTextBox1.Name = "mRichTextBox1";
            this.mRichTextBox1.sColumnName = null;
            this.mRichTextBox1.Size = new System.Drawing.Size(838, 377);
            this.mRichTextBox1.TabIndex = 0;
            this.mRichTextBox1.Text = resources.GetString("mRichTextBox1.Text");
            // 
            // fUpdateVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 455);
            this.Name = "fUpdateVersion";
            this.Text = "LỊCH SỬ UPDATE PHIÊN BẢN";
            this.msc_Context.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).EndInit();
            this.msc_Context.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MRichTextBox mRichTextBox1;
    }
}