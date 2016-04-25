using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 系统背景 : Form
    {
        public 系统背景()
        {
            InitializeComponent();
        }

        private void 系统背景_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

    }
}