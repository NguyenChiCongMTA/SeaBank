namespace SafeControl
{
    partial class f8SendAPI_SmsByBatch_bodyDialog
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
            this.phone = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.infor = new SafeControl.MComponent.MRichTextBox(this.components);
            this.channel = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel3 = new SafeControl.MComponent.MLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).BeginInit();
            this.msc_Context.Panel2.SuspendLayout();
            this.msc_Context.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpBottom
            // 
            this.mpBottom.Location = new System.Drawing.Point(0, 246);
            this.mpBottom.Size = new System.Drawing.Size(316, 28);
            // 
            // msc_Context
            // 
            // 
            // msc_Context.Panel2
            // 
            this.msc_Context.Panel2.Controls.Add(this.channel);
            this.msc_Context.Panel2.Controls.Add(this.mLabel3);
            this.msc_Context.Panel2.Controls.Add(this.infor);
            this.msc_Context.Panel2.Controls.Add(this.mLabel2);
            this.msc_Context.Panel2.Controls.Add(this.phone);
            this.msc_Context.Panel2.Controls.Add(this.mLabel1);
            this.msc_Context.Size = new System.Drawing.Size(316, 246);
            // 
            // mLabel1
            // 
            this.mLabel1.Location = new System.Drawing.Point(12, 12);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.sColumnName = null;
            this.mLabel1.Size = new System.Drawing.Size(83, 23);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "phone";
            this.mLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(120, 12);
            this.phone.Name = "phone";
            this.phone.sColumnName = null;
            this.phone.Size = new System.Drawing.Size(184, 22);
            this.phone.TabIndex = 1;
            this.phone.Text = "0989932221";
            // 
            // mLabel2
            // 
            this.mLabel2.Location = new System.Drawing.Point(12, 67);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(98, 23);
            this.mLabel2.TabIndex = 2;
            this.mLabel2.Text = "infor";
            this.mLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infor
            // 
            this.infor.AcceptsTab = true;
            this.infor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infor.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.infor.HideSelection = false;
            this.infor.Location = new System.Drawing.Point(15, 93);
            this.infor.Name = "infor";
            this.infor.sColumnName = null;
            this.infor.Size = new System.Drawing.Size(289, 88);
            this.infor.TabIndex = 5;
            this.infor.Text = "SeABank: Date 12/05/2020 Account: 11100014567135 Change: +30,000 VND. Balance: 38" +
    ",325 VND. Payee: 0974405977 Detail: NAP TIEN 437312 . .";
            // 
            // channel
            // 
            this.channel.Location = new System.Drawing.Point(120, 40);
            this.channel.Name = "channel";
            this.channel.sColumnName = null;
            this.channel.Size = new System.Drawing.Size(184, 22);
            this.channel.TabIndex = 7;
            this.channel.Text = "SMS/FireBase/Zalo";
            // 
            // mLabel3
            // 
            this.mLabel3.Location = new System.Drawing.Point(12, 40);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.sColumnName = null;
            this.mLabel3.Size = new System.Drawing.Size(83, 23);
            this.mLabel3.TabIndex = 6;
            this.mLabel3.Text = "channel";
            this.mLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // f8SendAPI_SmsByBatch_bodyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 274);
            this.Name = "f8SendAPI_SmsByBatch_bodyDialog";
            this.Text = "Tham số API_SmsByBatch";
            this.msc_Context.Panel2.ResumeLayout(false);
            this.msc_Context.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).EndInit();
            this.msc_Context.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MLabel mLabel1;
        private MComponent.MLabel mLabel2;
        private MComponent.MTextBox phone;
        private MComponent.MRichTextBox infor;
        private MComponent.MTextBox channel;
        private MComponent.MLabel mLabel3;
    }
}