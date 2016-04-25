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
	/// 数据访问类:t_Department
	/// </summary>
	public partial class t_Department:It_Department
	{
		public t_Department()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMysql.GetMaxID("FParentId", "t_Department"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FParentId,int FItemId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_Department");
			strSql.Append(" where FParentId=@FParentId and FItemId=@FItemId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FParentId", MySqlDbType.Int32,4),
					new MySqlParameter("@FItemId", MySqlDbType.Int32,4)			};
			parameters[0].Value = FParentId;
			parameters[1].Value = FItemId;

			return DbHelperMysql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FineOA.Model.t_Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_Department(");
			strSql.Append("FParentId,FNumber,FName,FDescription)");
			strSql.Append(" values (");
			strSql.Append("@FParentId,@FNumber,@FName,@FDescription)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FParentId", MySqlDbType.Int32,4),
					new MySqlParameter("@FNumber", MySqlDbType.String,50),
					new MySqlParameter("@FName", MySqlDbType.String,50),
					new MySqlParameter("@FDescription", MySqlDbType.String,500)};
			parameters[0].Value = model.FParentId;
			parameters[1].Value = model.FNumber;
			parameters[2].Value = model.FName;
			parameters[3].Value = model.FDescription;

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
		public bool Update(FineOA.Model.t_Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_Department set ");
			strSql.Append("FNumber=@FNumber,");
			strSql.Append("FName=@FName,");
			strSql.Append("FDescription=@FDescription");
			strSql.Append(" where FItemId=@FItemId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FNumber", MySqlDbType.String,50),
					new MySqlParameter("@FName", MySqlDbType.String,50),
					new MySqlParameter("@FDescription", MySqlDbType.String,500),
					new MySqlParameter("@FItemId", MySqlDbType.Int32,4),
					new MySqlParameter("@FParentId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.FNumber;
			parameters[1].Value = model.FName;
			parameters[2].Value = model.FDescription;
			parameters[3].Value = model.FItemId;
			parameters[4].Value = model.FParentId;

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
		public bool Delete(int FItemId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Department ");
			strSql.Append(" where FItemId=@FItemId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FItemId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = FItemId;

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
		public bool Delete(int FParentId,int FItemId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Department ");
			strSql.Append(" where FParentId=@FParentId and FItemId=@FItemId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FParentId", MySqlDbType.Int32,4),
					new MySqlParameter("@FItemId", MySqlDbType.Int32,4)			};
			parameters[0].Value = FParentId;
			parameters[1].Value = FItemId;

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
		public bool DeleteList(string FItemIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Department ");
			strSql.Append(" where FItemId in ("+FItemIdlist + ")  ");
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
		public FineOA.Model.t_Department GetModel(int FItemId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FItemId,FParentId,FNumber,FName,FDescription from t_Department ");
			strSql.Append(" where FItemId=@FItemId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FItemId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = FItemId;

			FineOA.Model.t_Department model=new FineOA.Model.t_Department();
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
		public FineOA.Model.t_Department DataRowToModel(DataRow row)
		{
			FineOA.Model.t_Department model=new FineOA.Model.t_Department();
			if (row != null)
			{
				if(row["FItemId"]!=null && row["FItemId"].ToString()!="")
				{
					model.FItemId=int.Parse(row["FItemId"].ToString());
				}
				if(row["FParentId"]!=null && row["FParentId"].ToString()!="")
				{
					model.FParentId=int.Parse(row["FParentId"].ToString());
				}
				if(row["FNumber"]!=null)
				{
					model.FNumber=row["FNumber"].ToString();
				}
				if(row["FName"]!=null)
				{
					model.FName=row["FName"].ToString();
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
			strSql.Append("select FItemId,FParentId,FNumber,FName,FDescription ");
			strSql.Append(" FROM t_Department ");
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
			strSql.Append(" FItemId,FParentId,FNumber,FName,FDescription ");
			strSql.Append(" FROM t_Department ");
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
			strSql.Append("select count(1) FROM t_Department ");
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
				strSql.Append("order by T.FItemId desc");
			}
			strSql.Append(")AS Row, T.*  from t_Department T ");
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
			parameters[0].Value = "t_Department";
			parameters[1].Value = "FItemId";
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

