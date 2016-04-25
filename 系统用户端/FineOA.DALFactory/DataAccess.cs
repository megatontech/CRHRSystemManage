using System;
using System.Reflection;
using System.Configuration;
namespace FineOA.DALFactory
{
	/// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
	/// </summary>
	public sealed class DataAccess 
	{
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];        
		public DataAccess()
		{ }

        #region CreateObject 

		//不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath,string classNamespace)
		{		
			try
			{
				object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);	
				return objType;
			}
			catch//(System.Exception ex)
			{
				//string str=ex.Message;// 记录错误日志
				return null;
			}			
			
        }
		//使用缓存
		private static object CreateObject(string AssemblyPath,string classNamespace)
		{			
			object objType = DataCache.GetCache(classNamespace);
			if (objType == null)
			{
				try
				{
					objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);					
					DataCache.SetCache(classNamespace, objType);// 写入缓存
				}
				catch(System.Exception ex)
				{
					string str=ex.Message;// 记录错误日志
				}
			}
			return objType;
		}
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

   
		/// <summary>
		/// 创建t_BillId数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_BillId Createt_BillId()
		{

			string ClassNamespace = AssemblyPath +".t_BillId";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_BillId)objType;
		}


		/// <summary>
		/// 创建t_BillNo数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_BillNo Createt_BillNo()
		{

			string ClassNamespace = AssemblyPath +".t_BillNo";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_BillNo)objType;
		}


		/// <summary>
		/// 创建t_Config数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_Config Createt_Config()
		{

			string ClassNamespace = AssemblyPath +".t_Config";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_Config)objType;
		}


		/// <summary>
		/// 创建t_Department数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_Department Createt_Department()
		{

			string ClassNamespace = AssemblyPath +".t_Department";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_Department)objType;
		}


		/// <summary>
		/// 创建t_Log数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_Log Createt_Log()
		{

			string ClassNamespace = AssemblyPath +".t_Log";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_Log)objType;
		}


		/// <summary>
		/// 创建t_Menu数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_Menu Createt_Menu()
		{

			string ClassNamespace = AssemblyPath +".t_Menu";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_Menu)objType;
		}


		/// <summary>
		/// 创建t_Online数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_Online Createt_Online()
		{

			string ClassNamespace = AssemblyPath +".t_Online";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_Online)objType;
		}


		/// <summary>
		/// 创建t_Power数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_Power Createt_Power()
		{

			string ClassNamespace = AssemblyPath +".t_Power";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_Power)objType;
		}


		/// <summary>
		/// 创建t_Role数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_Role Createt_Role()
		{

			string ClassNamespace = AssemblyPath +".t_Role";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_Role)objType;
		}


		/// <summary>
		/// 创建t_RolePower数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_RolePower Createt_RolePower()
		{

			string ClassNamespace = AssemblyPath +".t_RolePower";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_RolePower)objType;
		}


		/// <summary>
		/// 创建t_RoleUser数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_RoleUser Createt_RoleUser()
		{

			string ClassNamespace = AssemblyPath +".t_RoleUser";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_RoleUser)objType;
		}


		/// <summary>
		/// 创建t_SubMessage数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_SubMessage Createt_SubMessage()
		{

			string ClassNamespace = AssemblyPath +".t_SubMessage";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_SubMessage)objType;
		}


		/// <summary>
		/// 创建t_User数据层接口。
		/// </summary>
		public static FineOA.IDAL.It_User Createt_User()
		{

			string ClassNamespace = AssemblyPath +".t_User";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (FineOA.IDAL.It_User)objType;
		}

}
}