using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyOffice.BLL;
using MyOffice.Models;
using System.Collections.Generic;
public partial class SysManage_RoleManage_RoleUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayRoleRightMenu();
        }
    }
    protected void DisplayRoleRightMenu() 
    {
        if (hidParentMenu.Value != "" && hidRoleId.Value!="")
        {
            //得到父节点的Id
            int nodeId = int.Parse(hidParentMenu.Value);
            //得到当前角色Id
            int roleId = int.Parse(hidRoleId.Value);
            ArrayList arrRoleChildMenu = new ArrayList();
            //得到系统菜单表中所有的第一级菜单
            IList<SysFun> sysFuns = SysFunManager.GetSysFunByParentNodeId(nodeId);
            //根据角色Id和父节点Id得到RoleRight表中已经存在的子菜单信息
            IList<RoleRight> roleChildRights = RoleRightManager.GetRoleRightByParentNodeIdAndRoleId(nodeId, roleId);
            foreach (RoleRight roleRight in roleChildRights)
            {
                arrRoleChildMenu.Add(roleRight.Node.NodeId.ToString());
            }

            //将子节点循环追加到CheckBoxLisr控件中
            foreach (SysFun sysFun in sysFuns)
            {
                ListItem li = new ListItem();
                li.Value = sysFun.NodeId.ToString();
                li.Text = sysFun.DisplayName;
                if (arrRoleChildMenu.Contains(li.Value))
                {
                    li.Selected = true;
                }
                chklstChildMenu.Items.Add(li);
            }
        }
        
        
    }
}
