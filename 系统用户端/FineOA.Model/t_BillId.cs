using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_BillId:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_BillId
	{
		public t_BillId()
		{}
		#region Model
		private string _fbillname;
		private int _fmaxid;
		/// <summary>
		/// 表单名称
		/// </summary>
		public string FBillName
		{
			set{ _fbillname=value;}
			get{return _fbillname;}
		}
		/// <summary>
		/// 当前最大ID
		/// </summary>
		public int FMaxId
		{
			set{ _fmaxid=value;}
			get{return _fmaxid;}
		}
		#endregion Model

	}
}

