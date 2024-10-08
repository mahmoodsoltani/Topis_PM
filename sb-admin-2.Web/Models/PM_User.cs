
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_UserMetaData))]
  public partial class PM_User
   {
   }
   public class PM_UserMetaData
    {
        [Display(Name = "PM_UserID")]
        //[Required (ErrorMessage =" PM_UserID را وارد نمائيد ")]
		public int PM_UserID { get; set; } 
		
        [Display(Name = "نام کاربري")]
        //[Required (ErrorMessage =" نام کاربري را وارد نمائيد ")]
		public string UserName { get; set; }
  [Display(Name = "نقش کاربری")]
        //[Required (ErrorMessage =" نام کاربري را وارد نمائيد ")]
		public string RoleName { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        public string PersonName { get; set; }
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        //[Required (ErrorMessage =" کلمه عبور را وارد نمائيد ")]
        public string PassWord { get; set; } 
		
        [Display(Name = "پرسنل")]
        //[Required (ErrorMessage =" پرسنل را وارد نمائيد ")]
		public int? ID_Person { get; set; } 
		
        [Display(Name = "پست")]
        //[Required (ErrorMessage =" پست را وارد نمائيد ")]
		public int? Id_Role { get; set; }

        [Display(Name = "Ctime")]
        //[Required (ErrorMessage =" Ctime را وارد نمائيد ")]
        public string Ctime { get; set; }

        [Display(Name = "Creator")]
        //[Required (ErrorMessage =" Ctime را وارد نمائيد ")]
        public string Creator { get; set; }

        [Display(Name = "Modifier")]
        //[Required (ErrorMessage =" Modifier را وارد نمائيد ")]
		public string Modifier { get; set; } 
		
        [Display(Name = "Mtime")]
        //[Required (ErrorMessage =" Mtime را وارد نمائيد ")]
		public string Mtime { get; set; } 
		
        [Display(Name = "فعال")]
        //[Required (ErrorMessage =" فعال را وارد نمائيد ")]
		public bool Is_Public { get; set; } 

        [Display(Name = "فعال")]
        //[Required (ErrorMessage =" فعال را وارد نمائيد ")]
		public bool IsEnabled { get; set; } 		
        [Display(Name = "IsDeleted")]
        //[Required (ErrorMessage =" IsDeleted را وارد نمائيد ")]
		public bool IsDeleted { get; set; } 
		
   }
 }


