using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_Role:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_Role
	{
		public t_Role()
		{}
		#region Model
		private int _froleid;
		private string _frolename;
		private string _fdescription;
		/// <summary>
		/// 角色ID
		/// </summary>
		public int FRoleId
		{
			set{ _froleid=value;}
			get{return _froleid;}
		}
		/// <summary>
		/// 角色名
		/// </summary>
		public string FRoleName
		{
			set{ _frolename=value;}
			get{return _frolename;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string FDescription
		{
			set{ _fdescription=value;}
			get{return _fdescription;}
		}
		#endregion Model

	}
}

