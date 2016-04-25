using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_RoleUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_RoleUser
	{
		public t_RoleUser()
		{}
		#region Model
		private int _froleid;
		private int _fuserid;
		/// <summary>
		/// 
		/// </summary>
		public int FRoleId
		{
			set{ _froleid=value;}
			get{return _froleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FUserId
		{
			set{ _fuserid=value;}
			get{return _fuserid;}
		}
		#endregion Model

	}
}

