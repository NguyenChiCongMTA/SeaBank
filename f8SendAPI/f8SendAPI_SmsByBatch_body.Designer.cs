namespace SafeControl
{
    partial class f8SendAPI_SmsByBatch_body
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
            this.mTabControl1 = new SafeControl.MComponent.MTabControl(this.components);
            this.body = new System.Windows.Forms.TabPage();
            this.mllDel = new SafeControl.MComponent.MLinkLabel(this.components);
            this.mllAdd = new SafeControl.MComponent.MLinkLabel(this.components);
            this.utility_paramlist_batch = new SafeControl.MComponent.MListView(this.components);
            this.phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.infor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.command = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel7 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.channel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.mTabControl1.Size = new System.Drawing.Size(300, 384);
            this.mTabControl1.TabIndex = 10;
            // 
            // body
            // 
            this.body.AutoScroll = true;
            this.body.Controls.Add(this.mllDel);
            this.body.Controls.Add(this.mllAdd);
            this.body.Controls.Add(this.utility_paramlist_batch);
            this.body.Controls.Add(this.command);
            this.body.Controls.Add(this.mLabel7);
            this.body.Controls.Add(this.mLabel2);
            this.body.Location = new System.Drawing.Point(4, 22);
            this.body.Name = "body";
            this.body.Padding = new System.Windows.Forms.Padding(3);
            this.body.Size = new System.Drawing.Size(292, 358);
            this.body.TabIndex = 1;
            this.body.Text = "body";
            this.body.UseVisualStyleBackColor = true;
            // 
            // mllDel
            // 
            this.mllDel.Location = new System.Drawing.Point(249, 29);
            this.mllDel.Name = "mllDel";
            this.mllDel.sColumnName = null;
            this.mllDel.Size = new System.Drawing.Size(29, 18);
            this.mllDel.TabIndex = 31;
            this.mllDel.TabStop = true;
            this.mllDel.Text = "del";
            this.mllDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mllAdd
            // 
            this.mllAdd.Location = new System.Drawing.Point(216, 29);
            this.mllAdd.Name = "mllAdd";
            this.mllAdd.sColumnName = null;
            this.mllAdd.Size = new System.Drawing.Size(29, 18);
            this.mllAdd.TabIndex = 30;
            this.mllAdd.TabStop = true;
            this.mllAdd.Text = "add";
            this.mllAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utility_paramlist_batch
            // 
            this.utility_paramlist_batch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.utility_paramlist_batch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.phone,
            this.channel,
            this.infor});
            this.utility_paramlist_batch.FullRowSelect = true;
            this.utility_paramlist_batch.GridLines = true;
            this.utility_paramlist_batch.HideSelection = false;
            this.utility_paramlist_batch.Location = new System.Drawing.Point(8, 50);
            this.utility_paramlist_batch.Name = "utility_paramlist_batch";
            this.utility_paramlist_batch.sColumnName = null;
            this.utility_paramlist_batch.Size = new System.Drawing.Size(264, 302);
            this.utility_paramlist_batch.TabIndex = 29;
            this.utility_paramlist_batch.TileSize = new System.Drawing.Size(188, 20);
            this.utility_paramlist_batch.UseCompatibleStateImageBehavior = false;
            this.utility_paramlist_batch.View = System.Windows.Forms.View.Details;
            // 
            // phone
            // 
            this.phone.Text = "phone";
            this.phone.Width = 70;
            // 
            // infor
            // 
            this.infor.Text = "infor";
            this.infor.Width = 133;
            // 
            // command
            // 
            this.command.Location = new System.Drawing.Point(85, 6);
            this.command.Name = "command";
            this.command.sColumnName = null;
            this.command.Size = new System.Drawing.Size(187, 22);
            this.command.TabIndex = 6;
            this.command.Text = "SendSmsByTemplate";
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
            // mLabel2
            // 
            this.mLabel2.Location = new System.Drawing.Point(10, 34);
            this.mLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(70, 13);
            this.mLabel2.TabIndex = 17;
            this.mLabel2.Text = "batch";
            this.mLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // channel
            // 
            this.channel.Text = "channel";
            this.channel.Width = 55;
            // 
            // f8SendAPI_SmsByBatch_body
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mTabControl1);
            this.Name = "f8SendAPI_SmsByBatch_body";
            this.Size = new System.Drawing.Size(300, 384);
            this.mTabControl1.ResumeLayout(false);
            this.body.ResumeLayout(false);
            this.body.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MComponent.MTextBox command;
        private MComponent.MLabel mLabel7;
        private MComponent.MLabel mLabel2;
        private MComponent.MTabControl mTabControl1;
        private System.Windows.Forms.TabPage body;
        private MComponent.MLinkLabel mllDel;
        private MComponent.MLinkLabel mllAdd;
        public MComponent.MListView utility_paramlist_batch;
        public System.Windows.Forms.ColumnHeader phone;
        public System.Windows.Forms.ColumnHeader infor;
        private System.Windows.Forms.ColumnHeader channel;

    }
}
