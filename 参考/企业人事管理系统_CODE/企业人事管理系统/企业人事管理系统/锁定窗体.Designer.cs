namespace 企业人事管理系统
{
    partial class 锁定窗体
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(锁定窗体));
            this.label3 = new System.Windows.Forms.Label();
            this.Join_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.top_pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.user_name = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Password = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.user_name_label = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.top_pictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(233, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 8;
            // 
            // Join_button
            // 
            this.Join_button.BackColor = System.Drawing.SystemColors.Window;
            this.Join_button.Location = new System.Drawing.Point(151, 167);
            this.Join_button.Name = "Join_button";
            this.Join_button.Size = new System.Drawing.Size(73, 21);
            this.Join_button.TabIndex = 12;
            this.Join_button.Text = "登陆";
            this.Join_button.UseVisualStyleBackColor = false;
            this.Join_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.BackColor = System.Drawing.SystemColors.Window;
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(230, 167);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(73, 21);
            this.cancel_button.TabIndex = 13;
            this.cancel_button.Text = "退出系统";
            this.cancel_button.UseVisualStyleBackColor = false;
            this.cancel_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // top_pictureBox
            // 
            this.top_pictureBox.BackgroundImage = global::企业人事管理系统.Properties.Resources.LOGO;
            this.top_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.top_pictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.top_pictureBox.Name = "top_pictureBox";
            this.top_pictureBox.Size = new System.Drawing.Size(323, 46);
            this.top_pictureBox.TabIndex = 11;
            this.top_pictureBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.user_name);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.Password);
            this.groupBox2.Controls.Add(this.password_label);
            this.groupBox2.Controls.Add(this.user_name_label);
            this.groupBox2.Location = new System.Drawing.Point(8, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 116);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // user_name
            // 
            this.user_name.Location = new System.Drawing.Point(74, 27);
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            this.user_name.Size = new System.Drawing.Size(153, 21);
            this.user_name.TabIndex = 12;
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
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(74, 61);
            this.Password.MaxLength = 12;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(153, 21);
            this.Password.TabIndex = 1;
            this.Password.UseSystemPasswordChar = true;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
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
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.DarkMagenta;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.DisabledLinkColor = System.Drawing.Color.DarkMagenta;
            this.linkLabel2.ForeColor = System.Drawing.Color.DarkMagenta;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.DarkMagenta;
            this.linkLabel2.Location = new System.Drawing.Point(41, 92);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(227, 12);
            this.linkLabel2.TabIndex = 13;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "系统已锁定,离开前建议您保存当前的工作";
            // 
            // 锁定窗体
            // 
            this.AcceptButton = this.Join_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(320, 194);
            this.Controls.Add(this.Join_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.top_pictureBox);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "锁定窗体";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "锁定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.锁定窗体_FormClosing);
            this.Load += new System.EventHandler(this.锁定窗体_Load);
            ((System.ComponentModel.ISupportInitialize)(this.top_pictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Join_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.PictureBox top_pictureBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox user_name;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label user_name_label;
        private System.Windows.Forms.LinkLabel linkLabel2;

    }
}