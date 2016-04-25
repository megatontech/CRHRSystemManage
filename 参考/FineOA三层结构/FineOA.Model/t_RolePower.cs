using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_RolePower:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_RolePower
	{
		public t_RolePower()
		{}
		#region Model
		private int _froleid;
		private int _fpowerid;
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
		public int FPowerId
		{
			set{ _fpowerid=value;}
			get{return _fpowerid;}
		}
		#endregion Model

	}
}

