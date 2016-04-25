using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Newtonsoft.Json.Linq;
using FineOA.Web.Helper;
using FineUI;
using FineOA.Model;

namespace FineOA.Web
{
    public partial class main : PageBase
    {
        #region Page_Init

        protected void Page_Init(object sender, EventArgs e)
        {
            // 工具栏上的帮助菜单
            JArray ja = JArray.Parse(ConfigHelper.HelpList);
            foreach (JObject jo in ja)
            {
                MenuButton menuItem = new MenuButton();
                menuItem.EnablePostBack = false;
                menuItem.Text = jo.Value<string>("Text");
                menuItem.Icon = IconHelper.String2Icon(jo.Value<string>("Icon"), true);
                menuItem.OnClientClick = String.Format("addExampleTab('{0}','{1}','{2}')", jo.Value<string>("ID"), ResolveUrl(jo.Value<string>("URL")), jo.Value<string>("Text"));

                btnHelp.Menu.Items.Add(menuItem);
            }

            // 用户可见的菜单列表
            List<t_Menu> menus = ResolveUserMenuList();
            if (menus.Count == 0)
            {
                Response.Write("系统管理员尚未给你配置菜单！");
                Response.End();

                return;
            }


            // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
            JObject ids = GetClientIDS(regionPanel, regionTop, btnShowHideHeader, mainTabStrip, txtUser,
                txtOnlineUserCount, txtCurrentTime, btnRefresh);
            //ids.Add("userName", GetIdentityName());
            //ids.Add("userIP", Request.UserHostAddress);
            //ids.Add("onlineUserCount", GetOnlineCount());

            if (ConfigHelper.MenuType == "accordion")
            {
                Accordion accordionMenu = InitAccordionMenu(menus);
                ids.Add("mainMenu", accordionMenu.ClientID);
                ids.Add("menuType", "accordion");
            }
            else
            {
                Tree treeMenu = InitTreeMenu(menus);
                ids.Add("mainMenu", treeMenu.ClientID);
                ids.Add("menuType", "menu");
            }

            string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
            PageContext.RegisterStartupScript(idsScriptStr);
            //string idsScriptStr = String.Format("window.DATA={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
            //PageContext.RegisterStartupScript(idsScriptStr);
        }

        private JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }

            return jo;
        }

        #region InitAccordionMenu

        /// <summary>
        /// 创建手风琴菜单
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        private Accordion InitAccordionMenu(List<t_Menu> menus)
        {
            Accordion accordionMenu = new Accordion();
            accordionMenu.ID = "accordionMenu";
            accordionMenu.EnableFill = true;
            accordionMenu.ShowBorder = true;
            accordionMenu.ShowHeader = false;
            regionLeft.Items.Add(accordionMenu);

            foreach (var menu in menus)
            {
                if (menu.FParentId == 0)
                {
                    AccordionPane accordionPane = new AccordionPane();
                    accordionPane.Title = menu.FName;
                    accordionPane.Layout = Layout.Fit;
                    accordionPane.ShowBorder = false;
                    accordionPane.BodyPadding = "2px 0 0 0";
                    accordionMenu.Items.Add(accordionPane);

                    Tree innerTree = new Tree();
                    innerTree.EnableArrows = true;
                    innerTree.ShowBorder = true;
                    innerTree.ShowHeader = false;
                    innerTree.EnableIcons = false;
                    innerTree.AutoScroll = true;
                    innerTree.EnableLines = true;
                    accordionPane.Items.Add(innerTree);

                    // 生成树
                    ResolveMenuTree(menus, menu.FItemId, innerTree.Nodes);
                }
            }
            return accordionMenu;
        }

        #endregion

        #region InitTreeMenu

        /// <summary>
        /// 创建树菜单
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        private Tree InitTreeMenu(List<t_Menu> menus)
        {
            Tree treeMenu = new Tree();
            treeMenu.ID = "mainMenu";
            treeMenu.EnableArrows = true;
            treeMenu.ShowBorder = true;
            treeMenu.ShowHeader = false;
            treeMenu.EnableIcons = false;
            treeMenu.AutoScroll = true;
            treeMenu.EnableLines = true;
            regionLeft.Items.Add(treeMenu);

            // 生成树
            ResolveMenuTree(menus, 0, treeMenu.Nodes);

            // 展开第一个树节点
            treeMenu.Nodes[0].Expanded = true;

            return treeMenu;
        }

        /// <summary>
        /// 生成菜单树
        /// </summary>
        /// <param name="menus"></param>
        /// <param name="parentMenuId"></param>
        /// <param name="nodes"></param>
        private void ResolveMenuTree(List<t_Menu> menus, int parentMenuId, FineUI.TreeNodeCollection nodes)
        {
            foreach (t_Menu menu in menus)
            {
                if (menu.FParentId == parentMenuId)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    nodes.Add(node);

                    node.Text = menu.FName;
                    node.IconUrl = menu.FImageUrl;
                    if (!String.IsNullOrEmpty(menu.FNavigateUrl))
                    {
                        node.EnablePostBack = false;
                        node.NavigateUrl = ResolveUrl(menu.FNavigateUrl);
                        //node.OnClientClick = String.Format("addTab('{0}','{1}','{2}')", node.NodeID, ResolveUrl(menu.NavigateUrl), node.Text.Replace("'", ""));
                    }

                    ResolveMenuTree(menus, menu.FItemId, node.Nodes);
                }
            }
        }

        #endregion

        #region ResolveUserMenuList

        // 获取用户可用的菜单列表
        private List<t_Menu> ResolveUserMenuList()
        {
            // 当前登陆用户的权限列表
            List<string> rolePowerNames = GetRolePowerNames();

            // 当前用户所属角色可用的菜单列表
            List<t_Menu> menus = new List<t_Menu>();

            BLL.t_Menu bll = new BLL.t_Menu();
            List<t_Menu> items = bll.GetModelList("");

            foreach (t_Menu menu in items)
            {
                // 如果此菜单不属于任何模块，或者此用户所属角色拥有对此模块的权限
                //if (menu.FViewPowerId == null || rolePowerNames.Contains(menu.ViewPower.FName))
                //{
                menus.Add(menu);
                //}
            }

            return menus;
        }

        #endregion

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
            //txtUser.Text = String.Format("欢迎您：<span style=\"font-weight:bold;color:red;\">{0}</span> [{1}]", User.Identity.Name, Request.UserHostAddress);
            //txtOnlineUserCount.Text = String.Format("在线用户：{0}", "2");

            //btnSysConfig.OnClientClick = Window1.GetShowReference("~/admin/config.aspx", "系统设置");

            litProductVersion.Text = String.Format("(Version{0})", GetProductVersion());
        }


        #endregion

        #region Events

        protected void btnExit_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            FormsAuthentication.RedirectToLoginPage();
        }

        #endregion
    }
}