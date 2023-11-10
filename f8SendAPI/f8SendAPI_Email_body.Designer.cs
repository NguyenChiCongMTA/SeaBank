namespace SafeControl
{
    partial class f8SendAPI_Email_body
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f8SendAPI_Email_body));
            this.mTabControl1 = new SafeControl.MComponent.MTabControl(this.components);
            this.body = new System.Windows.Forms.TabPage();
            this.mllDel = new SafeControl.MComponent.MLinkLabel(this.components);
            this.mllAdd = new SafeControl.MComponent.MLinkLabel(this.components);
            this.file = new SafeControl.MComponent.MListView(this.components);
            this.file_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.file_byte64 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.utility_paramlist_bodym = new SafeControl.MComponent.MRichTextBox(this.components);
            this.command = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel7 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel11 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel6 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.utility_paramlist_from_add = new SafeControl.MComponent.MTextBox(this.components);
            this.utility_paramlist_mail_priority = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel5 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel3 = new SafeControl.MComponent.MLabel(this.components);
            this.utility_paramlist_to_add = new SafeControl.MComponent.MTextBox(this.components);
            this.utility_paramlist_is_html_body = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel4 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel8 = new SafeControl.MComponent.MLabel(this.components);
            this.utility_paramlist_subject = new SafeControl.MComponent.MTextBox(this.components);
            this.mTabControl1.SuspendLayout();
            this.body.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTabControl1
            // 
            this.mTabControl1.Controls.Add(this.body);
            this.mTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTabControl1.Location = new System.Drawing.Point(0, 0);
            this.mTabControl1.Name = "mTabControl1";
            this.mTabControl1.sColumnName = null;
            this.mTabControl1.SelectedIndex = 0;
            this.mTabControl1.Size = new System.Drawing.Size(300, 476);
            this.mTabControl1.TabIndex = 10;
            // 
            // body
            // 
            this.body.AutoScroll = true;
            this.body.Controls.Add(this.mllDel);
            this.body.Controls.Add(this.mllAdd);
            this.body.Controls.Add(this.file);
            this.body.Controls.Add(this.utility_paramlist_bodym);
            this.body.Controls.Add(this.command);
            this.body.Controls.Add(this.mLabel7);
            this.body.Controls.Add(this.mLabel11);
            this.body.Controls.Add(this.mLabel6);
            this.body.Controls.Add(this.mLabel2);
            this.body.Controls.Add(this.utility_paramlist_from_add);
            this.body.Controls.Add(this.utility_paramlist_mail_priority);
            this.body.Controls.Add(this.mLabel5);
            this.body.Controls.Add(this.mLabel3);
            this.body.Controls.Add(this.utility_paramlist_to_add);
            this.body.Controls.Add(this.utility_paramlist_is_html_body);
            this.body.Controls.Add(this.mLabel4);
            this.body.Controls.Add(this.mLabel8);
            this.body.Controls.Add(this.utility_paramlist_subject);
            this.body.Location = new System.Drawing.Point(4, 22);
            this.body.Name = "body";
            this.body.Padding = new System.Windows.Forms.Padding(3);
            this.body.Size = new System.Drawing.Size(292, 450);
            this.body.TabIndex = 1;
            this.body.Text = "body";
            this.body.UseVisualStyleBackColor = true;
            // 
            // mllDel
            // 
            this.mllDel.Location = new System.Drawing.Point(244, 166);
            this.mllDel.Name = "mllDel";
            this.mllDel.sColumnName = null;
            this.mllDel.Size = new System.Drawing.Size(29, 18);
            this.mllDel.TabIndex = 28;
            this.mllDel.TabStop = true;
            this.mllDel.Text = "del";
            this.mllDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mllAdd
            // 
            this.mllAdd.Location = new System.Drawing.Point(211, 166);
            this.mllAdd.Name = "mllAdd";
            this.mllAdd.sColumnName = null;
            this.mllAdd.Size = new System.Drawing.Size(29, 18);
            this.mllAdd.TabIndex = 27;
            this.mllAdd.TabStop = true;
            this.mllAdd.Text = "add";
            this.mllAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // file
            // 
            this.file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.file_name,
            this.file_byte64});
            this.file.FullRowSelect = true;
            this.file.GridLines = true;
            this.file.HideSelection = false;
            this.file.Location = new System.Drawing.Point(8, 187);
            this.file.Name = "file";
            this.file.sColumnName = null;
            this.file.Size = new System.Drawing.Size(264, 95);
            this.file.TabIndex = 26;
            this.file.TileSize = new System.Drawing.Size(188, 20);
            this.file.UseCompatibleStateImageBehavior = false;
            this.file.View = System.Windows.Forms.View.Details;
            // 
            // file_name
            // 
            this.file_name.Text = "file_name";
            this.file_name.Width = 80;
            // 
            // file_byte64
            // 
            this.file_byte64.Text = "file_byte64";
            this.file_byte64.Width = 179;
            // 
            // utility_paramlist_bodym
            // 
            this.utility_paramlist_bodym.AcceptsTab = true;
            this.utility_paramlist_bodym.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.utility_paramlist_bodym.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.utility_paramlist_bodym.HideSelection = false;
            this.utility_paramlist_bodym.Location = new System.Drawing.Point(8, 303);
            this.utility_paramlist_bodym.Name = "utility_paramlist_bodym";
            this.utility_paramlist_bodym.sColumnName = null;
            this.utility_paramlist_bodym.Size = new System.Drawing.Size(264, 142);
            this.utility_paramlist_bodym.TabIndex = 25;
            this.utility_paramlist_bodym.Text = resources.GetString("utility_paramlist_bodym.Text");
            // 
            // command
            // 
            this.command.Location = new System.Drawing.Point(85, 6);
            this.command.Name = "command";
            this.command.sColumnName = null;
            this.command.Size = new System.Drawing.Size(187, 22);
            this.command.TabIndex = 6;
            this.command.Text = "SendNormalMail";
            // 
            // mLabel7
            // 
            this.mLabel7.Location = new System.Drawing.Point(10, 9);
            this.mLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel7.Name = "mLabel7";
            this.mLabel7.sColumnName = null;
            this.mLabel7.Size = new System.Drawing.Size(70, 13);
            this.mLabel7.TabIndex = 4;
            this.mLabel7.Text = "command";
            this.mLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mLabel11
            // 
            this.mLabel11.Location = new System.Drawing.Point(10, 285);
            this.mLabel11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel11.Name = "mLabel11";
            this.mLabel11.sColumnName = null;
            this.mLabel11.Size = new System.Drawing.Size(70, 15);
            this.mLabel11.TabIndex = 23;
            this.mLabel11.Text = "bodym";
            this.mLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mLabel6
            // 
            this.mLabel6.Location = new System.Drawing.Point(10, 36);
            this.mLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel6.Name = "mLabel6";
            this.mLabel6.sColumnName = null;
            this.mLabel6.Size = new System.Drawing.Size(70, 13);
            this.mLabel6.TabIndex = 7;
            this.mLabel6.Text = "from_add";
            this.mLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mLabel2
            // 
            this.mLabel2.Location = new System.Drawing.Point(-7, 166);
            this.mLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(102, 20);
            this.mLabel2.TabIndex = 17;
            this.mLabel2.Text = "file_attachment";
            this.mLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // utility_paramlist_from_add
            // 
            this.utility_paramlist_from_add.Location = new System.Drawing.Point(85, 33);
            this.utility_paramlist_from_add.Name = "utility_paramlist_from_add";
            this.utility_paramlist_from_add.sColumnName = null;
            this.utility_paramlist_from_add.Size = new System.Drawing.Size(187, 22);
            this.utility_paramlist_from_add.TabIndex = 8;
            this.utility_paramlist_from_add.Text = "mailservice";
            // 
            // utility_paramlist_mail_priority
            // 
            this.utility_paramlist_mail_priority.Location = new System.Drawing.Point(85, 141);
            this.utility_paramlist_mail_priority.Name = "utility_paramlist_mail_priority";
            this.utility_paramlist_mail_priority.sColumnName = null;
            this.utility_paramlist_mail_priority.Size = new System.Drawing.Size(187, 22);
            this.utility_paramlist_mail_priority.TabIndex = 16;
            this.utility_paramlist_mail_priority.Text = "high";
            // 
            // mLabel5
            // 
            this.mLabel5.Location = new System.Drawing.Point(10, 63);
            this.mLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.sColumnName = null;
            this.mLabel5.Size = new System.Drawing.Size(70, 13);
            this.mLabel5.TabIndex = 9;
            this.mLabel5.Text = "to_add";
            this.mLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mLabel3
            // 
            this.mLabel3.Location = new System.Drawing.Point(10, 144);
            this.mLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.sColumnName = null;
            this.mLabel3.Size = new System.Drawing.Size(70, 13);
            this.mLabel3.TabIndex = 15;
            this.mLabel3.Text = "mail_priority";
            this.mLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // utility_paramlist_to_add
            // 
            this.utility_paramlist_to_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.utility_paramlist_to_add.Location = new System.Drawing.Point(85, 60);
            this.utility_paramlist_to_add.Name = "utility_paramlist_to_add";
            this.utility_paramlist_to_add.sColumnName = null;
            this.utility_paramlist_to_add.Size = new System.Drawing.Size(187, 22);
            this.utility_paramlist_to_add.TabIndex = 10;
            this.utility_paramlist_to_add.Text = "truong811@gmail.com";
            // 
            // utility_paramlist_is_html_body
            // 
            this.utility_paramlist_is_html_body.Location = new System.Drawing.Point(85, 114);
            this.utility_paramlist_is_html_body.Name = "utility_paramlist_is_html_body";
            this.utility_paramlist_is_html_body.sColumnName = null;
            this.utility_paramlist_is_html_body.Size = new System.Drawing.Size(187, 22);
            this.utility_paramlist_is_html_body.TabIndex = 14;
            this.utility_paramlist_is_html_body.Text = "true";
            // 
            // mLabel4
            // 
            this.mLabel4.Location = new System.Drawing.Point(10, 90);
            this.mLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.sColumnName = null;
            this.mLabel4.Size = new System.Drawing.Size(70, 13);
            this.mLabel4.TabIndex = 11;
            this.mLabel4.Text = "subject";
            this.mLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mLabel8
            // 
            this.mLabel8.Location = new System.Drawing.Point(5, 117);
            this.mLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel8.Name = "mLabel8";
            this.mLabel8.sColumnName = null;
            this.mLabel8.Size = new System.Drawing.Size(75, 13);
            this.mLabel8.TabIndex = 13;
            this.mLabel8.Text = "is_html_body";
            this.mLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // utility_paramlist_subject
            // 
            this.utility_paramlist_subject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.utility_paramlist_subject.Location = new System.Drawing.Point(85, 87);
            this.utility_paramlist_subject.Name = "utility_paramlist_subject";
            this.utility_paramlist_subject.sColumnName = null;
            this.utility_paramlist_subject.Size = new System.Drawing.Size(187, 22);
            this.utility_paramlist_subject.TabIndex = 12;
            this.utility_paramlist_subject.Text = "Test";
            // 
            // f8SendAPI_Email_body
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mTabControl1);
            this.Name = "f8SendAPI_Email_body";
            this.Size = new System.Drawing.Size(300, 476);
            this.mTabControl1.ResumeLayout(false);
            this.body.ResumeLayout(false);
            this.body.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MComponent.MTextBox utility_paramlist_subject;
        private MComponent.MLabel mLabel4;
        public MComponent.MTextBox utility_paramlist_to_add;
        private MComponent.MLabel mLabel5;
        public MComponent.MTextBox utility_paramlist_from_add;
        private MComponent.MLabel mLabel6;
        public MComponent.MTextBox command;
        private MComponent.MLabel mLabel7;
        private MComponent.MLabel mLabel11;
        private MComponent.MLabel mLabel2;
        public MComponent.MTextBox utility_paramlist_mail_priority;
        private MComponent.MLabel mLabel3;
        public MComponent.MTextBox utility_paramlist_is_html_body;
        private MComponent.MLabel mLabel8;
        private MComponent.MTabControl mTabControl1;
        private System.Windows.Forms.TabPage body;
        public MComponent.MRichTextBox utility_paramlist_bodym;
        public MComponent.MListView file;
        public System.Windows.Forms.ColumnHeader file_name;
        public System.Windows.Forms.ColumnHeader file_byte64;
        private MComponent.MLinkLabel mllAdd;
        private MComponent.MLinkLabel mllDel;

    }
}
