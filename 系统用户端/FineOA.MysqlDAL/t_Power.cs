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
	/// 数据访问类:t_Power
	/// </summary>
	public partial class t_Power:It_Power
	{
		public t_Power()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMysql.GetMaxID("FPowerId", "t_Power"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FPowerId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_Power");
			strSql.Append(" where FPowerId=@FPowerId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FPowerId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = FPowerId;

			return DbHelperMysql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FineOA.Model.t_Power model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_Power(");
			strSql.Append("FName,FGroupName,FTitle,FDescription)");
			strSql.Append(" values (");
			strSql.Append("@FName,@FGroupName,@FTitle,@FDescription)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FName", MySqlDbType.String,50),
					new MySqlParameter("@FGroupName", MySqlDbType.String,50),
					new MySqlParameter("@FTitle", MySqlDbType.String,200),
					new MySqlParameter("@FDescription", MySqlDbType.String,500)};
			parameters[0].Value = model.FName;
			parameters[1].Value = model.FGroupName;
			parameters[2].Value = model.FTitle;
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
		public bool Update(FineOA.Model.t_Power model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_Power set ");
			strSql.Append("FName=@FName,");
			strSql.Append("FGroupName=@FGroupName,");
			strSql.Append("FTitle=@FTitle,");
			strSql.Append("FDescription=@FDescription");
			strSql.Append(" where FPowerId=@FPowerId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FName", MySqlDbType.String,50),
					new MySqlParameter("@FGroupName", MySqlDbType.String,50),
					new MySqlParameter("@FTitle", MySqlDbType.String,200),
					new MySqlParameter("@FDescription", MySqlDbType.String,500),
					new MySqlParameter("@FPowerId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.FName;
			parameters[1].Value = model.FGroupName;
			parameters[2].Value = model.FTitle;
			parameters[3].Value = model.FDescription;
			parameters[4].Value = model.FPowerId;

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
		public bool Delete(int FPowerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Power ");
			strSql.Append(" where FPowerId=@FPowerId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FPowerId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = FPowerId;

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
		public bool DeleteList(string FPowerIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Power ");
			strSql.Append(" where FPowerId in ("+FPowerIdlist + ")  ");
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
		public FineOA.Model.t_Power GetModel(int FPowerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FPowerId,FName,FGroupName,FTitle,FDescription from t_Power ");
			strSql.Append(" where FPowerId=@FPowerId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FPowerId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = FPowerId;

			FineOA.Model.t_Power model=new FineOA.Model.t_Power();
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
		public FineOA.Model.t_Power DataRowToModel(DataRow row)
		{
			FineOA.Model.t_Power model=new FineOA.Model.t_Power();
			if (row != null)
			{
				if(row["FPowerId"]!=null && row["FPowerId"].ToString()!="")
				{
					model.FPowerId=int.Parse(row["FPowerId"].ToString());
				}
				if(row["FName"]!=null)
				{
					model.FName=row["FName"].ToString();
				}
				if(row["FGroupName"]!=null)
				{
					model.FGroupName=row["FGroupName"].ToString();
				}
				if(row["FTitle"]!=null)
				{
					model.FTitle=row["FTitle"].ToString();
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
			strSql.Append("select FPowerId,FName,FGroupName,FTitle,FDescription ");
			strSql.Append(" FROM t_Power ");
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
			strSql.Append(" FPowerId,FName,FGroupName,FTitle,FDescription ");
			strSql.Append(" FROM t_Power ");
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
			strSql.Append("select count(1) FROM t_Power ");
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
				strSql.Append("order by T.FPowerId desc");
			}
			strSql.Append(")AS Row, T.*  from t_Power T ");
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
			parameters[0].Value = "t_Power";
			parameters[1].Value = "FPowerId";
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

