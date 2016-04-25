using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FineOA.IDAL;
using FineOA.DBUtility;
using MySql.Data.MySqlClient;//Please add references
namespace FineOA.MysqlDAL
{
	/// <summary>
	/// 数据访问类:t_RoleUser
	/// </summary>
	public partial class t_RoleUser:It_RoleUser
	{
		public t_RoleUser()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMysql.GetMaxID("FRoleId", "t_RoleUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FRoleId,int FUserId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_RoleUser");
			strSql.Append(" where FRoleId=@FRoleId and FUserId=@FUserId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FRoleId", MySqlDbType.Int32,4),
					new MySqlParameter("@FUserId", MySqlDbType.Int32,4)			};
			parameters[0].Value = FRoleId;
			parameters[1].Value = FUserId;

			return DbHelperMysql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(FineOA.Model.t_RoleUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_RoleUser(");
			strSql.Append("FRoleId,FUserId)");
			strSql.Append(" values (");
			strSql.Append("@FRoleId,@FUserId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FRoleId", MySqlDbType.Int32,4),
					new MySqlParameter("@FUserId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.FRoleId;
			parameters[1].Value = model.FUserId;

			int rows=DbHelperMysql.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FineOA.Model.t_RoleUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_RoleUser set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("FRoleId=@FRoleId,");
			strSql.Append("FUserId=@FUserId");
			strSql.Append(" where FRoleId=@FRoleId and FUserId=@FUserId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FRoleId", MySqlDbType.Int32,4),
					new MySqlParameter("@FUserId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.FRoleId;
			parameters[1].Value = model.FUserId;

			int rows=DbHelperMysql.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FRoleId,int FUserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_RoleUser ");
			strSql.Append(" where FRoleId=@FRoleId and FUserId=@FUserId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FRoleId", MySqlDbType.Int32,4),
					new MySqlParameter("@FUserId", MySqlDbType.Int32,4)			};
			parameters[0].Value = FRoleId;
			parameters[1].Value = FUserId;

			int rows=DbHelperMysql.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FineOA.Model.t_RoleUser GetModel(int FRoleId,int FUserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FRoleId,FUserId from t_RoleUser ");
			strSql.Append(" where FRoleId=@FRoleId and FUserId=@FUserId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FRoleId", MySqlDbType.Int32,4),
					new MySqlParameter("@FUserId", MySqlDbType.Int32,4)			};
			parameters[0].Value = FRoleId;
			parameters[1].Value = FUserId;

			FineOA.Model.t_RoleUser model=new FineOA.Model.t_RoleUser();
			DataSet ds=DbHelperMysql.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FineOA.Model.t_RoleUser DataRowToModel(DataRow row)
		{
			FineOA.Model.t_RoleUser model=new FineOA.Model.t_RoleUser();
			if (row != null)
			{
				if(row["FRoleId"]!=null && row["FRoleId"].ToString()!="")
				{
					model.FRoleId=int.Parse(row["FRoleId"].ToString());
				}
				if(row["FUserId"]!=null && row["FUserId"].ToString()!="")
				{
					model.FUserId=int.Parse(row["FUserId"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FRoleId,FUserId ");
			strSql.Append(" FROM t_RoleUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMysql.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" FRoleId,FUserId ");
			strSql.Append(" FROM t_RoleUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperMysql.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_RoleUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperMysql.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.FUserId desc");
			}
			strSql.Append(")AS Row, T.*  from t_RoleUser T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMysql.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_RoleUser";
			parameters[1].Value = "FUserId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMysql.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

