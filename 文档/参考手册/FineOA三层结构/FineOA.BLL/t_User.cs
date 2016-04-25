using System;
using System.Data;
using System.Collections.Generic;
using FineOA.Common;
using FineOA.Model;
using FineOA.DALFactory;
using FineOA.IDAL;
namespace FineOA.BLL
{
	/// <summary>
	/// t_User
	/// </summary>
	public partial class t_User
	{
		private readonly It_User dal=DataAccess.Createt_User();
		public t_User()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FDepartmentId,int FUserId)
		{
			return dal.Exists(FDepartmentId,FUserId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(FineOA.Model.t_User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FineOA.Model.t_User model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FUserId)
		{
			
			return dal.Delete(FUserId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FDepartmentId,int FUserId)
		{
			
			return dal.Delete(FDepartmentId,FUserId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string FUserIdlist )
		{
			return dal.DeleteList(FUserIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FineOA.Model.t_User GetModel(int FUserId)
		{
			
			return dal.GetModel(FUserId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public FineOA.Model.t_User GetModelByCache(int FUserId)
		{
			
			string CacheKey = "t_UserModel-" + FUserId;
			object objModel = FineOA.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FUserId);
					if (objModel != null)
					{
						int ModelCache = FineOA.Common.ConfigHelper.GetConfigInt("ModelCache");
						FineOA.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (FineOA.Model.t_User)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FineOA.Model.t_User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FineOA.Model.t_User> DataTableToList(DataTable dt)
		{
			List<FineOA.Model.t_User> modelList = new List<FineOA.Model.t_User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FineOA.Model.t_User model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

