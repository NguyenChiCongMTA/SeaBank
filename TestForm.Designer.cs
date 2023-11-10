
namespace SafeControl
{
    partial class TestForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.mListBox1 = new SafeControl.MComponent.MListBox(this.components);
            this.mTextBox1 = new SafeControl.MComponent.MTextBox(this.components);
            this.f8SendAPI_Email1 = new SafeControl.f8SendAPI_Email();
            this.SuspendLayout();
            // 
            // mListBox1
            // 
            this.mListBox1.FormattingEnabled = true;
            this.mListBox1.Location = new System.Drawing.Point(12, 12);
            this.mListBox1.Name = "mListBox1";
            this.mListBox1.sColumnName = null;
            this.mListBox1.Size = new System.Drawing.Size(511, 95);
            this.mListBox1.TabIndex = 0;
            this.mListBox1.SelectedIndexChanged += new System.EventHandler(this.mListBox1_SelectedIndexChanged);
            // 
            // mTextBox1
            // 
            this.mTextBox1.Location = new System.Drawing.Point(12, 113);
            this.mTextBox1.Multiline = true;
            this.mTextBox1.Name = "mTextBox1";
            this.mTextBox1.sColumnName = null;
            this.mTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mTextBox1.Size = new System.Drawing.Size(511, 224);
            this.mTextBox1.TabIndex = 3;
            // 
            // f8SendAPI_Email1
            // 
            this.f8SendAPI_Email1.AutoScroll = true;
            this.f8SendAPI_Email1.Location = new System.Drawing.Point(529, 12);
            this.f8SendAPI_Email1.Name = "f8SendAPI_Email1";
            this.f8SendAPI_Email1.Size = new System.Drawing.Size(343, 663);
            this.f8SendAPI_Email1.TabIndex = 4;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 699);
            this.Controls.Add(this.f8SendAPI_Email1);
            this.Controls.Add(this.mTextBox1);
            this.Controls.Add(this.mListBox1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MComponent.MListBox mListBox1;
        private MComponent.MTextBox mTextBox1;
        private f8SendAPI_Email f8SendAPI_Email1;
    }
}