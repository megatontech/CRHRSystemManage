using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_Department:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_Department
	{
		public t_Department()
		{}
		#region Model
		private int _fitemid;
		private int _fparentid;
		private string _fnumber;
		private string _fname;
		private string _fdescription;
		/// <summary>
		/// 表单ID
		/// </summary>
		public int FItemId
		{
			set{ _fitemid=value;}
			get{return _fitemid;}
		}
		/// <summary>
		/// 上级ID
		/// </summary>
		public int FParentId
		{
			set{ _fparentid=value;}
			get{return _fparentid;}
		}
		/// <summary>
		/// 部门编码
		/// </summary>
		public string FNumber
		{
			set{ _fnumber=value;}
			get{return _fnumber;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string FName
		{
			set{ _fname=value;}
			get{return _fname;}
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

