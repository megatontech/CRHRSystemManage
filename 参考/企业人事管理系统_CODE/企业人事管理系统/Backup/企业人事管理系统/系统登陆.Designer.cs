namespace 企业人事管理系统
{
    partial class Form_Join
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Join));
            this.top_pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.user_name_comboBox = new System.Windows.Forms.ComboBox();
            this.password_label = new System.Windows.Forms.Label();
            this.user_name_label = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.Join_button = new System.Windows.Forms.Button();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.set_system_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.help_2_label = new System.Windows.Forms.Label();
            this.help_1_label = new System.Windows.Forms.Label();
            this.system_name_textBox = new System.Windows.Forms.TextBox();
            this.company_name_textBox = new System.Windows.Forms.TextBox();
            this.system_name_lable = new System.Windows.Forms.Label();
            this.company_name_label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.help_3_label = new System.Windows.Forms.Label();
            this.sqlserver_name_comboBox = new System.Windows.Forms.ComboBox();
            this.sql_password_label = new System.Windows.Forms.Label();
            this.sql_password_textBox = new System.Windows.Forms.TextBox();
            this.sql_user_textBox = new System.Windows.Forms.TextBox();
            this.sql_user_label = new System.Windows.Forms.Label();
            this.sqlserver_name_label = new System.Windows.Forms.Label();
            this.reord_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.检查更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.top_pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_pictureBox
            // 
            this.top_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.top_pictureBox.BackgroundImage = global::企业人事管理系统.Properties.Resources.LOGO;
            this.top_pictureBox.Location = new System.Drawing.Point(-2, 0);
            this.top_pictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.top_pictureBox.Name = "top_pictureBox";
            this.top_pictureBox.Size = new System.Drawing.Size(311, 46);
            this.top_pictureBox.TabIndex = 0;
            this.top_pictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkLabel);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.password_textBox);
            this.groupBox1.Controls.Add(this.user_name_comboBox);
            this.groupBox1.Controls.Add(this.password_label);
            this.groupBox1.Controls.Add(this.user_name_label);
            this.groupBox1.Location = new System.Drawing.Point(6, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 113);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(72, 88);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(65, 12);
            this.linkLabel.TabIndex = 11;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "购买注册码";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(72, 88);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(11, 12);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = " ";
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(74, 61);
            this.password_textBox.MaxLength = 12;
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(153, 21);
            this.password_textBox.TabIndex = 1;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // user_name_comboBox
            // 
            this.user_name_comboBox.FormattingEnabled = true;
            this.user_name_comboBox.Location = new System.Drawing.Point(74, 27);
            this.user_name_comboBox.MaxDropDownItems = 100;
            this.user_name_comboBox.Name = "user_name_comboBox";
            this.user_name_comboBox.Size = new System.Drawing.Size(153, 20);
            this.user_name_comboBox.TabIndex = 0;
            this.user_name_comboBox.DropDown += new System.EventHandler(this.user_name_comboBox_DropDown);
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(21, 64);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(29, 12);
            this.password_label.TabIndex = 10;
            this.password_label.Text = "密码";
            // 
            // user_name_label
            // 
            this.user_name_label.AutoSize = true;
            this.user_name_label.Location = new System.Drawing.Point(21, 30);
            this.user_name_label.Name = "user_name_label";
            this.user_name_label.Size = new System.Drawing.Size(29, 12);
            this.user_name_label.TabIndex = 10;
            this.user_name_label.Text = "用户";
            // 
            // cancel_button
            // 
            this.cancel_button.BackColor = System.Drawing.SystemColors.Window;
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(228, 163);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(73, 21);
            this.cancel_button.TabIndex = 5;
            this.cancel_button.Text = "取消";
            this.cancel_button.UseVisualStyleBackColor = false;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // Join_button
            // 
            this.Join_button.BackColor = System.Drawing.SystemColors.Window;
            this.Join_button.Location = new System.Drawing.Point(149, 163);
            this.Join_button.Name = "Join_button";
            this.Join_button.Size = new System.Drawing.Size(73, 21);
            this.Join_button.TabIndex = 4;
            this.Join_button.Text = "登陆";
            this.Join_button.UseVisualStyleBackColor = false;
            this.Join_button.Click += new System.EventHandler(this.Join_button_Click);
            // 
            // skinEngine1
            // 
            this.skinEngine1.BuiltIn = false;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = "";
            // 
            // set_system_button
            // 
            this.set_system_button.BackColor = System.Drawing.SystemColors.Window;
            this.set_system_button.Location = new System.Drawing.Point(6, 163);
            this.set_system_button.Name = "set_system_button";
            this.set_system_button.Size = new System.Drawing.Size(73, 21);
            this.set_system_button.TabIndex = 6;
            this.set_system_button.Text = "公司设置↓";
            this.set_system_button.UseVisualStyleBackColor = false;
            this.set_system_button.Click += new System.EventHandler(this.set_system_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.help_2_label);
            this.groupBox2.Controls.Add(this.help_1_label);
            this.groupBox2.Controls.Add(this.system_name_textBox);
            this.groupBox2.Controls.Add(this.company_name_textBox);
            this.groupBox2.Controls.Add(this.system_name_lable);
            this.groupBox2.Controls.Add(this.company_name_label);
            this.groupBox2.Location = new System.Drawing.Point(6, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 87);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本设置";
            // 
            // help_2_label
            // 
            this.help_2_label.AutoSize = true;
            this.help_2_label.ForeColor = System.Drawing.Color.Blue;
            this.help_2_label.Location = new System.Drawing.Point(188, 56);
            this.help_2_label.Name = "help_2_label";
            this.help_2_label.Size = new System.Drawing.Size(101, 12);
            this.help_2_label.TabIndex = 11;
            this.help_2_label.Text = "您期望的系统名称";
            // 
            // help_1_label
            // 
            this.help_1_label.AutoSize = true;
            this.help_1_label.ForeColor = System.Drawing.Color.Blue;
            this.help_1_label.Location = new System.Drawing.Point(187, 23);
            this.help_1_label.Name = "help_1_label";
            this.help_1_label.Size = new System.Drawing.Size(101, 12);
            this.help_1_label.TabIndex = 11;
            this.help_1_label.Text = "尽量保证精简易记";
            // 
            // system_name_textBox
            // 
            this.system_name_textBox.Enabled = false;
            this.system_name_textBox.Location = new System.Drawing.Point(74, 53);
            this.system_name_textBox.Name = "system_name_textBox";
            this.system_name_textBox.Size = new System.Drawing.Size(101, 21);
            this.system_name_textBox.TabIndex = 9;
            // 
            // company_name_textBox
            // 
            this.company_name_textBox.Enabled = false;
            this.company_name_textBox.Location = new System.Drawing.Point(74, 20);
            this.company_name_textBox.Name = "company_name_textBox";
            this.company_name_textBox.Size = new System.Drawing.Size(101, 21);
            this.company_name_textBox.TabIndex = 7;
            // 
            // system_name_lable
            // 
            this.system_name_lable.AutoSize = true;
            this.system_name_lable.Location = new System.Drawing.Point(6, 56);
            this.system_name_lable.Name = "system_name_lable";
            this.system_name_lable.Size = new System.Drawing.Size(53, 12);
            this.system_name_lable.TabIndex = 0;
            this.system_name_lable.Text = "系统名称";
            // 
            // company_name_label
            // 
            this.company_name_label.AutoSize = true;
            this.company_name_label.Location = new System.Drawing.Point(6, 23);
            this.company_name_label.Name = "company_name_label";
            this.company_name_label.Size = new System.Drawing.Size(53, 12);
            this.company_name_label.TabIndex = 0;
            this.company_name_label.Text = "公司名称";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.help_3_label);
            this.groupBox3.Controls.Add(this.sqlserver_name_comboBox);
            this.groupBox3.Controls.Add(this.sql_password_label);
            this.groupBox3.Controls.Add(this.sql_password_textBox);
            this.groupBox3.Controls.Add(this.sql_user_textBox);
            this.groupBox3.Controls.Add(this.sql_user_label);
            this.groupBox3.Controls.Add(this.sqlserver_name_label);
            this.groupBox3.Location = new System.Drawing.Point(6, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(295, 84);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据库设置";
            // 
            // help_3_label
            // 
            this.help_3_label.AutoSize = true;
            this.help_3_label.ForeColor = System.Drawing.Color.Blue;
            this.help_3_label.Location = new System.Drawing.Point(187, 21);
            this.help_3_label.Name = "help_3_label";
            this.help_3_label.Size = new System.Drawing.Size(107, 12);
            this.help_3_label.TabIndex = 11;
            this.help_3_label.Text = "SQL服务器名称或IP";
            // 
            // sqlserver_name_comboBox
            // 
            this.sqlserver_name_comboBox.Enabled = false;
            this.sqlserver_name_comboBox.FormattingEnabled = true;
            this.sqlserver_name_comboBox.Location = new System.Drawing.Point(74, 16);
            this.sqlserver_name_comboBox.Name = "sqlserver_name_comboBox";
            this.sqlserver_name_comboBox.Size = new System.Drawing.Size(101, 20);
            this.sqlserver_name_comboBox.TabIndex = 11;
            this.sqlserver_name_comboBox.DropDown += new System.EventHandler(this.sqlserver_name_comboBox_DropDown);
            // 
            // sql_password_label
            // 
            this.sql_password_label.AutoSize = true;
            this.sql_password_label.Location = new System.Drawing.Point(160, 52);
            this.sql_password_label.Name = "sql_password_label";
            this.sql_password_label.Size = new System.Drawing.Size(29, 12);
            this.sql_password_label.TabIndex = 5;
            this.sql_password_label.Text = "密码";
            // 
            // sql_password_textBox
            // 
            this.sql_password_textBox.Enabled = false;
            this.sql_password_textBox.Location = new System.Drawing.Point(216, 49);
            this.sql_password_textBox.Name = "sql_password_textBox";
            this.sql_password_textBox.PasswordChar = '*';
            this.sql_password_textBox.Size = new System.Drawing.Size(72, 21);
            this.sql_password_textBox.TabIndex = 14;
            this.sql_password_textBox.UseSystemPasswordChar = true;
            // 
            // sql_user_textBox
            // 
            this.sql_user_textBox.Enabled = false;
            this.sql_user_textBox.Location = new System.Drawing.Point(74, 49);
            this.sql_user_textBox.Name = "sql_user_textBox";
            this.sql_user_textBox.Size = new System.Drawing.Size(72, 21);
            this.sql_user_textBox.TabIndex = 13;
            // 
            // sql_user_label
            // 
            this.sql_user_label.AutoSize = true;
            this.sql_user_label.Location = new System.Drawing.Point(6, 52);
            this.sql_user_label.Name = "sql_user_label";
            this.sql_user_label.Size = new System.Drawing.Size(41, 12);
            this.sql_user_label.TabIndex = 3;
            this.sql_user_label.Text = "用户名";
            // 
            // sqlserver_name_label
            // 
            this.sqlserver_name_label.AutoSize = true;
            this.sqlserver_name_label.Location = new System.Drawing.Point(6, 24);
            this.sqlserver_name_label.Name = "sqlserver_name_label";
            this.sqlserver_name_label.Size = new System.Drawing.Size(41, 12);
            this.sqlserver_name_label.TabIndex = 0;
            this.sqlserver_name_label.Text = "服务器";
            // 
            // reord_button
            // 
            this.reord_button.BackColor = System.Drawing.SystemColors.Window;
            this.reord_button.Location = new System.Drawing.Point(149, 381);
            this.reord_button.Name = "reord_button";
            this.reord_button.Size = new System.Drawing.Size(73, 21);
            this.reord_button.TabIndex = 15;
            this.reord_button.Text = "保存";
            this.reord_button.UseVisualStyleBackColor = false;
            this.reord_button.Click += new System.EventHandler(this.reord_button_Click);
            // 
            // update_button
            // 
            this.update_button.BackColor = System.Drawing.SystemColors.Window;
            this.update_button.Location = new System.Drawing.Point(228, 381);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(73, 21);
            this.update_button.TabIndex = 16;
            this.update_button.Text = "重新设置";
            this.update_button.UseVisualStyleBackColor = false;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "嘉源人事管理V1.1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.检查更新ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出系统ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 54);
            // 
            // 检查更新ToolStripMenuItem
            // 
            this.检查更新ToolStripMenuItem.Name = "检查更新ToolStripMenuItem";
            this.检查更新ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.检查更新ToolStripMenuItem.Text = "检查更新";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 384);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 16);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Windows验证模式";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form_Join
            // 
            this.AcceptButton = this.Join_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(307, 194);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Join_button);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.reord_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.set_system_button);
            this.Controls.Add(this.top_pictureBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Join";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登陆";
            this.Load += new System.EventHandler(this.Form_Join_Load);
            ((System.ComponentModel.ISupportInitialize)(this.top_pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox top_pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button Join_button;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label user_name_label;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Button set_system_button;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox system_name_textBox;
        private System.Windows.Forms.TextBox company_name_textBox;
        private System.Windows.Forms.Label system_name_lable;
        private System.Windows.Forms.Label company_name_label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label sql_password_label;
        private System.Windows.Forms.TextBox sql_password_textBox;
        private System.Windows.Forms.TextBox sql_user_textBox;
        private System.Windows.Forms.Label sql_user_label;
        private System.Windows.Forms.Label sqlserver_name_label;
        private System.Windows.Forms.ComboBox sqlserver_name_comboBox;
        private System.Windows.Forms.Button reord_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Label help_2_label;
        private System.Windows.Forms.Label help_1_label;
        private System.Windows.Forms.Label help_3_label;
        private System.Windows.Forms.LinkLabel linkLabel;
        public System.Windows.Forms.ComboBox user_name_comboBox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查更新ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

