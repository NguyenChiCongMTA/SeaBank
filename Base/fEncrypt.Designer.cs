namespace SafeControl.Base
{
    partial class fEncrypt
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
            this.mtb_key = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel3 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel4 = new SafeControl.MComponent.MLabel(this.components);
            this.mbt_MaHoa = new SafeControl.MComponent.MButton(this.components);
            this.mrtb_MAC = new SafeControl.MComponent.MRichTextBox(this.components);
            this.mrtb_encrypt = new SafeControl.MComponent.MRichTextBox(this.components);
            this.mpMainContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpMainContext
            // 
            this.mpMainContext.Controls.Add(this.mrtb_encrypt);
            this.mpMainContext.Controls.Add(this.mrtb_MAC);
            this.mpMainContext.Controls.Add(this.mbt_MaHoa);
            this.mpMainContext.Controls.Add(this.mLabel4);
            this.mpMainContext.Controls.Add(this.mLabel3);
            this.mpMainContext.Controls.Add(this.mLabel2);
            this.mpMainContext.Controls.Add(this.mtb_key);
            this.mpMainContext.Size = new System.Drawing.Size(582, 367);
            // 
            // mtb_key
            // 
            this.mtb_key.Location = new System.Drawing.Point(131, 154);
            this.mtb_key.Name = "mtb_key";
            this.mtb_key.sColumnName = null;
            this.mtb_key.Size = new System.Drawing.Size(416, 22);
            this.mtb_key.TabIndex = 0;
            this.mtb_key.Text = "123";
            this.mtb_key.UseSystemPasswordChar = true;
            // 
            // mLabel2
            // 
            this.mLabel2.Location = new System.Drawing.Point(19, 62);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(100, 23);
            this.mLabel2.TabIndex = 1;
            this.mLabel2.Text = "MAC";
            // 
            // mLabel3
            // 
            this.mLabel3.Location = new System.Drawing.Point(19, 166);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.sColumnName = null;
            this.mLabel3.Size = new System.Drawing.Size(100, 23);
            this.mLabel3.TabIndex = 1;
            this.mLabel3.Text = "Key";
            // 
            // mLabel4
            // 
            this.mLabel4.Location = new System.Drawing.Point(19, 241);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.sColumnName = null;
            this.mLabel4.Size = new System.Drawing.Size(100, 23);
            this.mLabel4.TabIndex = 1;
            this.mLabel4.Text = "Encrypt";
            // 
            // mbt_MaHoa
            // 
            this.mbt_MaHoa.Location = new System.Drawing.Point(221, 323);
            this.mbt_MaHoa.Name = "mbt_MaHoa";
            this.mbt_MaHoa.sColumnName = null;
            this.mbt_MaHoa.Size = new System.Drawing.Size(75, 23);
            this.mbt_MaHoa.TabIndex = 2;
            this.mbt_MaHoa.Text = "Mã hóa";
            this.mbt_MaHoa.UseVisualStyleBackColor = true;
            this.mbt_MaHoa.Click += new System.EventHandler(this.mbt_MaHoa_Click);
            // 
            // mrtb_MAC
            // 
            this.mrtb_MAC.AcceptsTab = true;
            this.mrtb_MAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mrtb_MAC.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.mrtb_MAC.HideSelection = false;
            this.mrtb_MAC.Location = new System.Drawing.Point(131, 29);
            this.mrtb_MAC.Name = "mrtb_MAC";
            this.mrtb_MAC.sColumnName = null;
            this.mrtb_MAC.Size = new System.Drawing.Size(416, 96);
            this.mrtb_MAC.TabIndex = 3;
            this.mrtb_MAC.Text = "";
            // 
            // mrtb_encrypt
            // 
            this.mrtb_encrypt.AcceptsTab = true;
            this.mrtb_encrypt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mrtb_encrypt.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.mrtb_encrypt.HideSelection = false;
            this.mrtb_encrypt.Location = new System.Drawing.Point(131, 205);
            this.mrtb_encrypt.Name = "mrtb_encrypt";
            this.mrtb_encrypt.sColumnName = null;
            this.mrtb_encrypt.Size = new System.Drawing.Size(416, 96);
            this.mrtb_encrypt.TabIndex = 3;
            this.mrtb_encrypt.Text = "";
            // 
            // fEncrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 447);
            this.Name = "fEncrypt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fEncrypt";
            this.Load += new System.EventHandler(this.fEncrypt_Load);
            this.mpMainContext.ResumeLayout(false);
            this.mpMainContext.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MLabel mLabel2;
        private MComponent.MTextBox mtb_key;
        private MComponent.MButton mbt_MaHoa;
        private MComponent.MLabel mLabel4;
        private MComponent.MLabel mLabel3;
        private MComponent.MRichTextBox mrtb_encrypt;
        private MComponent.MRichTextBox mrtb_MAC;
    }
}