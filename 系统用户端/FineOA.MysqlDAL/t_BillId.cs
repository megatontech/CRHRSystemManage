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
	/// 数据访问类:t_BillId
	/// </summary>
	public partial class t_BillId:It_BillId
	{
		public t_BillId()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FBillName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_BillId");
			strSql.Append(" where FBillName=@FBillName ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FBillName", MySqlDbType.String,128)			};
			parameters[0].Value = FBillName;

            return DbHelperMysql.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(FineOA.Model.t_BillId model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_BillId(");
			strSql.Append("FBillName,FMaxId)");
			strSql.Append(" values (");
			strSql.Append("@FBillName,@FMaxId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FBillName", MySqlDbType.String,128),
					new MySqlParameter("@FMaxId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.FBillName;
			parameters[1].Value = model.FMaxId;

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
		public bool Update(FineOA.Model.t_BillId model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_BillId set ");
			strSql.Append("FMaxId=@FMaxId");
			strSql.Append(" where FBillName=@FBillName ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FMaxId", MySqlDbType.Int32,4),
					new MySqlParameter("@FBillName", MySqlDbType.String,128)};
			parameters[0].Value = model.FMaxId;
			parameters[1].Value = model.FBillName;

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
		public bool Delete(string FBillName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_BillId ");
			strSql.Append(" where FBillName=@FBillName ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FBillName", MySqlDbType.String,128)			};
			parameters[0].Value = FBillName;

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
		public bool DeleteList(string FBillNamelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_BillId ");
			strSql.Append(" where FBillName in ("+FBillNamelist + ")  ");
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
		public FineOA.Model.t_BillId GetModel(string FBillName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FBillName,FMaxId from t_BillId ");
			strSql.Append(" where FBillName=@FBillName ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FBillName", MySqlDbType.String,128)			};
			parameters[0].Value = FBillName;

			FineOA.Model.t_BillId model=new FineOA.Model.t_BillId();
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
		public FineOA.Model.t_BillId DataRowToModel(DataRow row)
		{
			FineOA.Model.t_BillId model=new FineOA.Model.t_BillId();
			if (row != null)
			{
				if(row["FBillName"]!=null)
				{
					model.FBillName=row["FBillName"].ToString();
				}
				if(row["FMaxId"]!=null && row["FMaxId"].ToString()!="")
				{
					model.FMaxId=int.Parse(row["FMaxId"].ToString());
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
			strSql.Append("select FBillName,FMaxId ");
			strSql.Append(" FROM t_BillId ");
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
			strSql.Append(" FBillName,FMaxId ");
			strSql.Append(" FROM t_BillId ");
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
			strSql.Append("select count(1) FROM t_BillId ");
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
				strSql.Append("order by T.FBillName desc");
			}
			strSql.Append(")AS Row, T.*  from t_BillId T ");
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
			parameters[0].Value = "t_BillId";
			parameters[1].Value = "FBillName";
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

