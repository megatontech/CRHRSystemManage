using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_Power:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_Power
	{
		public t_Power()
		{}
		#region Model
		private int _fpowerid;
		private string _fname;
		private string _fgroupname;
		private string _ftitle;
		private string _fdescription;
		/// <summary>
		/// 
		/// </summary>
		public int FPowerId
		{
			set{ _fpowerid=value;}
			get{return _fpowerid;}
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
		public string FGroupName
		{
			set{ _fgroupname=value;}
			get{return _fgroupname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FTitle
		{
			set{ _ftitle=value;}
			get{return _ftitle;}
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

