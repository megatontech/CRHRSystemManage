using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_BillNo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_BillNo
	{
		public t_BillNo()
		{}
		#region Model
		private int _fitemid;
		private string _fbillname;
		private string _ftablename;
		private string _fpreletter;
		private int _fcurid;
		private string _fsufletter;
		private string _fformat;
		private int _flen;
		private int _ftrantype;
		/// <summary>
		/// 表单ID
		/// </summary>
		public int FItemId
		{
			set{ _fitemid=value;}
			get{return _fitemid;}
		}
		/// <summary>
		/// 表名称
		/// </summary>
		public string FBillName
		{
			set{ _fbillname=value;}
			get{return _fbillname;}
		}
		/// <summary>
		/// 单据名称
		/// </summary>
		public string FTableName
		{
			set{ _ftablename=value;}
			get{return _ftablename;}
		}
		/// <summary>
		/// 前缀
		/// </summary>
		public string FPreLetter
		{
			set{ _fpreletter=value;}
			get{return _fpreletter;}
		}
		/// <summary>
		/// 当前表单ID
		/// </summary>
		public int FCurId
		{
			set{ _fcurid=value;}
			get{return _fcurid;}
		}
		/// <summary>
		/// 后缀
		/// </summary>
		public string FSufLetter
		{
			set{ _fsufletter=value;}
			get{return _fsufletter;}
		}
		/// <summary>
		/// 编码格式
		/// </summary>
		public string FFormat
		{
			set{ _fformat=value;}
			get{return _fformat;}
		}
		/// <summary>
		/// 编码长度
		/// </summary>
		public int FLen
		{
			set{ _flen=value;}
			get{return _flen;}
		}
		/// <summary>
		/// 单据类型ID
		/// </summary>
		public int FTranType
		{
			set{ _ftrantype=value;}
			get{return _ftrantype;}
		}
		#endregion Model

	}
}

