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
public partial class PersonManage_UserInfoManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["UserId"] = "";
            ViewState["Password"] = "";
            LoadBranch();         
            LoadRole();
            LoadUserState();
            Inite();
        }
    }
    public int UserId
    {
        get { return Convert.ToInt32(ViewState["UserId"]); }
        set { ViewState["UserId"] = value; }
    }
    public string Password
    {
        get { return Convert.ToString(ViewState["Password"]); }
        set { ViewState["Password"] = value; }
    }
    /// <summary>
    /// 初始化机构下拉菜单
    /// </summary>
    protected void LoadBranch()
    {
        IList<BranchInfo> branchs = BranchInfoManger.GetBranchInfo();
        ddlBranchs.Items.Clear();
        ddlBranchs.Items.Add(new ListItem("==请选择==", "0"));
        foreach (BranchInfo branch in branchs)
        {
            ListItem li = new ListItem();
            li.Value = branch.Id.ToString();
            li.Text = branch.BranchName;
            ddlBranchs.Items.Add(li);
        }
    }
    /// <summary>
    /// 初始化部门下拉菜单
    /// </summary>
    /// <param name="branchId"></param>
    protected void LoadDepart(int branchId)
    {
        IList<DepartInfo> departs = DepartInfoManager.GetDepartInfoByBranchId(branchId);
        ddlDepart.Items.Clear();
        ddlDepart.Items.Add(new ListItem("==请选择==", "0"));
        foreach (DepartInfo depart in departs)
        {
            ListItem li = new ListItem();
            li.Value = depart.Id.ToString();
            li.Text = depart.DepartName;
            ddlDepart.Items.Add(li);
        }

    }
    /// <summary>
    /// 初始化焦色下拉菜单
    /// </summary>
    protected void LoadRole()
    {
        IList<RoleInfo> roles = RoleInfoManager.GetRoleInfoAll();
        ddlRole.Items.Clear();
       
        foreach (RoleInfo role in roles)
        {
            ListItem li = new ListItem();
            li.Value = role.Id.ToString();
            li.Text = role.RoleName;
            ddlRole.Items.Add(li);
        }

    }
    protected void LoadUserState()
    {
        IList<UserState> states = UserStateManager.GetAllUserState();
        ddlState.Items.Clear();      
        foreach (UserState state in states)
        {
            ListItem li = new ListItem();
            li.Value = state.Id.ToString();
            li.Text = state.UserStateName;
            ddlState.Items.Add(li);
        }
        this.ddlState.SelectedValue = "2";
    }

    public void Inite() 
    {
        if (Request.QueryString["uid"] != null)
        {
            int uid = int.Parse(Request.QueryString["uid"]);
            ViewState["UserId"] = Request.QueryString["uid"];
            UserInfo user = UserInfoManager.GetUserInfoById(uid);
            this.txtLoginId.Text = user.LoginId.ToString();
            ViewState["Password"] = user.Password;
            for (int i = 0; i < user.Password.Length; i++)
            {
                this.txtPassword.Text += "*";
                this.txtPasswordOk.Text += "*";
            }
            this.txtPassword.ReadOnly = true;
            this.txtPassword.TextMode =TextBoxMode.SingleLine ;
            this.txtPasswordOk.ReadOnly = true;
            this.txtPasswordOk.TextMode = TextBoxMode.SingleLine;
            this.ddlRole.SelectedValue = user.Role.Id.ToString();
            this.rblGender.SelectedValue = user.Gender.ToString();
            this.ddlBranchs.SelectedValue = user.Depart.Branch.Id.ToString();
            LoadDepart(user.Depart.Branch.Id);
            this.ddlDepart.SelectedValue = user.Depart.Id.ToString();
            this.txtUserName.Text = user.UserName.ToString();
            this.ddlRole.SelectedValue = user.Role.Id.ToString();
            this.ddlState.SelectedValue = user.UserState.Id.ToString();
            this.imgFace.ImageUrl = "~/images/Users/" + this.txtLoginId.Text + ".jpg";
        }
        else
        {
            LoadDepart(int.Parse(this.ddlBranchs.SelectedValue));
            string imgurl = "~/images/Users/noperson.jpg";
            this.imgFace.ImageUrl = imgurl;
        }
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserInfo user = new UserInfo();
        string logid = this.txtLoginId.Text.ToString();
        user.LoginId = this.txtLoginId.Text.ToString();
        user.Password = this.txtPassword.Text.ToString();
        RoleInfo role = new RoleInfo();
        role.Id = int.Parse(this.ddlRole.SelectedValue.ToString());
        user.Role = role;
        UserState state = new UserState();
        state.Id = int.Parse(this.ddlState.SelectedValue.ToString());
        user.UserState = state;
        user.UserName = this.txtUserName.Text.ToString();
        user.Gender = int.Parse(this.rblGender.SelectedValue.ToString());
        DepartInfo depart = new DepartInfo();
        BranchInfo branch = new BranchInfo();
        branch.BranchName = this.ddlBranchs.Text.ToString();
        branch.Id = int.Parse(this.ddlBranchs.SelectedValue.ToString());
        depart.Branch = branch;
        depart.Id=int.Parse(this.ddlDepart.SelectedValue.ToString());
        user.Depart = depart;
        if (Request.QueryString["uid"] != null)
        {
            this.txtLoginId.Enabled = false;
            user.Id = int.Parse(Request.QueryString["uid"]);
            user.Password = Password;
            bool modifybool = UserInfoManager.ModifyUserById(user);
        }
        else
        {
            this.txtLoginId.Enabled = true;
            bool b = UserInfoManager.CheckUser(logid);
            if (!b)
            {
                bool bo = UserInfoManager.AddUser(user);
                if (bo)
                {
                    string UserFace = this.txtLoginId.Text;
                    string fileName = fuFace.FileName;
                    if (fileName.Length != 0)
                    {
                        string strPath = Server.MapPath(@"~\images\Users");
                        fuFace.PostedFile.SaveAs(strPath + "\\" + UserFace + ".jpg");
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('添加成功！！')</script>", false);                  
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('添加失败！！')</script>", false);                    
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('添加失败，已有该用户名，请重新填写！！')</script>", false);               
            }
        }
        Response.Redirect("UserManage.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserManage.aspx");
    }
    protected void ddlBranchs_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDepart(int.Parse(this.ddlBranchs.SelectedValue));
    }
    protected void btnReBuild_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserInfoManage.aspx?uid=" + UserId);
    }
   
}
