using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_SubMessage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_SubMessage
	{
		public t_SubMessage()
		{}
		#region Model
		private int _fitemid;
		private int _fparentid;
		private string _fname;
		private int _ftype;
		private bool _fdetail;
		private string _fdescription;
		/// <summary>
		/// 
		/// </summary>
		public int FItemId
		{
			set{ _fitemid=value;}
			get{return _fitemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FParentId
		{
			set{ _fparentid=value;}
			get{return _fparentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FName
		{
			set{ _fname=value;}
			get{return _fname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FType
		{
			set{ _ftype=value;}
			get{return _ftype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool FDetail
		{
			set{ _fdetail=value;}
			get{return _fdetail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FDescription
		{
			set{ _fdescription=value;}
			get{return _fdescription;}
		}
		#endregion Model

	}
}

