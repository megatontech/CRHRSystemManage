using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FineOA.IDAL;
using FineOA.DBUtility;//Please add references
namespace FineOA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:t_BillNo
	/// </summary>
	public partial class t_BillNo:It_BillNo
	{
		public t_BillNo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FItemId", "t_BillNo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FItemId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_BillNo");
			strSql.Append(" where FItemId=@FItemId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FItemId", SqlDbType.Int,4)			};
			parameters[0].Value = FItemId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(FineOA.Model.t_BillNo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_BillNo(");
			strSql.Append("FItemId,FBillName,FTableName,FPreLetter,FCurId,FSufLetter,FFormat,FLen,FTranType)");
			strSql.Append(" values (");
			strSql.Append("@FItemId,@FBillName,@FTableName,@FPreLetter,@FCurId,@FSufLetter,@FFormat,@FLen,@FTranType)");
			SqlParameter[] parameters = {
					new SqlParameter("@FItemId", SqlDbType.Int,4),
					new SqlParameter("@FBillName", SqlDbType.NVarChar,-1),
					new SqlParameter("@FTableName", SqlDbType.NVarChar,-1),
					new SqlParameter("@FPreLetter", SqlDbType.NVarChar,-1),
					new SqlParameter("@FCurId", SqlDbType.Int,4),
					new SqlParameter("@FSufLetter", SqlDbType.NVarChar,-1),
					new SqlParameter("@FFormat", SqlDbType.NVarChar,-1),
					new SqlParameter("@FLen", SqlDbType.Int,4),
					new SqlParameter("@FTranType", SqlDbType.Int,4)};
			parameters[0].Value = model.FItemId;
			parameters[1].Value = model.FBillName;
			parameters[2].Value = model.FTableName;
			parameters[3].Value = model.FPreLetter;
			parameters[4].Value = model.FCurId;
			parameters[5].Value = model.FSufLetter;
			parameters[6].Value = model.FFormat;
			parameters[7].Value = model.FLen;
			parameters[8].Value = model.FTranType;

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
		public bool Update(FineOA.Model.t_BillNo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_BillNo set ");
			strSql.Append("FBillName=@FBillName,");
			strSql.Append("FTableName=@FTableName,");
			strSql.Append("FPreLetter=@FPreLetter,");
			strSql.Append("FCurId=@FCurId,");
			strSql.Append("FSufLetter=@FSufLetter,");
			strSql.Append("FFormat=@FFormat,");
			strSql.Append("FLen=@FLen,");
			strSql.Append("FTranType=@FTranType");
			strSql.Append(" where FItemId=@FItemId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FBillName", SqlDbType.NVarChar,-1),
					new SqlParameter("@FTableName", SqlDbType.NVarChar,-1),
					new SqlParameter("@FPreLetter", SqlDbType.NVarChar,-1),
					new SqlParameter("@FCurId", SqlDbType.Int,4),
					new SqlParameter("@FSufLetter", SqlDbType.NVarChar,-1),
					new SqlParameter("@FFormat", SqlDbType.NVarChar,-1),
					new SqlParameter("@FLen", SqlDbType.Int,4),
					new SqlParameter("@FTranType", SqlDbType.Int,4),
					new SqlParameter("@FItemId", SqlDbType.Int,4)};
			parameters[0].Value = model.FBillName;
			parameters[1].Value = model.FTableName;
			parameters[2].Value = model.FPreLetter;
			parameters[3].Value = model.FCurId;
			parameters[4].Value = model.FSufLetter;
			parameters[5].Value = model.FFormat;
			parameters[6].Value = model.FLen;
			parameters[7].Value = model.FTranType;
			parameters[8].Value = model.FItemId;

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
			strSql.Append("delete from t_BillNo ");
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
			strSql.Append("delete from t_BillNo ");
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
		public FineOA.Model.t_BillNo GetModel(int FItemId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FItemId,FBillName,FTableName,FPreLetter,FCurId,FSufLetter,FFormat,FLen,FTranType from t_BillNo ");
			strSql.Append(" where FItemId=@FItemId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FItemId", SqlDbType.Int,4)			};
			parameters[0].Value = FItemId;

			FineOA.Model.t_BillNo model=new FineOA.Model.t_BillNo();
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
		public FineOA.Model.t_BillNo DataRowToModel(DataRow row)
		{
			FineOA.Model.t_BillNo model=new FineOA.Model.t_BillNo();
			if (row != null)
			{
				if(row["FItemId"]!=null && row["FItemId"].ToString()!="")
				{
					model.FItemId=int.Parse(row["FItemId"].ToString());
				}
				if(row["FBillName"]!=null)
				{
					model.FBillName=row["FBillName"].ToString();
				}
				if(row["FTableName"]!=null)
				{
					model.FTableName=row["FTableName"].ToString();
				}
				if(row["FPreLetter"]!=null)
				{
					model.FPreLetter=row["FPreLetter"].ToString();
				}
				if(row["FCurId"]!=null && row["FCurId"].ToString()!="")
				{
					model.FCurId=int.Parse(row["FCurId"].ToString());
				}
				if(row["FSufLetter"]!=null)
				{
					model.FSufLetter=row["FSufLetter"].ToString();
				}
				if(row["FFormat"]!=null)
				{
					model.FFormat=row["FFormat"].ToString();
				}
				if(row["FLen"]!=null && row["FLen"].ToString()!="")
				{
					model.FLen=int.Parse(row["FLen"].ToString());
				}
				if(row["FTranType"]!=null && row["FTranType"].ToString()!="")
				{
					model.FTranType=int.Parse(row["FTranType"].ToString());
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
			strSql.Append("select FItemId,FBillName,FTableName,FPreLetter,FCurId,FSufLetter,FFormat,FLen,FTranType ");
			strSql.Append(" FROM t_BillNo ");
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
			strSql.Append(" FItemId,FBillName,FTableName,FPreLetter,FCurId,FSufLetter,FFormat,FLen,FTranType ");
			strSql.Append(" FROM t_BillNo ");
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
			strSql.Append("select count(1) FROM t_BillNo ");
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
			strSql.Append(")AS Row, T.*  from t_BillNo T ");
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
			parameters[0].Value = "t_BillNo";
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

