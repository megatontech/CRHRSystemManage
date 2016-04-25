using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace FineOA.Web.admin
{
    public partial class TUser_Edit : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreUserEdit";
            }
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            int id = GetQueryIntValue("id");
            BLL.t_User bll = new BLL.t_User();
            Model.t_User user = bll.GetModel(id);

            if (user == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            if (user.FUserName == "admin" && GetIdentityName() != "admin")
            {
                Alert.Show("你无权编辑超级管理员！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            labName.Text = user.FUserName;
            tbxRealName.Text = user.FChineseName;
            tbxCompanyEmail.Text = user.FCompanyEmail;
            tbxEmail.Text = user.FEmail;
            tbxCellPhone.Text = user.FCellPhone;
            tbxOfficePhone.Text = user.FOfficePhone;
            tbxOfficePhoneExt.Text = user.FOfficePhoneExt;
            tbxHomePhone.Text = user.FHomePhone;
            tbxRemark.Text = user.FDescription;
            cbxEnabled.Checked = user.FEnabled;
            ddlGender.SelectedValue = user.FGender;

            // 初始化用户所属角色
            InitUserRole(user);

            //// 初始化用户所属部门
            //InitUserDept(current);

            //// 初始化用户所属职称
            //InitUserTitle(current);
        }

        #region InitUserRole

        private void InitUserDept(Model.t_User current)
        {
            //if (current.FDepartmentId != null)
            //{
            //    tbSelectedDept.Text = current.Dept.FName;
            //    hfSelectedDept.Text = current.Dept.FItemId.ToString();
            //}

            //// 打开编辑窗口
            //string selectDeptURL = String.Format("./user_select_dept.aspx?ids=<script>{0}</script>", hfSelectedDept.GetValueReference());
            //tbSelectedDept.OnClientTriggerClick = Window1.GetSaveStateReference(hfSelectedDept.ClientID, tbSelectedDept.ClientID)
            //        + Window1.GetShowReference(selectDeptURL, "选择用户所属的部门");
        }

        #endregion

        #region InitUserRole

        private void InitUserRole(Model.t_User current)
        {
            //BLL.t_RoleUser bll = new BLL.t_RoleUser();

            //tbSelectedRole.Text = String.Join(",", bll.GetModelList("").);
            //hfSelectedRole.Text = String.Join(",", current.Roles.Select(u => u.FItemId).ToArray());

            //// 打开编辑角色的窗口
            //string selectRoleURL = String.Format("./user_select_role.aspx?ids=<script>{0}</script>", hfSelectedRole.GetValueReference());
            //tbSelectedRole.OnClientTriggerClick = Window1.GetSaveStateReference(hfSelectedRole.ClientID, tbSelectedRole.ClientID)
            //        + Window1.GetShowReference(selectRoleURL, "选择用户所属的角色");
        }
        #endregion

        #region InitUserTitle

        private void InitUserTitle(Model.t_User current)
        {
            //tbSelectedTitle.Text = String.Join(",", current.Titles.Select(u => u.FName).ToArray()); ;
            //hfSelectedTitle.Text = String.Join(",", current.Titles.Select(u => u.FItemId).ToArray()); ;

            //// 打开编辑角色的窗口
            //string selectTitleURL = String.Format("./user_select_title.aspx?ids=<script>{0}</script>", hfSelectedTitle.GetValueReference());
            //tbSelectedTitle.OnClientTriggerClick = Window1.GetSaveStateReference(hfSelectedTitle.ClientID, tbSelectedTitle.ClientID)
            //        + Window1.GetShowReference(selectTitleURL, "选择用户拥有的职称");

        }
        #endregion


        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            //t_User item = DB.Users
            //    .Include(u => u.Dept)
            //    .Include(u => u.Roles)
            //    .Include(u => u.Titles)
            //    .Where(u => u.FItemId == id).FirstOrDefault();
            ////item.Name = tbxName.Text.Trim();
            //item.FChineseName = tbxRealName.Text.Trim();
            //item.FGender = ddlGender.SelectedValue;
            //item.FCompanyEmail = tbxCompanyEmail.Text.Trim();
            //item.FEmail = tbxEmail.Text.Trim();
            //item.FCellPhone = tbxCellPhone.Text.Trim();
            //item.FOfficePhone = tbxOfficePhone.Text.Trim();
            //item.FOfficePhoneExt = tbxOfficePhoneExt.Text.Trim();
            //item.FHomePhone = tbxHomePhone.Text.Trim();
            //item.FDescription = tbxRemark.Text.Trim();
            //item.FEnabled = cbxEnabled.Checked;


            //if (String.IsNullOrEmpty(hfSelectedDept.Text))
            //{
            //    item.Dept = null;
            //}
            //else
            //{
            //    int newDeptID = Convert.ToInt32(hfSelectedDept.Text);

            //    t_Department dept = Attach<t_Department>(newDeptID);
            //    item.Dept = dept;

            //}


            //int[] roleIDs = StringUtil.GetIntArrayFromString(hfSelectedRole.Text);
            //ReplaceEntities<t_Role>(item.Roles, roleIDs);

            //int[] titleIDs = StringUtil.GetIntArrayFromString(hfSelectedTitle.Text);
            //ReplaceEntities<t_Title>(item.Titles, titleIDs);

            //DB.SaveChanges();

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion
    }
}