using System;
using System.Data;
namespace FineOA.IDAL
{
	/// <summary>
	/// 接口层t_User
	/// </summary>
	public interface It_User
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int FDepartmentId,int FUserId);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(FineOA.Model.t_User model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(FineOA.Model.t_User model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int FUserId);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int FDepartmentId,int FUserId);
		bool DeleteList(string FUserIdlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		FineOA.Model.t_User GetModel(int FUserId);
		FineOA.Model.t_User DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	} 
}
