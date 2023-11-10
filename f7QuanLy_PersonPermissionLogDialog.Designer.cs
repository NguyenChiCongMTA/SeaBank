namespace SafeControl
{
    partial class f7QuanLy_PersonPermissionLogDialog
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
            this.mtb_sControlName = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.mtb_sNote = new SafeControl.MComponent.MRichTextBox(this.components);
            this.mtb_sPersonPermission = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel3 = new SafeControl.MComponent.MLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).BeginInit();
            this.msc_Context.Panel2.SuspendLayout();
            this.msc_Context.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpBottom
            // 
            this.mpBottom.Location = new System.Drawing.Point(0, 151);
            this.mpBottom.Size = new System.Drawing.Size(405, 28);
            // 
            // msc_Context
            // 
            // 
            // msc_Context.Panel2
            // 
            this.msc_Context.Panel2.Controls.Add(this.mtb_sPersonPermission);
            this.msc_Context.Panel2.Controls.Add(this.mLabel3);
            this.msc_Context.Panel2.Controls.Add(this.mtb_sNote);
            this.msc_Context.Panel2.Controls.Add(this.mLabel2);
            this.msc_Context.Panel2.Controls.Add(this.mtb_sControlName);
            this.msc_Context.Panel2.Controls.Add(this.mLabel1);
            this.msc_Context.Size = new System.Drawing.Size(405, 151);
            // 
            // mLabel1
            // 
            this.mLabel1.Location = new System.Drawing.Point(12, 12);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.sColumnName = null;
            this.mLabel1.Size = new System.Drawing.Size(83, 23);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "ControlName";
            this.mLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mtb_sControlName
            // 
            this.mtb_sControlName.Location = new System.Drawing.Point(115, 12);
            this.mtb_sControlName.Name = "mtb_sControlName";
            this.mtb_sControlName.sColumnName = null;
            this.mtb_sControlName.Size = new System.Drawing.Size(278, 22);
            this.mtb_sControlName.TabIndex = 1;
            // 
            // mLabel2
            // 
            this.mLabel2.Location = new System.Drawing.Point(12, 68);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(83, 23);
            this.mLabel2.TabIndex = 2;
            this.mLabel2.Text = "Note";
            this.mLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mtb_sNote
            // 
            this.mtb_sNote.AcceptsTab = true;
            this.mtb_sNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtb_sNote.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.mtb_sNote.HideSelection = false;
            this.mtb_sNote.Location = new System.Drawing.Point(115, 68);
            this.mtb_sNote.Name = "mtb_sNote";
            this.mtb_sNote.sColumnName = null;
            this.mtb_sNote.Size = new System.Drawing.Size(278, 22);
            this.mtb_sNote.TabIndex = 5;
            this.mtb_sNote.Text = "";
            // 
            // mtb_sPersonPermission
            // 
            this.mtb_sPersonPermission.Location = new System.Drawing.Point(115, 40);
            this.mtb_sPersonPermission.Name = "mtb_sPersonPermission";
            this.mtb_sPersonPermission.sColumnName = null;
            this.mtb_sPersonPermission.Size = new System.Drawing.Size(278, 22);
            this.mtb_sPersonPermission.TabIndex = 7;
            // 
            // mLabel3
            // 
            this.mLabel3.Location = new System.Drawing.Point(12, 40);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.sColumnName = null;
            this.mLabel3.Size = new System.Drawing.Size(113, 23);
            this.mLabel3.TabIndex = 6;
            this.mLabel3.Text = "PersonPermission";
            this.mLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // f7QuanLy_PersonPermissionLogDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 179);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "f7QuanLy_PersonPermissionLogDialog";
            this.Text = "PersonPermissionLog";
            this.msc_Context.Panel2.ResumeLayout(false);
            this.msc_Context.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msc_Context)).EndInit();
            this.msc_Context.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MComponent.MLabel mLabel1;
        private MComponent.MLabel mLabel2;
        private MComponent.MTextBox mtb_sControlName;
        private MComponent.MRichTextBox mtb_sNote;
        private MComponent.MTextBox mtb_sPersonPermission;
        private MComponent.MLabel mLabel3;
    }
}