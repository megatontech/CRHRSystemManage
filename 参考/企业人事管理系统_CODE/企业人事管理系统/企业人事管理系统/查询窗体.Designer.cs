namespace 企业人事管理系统
{
    partial class 查询窗体
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(查询窗体));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.取消按钮 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.确定按钮 = new System.Windows.Forms.Button();
            this.清空 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.或 = new System.Windows.Forms.RadioButton();
            this.和 = new System.Windows.Forms.RadioButton();
            this.添加按钮 = new System.Windows.Forms.Button();
            this.值 = new System.Windows.Forms.TextBox();
            this.条件 = new System.Windows.Forms.ComboBox();
            this.字段名 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.取消按钮);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.确定按钮);
            this.groupBox1.Controls.Add(this.清空);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.或);
            this.groupBox1.Controls.Add(this.和);
            this.groupBox1.Controls.Add(this.添加按钮);
            this.groupBox1.Controls.Add(this.值);
            this.groupBox1.Controls.Add(this.条件);
            this.groupBox1.Controls.Add(this.字段名);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 239);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // 取消按钮
            // 
            this.取消按钮.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.取消按钮.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.取消按钮.Location = new System.Drawing.Point(345, 209);
            this.取消按钮.Name = "取消按钮";
            this.取消按钮.Size = new System.Drawing.Size(61, 23);
            this.取消按钮.TabIndex = 3;
            this.取消按钮.Text = "取消";
            this.取消按钮.UseVisualStyleBackColor = true;
            this.取消按钮.Click += new System.EventHandler(this.取消按钮_Click);
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Location = new System.Drawing.Point(6, 91);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(400, 112);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // 确定按钮
            // 
            this.确定按钮.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.确定按钮.Location = new System.Drawing.Point(278, 209);
            this.确定按钮.Name = "确定按钮";
            this.确定按钮.Size = new System.Drawing.Size(61, 23);
            this.确定按钮.TabIndex = 3;
            this.确定按钮.Text = "确定";
            this.确定按钮.UseVisualStyleBackColor = true;
            this.确定按钮.Click += new System.EventHandler(this.确定按钮_Click);
            // 
            // 清空
            // 
            this.清空.Location = new System.Drawing.Point(6, 209);
            this.清空.Name = "清空";
            this.清空.Size = new System.Drawing.Size(61, 23);
            this.清空.TabIndex = 13;
            this.清空.Text = "清空";
            this.清空.UseVisualStyleBackColor = true;
            this.清空.Click += new System.EventHandler(this.清空_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "字段名";
            // 
            // 或
            // 
            this.或.AutoSize = true;
            this.或.Location = new System.Drawing.Point(53, 69);
            this.或.Name = "或";
            this.或.Size = new System.Drawing.Size(35, 16);
            this.或.TabIndex = 8;
            this.或.Text = "或";
            this.或.UseVisualStyleBackColor = true;
            // 
            // 和
            // 
            this.和.AutoSize = true;
            this.和.Checked = true;
            this.和.Location = new System.Drawing.Point(12, 69);
            this.和.Name = "和";
            this.和.Size = new System.Drawing.Size(35, 16);
            this.和.TabIndex = 8;
            this.和.TabStop = true;
            this.和.Text = "和";
            this.和.UseVisualStyleBackColor = true;
            // 
            // 添加按钮
            // 
            this.添加按钮.Location = new System.Drawing.Point(345, 41);
            this.添加按钮.Name = "添加按钮";
            this.添加按钮.Size = new System.Drawing.Size(61, 23);
            this.添加按钮.TabIndex = 6;
            this.添加按钮.Text = "添加";
            this.添加按钮.UseVisualStyleBackColor = true;
            this.添加按钮.Click += new System.EventHandler(this.添加按钮_Click);
            // 
            // 值
            // 
            this.值.Location = new System.Drawing.Point(227, 43);
            this.值.Name = "值";
            this.值.Size = new System.Drawing.Size(112, 21);
            this.值.TabIndex = 4;
            // 
            // 条件
            // 
            this.条件.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.条件.FormattingEnabled = true;
            this.条件.Items.AddRange(new object[] {
            "包含",
            "等于",
            "大于",
            "大于等于",
            "小于",
            "小于等于",
            "不等于"});
            this.条件.Location = new System.Drawing.Point(140, 43);
            this.条件.Name = "条件";
            this.条件.Size = new System.Drawing.Size(81, 20);
            this.条件.TabIndex = 3;
            // 
            // 字段名
            // 
            this.字段名.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.字段名.FormattingEnabled = true;
            this.字段名.Location = new System.Drawing.Point(6, 43);
            this.字段名.Name = "字段名";
            this.字段名.Size = new System.Drawing.Size(128, 20);
            this.字段名.TabIndex = 2;
            // 
            // 查询窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(419, 245);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "查询窗体";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询窗体";
            this.Load += new System.EventHandler(this.查询窗体_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox 值;
        private System.Windows.Forms.ComboBox 条件;
        private System.Windows.Forms.ComboBox 字段名;
        private System.Windows.Forms.Button 添加按钮;
        private System.Windows.Forms.Button 确定按钮;
        private System.Windows.Forms.Button 取消按钮;
        private System.Windows.Forms.RadioButton 或;
        private System.Windows.Forms.RadioButton 和;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button 清空;
        private System.Windows.Forms.ListView listView1;
    }
}