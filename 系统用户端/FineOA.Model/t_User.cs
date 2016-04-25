using System;
namespace FineOA.Model
{
	/// <summary>
	/// t_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_User
	{
		public t_User()
		{}
		#region Model
		private int _fuserid;
		private string _fusername;
		private string _femail;
		private string _fpassword;
		private bool _fenabled;
		private string _fgender;
		private string _fchinesename;
		private string _fenglishname;
		private string _fphoto;
		private string _fqq;
		private string _fcompanyemail;
		private string _fofficephone;
		private string _fofficephoneext;
		private string _fhomephone;
		private string _fcellphone;
		private string _faddress;
		private string _fdescription;
		private string _fidentitycard;
		private DateTime? _fbirthday;
		private DateTime? _ftakeofficetime;
		private DateTime? _flastlogintime;
		private DateTime? _fbuilddate;
		private int _fdepartmentid;
		/// <summary>
		/// 
		/// </summary>
		public int FUserId
		{
			set{ _fuserid=value;}
			get{return _fuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FUserName
		{
			set{ _fusername=value;}
			get{return _fusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FEmail
		{
			set{ _femail=value;}
			get{return _femail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FPassword
		{
			set{ _fpassword=value;}
			get{return _fpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool FEnabled
		{
			set{ _fenabled=value;}
			get{return _fenabled;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FGender
		{
			set{ _fgender=value;}
			get{return _fgender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FChineseName
		{
			set{ _fchinesename=value;}
			get{return _fchinesename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FEnglishName
		{
			set{ _fenglishname=value;}
			get{return _fenglishname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FPhoto
		{
			set{ _fphoto=value;}
			get{return _fphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FQQ
		{
			set{ _fqq=value;}
			get{return _fqq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FCompanyEmail
		{
			set{ _fcompanyemail=value;}
			get{return _fcompanyemail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FOfficePhone
		{
			set{ _fofficephone=value;}
			get{return _fofficephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FOfficePhoneExt
		{
			set{ _fofficephoneext=value;}
			get{return _fofficephoneext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FHomePhone
		{
			set{ _fhomephone=value;}
			get{return _fhomephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FCellPhone
		{
			set{ _fcellphone=value;}
			get{return _fcellphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FAddress
		{
			set{ _faddress=value;}
			get{return _faddress;}
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
		public string FIdentityCard
		{
			set{ _fidentitycard=value;}
			get{return _fidentitycard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FBirthday
		{
			set{ _fbirthday=value;}
			get{return _fbirthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FTakeOfficeTime
		{
			set{ _ftakeofficetime=value;}
			get{return _ftakeofficetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FLastLoginTime
		{
			set{ _flastlogintime=value;}
			get{return _flastlogintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FBuildDate
		{
			set{ _fbuilddate=value;}
			get{return _fbuilddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FDepartmentId
		{
			set{ _fdepartmentid=value;}
			get{return _fdepartmentid;}
		}
		#endregion Model

	}
}

