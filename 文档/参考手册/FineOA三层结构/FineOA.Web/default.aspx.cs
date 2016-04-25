using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Web.Security;
using FineOA.Model;
using FineOA.Common;

namespace FineOA.Web
{
    public partial class _default : PageBase
    {
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
            // 如果用户已经登录，则重定向到管理首页
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }

            Window1.Title = String.Format("系统登录（FineOA v{0}）", GetProductVersion());
        }

        #endregion

        #region Events

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ////执行事务
            //using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            //{
            //    try
            //    {
            //        BLL.t_RoleUser bll = new BLL.t_RoleUser();
            //        Model.t_RoleUser mdl = new t_RoleUser();
            //        mdl.FUserId = 8;
            //        mdl.FRoleId = 3;
            //        bll.Add(mdl);

            //        mdl.FRoleId = 4;
            //        mdl.FUserId = 3;

            //        bll.Add(mdl);                    
            //        ts.Complete();

            //        Alert.Show("OK");
            //    }
            //    catch (Exception ex)
            //    {

            //        Alert.Show(ex.Message);
            //    }
            //}
            //return;

            string userName = tbxUserName.Text.Trim();
            string password = tbxPassword.Text.Trim();

            BLL.t_User item = new BLL.t_User();
            t_User user = item.GetModelList("FUserName='" + userName + "'").Single();

            if (user != null)
            {
                if (Password.ComparePasswords(user.FPassword, password))
                {
                    if (!user.FEnabled)
                    {
                        Alert.Show("用户未启用，请联系管理员！");
                    }
                    else
                    {
                        // 登录成功
                        LogInfo(String.Format("登录成功：用户“{0}”", userName));

                        LoginSuccess(user);

                        return;
                    }
                }
                else
                {
                    LogInfo(String.Format("登录失败：用户“{0}”密码错误", userName));
                    Alert.Show("用户名或密码错误！");
                    return;
                }
            }
            else
            {
                LogInfo(String.Format("登录失败：用户“{0}”不存在", userName));
                Alert.Show("用户名或密码错误！");
                return;
            }
        }

        private void LoginSuccess(t_User user)
        {
            RegisterOnlineUser(user);

            //用户所属的角色字符串，以逗号分隔
            string roleIDs = String.Empty;
            //if (user.Roles != null)
            //{
            //    roleIDs = String.Join(",", user.Roles.Select(r => r.FRoleId).ToArray());
            //}

            bool isPersistent = false;
            DateTime expiration = DateTime.Now.AddMinutes(120);
            CreateFormsAuthenticationTicket(user.FUserName, roleIDs, isPersistent, expiration);

            // 重定向到登陆后首页
            Response.Redirect(FormsAuthentication.DefaultUrl);
        }

        #endregion
    }
}