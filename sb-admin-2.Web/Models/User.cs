
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(UserMetaData))]
  public partial class User
   {
   }
   public class UserMetaData
    {
        [Display(Name = "کدکابر")]
        //[Required (ErrorMessage =" کدکابر را وارد نمائيد ")]
		public string user_id { get; set; } 
		
        [Display(Name = "شناسه")]
        //[Required (ErrorMessage =" شناسه را وارد نمائيد ")]
		public string account { get; set; } 
		
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        [Required (ErrorMessage =" کلمه عبور را وارد نمائيد ")]
		public string password { get; set; } 
		
        [Display(Name = "نام کاربري")]
        [Required (ErrorMessage =" نام کاربري را وارد نمائيد ")]
		public string username { get; set; } 
		
        [Display(Name = "توضيحات")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
		public string description { get; set; } 
		
        [Display(Name = "tags")]
        //[Required (ErrorMessage =" tags را وارد نمائيد ")]
		public string tags { get; set; } 
		
        [Display(Name = "شماره تلفن")]
        //[Required (ErrorMessage =" شماره تلفن را وارد نمائيد ")]
		public string phone_no { get; set; } 
		
        [Display(Name = "شماره همراه")]
        //[Required (ErrorMessage =" شماره همراه را وارد نمائيد ")]
		public string mobile_no { get; set; } 
		
        [Display(Name = "آدرس ايميل")]
        //[Required (ErrorMessage =" آدرس ايميل را وارد نمائيد ")]
		public string email { get; set; } 
		
        [Display(Name = "آدرس")]
        //[Required (ErrorMessage =" آدرس را وارد نمائيد ")]
		public string locale { get; set; } 
		
        [Display(Name = "تصوير")]
        //[Required (ErrorMessage =" تصوير را وارد نمائيد ")]
		public string thumbnail_photo { get; set; } 
		
        [Display(Name = "تعداد تلاش ناموفق")]
        //[Required (ErrorMessage =" تعداد تلاش ناموفق را وارد نمائيد ")]
		public int? RetryAttemps { get; set; } 
		
        [Display(Name = "بلاک شده؟")]
        //[Required (ErrorMessage =" بلاک شده؟ را وارد نمائيد ")]
		public bool? IsLocked { get; set; } 
		
        [Display(Name = "تاريخ بلاک")]
        //[Required (ErrorMessage =" تاريخ بلاک را وارد نمائيد ")]
		public DateTime? LockedDateTime { get; set; } 
		
        [Display(Name = "دريافت ايميل؟")]
        //[Required (ErrorMessage =" دريافت ايميل؟ را وارد نمائيد ")]
		public int? is_recieve_email { get; set; } 
		
        [Display(Name = "تاريخ آخرين ورود")]
        //[Required (ErrorMessage =" تاريخ آخرين ورود را وارد نمائيد ")]
		public DateTime? last_login { get; set; } 
		
        [Display(Name = "تاريخ آخرين خروج")]
        //[Required (ErrorMessage =" تاريخ آخرين خروج را وارد نمائيد ")]
		public DateTime? last_logout { get; set; } 
		
        [Display(Name = "تاييد کننده")]
        //[Required (ErrorMessage =" تاييد کننده را وارد نمائيد ")]
		public string approver { get; set; } 
		
        [Display(Name = "وضعيت تاييد")]
        //[Required (ErrorMessage =" وضعيت تاييد را وارد نمائيد ")]
		public int approval_status { get; set; } 
		
        [Display(Name = "حذف شده؟")]
        //[Required (ErrorMessage =" حذف شده؟ را وارد نمائيد ")]
		public int is_deleted { get; set; } 
		
        [Display(Name = "تاييد خودکار؟")]
        //[Required (ErrorMessage =" تاييد خودکار؟ را وارد نمائيد ")]
		public int? auto_approval { get; set; } 
		
        [Display(Name = "ايجاد کننده")]
        //[Required (ErrorMessage =" ايجاد کننده را وارد نمائيد ")]
		public string Creator { get; set; } 
		
        [Display(Name = "تاريخ ايجاد")]
        //[Required (ErrorMessage =" تاريخ ايجاد را وارد نمائيد ")]
		public string Ctime { get; set; } 
		
        [Display(Name = "ويرايش کننده")]
        //[Required (ErrorMessage =" ويرايش کننده را وارد نمائيد ")]
		public string Modifier { get; set; } 
		
        [Display(Name = "تاريخ ويرايش")]
        //[Required (ErrorMessage =" تاريخ ويرايش را وارد نمائيد ")]
		public string Mtime { get; set; }

        [Display(Name = "خطای ورود")]
        public string LoginErrorMessage { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password1")]
        //public string Password1 { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password1", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

    }
 }


