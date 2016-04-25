using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_Config:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_Config
	{
		public t_Config()
		{}
		#region Model
		private int _fitemid;
		private string _fconfigkey;
		private string _fconfigvalue;
		private string _fdescription;
		/// <summary>
		/// 表ID
		/// </summary>
		public int FItemId
		{
			set{ _fitemid=value;}
			get{return _fitemid;}
		}
		/// <summary>
		/// 配置类型
		/// </summary>
		public string FConfigKey
		{
			set{ _fconfigkey=value;}
			get{return _fconfigkey;}
		}
		/// <summary>
		/// 配置内容
		/// </summary>
		public string FConfigValue
		{
			set{ _fconfigvalue=value;}
			get{return _fconfigvalue;}
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

