﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FineOA.IDAL;
using FineOA.DBUtility;//Please add references
namespace FineOA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:t_SubMessage
	/// </summary>
	public partial class t_SubMessage:It_SubMessage
	{
		public t_SubMessage()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FItemId", "t_SubMessage"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FItemId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_SubMessage");
			strSql.Append(" where FItemId=@FItemId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FItemId", SqlDbType.Int,4)			};
			parameters[0].Value = FItemId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(FineOA.Model.t_SubMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_SubMessage(");
			strSql.Append("FItemId,FParentId,FName,FType,FDetail,FDescription)");
			strSql.Append(" values (");
			strSql.Append("@FItemId,@FParentId,@FName,@FType,@FDetail,@FDescription)");
			SqlParameter[] parameters = {
					new SqlParameter("@FItemId", SqlDbType.Int,4),
					new SqlParameter("@FParentId", SqlDbType.Int,4),
					new SqlParameter("@FName", SqlDbType.NVarChar,50),
					new SqlParameter("@FType", SqlDbType.Int,4),
					new SqlParameter("@FDetail", SqlDbType.Bit,1),
					new SqlParameter("@FDescription", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.FItemId;
			parameters[1].Value = model.FParentId;
			parameters[2].Value = model.FName;
			parameters[3].Value = model.FType;
			parameters[4].Value = model.FDetail;
			parameters[5].Value = model.FDescription;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(FineOA.Model.t_SubMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_SubMessage set ");
			strSql.Append("FParentId=@FParentId,");
			strSql.Append("FName=@FName,");
			strSql.Append("FType=@FType,");
			strSql.Append("FDetail=@FDetail,");
			strSql.Append("FDescription=@FDescription");
			strSql.Append(" where FItemId=@FItemId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FParentId", SqlDbType.Int,4),
					new SqlParameter("@FName", SqlDbType.NVarChar,50),
					new SqlParameter("@FType", SqlDbType.Int,4),
					new SqlParameter("@FDetail", SqlDbType.Bit,1),
					new SqlParameter("@FDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@FItemId", SqlDbType.Int,4)};
			parameters[0].Value = model.FParentId;
			parameters[1].Value = model.FName;
			parameters[2].Value = model.FType;
			parameters[3].Value = model.FDetail;
			parameters[4].Value = model.FDescription;
			parameters[5].Value = model.FItemId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append("delete from t_SubMessage ");
			strSql.Append(" where FItemId=@FItemId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FItemId", SqlDbType.Int,4)			};
			parameters[0].Value = FItemId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append("delete from t_SubMessage ");
			strSql.Append(" where FItemId in ("+FItemIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public FineOA.Model.t_SubMessage GetModel(int FItemId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FItemId,FParentId,FName,FType,FDetail,FDescription from t_SubMessage ");
			strSql.Append(" where FItemId=@FItemId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FItemId", SqlDbType.Int,4)			};
			parameters[0].Value = FItemId;

			FineOA.Model.t_SubMessage model=new FineOA.Model.t_SubMessage();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public FineOA.Model.t_SubMessage DataRowToModel(DataRow row)
		{
			FineOA.Model.t_SubMessage model=new FineOA.Model.t_SubMessage();
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
				if(row["FName"]!=null)
				{
					model.FName=row["FName"].ToString();
				}
				if(row["FType"]!=null && row["FType"].ToString()!="")
				{
					model.FType=int.Parse(row["FType"].ToString());
				}
				if(row["FDetail"]!=null && row["FDetail"].ToString()!="")
				{
					if((row["FDetail"].ToString()=="1")||(row["FDetail"].ToString().ToLower()=="true"))
					{
						model.FDetail=true;
					}
					else
					{
						model.FDetail=false;
					}
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
			strSql.Append("select FItemId,FParentId,FName,FType,FDetail,FDescription ");
			strSql.Append(" FROM t_SubMessage ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" FItemId,FParentId,FName,FType,FDetail,FDescription ");
			strSql.Append(" FROM t_SubMessage ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_SubMessage ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from t_SubMessage T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_SubMessage";
			parameters[1].Value = "FItemId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

