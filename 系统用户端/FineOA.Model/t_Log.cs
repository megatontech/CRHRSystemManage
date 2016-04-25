using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_Log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_Log
	{
		public t_Log()
		{}
		#region Model
		private int _fitemid;
		private string _flevel;
		private string _flogger;
		private string _fmessage;
		private string _fexception;
		private DateTime _flogtime;
		/// <summary>
		/// 表单ID
		/// </summary>
		public int FItemId
		{
			set{ _fitemid=value;}
			get{return _fitemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLevel
		{
			set{ _flevel=value;}
			get{return _flevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLogger
		{
			set{ _flogger=value;}
			get{return _flogger;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FMessage
		{
			set{ _fmessage=value;}
			get{return _fmessage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FException
		{
			set{ _fexception=value;}
			get{return _fexception;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime FLogTime
		{
			set{ _flogtime=value;}
			get{return _flogtime;}
		}
		#endregion Model

	}
}

