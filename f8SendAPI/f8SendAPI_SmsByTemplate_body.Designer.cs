namespace SafeControl
{
    partial class f8SendAPI_SmsByTemplate_body
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
            this.utility_paramlist_body_param_param = new SafeControl.MComponent.MListView(this.components);
            this.param_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.param_value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.utility_paramlist_co_code = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel3 = new SafeControl.MComponent.MLabel(this.components);
            this.utility_paramlist_id_temp = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel1 = new SafeControl.MComponent.MLabel(this.components);
            this.command = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel7 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel2 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel5 = new SafeControl.MComponent.MLabel(this.components);
            this.utility_paramlist_user_id = new SafeControl.MComponent.MTextBox(this.components);
            this.utility_paramlist_service_id = new SafeControl.MComponent.MTextBox(this.components);
            this.mLabel4 = new SafeControl.MComponent.MLabel(this.components);
            this.mLabel8 = new SafeControl.MComponent.MLabel(this.components);
            this.utility_paramlist_channel = new SafeControl.MComponent.MTextBox(this.components);
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
            this.body.Controls.Add(this.utility_paramlist_body_param_param);
            this.body.Controls.Add(this.utility_paramlist_co_code);
            this.body.Controls.Add(this.mLabel3);
            this.body.Controls.Add(this.utility_paramlist_id_temp);
            this.body.Controls.Add(this.mLabel1);
            this.body.Controls.Add(this.command);
            this.body.Controls.Add(this.mLabel7);
            this.body.Controls.Add(this.mLabel2);
            this.body.Controls.Add(this.mLabel5);
            this.body.Controls.Add(this.utility_paramlist_user_id);
            this.body.Controls.Add(this.utility_paramlist_service_id);
            this.body.Controls.Add(this.mLabel4);
            this.body.Controls.Add(this.mLabel8);
            this.body.Controls.Add(this.utility_paramlist_channel);
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
            this.mllDel.Location = new System.Drawing.Point(249, 167);
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
            this.mllAdd.Location = new System.Drawing.Point(216, 167);
            this.mllAdd.Name = "mllAdd";
            this.mllAdd.sColumnName = null;
            this.mllAdd.Size = new System.Drawing.Size(29, 18);
            this.mllAdd.TabIndex = 30;
            this.mllAdd.TabStop = true;
            this.mllAdd.Text = "add";
            this.mllAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utility_paramlist_body_param_param
            // 
            this.utility_paramlist_body_param_param.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.utility_paramlist_body_param_param.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.param_name,
            this.param_value});
            this.utility_paramlist_body_param_param.FullRowSelect = true;
            this.utility_paramlist_body_param_param.GridLines = true;
            this.utility_paramlist_body_param_param.HideSelection = false;
            this.utility_paramlist_body_param_param.Location = new System.Drawing.Point(8, 188);
            this.utility_paramlist_body_param_param.Name = "utility_paramlist_body_param_param";
            this.utility_paramlist_body_param_param.sColumnName = null;
            this.utility_paramlist_body_param_param.Size = new System.Drawing.Size(264, 164);
            this.utility_paramlist_body_param_param.TabIndex = 29;
            this.utility_paramlist_body_param_param.TileSize = new System.Drawing.Size(188, 20);
            this.utility_paramlist_body_param_param.UseCompatibleStateImageBehavior = false;
            this.utility_paramlist_body_param_param.View = System.Windows.Forms.View.Details;
            // 
            // param_name
            // 
            this.param_name.Text = "param_name";
            this.param_name.Width = 116;
            // 
            // param_value
            // 
            this.param_value.Text = "param_value";
            this.param_value.Width = 141;
            // 
            // utility_paramlist_co_code
            // 
            this.utility_paramlist_co_code.Location = new System.Drawing.Point(85, 144);
            this.utility_paramlist_co_code.Name = "utility_paramlist_co_code";
            this.utility_paramlist_co_code.sColumnName = null;
            this.utility_paramlist_co_code.Size = new System.Drawing.Size(187, 22);
            this.utility_paramlist_co_code.TabIndex = 28;
            this.utility_paramlist_co_code.Text = "VN0010701";
            // 
            // mLabel3
            // 
            this.mLabel3.Location = new System.Drawing.Point(5, 147);
            this.mLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.sColumnName = null;
            this.mLabel3.Size = new System.Drawing.Size(75, 13);
            this.mLabel3.TabIndex = 27;
            this.mLabel3.Text = "co_code";
            this.mLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // utility_paramlist_id_temp
            // 
            this.utility_paramlist_id_temp.Location = new System.Drawing.Point(85, 90);
            this.utility_paramlist_id_temp.Name = "utility_paramlist_id_temp";
            this.utility_paramlist_id_temp.sColumnName = null;
            this.utility_paramlist_id_temp.Size = new System.Drawing.Size(187, 22);
            this.utility_paramlist_id_temp.TabIndex = 26;
            this.utility_paramlist_id_temp.Text = "smsBaoLoiThe";
            // 
            // mLabel1
            // 
            this.mLabel1.Location = new System.Drawing.Point(5, 93);
            this.mLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.sColumnName = null;
            this.mLabel1.Size = new System.Drawing.Size(75, 13);
            this.mLabel1.TabIndex = 25;
            this.mLabel1.Text = "id_temp";
            this.mLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.mLabel2.Location = new System.Drawing.Point(10, 172);
            this.mLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.sColumnName = null;
            this.mLabel2.Size = new System.Drawing.Size(70, 13);
            this.mLabel2.TabIndex = 17;
            this.mLabel2.Text = "param";
            this.mLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mLabel5
            // 
            this.mLabel5.Location = new System.Drawing.Point(10, 37);
            this.mLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.sColumnName = null;
            this.mLabel5.Size = new System.Drawing.Size(70, 13);
            this.mLabel5.TabIndex = 9;
            this.mLabel5.Text = "user_id";
            this.mLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // utility_paramlist_user_id
            // 
            this.utility_paramlist_user_id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.utility_paramlist_user_id.Location = new System.Drawing.Point(85, 34);
            this.utility_paramlist_user_id.Name = "utility_paramlist_user_id";
            this.utility_paramlist_user_id.sColumnName = null;
            this.utility_paramlist_user_id.Size = new System.Drawing.Size(187, 22);
            this.utility_paramlist_user_id.TabIndex = 10;
            this.utility_paramlist_user_id.Text = "0989932221";
            // 
            // utility_paramlist_service_id
            // 
            this.utility_paramlist_service_id.Location = new System.Drawing.Point(85, 62);
            this.utility_paramlist_service_id.Name = "utility_paramlist_service_id";
            this.utility_paramlist_service_id.sColumnName = null;
            this.utility_paramlist_service_id.Size = new System.Drawing.Size(187, 22);
            this.utility_paramlist_service_id.TabIndex = 14;
            this.utility_paramlist_service_id.Text = "SeABank";
            // 
            // mLabel4
            // 
            this.mLabel4.Location = new System.Drawing.Point(10, 119);
            this.mLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.sColumnName = null;
            this.mLabel4.Size = new System.Drawing.Size(70, 13);
            this.mLabel4.TabIndex = 11;
            this.mLabel4.Text = "channel";
            this.mLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mLabel8
            // 
            this.mLabel8.Location = new System.Drawing.Point(5, 65);
            this.mLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel8.Name = "mLabel8";
            this.mLabel8.sColumnName = null;
            this.mLabel8.Size = new System.Drawing.Size(75, 13);
            this.mLabel8.TabIndex = 13;
            this.mLabel8.Text = "service_id";
            this.mLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // utility_paramlist_channel
            // 
            this.utility_paramlist_channel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.utility_paramlist_channel.Location = new System.Drawing.Point(85, 116);
            this.utility_paramlist_channel.Name = "utility_paramlist_channel";
            this.utility_paramlist_channel.sColumnName = null;
            this.utility_paramlist_channel.Size = new System.Drawing.Size(187, 22);
            this.utility_paramlist_channel.TabIndex = 12;
            this.utility_paramlist_channel.Text = "SMS/FireBase/Zalo";
            // 
            // f8SendAPI_SmsByTemplate_body
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mTabControl1);
            this.Name = "f8SendAPI_SmsByTemplate_body";
            this.Size = new System.Drawing.Size(300, 384);
            this.mTabControl1.ResumeLayout(false);
            this.body.ResumeLayout(false);
            this.body.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MComponent.MTextBox utility_paramlist_channel;
        private MComponent.MLabel mLabel4;
        public MComponent.MTextBox utility_paramlist_user_id;
        private MComponent.MLabel mLabel5;
        public MComponent.MTextBox command;
        private MComponent.MLabel mLabel7;
        private MComponent.MLabel mLabel2;
        public MComponent.MTextBox utility_paramlist_service_id;
        private MComponent.MLabel mLabel8;
        private MComponent.MTabControl mTabControl1;
        private System.Windows.Forms.TabPage body;
        public MComponent.MTextBox utility_paramlist_co_code;
        private MComponent.MLabel mLabel3;
        public MComponent.MTextBox utility_paramlist_id_temp;
        private MComponent.MLabel mLabel1;
        private MComponent.MLinkLabel mllDel;
        private MComponent.MLinkLabel mllAdd;
        public MComponent.MListView utility_paramlist_body_param_param;
        public System.Windows.Forms.ColumnHeader param_name;
        public System.Windows.Forms.ColumnHeader param_value;

    }
}
