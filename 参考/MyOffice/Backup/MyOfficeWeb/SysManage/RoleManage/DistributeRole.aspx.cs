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

public partial class SysManage_RoleManage_DistributeRole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int roleId = int.Parse(Request.QueryString["RoleId"]);//得到指定的角色Id
        if (!IsPostBack) 
        {
            if (Request.QueryString["RoleId"] != null) 
            {
                
                RoleInfo roleInfo = RoleInfoManager.GetRoleInfoById(roleId);//根据角色Id得到角色信息
                this.lblCurrentRole.Text = roleInfo.RoleName;//显示角色名称
                
            }
        }
        DisplayRoleRightInfo(roleId);
    }

    protected void DisplayRoleRightInfo(int roleId) 
    {
        //得到所有父节点信息
        IList<SysFun> sysFuns = SysFunManager.GetAllParentNodeInfo();
        foreach (SysFun sysFun in sysFuns)
        {
            //得到父节点的Id
            string nodeId = sysFun.NodeId.ToString();
            //得到父节点名称
            string displayName = sysFun.DisplayName;

            //实例化用户控件
            //SysManage_RoleManage_RoleUserControl role = new SysManage_RoleManage_RoleUserControl();

            SysManage_RoleManage_RoleUserControl roleControl = (SysManage_RoleManage_RoleUserControl)LoadControl(@"~/SysManage/RoleManage/RoleUserControl.ascx");

            //实例化隐藏域，用以存储父节点Id
            HtmlInputControl hidParentMenu = (HtmlInputControl)roleControl.FindControl("hidParentMenu");
            hidParentMenu.Value = nodeId;

            //实例化隐藏域，用以存储角色Id
            HtmlInputControl hidRoleId = (HtmlInputControl)roleControl.FindControl("hidRoleId");
            hidRoleId.Value = roleId.ToString();

            //实例化用户控件的CheckBox
            CheckBox chkParentMenu = (CheckBox)roleControl.FindControl("chkParentMenu");
            chkParentMenu.Text = displayName;//显示父菜单名称

            //把父节点生成的用户控件 追加到PlaceHolder容器中
            phRoleDistribute.Controls.Add(roleControl);
            
            int count = phRoleDistribute.Controls.Count;
            IList<RoleRight> roleChildRights = RoleRightManager.GetRoleRightByParentNodeIdAndRoleId(int.Parse(nodeId), roleId);
            if (roleChildRights.Count > 0) 
            {
                chkParentMenu.Checked = true;
            }
        }
    }
    //保存分配权限
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        
        int roleId = int.Parse(Request.QueryString["RoleId"]);//得到指定的角色Id
        // 根据角色Id从RoleRight得到所有节点信息
        IList<RoleRight> currentRoleRights = RoleRightManager.GetRoleRightByRoleId(roleId);
        ArrayList arrRoleNodes = new ArrayList();
        //循环将节点添加到ArrayList中
        foreach (RoleRight roleRight in currentRoleRights)
        {
            arrRoleNodes.Add(roleRight.Node.NodeId.ToString());
        }
        //循环每一个用户控件
        int count = phRoleDistribute.Controls.Count;
        foreach (Control ct in phRoleDistribute.Controls) 
        {
            //实例化CheckBox
            CheckBox chk = (CheckBox)ct.FindControl("chkParentMenu");
             HtmlInputControl hidParentMenu = (HtmlInputControl)ct.FindControl("hidParentMenu");
        //假如数据中不存在我们选中的节点，则添加该节点记录
             if (chk.Checked)
             {
                 if (!arrRoleNodes.Contains(hidParentMenu.Value))
                 {
                     bool b = RoleRightManager.AddRoleRight(roleId, int.Parse(hidParentMenu.Value));
                 }
             }
             //假如我们没选中的节点在数据中存在，则从数据库中删除
             else 
             {
                 if (arrRoleNodes.Contains(hidParentMenu.Value))
                 {
                     bool b = RoleRightManager.DeleteRoleRightByRoleIdAndNodeId(roleId, int.Parse(hidParentMenu.Value));
                 }
             }
             /**
              * 以上实现了保存父节点
              * /
          /**
          * 以下实现了保存子节点
          * 
          * **/
             CheckBoxList chklst = (CheckBoxList)ct.FindControl("chklstChildMenu");
             foreach (ListItem li in chklst.Items) 
             {
                 if (li.Selected) 
                 {
                     if (!arrRoleNodes.Contains(li.Value))
                     {
                         bool b = RoleRightManager.AddRoleRight(roleId, int.Parse(li.Value));
                     }
                 }
                 else
                 {
                     if (arrRoleNodes.Contains(li.Value))
                     {
                         bool b = RoleRightManager.DeleteRoleRightByRoleIdAndNodeId(roleId, int.Parse(li.Value));
                     }
                 }
             }

        }
        //Response.Write("<script>alert('权限已生效！！');self.document.location.href='RoleManage.aspx'</script>");
       
    }
    protected void btnRet_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("~/SysManage/RoleManage/RoleManage.aspx");
    }
}
