using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using AjaxControlToolkit;
using MyOffice.BLL;
using MyOffice.Models;
using System.Collections.Specialized;

/// <summary>
/// BranchService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService()]
public class BranchService : System.Web.Services.WebService
{

    public BranchService()
    {
        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetBranchIf(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> provinceList = new List<CascadingDropDownNameValue>();
        IList<BranchInfo> listbranch = BranchInfoManger.GetBranchInfo();
        foreach (BranchInfo branch in listbranch)
        {
            provinceList.Add(new CascadingDropDownNameValue(branch.BranchName, branch.Id.ToString()));
        }

        return provinceList.ToArray();
    }
    [WebMethod]
    public CascadingDropDownNameValue[] GetDepart(string knownCategoryValues, string category)
    {

        string[] categoryValues = knownCategoryValues.Split(':', ';');

        List<CascadingDropDownNameValue> provinceList = new List<CascadingDropDownNameValue>();
        IList<DepartInfo> listdepart = DepartInfoManager.GetDepartInfoByBranchId(int.Parse(categoryValues[1]));
        foreach (DepartInfo depart in listdepart)
        {
            provinceList.Add(new CascadingDropDownNameValue(depart.DepartName, depart.Id.ToString()));
        }

        return provinceList.ToArray();
    }

}

