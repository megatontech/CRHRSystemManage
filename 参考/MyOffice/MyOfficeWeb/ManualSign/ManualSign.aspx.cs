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


//http://bbs.51aspx.com
public partial class ManualSign_ManualSign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] != null)
            {
                UserInfo user = (UserInfo)Session["user"];
                string today = DateTime.Now.ToShortDateString();
                this.txtSignDate.Text = today;//初始化时间

                int userId = user.Id;
                ManualSign manualSign = ManualSignManager.GetMaxSignIdByUserId(userId);//查找登录用户的最大签卡信息


                //用户今天没有签到和签退
                if (manualSign == null)
                {
                    btnArrive.Enabled = true;
                    btnLeave.Enabled = false;
                }
                else //判断用户今天是否已签到或签退
                {
                    if (manualSign.SignTag == 1)//如果已签到，
                    {
                        btnArrive.Enabled = false;//则把签到按钮设置为不可用
                        btnLeave.Enabled = true;//签退按钮设置为可用
                        this.lblMessage.Text = "您好，你今天已经签到了 ！,请签退！！";
                        this.lblMessage.Visible = true;
                    }
                    else//签退按钮设置为可用，否则反之
                    {
                        btnArrive.Enabled = false;
                        btnLeave.Enabled = false;
                        this.lblMessage.Text = "您好，你今天已经签到,签退！！";
                        this.lblMessage.Visible = true;
                    }
                }
                if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday) 
                {
                    btnArrive.Enabled = false;
                    btnLeave.Enabled = false;
                    this.lblMessage.Text = "您好，今天休假日！！";
                    this.lblMessage.Visible = true;

                }
            }
        }

    }
    //签到
    protected void btnArrive_Click(object sender, EventArgs e)
    {
        UserInfo user = (UserInfo)Session["user"];
        ManualSign manualSign = new ManualSign();
        manualSign.User = user;
        manualSign.SignTime = DateTime.Now;
        manualSign.SignTag = 1;
        manualSign.SignDesc = this.TxtSignDescNow.Text;
        bool b = ManualSignManager.AddManualSign(manualSign);
        if (b) 
        {
            btnLeave.Enabled = true;
            btnArrive.Enabled = false;
            this.divManualSignIn.Visible = true;

            TxtUserId.Text = "----" + user.LoginId;
            TxtUserName.Text = "----" + user.UserName;

            TxtDepart.Text = "----" + user.Depart.DepartName;
            TxtBranch.Text = "----" + user.Depart.Branch.BranchName;

            TxtSignTime.Text = "----" + DateTime.Now.ToString();
            TxtSignDesc.Text = TxtSignDescNow.Text;
        }
    }
    //签退
    protected void btnLeave_Click(object sender, EventArgs e)
    {
        UserInfo user = (UserInfo)Session["user"];
        ManualSign manualSign = new ManualSign();
        manualSign.User = user;
        manualSign.SignTime = DateTime.Now;
        manualSign.SignTag = 0;
        manualSign.SignDesc = this.TxtSignDescNow.Text;
        bool b = ManualSignManager.AddManualSign(manualSign);
        if (b)
        {
            btnLeave.Enabled = false;
            btnArrive.Enabled = false;
            this.divManualSignIn.Visible = false;
            this.divManualSignOut.Visible = true;

            TxtUserId2.Text = "----" + user.LoginId;
            TxtUserName2.Text = "----" + user.UserName;

            TxtDepart2.Text = "----" + user.Depart.DepartName;
            TxtBranch2.Text = "----" + user.Depart.Branch.BranchName;

            TxtSignTime2.Text = "----" + DateTime.Now.ToString();
            TxtSignDesc2.Text = TxtSignDescNow.Text;
            this.lblMessage.Visible = false;
        }
    }
}
