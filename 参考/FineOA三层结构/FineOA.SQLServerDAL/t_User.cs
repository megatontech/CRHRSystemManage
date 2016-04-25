using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FineOA.IDAL;
using FineOA.DBUtility;//Please add references
namespace FineOA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:t_User
	/// </summary>
	public partial class t_User:It_User
	{
		public t_User()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FDepartmentId", "t_User"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FDepartmentId,int FUserId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_User");
			strSql.Append(" where FDepartmentId=@FDepartmentId and FUserId=@FUserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FDepartmentId", SqlDbType.Int,4),
					new SqlParameter("@FUserId", SqlDbType.Int,4)			};
			parameters[0].Value = FDepartmentId;
			parameters[1].Value = FUserId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FineOA.Model.t_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_User(");
			strSql.Append("FUserName,FEmail,FPassword,FEnabled,FGender,FChineseName,FEnglishName,FPhoto,FQQ,FCompanyEmail,FOfficePhone,FOfficePhoneExt,FHomePhone,FCellPhone,FAddress,FDescription,FIdentityCard,FBirthday,FTakeOfficeTime,FLastLoginTime,FBuildDate,FDepartmentId)");
			strSql.Append(" values (");
			strSql.Append("@FUserName,@FEmail,@FPassword,@FEnabled,@FGender,@FChineseName,@FEnglishName,@FPhoto,@FQQ,@FCompanyEmail,@FOfficePhone,@FOfficePhoneExt,@FHomePhone,@FCellPhone,@FAddress,@FDescription,@FIdentityCard,@FBirthday,@FTakeOfficeTime,@FLastLoginTime,@FBuildDate,@FDepartmentId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@FEmail", SqlDbType.NVarChar,100),
					new SqlParameter("@FPassword", SqlDbType.NVarChar,50),
					new SqlParameter("@FEnabled", SqlDbType.Bit,1),
					new SqlParameter("@FGender", SqlDbType.NVarChar,10),
					new SqlParameter("@FChineseName", SqlDbType.NVarChar,100),
					new SqlParameter("@FEnglishName", SqlDbType.NVarChar,100),
					new SqlParameter("@FPhoto", SqlDbType.NVarChar,200),
					new SqlParameter("@FQQ", SqlDbType.NVarChar,50),
					new SqlParameter("@FCompanyEmail", SqlDbType.NVarChar,100),
					new SqlParameter("@FOfficePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@FOfficePhoneExt", SqlDbType.NVarChar,50),
					new SqlParameter("@FHomePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@FCellPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@FAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@FDescription", SqlDbType.NVarChar,500),
					new SqlParameter("@FIdentityCard", SqlDbType.NVarChar,50),
					new SqlParameter("@FBirthday", SqlDbType.DateTime),
					new SqlParameter("@FTakeOfficeTime", SqlDbType.DateTime),
					new SqlParameter("@FLastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@FBuildDate", SqlDbType.DateTime),
					new SqlParameter("@FDepartmentId", SqlDbType.Int,4)};
			parameters[0].Value = model.FUserName;
			parameters[1].Value = model.FEmail;
			parameters[2].Value = model.FPassword;
			parameters[3].Value = model.FEnabled;
			parameters[4].Value = model.FGender;
			parameters[5].Value = model.FChineseName;
			parameters[6].Value = model.FEnglishName;
			parameters[7].Value = model.FPhoto;
			parameters[8].Value = model.FQQ;
			parameters[9].Value = model.FCompanyEmail;
			parameters[10].Value = model.FOfficePhone;
			parameters[11].Value = model.FOfficePhoneExt;
			parameters[12].Value = model.FHomePhone;
			parameters[13].Value = model.FCellPhone;
			parameters[14].Value = model.FAddress;
			parameters[15].Value = model.FDescription;
			parameters[16].Value = model.FIdentityCard;
			parameters[17].Value = model.FBirthday;
			parameters[18].Value = model.FTakeOfficeTime;
			parameters[19].Value = model.FLastLoginTime;
			parameters[20].Value = model.FBuildDate;
			parameters[21].Value = model.FDepartmentId;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(FineOA.Model.t_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_User set ");
			strSql.Append("FUserName=@FUserName,");
			strSql.Append("FEmail=@FEmail,");
			strSql.Append("FPassword=@FPassword,");
			strSql.Append("FEnabled=@FEnabled,");
			strSql.Append("FGender=@FGender,");
			strSql.Append("FChineseName=@FChineseName,");
			strSql.Append("FEnglishName=@FEnglishName,");
			strSql.Append("FPhoto=@FPhoto,");
			strSql.Append("FQQ=@FQQ,");
			strSql.Append("FCompanyEmail=@FCompanyEmail,");
			strSql.Append("FOfficePhone=@FOfficePhone,");
			strSql.Append("FOfficePhoneExt=@FOfficePhoneExt,");
			strSql.Append("FHomePhone=@FHomePhone,");
			strSql.Append("FCellPhone=@FCellPhone,");
			strSql.Append("FAddress=@FAddress,");
			strSql.Append("FDescription=@FDescription,");
			strSql.Append("FIdentityCard=@FIdentityCard,");
			strSql.Append("FBirthday=@FBirthday,");
			strSql.Append("FTakeOfficeTime=@FTakeOfficeTime,");
			strSql.Append("FLastLoginTime=@FLastLoginTime,");
			strSql.Append("FBuildDate=@FBuildDate");
			strSql.Append(" where FUserId=@FUserId");
			SqlParameter[] parameters = {
					new SqlParameter("@FUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@FEmail", SqlDbType.NVarChar,100),
					new SqlParameter("@FPassword", SqlDbType.NVarChar,50),
					new SqlParameter("@FEnabled", SqlDbType.Bit,1),
					new SqlParameter("@FGender", SqlDbType.NVarChar,10),
					new SqlParameter("@FChineseName", SqlDbType.NVarChar,100),
					new SqlParameter("@FEnglishName", SqlDbType.NVarChar,100),
					new SqlParameter("@FPhoto", SqlDbType.NVarChar,200),
					new SqlParameter("@FQQ", SqlDbType.NVarChar,50),
					new SqlParameter("@FCompanyEmail", SqlDbType.NVarChar,100),
					new SqlParameter("@FOfficePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@FOfficePhoneExt", SqlDbType.NVarChar,50),
					new SqlParameter("@FHomePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@FCellPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@FAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@FDescription", SqlDbType.NVarChar,500),
					new SqlParameter("@FIdentityCard", SqlDbType.NVarChar,50),
					new SqlParameter("@FBirthday", SqlDbType.DateTime),
					new SqlParameter("@FTakeOfficeTime", SqlDbType.DateTime),
					new SqlParameter("@FLastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@FBuildDate", SqlDbType.DateTime),
					new SqlParameter("@FUserId", SqlDbType.Int,4),
					new SqlParameter("@FDepartmentId", SqlDbType.Int,4)};
			parameters[0].Value = model.FUserName;
			parameters[1].Value = model.FEmail;
			parameters[2].Value = model.FPassword;
			parameters[3].Value = model.FEnabled;
			parameters[4].Value = model.FGender;
			parameters[5].Value = model.FChineseName;
			parameters[6].Value = model.FEnglishName;
			parameters[7].Value = model.FPhoto;
			parameters[8].Value = model.FQQ;
			parameters[9].Value = model.FCompanyEmail;
			parameters[10].Value = model.FOfficePhone;
			parameters[11].Value = model.FOfficePhoneExt;
			parameters[12].Value = model.FHomePhone;
			parameters[13].Value = model.FCellPhone;
			parameters[14].Value = model.FAddress;
			parameters[15].Value = model.FDescription;
			parameters[16].Value = model.FIdentityCard;
			parameters[17].Value = model.FBirthday;
			parameters[18].Value = model.FTakeOfficeTime;
			parameters[19].Value = model.FLastLoginTime;
			parameters[20].Value = model.FBuildDate;
			parameters[21].Value = model.FUserId;
			parameters[22].Value = model.FDepartmentId;

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
		public bool Delete(int FUserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_User ");
			strSql.Append(" where FUserId=@FUserId");
			SqlParameter[] parameters = {
					new SqlParameter("@FUserId", SqlDbType.Int,4)
			};
			parameters[0].Value = FUserId;

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
		public bool Delete(int FDepartmentId,int FUserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_User ");
			strSql.Append(" where FDepartmentId=@FDepartmentId and FUserId=@FUserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FDepartmentId", SqlDbType.Int,4),
					new SqlParameter("@FUserId", SqlDbType.Int,4)			};
			parameters[0].Value = FDepartmentId;
			parameters[1].Value = FUserId;

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
		public bool DeleteList(string FUserIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_User ");
			strSql.Append(" where FUserId in ("+FUserIdlist + ")  ");
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
		public FineOA.Model.t_User GetModel(int FUserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FUserId,FUserName,FEmail,FPassword,FEnabled,FGender,FChineseName,FEnglishName,FPhoto,FQQ,FCompanyEmail,FOfficePhone,FOfficePhoneExt,FHomePhone,FCellPhone,FAddress,FDescription,FIdentityCard,FBirthday,FTakeOfficeTime,FLastLoginTime,FBuildDate,FDepartmentId from t_User ");
			strSql.Append(" where FUserId=@FUserId");
			SqlParameter[] parameters = {
					new SqlParameter("@FUserId", SqlDbType.Int,4)
			};
			parameters[0].Value = FUserId;

			FineOA.Model.t_User model=new FineOA.Model.t_User();
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
		public FineOA.Model.t_User DataRowToModel(DataRow row)
		{
			FineOA.Model.t_User model=new FineOA.Model.t_User();
			if (row != null)
			{
				if(row["FUserId"]!=null && row["FUserId"].ToString()!="")
				{
					model.FUserId=int.Parse(row["FUserId"].ToString());
				}
				if(row["FUserName"]!=null)
				{
					model.FUserName=row["FUserName"].ToString();
				}
				if(row["FEmail"]!=null)
				{
					model.FEmail=row["FEmail"].ToString();
				}
				if(row["FPassword"]!=null)
				{
					model.FPassword=row["FPassword"].ToString();
				}
				if(row["FEnabled"]!=null && row["FEnabled"].ToString()!="")
				{
					if((row["FEnabled"].ToString()=="1")||(row["FEnabled"].ToString().ToLower()=="true"))
					{
						model.FEnabled=true;
					}
					else
					{
						model.FEnabled=false;
					}
				}
				if(row["FGender"]!=null)
				{
					model.FGender=row["FGender"].ToString();
				}
				if(row["FChineseName"]!=null)
				{
					model.FChineseName=row["FChineseName"].ToString();
				}
				if(row["FEnglishName"]!=null)
				{
					model.FEnglishName=row["FEnglishName"].ToString();
				}
				if(row["FPhoto"]!=null)
				{
					model.FPhoto=row["FPhoto"].ToString();
				}
				if(row["FQQ"]!=null)
				{
					model.FQQ=row["FQQ"].ToString();
				}
				if(row["FCompanyEmail"]!=null)
				{
					model.FCompanyEmail=row["FCompanyEmail"].ToString();
				}
				if(row["FOfficePhone"]!=null)
				{
					model.FOfficePhone=row["FOfficePhone"].ToString();
				}
				if(row["FOfficePhoneExt"]!=null)
				{
					model.FOfficePhoneExt=row["FOfficePhoneExt"].ToString();
				}
				if(row["FHomePhone"]!=null)
				{
					model.FHomePhone=row["FHomePhone"].ToString();
				}
				if(row["FCellPhone"]!=null)
				{
					model.FCellPhone=row["FCellPhone"].ToString();
				}
				if(row["FAddress"]!=null)
				{
					model.FAddress=row["FAddress"].ToString();
				}
				if(row["FDescription"]!=null)
				{
					model.FDescription=row["FDescription"].ToString();
				}
				if(row["FIdentityCard"]!=null)
				{
					model.FIdentityCard=row["FIdentityCard"].ToString();
				}
				if(row["FBirthday"]!=null && row["FBirthday"].ToString()!="")
				{
					model.FBirthday=DateTime.Parse(row["FBirthday"].ToString());
				}
				if(row["FTakeOfficeTime"]!=null && row["FTakeOfficeTime"].ToString()!="")
				{
					model.FTakeOfficeTime=DateTime.Parse(row["FTakeOfficeTime"].ToString());
				}
				if(row["FLastLoginTime"]!=null && row["FLastLoginTime"].ToString()!="")
				{
					model.FLastLoginTime=DateTime.Parse(row["FLastLoginTime"].ToString());
				}
				if(row["FBuildDate"]!=null && row["FBuildDate"].ToString()!="")
				{
					model.FBuildDate=DateTime.Parse(row["FBuildDate"].ToString());
				}
				if(row["FDepartmentId"]!=null && row["FDepartmentId"].ToString()!="")
				{
					model.FDepartmentId=int.Parse(row["FDepartmentId"].ToString());
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
			strSql.Append("select FUserId,FUserName,FEmail,FPassword,FEnabled,FGender,FChineseName,FEnglishName,FPhoto,FQQ,FCompanyEmail,FOfficePhone,FOfficePhoneExt,FHomePhone,FCellPhone,FAddress,FDescription,FIdentityCard,FBirthday,FTakeOfficeTime,FLastLoginTime,FBuildDate,FDepartmentId ");
			strSql.Append(" FROM t_User ");
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
			strSql.Append(" FUserId,FUserName,FEmail,FPassword,FEnabled,FGender,FChineseName,FEnglishName,FPhoto,FQQ,FCompanyEmail,FOfficePhone,FOfficePhoneExt,FHomePhone,FCellPhone,FAddress,FDescription,FIdentityCard,FBirthday,FTakeOfficeTime,FLastLoginTime,FBuildDate,FDepartmentId ");
			strSql.Append(" FROM t_User ");
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
			strSql.Append("select count(1) FROM t_User ");
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
				strSql.Append("order by T.FUserId desc");
			}
			strSql.Append(")AS Row, T.*  from t_User T ");
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
			parameters[0].Value = "t_User";
			parameters[1].Value = "FUserId";
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

