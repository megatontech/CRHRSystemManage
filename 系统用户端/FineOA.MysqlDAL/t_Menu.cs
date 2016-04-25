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
	/// 数据访问类:t_Menu
	/// </summary>
	public partial class t_Menu:It_Menu
	{
		public t_Menu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMysql.GetMaxID("FParentId", "t_Menu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FParentId,int FViewPowerId,int FItemId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_Menu");
			strSql.Append(" where FParentId=@FParentId and FViewPowerId=@FViewPowerId and FItemId=@FItemId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FParentId", MySqlDbType.Int32,4),
					new MySqlParameter("@FViewPowerId", MySqlDbType.Int32,4),
					new MySqlParameter("@FItemId", MySqlDbType.Int32,4)			};
			parameters[0].Value = FParentId;
			parameters[1].Value = FViewPowerId;
			parameters[2].Value = FItemId;

			return DbHelperMysql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FineOA.Model.t_Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_Menu(");
			strSql.Append("FName,FImageUrl,FNavigateUrl,FDescription,FSortIndex,FParentId,FViewPowerId)");
			strSql.Append(" values (");
			strSql.Append("@FName,@FImageUrl,@FNavigateUrl,@FDescription,@FSortIndex,@FParentId,@FViewPowerId)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FName", MySqlDbType.String,50),
					new MySqlParameter("@FImageUrl", MySqlDbType.String,200),
					new MySqlParameter("@FNavigateUrl", MySqlDbType.String,200),
					new MySqlParameter("@FDescription", MySqlDbType.String,500),
					new MySqlParameter("@FSortIndex", MySqlDbType.Int32,4),
					new MySqlParameter("@FParentId", MySqlDbType.Int32,4),
					new MySqlParameter("@FViewPowerId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.FName;
			parameters[1].Value = model.FImageUrl;
			parameters[2].Value = model.FNavigateUrl;
			parameters[3].Value = model.FDescription;
			parameters[4].Value = model.FSortIndex;
			parameters[5].Value = model.FParentId;
			parameters[6].Value = model.FViewPowerId;

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
		public bool Update(FineOA.Model.t_Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_Menu set ");
			strSql.Append("FName=@FName,");
			strSql.Append("FImageUrl=@FImageUrl,");
			strSql.Append("FNavigateUrl=@FNavigateUrl,");
			strSql.Append("FDescription=@FDescription,");
			strSql.Append("FSortIndex=@FSortIndex");
			strSql.Append(" where FItemId=@FItemId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FName", MySqlDbType.String,50),
					new MySqlParameter("@FImageUrl", MySqlDbType.String,200),
					new MySqlParameter("@FNavigateUrl", MySqlDbType.String,200),
					new MySqlParameter("@FDescription", MySqlDbType.String,500),
					new MySqlParameter("@FSortIndex", MySqlDbType.Int32,4),
					new MySqlParameter("@FItemId", MySqlDbType.Int32,4),
					new MySqlParameter("@FParentId", MySqlDbType.Int32,4),
					new MySqlParameter("@FViewPowerId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.FName;
			parameters[1].Value = model.FImageUrl;
			parameters[2].Value = model.FNavigateUrl;
			parameters[3].Value = model.FDescription;
			parameters[4].Value = model.FSortIndex;
			parameters[5].Value = model.FItemId;
			parameters[6].Value = model.FParentId;
			parameters[7].Value = model.FViewPowerId;

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
			strSql.Append("delete from t_Menu ");
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
		public bool Delete(int FParentId,int FViewPowerId,int FItemId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Menu ");
			strSql.Append(" where FParentId=@FParentId and FViewPowerId=@FViewPowerId and FItemId=@FItemId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FParentId", MySqlDbType.Int32,4),
					new MySqlParameter("@FViewPowerId", MySqlDbType.Int32,4),
					new MySqlParameter("@FItemId", MySqlDbType.Int32,4)			};
			parameters[0].Value = FParentId;
			parameters[1].Value = FViewPowerId;
			parameters[2].Value = FItemId;

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
			strSql.Append("delete from t_Menu ");
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
		public FineOA.Model.t_Menu GetModel(int FItemId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FItemId,FName,FImageUrl,FNavigateUrl,FDescription,FSortIndex,FParentId,FViewPowerId from t_Menu ");
			strSql.Append(" where FItemId=@FItemId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FItemId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = FItemId;

			FineOA.Model.t_Menu model=new FineOA.Model.t_Menu();
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
		public FineOA.Model.t_Menu DataRowToModel(DataRow row)
		{
			FineOA.Model.t_Menu model=new FineOA.Model.t_Menu();
			if (row != null)
			{
				if(row["FItemId"]!=null && row["FItemId"].ToString()!="")
				{
					model.FItemId=int.Parse(row["FItemId"].ToString());
				}
				if(row["FName"]!=null)
				{
					model.FName=row["FName"].ToString();
				}
				if(row["FImageUrl"]!=null)
				{
					model.FImageUrl=row["FImageUrl"].ToString();
				}
				if(row["FNavigateUrl"]!=null)
				{
					model.FNavigateUrl=row["FNavigateUrl"].ToString();
				}
				if(row["FDescription"]!=null)
				{
					model.FDescription=row["FDescription"].ToString();
				}
				if(row["FSortIndex"]!=null && row["FSortIndex"].ToString()!="")
				{
					model.FSortIndex=int.Parse(row["FSortIndex"].ToString());
				}
				if(row["FParentId"]!=null && row["FParentId"].ToString()!="")
				{
					model.FParentId=int.Parse(row["FParentId"].ToString());
				}
				if(row["FViewPowerId"]!=null && row["FViewPowerId"].ToString()!="")
				{
					model.FViewPowerId=int.Parse(row["FViewPowerId"].ToString());
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
			strSql.Append("select FItemId,FName,FImageUrl,FNavigateUrl,FDescription,FSortIndex,FParentId,FViewPowerId ");
			strSql.Append(" FROM t_Menu ");
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
			strSql.Append(" FItemId,FName,FImageUrl,FNavigateUrl,FDescription,FSortIndex,FParentId,FViewPowerId ");
			strSql.Append(" FROM t_Menu ");
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
			strSql.Append("select count(1) FROM t_Menu ");
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
			strSql.Append(")AS Row, T.*  from t_Menu T ");
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
			parameters[0].Value = "t_Menu";
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

