﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FineOA.IDAL;
using FineOA.DBUtility;
using MySql.Data.MySqlClient;//Please add references
namespace FineOA.MysqlDAL
{
	/// <summary>
	/// 数据访问类:t_Role
	/// </summary>
	public partial class t_Role:It_Role
	{
		public t_Role()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMysql.GetMaxID("FRoleId", "t_Role"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FRoleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_Role");
			strSql.Append(" where FRoleId=？FRoleId");
            MySql.Data.MySqlClient.MySqlParameter[] parameters = {
					new MySql.Data.MySqlClient.MySqlParameter("？FRoleId", MySql.Data.MySqlClient.MySqlDbType.Int32,4)
			};
			parameters[0].Value = FRoleId;

			return DbHelperMysql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FineOA.Model.t_Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_Role(");
			strSql.Append("FRoleName,FDescription)");
			strSql.Append(" values (");
			strSql.Append("？FRoleName,？FDescription)");
			strSql.Append(";select ？？IDENTITY");
			MySql.Data.MySqlClient.MySqlParameter[] parameters = {
					new MySql.Data.MySqlClient.MySqlParameter("？FRoleName", MySql.Data.MySqlClient.MySqlDbType.String,50),
					new MySql.Data.MySqlClient.MySqlParameter("？FDescription", MySql.Data.MySqlClient.MySqlDbType.String,500)};
			parameters[0].Value = model.FRoleName;
			parameters[1].Value = model.FDescription;

			object obj = DbHelperMysql.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(FineOA.Model.t_Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_Role set ");
			strSql.Append("FRoleName=？FRoleName,");
			strSql.Append("FDescription=？FDescription");
			strSql.Append(" where FRoleId=？FRoleId");
			MySql.Data.MySqlClient.MySqlParameter[] parameters = {
					new MySql.Data.MySqlClient.MySqlParameter("？FRoleName", MySql.Data.MySqlClient.MySqlDbType.String,50),
					new MySql.Data.MySqlClient.MySqlParameter("？FDescription", MySql.Data.MySqlClient.MySqlDbType.String,500),
					new MySql.Data.MySqlClient.MySqlParameter("？FRoleId", MySql.Data.MySqlClient.MySqlDbType.Int16,4)};
			parameters[0].Value = model.FRoleName;
			parameters[1].Value = model.FDescription;
			parameters[2].Value = model.FRoleId;

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
		public bool Delete(int FRoleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Role ");
			strSql.Append(" where FRoleId=？FRoleId");
			MySql.Data.MySqlClient.MySqlParameter[] parameters = {
					new MySql.Data.MySqlClient.MySqlParameter("？FRoleId", MySql.Data.MySqlClient.MySqlDbType.Int16,4)
			};
			parameters[0].Value = FRoleId;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string FRoleIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Role ");
			strSql.Append(" where FRoleId in ("+FRoleIdlist + ")  ");
			int rows=DbHelperMysql.ExecuteSql(strSql.ToString());
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
		public FineOA.Model.t_Role GetModel(int FRoleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FRoleId,FRoleName,FDescription from t_Role ");
			strSql.Append(" where FRoleId=？FRoleId");
			MySql.Data.MySqlClient.MySqlParameter[] parameters = {
					new MySql.Data.MySqlClient.MySqlParameter("？FRoleId", MySql.Data.MySqlClient.MySqlDbType.Int16,4)
			};
			parameters[0].Value = FRoleId;

			FineOA.Model.t_Role model=new FineOA.Model.t_Role();
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
		public FineOA.Model.t_Role DataRowToModel(DataRow row)
		{
			FineOA.Model.t_Role model=new FineOA.Model.t_Role();
			if (row != null)
			{
				if(row["FRoleId"]!=null && row["FRoleId"].ToString()!="")
				{
					model.FRoleId=int.Parse(row["FRoleId"].ToString());
				}
				if(row["FRoleName"]!=null)
				{
					model.FRoleName=row["FRoleName"].ToString();
				}
				if(row["FDescription"]!=null)
				{
					model.FDescription=row["FDescription"].ToString();
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
			strSql.Append("select FRoleId,FRoleName,FDescription ");
			strSql.Append(" FROM t_Role ");
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
			strSql.Append(" FRoleId,FRoleName,FDescription ");
			strSql.Append(" FROM t_Role ");
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
			strSql.Append("select count(1) FROM t_Role ");
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
				strSql.Append("order by T.FRoleId desc");
			}
			strSql.Append(")AS Row, T.*  from t_Role T ");
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
			MySql.Data.MySqlClient.MySqlParameter[] parameters = {
					new MySql.Data.MySqlClient.MySqlParameter("？tblName", MySql.Data.MySqlClient.MySqlDbType.VarChar, 255),
					new MySql.Data.MySqlClient.MySqlParameter("？fldName", MySql.Data.MySqlClient.MySqlDbType.VarChar, 255),
					new MySql.Data.MySqlClient.MySqlParameter("？PageSize", MySql.Data.MySqlClient.MySqlDbType.Int32),
					new MySql.Data.MySqlClient.MySqlParameter("？PageIndex", MySql.Data.MySqlClient.MySqlDbType.Int32),
					new MySql.Data.MySqlClient.MySqlParameter("？IsReCount", MySql.Data.MySqlClient.MySqlDbType.Bit),
					new MySql.Data.MySqlClient.MySqlParameter("？OrderType", MySql.Data.MySqlClient.MySqlDbType.Bit),
					new MySql.Data.MySqlClient.MySqlParameter("？strWhere", MySql.Data.MySqlClient.MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_Role";
			parameters[1].Value = "FRoleId";
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

