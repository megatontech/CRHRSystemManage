using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_Online:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_Online
	{
		public t_Online()
		{}
		#region Model
		private int _fitemid;
		private string _fipadddress;
		private DateTime _flogintime;
		private DateTime? _fupdatetime;
		private int _fuserid;
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
		public string FIPAdddress
		{
			set{ _fipadddress=value;}
			get{return _fipadddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime FLoginTime
		{
			set{ _flogintime=value;}
			get{return _flogintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FUpdateTime
		{
			set{ _fupdatetime=value;}
			get{return _fupdatetime;}
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

