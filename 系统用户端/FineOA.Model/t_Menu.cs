using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_Menu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_Menu
	{
		public t_Menu()
		{}
		#region Model
		private int _fitemid;
		private string _fname;
		private string _fimageurl;
		private string _fnavigateurl;
		private string _fdescription;
		private int _fsortindex;
		private int _fparentid;
		private int _fviewpowerid;
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
		public string FName
		{
			set{ _fname=value;}
			get{return _fname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FImageUrl
		{
			set{ _fimageurl=value;}
			get{return _fimageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FNavigateUrl
		{
			set{ _fnavigateurl=value;}
			get{return _fnavigateurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FDescription
		{
			set{ _fdescription=value;}
			get{return _fdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FSortIndex
		{
			set{ _fsortindex=value;}
			get{return _fsortindex;}
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
		public int FViewPowerId
		{
			set{ _fviewpowerid=value;}
			get{return _fviewpowerid;}
		}
		#endregion Model
	}
}

