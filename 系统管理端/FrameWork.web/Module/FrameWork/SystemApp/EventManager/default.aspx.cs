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

using FrameWork;
using FrameWork.Components;
using FrameWork.WebControls;

namespace FrameWork.web.Module.FrameWork.EventManager
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListBind();
                OnStart();
            }
        }



        public string Get_Type(int E_Type)
        {
            return MessageBox.Get_Type(E_Type);

        }

        private void OnStart()
        {
            BindUserList();
            BindE_ApplicationID();
        }

        private void BindE_ApplicationID()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            ArrayList lst = BusinessFacade.sys_ApplicationsList(qp, out RecordCount);
            E_ApplicationID.DataTextField = "A_AppName";
            E_ApplicationID.DataValueField = "ApplicationID";
            E_ApplicationID.DataSource = lst;
            E_ApplicationID.DataBind();
            E_ApplicationID.Items.Insert(0, new ListItem("不限", ""));
        }

        private void BindUserList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            ArrayList lst = BusinessFacade.sys_UserList(qp, out RecordCount);
            string stringDel = "";
            foreach (sys_UserTable var in lst)
            {
                stringDel = "";
                if (var.U_Status == 2)
                {
                    stringDel = "己删除";
                }
                E_UserID.Items.Add(new ListItem(var.U_LoginName + "(" + var.U_CName + ")" + stringDel, var.UserID.ToString()));
            }

            E_UserID.Items.Insert(0,new ListItem("不限", ""));
        }

        private void ListBind()
        {

            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            ArrayList lst = BusinessFacade.sys_EventList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
        }

        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            ListBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            int E_UserID_Value = (int)Common.sink(E_UserID.UniqueID, MethodType.Post, 255, 0, DataType.Int);
            int E_Type_Value = (int)Common.sink(E_Type.UniqueID, MethodType.Post, 255, 0, DataType.Int);
            int E_ApplicationID_Value = (int)Common.sink(E_ApplicationID.UniqueID, MethodType.Post, 255, 0, DataType.Int);
            string E_M_PageCode_Value = (string)Common.sink(E_M_PageCode.UniqueID, MethodType.Post, 6, 0, DataType.Str);
            DateTime S_E_DateTime_Value = (DateTime)Common.sink(S_E_DateTime.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime E_E_DateTime_Value = (DateTime)Common.sink(E_E_DateTime.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            string E_Record_Value = (string)Common.sink(E_Record.UniqueID, MethodType.Post, 200, 0, DataType.Str);
            string SqlSearch = "Where 1=1 ";

            if (E_UserID_Value != 0)
                SqlSearch = SqlSearch + " and E_UserID = " + E_UserID_Value.ToString();
            if (E_Type_Value!=0)
                SqlSearch = SqlSearch + " and E_Type = " + E_Type_Value.ToString();
            if (E_ApplicationID_Value!=0)
                SqlSearch = SqlSearch + " and E_ApplicationID = " + E_ApplicationID_Value.ToString();
            if (E_M_PageCode_Value!="")
                SqlSearch = SqlSearch + " and E_M_PageCode = '" + Common.inSQL(E_M_PageCode_Value.ToString())+"'";
            if (S_E_DateTime_Value != DateTime.MaxValue && E_E_DateTime_Value != DateTime.MaxValue)
            {
                if (Common.GetDBType == "Access")
                    SqlSearch = SqlSearch + string.Format(" and E_DateTime between #{0} 00:00:00# and #{1} 23:59:59# ", S_E_DateTime_Value.Date.ToShortDateString(), E_E_DateTime_Value.Date.ToShortDateString());
                else if (Common.GetDBType=="Oracle")
                    SqlSearch = SqlSearch + string.Format(" and E_DateTime between to_date('{0} 00:00:00','yyyy-mm-dd HH24:MI:SS') and to_date('{1} 23:59:59','yyyy-mm-dd HH24:MI:SS') ", S_E_DateTime_Value.Date.ToShortDateString(), E_E_DateTime_Value.Date.ToShortDateString());
                else
                    SqlSearch = SqlSearch + string.Format(" and E_DateTime between '{0} 00:00:00' and '{1} 23:59:59' ", S_E_DateTime_Value.Date.ToShortDateString(), E_E_DateTime_Value.Date.ToShortDateString());

            }
                
            if (E_Record_Value != "")
                SqlSearch = SqlSearch + string.Format(" and E_Record like '%{0}%'",Common.inSQL(E_Record_Value));

            ViewState["SearchTerms"] = SqlSearch;
            TabOptionWebControls1.SelectIndex = 0;
            ListBind();
            


        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = " Where 1 = 1";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        protected void E_ApplicationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.E_ApplicationID.SelectedValue != "")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                qp.Where = string.Format(" Where M_ApplicationID = {0} and M_ParentID<>0 ", this.E_ApplicationID.SelectedValue);
                int RecordCount = 0;
                ArrayList lst = BusinessFacade.sys_ModuleList(qp, out RecordCount);
                E_M_PageCode.DataTextField = "M_CName";
                E_M_PageCode.DataValueField = "M_PageCode";
                E_M_PageCode.DataSource = lst;
                E_M_PageCode.DataBind();
                E_M_PageCode.Items.Insert(0, new ListItem("不限", ""));
            }
            else {
                E_M_PageCode.Items.Clear();
            }
            TabOptionWebControls1.SelectIndex = 1;
        }
    }
}
