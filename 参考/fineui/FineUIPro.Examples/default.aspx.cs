using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FineUIPro.Examples
{
    public partial class _default : PageBase
    {
        #region Page_Init

        private string menuType = "menu";
        private bool showOnlyNew = false;
        private int examplesCount = 0;

        protected void Page_Init(object sender, EventArgs e)
        {
            // 从Cookie中读取左侧菜单类型
            HttpCookie menuCookie = Request.Cookies["MenuStyle_Pro"];
            if (menuCookie != null)
            {
                menuType = menuCookie.Value;
            }

            // 从Cookie中读取是否仅显示最新示例
            HttpCookie menuShowOnlyNew = Request.Cookies["ShowOnlyNew_Pro"];
            if (menuShowOnlyNew != null)
            {
                showOnlyNew = Convert.ToBoolean(menuShowOnlyNew.Value);
            }


            if (menuType == "accordion")
            {
                InitAccordionMenu();
            }
            else
            {
                InitTreeMenu();
            }

            leftPanel.Title = String.Format("全部示例（{0}）", examplesCount);
        }

        private Accordion InitAccordionMenu()
        {
            Accordion accordionMenu = new Accordion();
            accordionMenu.ID = "accordionMenu";
            accordionMenu.EnableFill = true;
            accordionMenu.ShowBorder = false;
            accordionMenu.ShowHeader = false;
            leftPanel.Items.Add(accordionMenu);

            // 标识左侧面板内放置的是手风琴控件
            leftPanel.CssClass += " accordioninside";


            XmlDocument xmlDoc = XmlDataSource1.GetXmlDocument();
            XmlNodeList xmlNodes = xmlDoc.SelectNodes("/Tree/TreeNode");
            foreach (XmlNode xmlNode in xmlNodes)
            {
                if (xmlNode.HasChildNodes)
                {
                    string accordionPaneTitle = xmlNode.Attributes["Text"].Value;
                    string isNewHtml = GetIsNewHtml(xmlNode);
                    if (!String.IsNullOrEmpty(isNewHtml))
                    {
                        accordionPaneTitle += isNewHtml;
                    }

                    AccordionPane accordionPane = new AccordionPane();
                    accordionPane.Title = accordionPaneTitle;
                    accordionPane.Layout = Layout.Fit;
                    accordionPane.ShowBorder = false;
                    //accordionPane.BodyPadding = "2px 0";
                    accordionMenu.Items.Add(accordionPane);

                    Tree innerTree = new Tree();
                    innerTree.ShowBorder = false;
                    innerTree.ShowHeader = false;
                    innerTree.EnableIcons = true;
                    innerTree.AutoScroll = true;
                    innerTree.EnableSingleClickExpand = true;
                    accordionPane.Items.Add(innerTree);

                    XmlDocument innerXmlDoc = new XmlDocument();
                    innerXmlDoc.LoadXml(String.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Tree>{0}</Tree>", xmlNode.InnerXml));

                    // 绑定AccordionPane内部的树控件
                    innerTree.NodeDataBound += treeMenu_NodeDataBound;
                    innerTree.PreNodeDataBound += treeMenu_PreNodeDataBound;
                    innerTree.DataSource = innerXmlDoc;
                    innerTree.DataBind();

                    //// 重新设置每个节点的图标
                    //ResolveTreeNode(innerTree.Nodes);
                }
            }

            return accordionMenu;
        }

        private Tree InitTreeMenu()
        {
            Tree treeMenu = new Tree();
            treeMenu.ID = "treeMenu";
            treeMenu.ShowBorder = false;
            treeMenu.ShowHeader = false;
            treeMenu.EnableIcons = true;
            treeMenu.AutoScroll = true;
            treeMenu.EnableSingleClickExpand = true;
            leftPanel.Items.Add(treeMenu);

            // 绑定 XML 数据源到树控件
            treeMenu.NodeDataBound += treeMenu_NodeDataBound;
            treeMenu.PreNodeDataBound += treeMenu_PreNodeDataBound;
            treeMenu.DataSource = XmlDataSource1;
            treeMenu.DataBind();

            //// 重新设置每个节点的图标
            //ResolveTreeNode(treeMenu.Nodes);

            return treeMenu;
        }

        /// <summary>
        /// 树节点的绑定后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeMenu_NodeDataBound(object sender, TreeNodeEventArgs e)
        {
            string isNewHtml = GetIsNewHtml(e.XmlNode);
            if (!String.IsNullOrEmpty(isNewHtml))
            {
                e.Node.Text += isNewHtml;
            }

            // 如果仅显示最新示例 并且 当前节点不是子节点，则展开当前节点
            if (showOnlyNew && !e.Node.Leaf)
            {
                e.Node.Expanded = true;
            }

        }

        /// <summary>
        /// 树节点的预绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeMenu_PreNodeDataBound(object sender, TreePreNodeEventArgs e)
        {
            // 如果仅显示最新示例
            if (showOnlyNew)
            {
                string isNewHtml = GetIsNewHtml(e.XmlNode);
                if (String.IsNullOrEmpty(isNewHtml))
                {
                    e.Cancelled = true;
                }
            }

            // 更新示例总数
            if (e.XmlNode.ChildNodes.Count == 0)
            {
                examplesCount++;
            }
        }


        private string GetIsNewHtml(XmlNode node)
        {
            string result = String.Empty;

            XmlAttribute isNewAttr = node.Attributes["IsNew"];
            if (isNewAttr != null)
            {
                if (Convert.ToBoolean(isNewAttr.Value))
                {
                    result = "&nbsp;<span class=\"isnew\">New!</span>";
                }
            }

            return result;
        }


        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitMenuStyleButton();
                InitLangMenuButton();
                InitMenuShowOnlyNew();

                litVersion.Text = FineUIPro.GlobalConfig.ProductVersion;
                litOnlineUserCount.Text = Application["OnlineUserCount"].ToString();

            }
        }


        private void InitMenuShowOnlyNew()
        {
            cbxShowOnlyNew.Checked = showOnlyNew;

            if (showOnlyNew)
            {
                leftPanel.Title = "最新示例";
            }
        }

        private void InitMenuStyleButton()
        {
            string menuStyleID = "MenuStyleTree";

            HttpCookie menuStyleCookie = Request.Cookies["MenuStyle_Pro"];
            if (menuStyleCookie != null)
            {
                switch (menuStyleCookie.Value)
                {
                    case "menu":
                        menuStyleID = "MenuStyleTree";
                        break;
                    case "accordion":
                        menuStyleID = "MenuStyleAccordion";
                        break;
                }
            }


            SetSelectedMenuID(MenuStyle, menuStyleID);
        }


        private void InitLangMenuButton()
        {
            string langMenuID = "MenuLangZHCN";

            string langValue = PageManager1.Language.ToString().ToLower();
            switch (langValue)
            {
                case "zh_cn":
                    langMenuID = "MenuLangZHCN";
                    break;
                case "zh_tw":
                    langMenuID = "MenuLangZHTW";
                    break;
                case "en":
                    langMenuID = "MenuLangEN";
                    break;
            }


            SetSelectedMenuID(MenuLang, langMenuID);
        }

        private void SetSelectedMenuID(MenuButton menuButton, string selectedMenuID)
        {
            foreach (MenuItem item in menuButton.Menu.Items)
            {
                MenuCheckBox checkBox = (item as MenuCheckBox);
                if (checkBox != null && checkBox.ID == selectedMenuID)
                {
                    checkBox.Checked = true;
                }
                else
                {
                    checkBox.Checked = false;
                }
            }
        }

        #endregion


    }
}
