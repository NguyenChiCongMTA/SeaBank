namespace SafeControl
{
    partial class f8SendAPI_SmsByTemplate_bodyDialog
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
            this.param_name = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.param_value = new SafeControl.MComponent.MRichTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).BeginInit();
            this.msc_Context.Panel2.SuspendLayout();
            this.msc_Context.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpBottom
            // 
            this.mpBottom.Location = new System.Drawing.Point(0, 190);
            this.mpBottom.Size = new System.Drawing.Size(316, 28);
            // 
            // msc_Context
            // 
            // 
            // msc_Context.Panel2
            // 
            this.msc_Context.Panel2.Controls.Add(this.param_value);
            this.msc_Context.Panel2.Controls.Add(this.mLabel2);
            this.msc_Context.Panel2.Controls.Add(this.param_name);
            this.msc_Context.Panel2.Controls.Add(this.mLabel1);
            this.msc_Context.Size = new System.Drawing.Size(316, 190);
            // 
            // mLabel1
            // 
            this.mLabel1.Location = new System.Drawing.Point(12, 12);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.sColumnName = null;
            this.mLabel1.Size = new System.Drawing.Size(83, 23);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "param_name";
            this.mLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // param_name
            // 
            this.param_name.Location = new System.Drawing.Point(120, 12);
            this.param_name.Name = "param_name";
            this.param_name.sColumnName = null;
            this.param_name.Size = new System.Drawing.Size(184, 22);
            this.param_name.TabIndex = 1;
            this.param_name.Text = "content";
            // 
            // mLabel2
            // 
            this.mLabel2.Location = new System.Drawing.Point(12, 40);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(98, 23);
            this.mLabel2.TabIndex = 2;
            this.mLabel2.Text = "param_value";
            this.mLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // param_value
            // 
            this.param_value.AcceptsTab = true;
            this.param_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.param_value.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.param_value.HideSelection = false;
            this.param_value.Location = new System.Drawing.Point(15, 66);
            this.param_value.Name = "param_value";
            this.param_value.sColumnName = null;
            this.param_value.Size = new System.Drawing.Size(289, 59);
            this.param_value.TabIndex = 5;
            this.param_value.Text = "1231239374 chi tieu khong thanh cong do khong du han muc. Vui long goi 1900555587" +
    " de biet them chi tiet.";
            // 
            // f8SendAPI_SmsByTemplate_bodyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 218);
            this.Name = "f8SendAPI_SmsByTemplate_bodyDialog";
            this.Text = "Tham số API_SmsByTemplate";
            this.msc_Context.Panel2.ResumeLayout(false);
            this.msc_Context.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).EndInit();
            this.msc_Context.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MLabel mLabel1;
        private MComponent.MLabel mLabel2;
        private MComponent.MTextBox param_name;
        private MComponent.MRichTextBox param_value;
    }
}