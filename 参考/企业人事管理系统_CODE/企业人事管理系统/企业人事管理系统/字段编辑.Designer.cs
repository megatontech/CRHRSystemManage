namespace 企业人事管理系统
{
    partial class 字段编辑
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(字段编辑));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Small_Num = new System.Windows.Forms.NumericUpDown();
            this.Data_Length = new System.Windows.Forms.NumericUpDown();
            this.Data_Type = new System.Windows.Forms.ComboBox();
            this.Data_Dealful_Value = new System.Windows.Forms.TextBox();
            this.Data_List = new System.Windows.Forms.TextBox();
            this.Data_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Small_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Length)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "字段名:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Small_Num);
            this.groupBox1.Controls.Add(this.Data_Length);
            this.groupBox1.Controls.Add(this.Data_Type);
            this.groupBox1.Controls.Add(this.Data_Dealful_Value);
            this.groupBox1.Controls.Add(this.Data_List);
            this.groupBox1.Controls.Add(this.Data_Name);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 193);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "字段值列表[逗号分隔]:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "默认值:";
            // 
            // Small_Num
            // 
            this.Small_Num.Enabled = false;
            this.Small_Num.Location = new System.Drawing.Point(196, 87);
            this.Small_Num.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Small_Num.Name = "Small_Num";
            this.Small_Num.Size = new System.Drawing.Size(51, 21);
            this.Small_Num.TabIndex = 4;
            this.Small_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Small_Num.ValueChanged += new System.EventHandler(this.Small_Num_ValueChanged);
            // 
            // Data_Length
            // 
            this.Data_Length.Location = new System.Drawing.Point(86, 87);
            this.Data_Length.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Data_Length.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Data_Length.Name = "Data_Length";
            this.Data_Length.Size = new System.Drawing.Size(51, 21);
            this.Data_Length.TabIndex = 4;
            this.Data_Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Data_Length.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // Data_Type
            // 
            this.Data_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Data_Type.FormattingEnabled = true;
            this.Data_Type.Items.AddRange(new object[] {
            "字符",
            "数字",
            "日期"});
            this.Data_Type.Location = new System.Drawing.Point(86, 61);
            this.Data_Type.Name = "Data_Type";
            this.Data_Type.Size = new System.Drawing.Size(83, 20);
            this.Data_Type.TabIndex = 2;
            this.Data_Type.SelectionChangeCommitted += new System.EventHandler(this.Data_Type_SelectionChangeCommitted);
            // 
            // Data_Dealful_Value
            // 
            this.Data_Dealful_Value.Location = new System.Drawing.Point(86, 114);
            this.Data_Dealful_Value.Name = "Data_Dealful_Value";
            this.Data_Dealful_Value.Size = new System.Drawing.Size(161, 21);
            this.Data_Dealful_Value.TabIndex = 1;
            this.Data_Dealful_Value.TextChanged += new System.EventHandler(this.Data_Dealful_Value_TextChanged);
            // 
            // Data_List
            // 
            this.Data_List.Location = new System.Drawing.Point(23, 158);
            this.Data_List.Name = "Data_List";
            this.Data_List.Size = new System.Drawing.Size(224, 21);
            this.Data_List.TabIndex = 1;
            // 
            // Data_Name
            // 
            this.Data_Name.Location = new System.Drawing.Point(86, 34);
            this.Data_Name.Name = "Data_Name";
            this.Data_Name.Size = new System.Drawing.Size(161, 21);
            this.Data_Name.TabIndex = 1;
            this.Data_Name.TextChanged += new System.EventHandler(this.Data_Name_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "小数位:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "字段长度:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "字段类型:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(181, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(175, 64);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "允许为空";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // 字段编辑
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(275, 236);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "字段编辑";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字段编辑";
            this.Load += new System.EventHandler(this.字段编辑_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Small_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Length)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Data_Name;
        private System.Windows.Forms.ComboBox Data_Type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Data_Length;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Data_Dealful_Value;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Data_List;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown Small_Num;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}