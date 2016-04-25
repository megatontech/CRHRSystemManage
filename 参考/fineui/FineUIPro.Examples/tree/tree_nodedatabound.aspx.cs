﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;

namespace FineUIPro.Examples.tree.databind
{
    public partial class tree_nodedatabound : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }


        private void LoadData()
        {

            Tree1.DataSource = XmlDataSource1;
            Tree1.DataBind();

        }

        protected void Tree1_NodeDataBound(object sender, TreeNodeEventArgs e)
        {
            XmlAttribute attr = e.XmlNode.Attributes["Highlight"];
            if(attr != null && Convert.ToBoolean(attr.Value)) {
                e.Node.Text = String.Format("<span class=\"highlight\">{0}</span>", e.Node.Text);
            }
            
        }


    }
}
