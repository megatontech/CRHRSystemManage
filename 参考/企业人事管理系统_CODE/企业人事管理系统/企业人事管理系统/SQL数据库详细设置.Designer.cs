namespace 企业人事管理系统
{
    partial class SQL数据库详细设置
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQL数据库详细设置));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Finish_Button = new System.Windows.Forms.Button();
            this.Canel_Button = new System.Windows.Forms.Button();
            this.Defaul_Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Bak_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.BuiltIn = false;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = ".\\skin\\skin.ssk";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::企业人事管理系统.Properties.Resources.数据库;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 98);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手动设置";
            // 
            // Finish_Button
            // 
            this.Finish_Button.BackColor = System.Drawing.SystemColors.Window;
            this.Finish_Button.Location = new System.Drawing.Point(148, 211);
            this.Finish_Button.Name = "Finish_Button";
            this.Finish_Button.Size = new System.Drawing.Size(73, 21);
            this.Finish_Button.TabIndex = 2;
            this.Finish_Button.Text = "完成";
            this.Finish_Button.UseVisualStyleBackColor = false;
            this.Finish_Button.Click += new System.EventHandler(this.Finish_Button_Click);
            // 
            // Canel_Button
            // 
            this.Canel_Button.BackColor = System.Drawing.SystemColors.Window;
            this.Canel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Canel_Button.Location = new System.Drawing.Point(227, 211);
            this.Canel_Button.Name = "Canel_Button";
            this.Canel_Button.Size = new System.Drawing.Size(73, 21);
            this.Canel_Button.TabIndex = 2;
            this.Canel_Button.Text = "取消";
            this.Canel_Button.UseVisualStyleBackColor = false;
            this.Canel_Button.Click += new System.EventHandler(this.Canel_Button_Click);
            // 
            // Defaul_Button
            // 
            this.Defaul_Button.BackColor = System.Drawing.SystemColors.Window;
            this.Defaul_Button.Location = new System.Drawing.Point(6, 211);
            this.Defaul_Button.Name = "Defaul_Button";
            this.Defaul_Button.Size = new System.Drawing.Size(90, 21);
            this.Defaul_Button.TabIndex = 2;
            this.Defaul_Button.Text = "恢复系统默认";
            this.Defaul_Button.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Bak_label);
            this.groupBox1.Location = new System.Drawing.Point(104, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 93);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统默认设置";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(67, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(116, 21);
            this.textBox3.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(67, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(116, 21);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(67, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "图片路径";
            // 
            // Bak_label
            // 
            this.Bak_label.AutoSize = true;
            this.Bak_label.Location = new System.Drawing.Point(8, 17);
            this.Bak_label.Name = "Bak_label";
            this.Bak_label.Size = new System.Drawing.Size(53, 12);
            this.Bak_label.TabIndex = 0;
            this.Bak_label.Text = "备份路径";
            // 
            // SQL数据库详细设置
            // 
            this.AcceptButton = this.Finish_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.Canel_Button;
            this.ClientSize = new System.Drawing.Size(307, 246);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Canel_Button);
            this.Controls.Add(this.Defaul_Button);
            this.Controls.Add(this.Finish_Button);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SQL数据库详细设置";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL数据库详细设置";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Finish_Button;
        private System.Windows.Forms.Button Canel_Button;
        private System.Windows.Forms.Button Defaul_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Bak_label;
    }
}