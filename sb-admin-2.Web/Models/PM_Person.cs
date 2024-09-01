
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_PersonMetaData))]
  public partial class PM_Person
   {
   }
   public class PM_PersonMetaData
    {
        [Display(Name = "PM_PersonID")]
        //[Required (ErrorMessage =" PM_PersonID را وارد نمائيد ")]
		public int PM_PersonID { get; set; } 
		
        [Display(Name = "نام")]
        //[Required (ErrorMessage =" نام را وارد نمائيد ")]
		public string Name { get; set; } 
		
        [Display(Name = "نام خانوادگي")]
        //[Required (ErrorMessage =" نام خانوادگي را وارد نمائيد ")]
		public string family { get; set; } 
		
        [Display(Name = "مهارت")]
        //[Required (ErrorMessage =" مهارت را وارد نمائيد ")]
		public int? Id_Skill { get; set; }

        [Display(Name = "مهارت")]
        //[Required (ErrorMessage =" مهارت را وارد نمائيد ")]
        public string SkillName { get; set; }

        [Display(Name = "کد پرسنلي")]
        //[Required (ErrorMessage =" کد پرسنلي را وارد نمائيد ")]
		public string Personalcode { get; set; } 
		
        [Display(Name = "کارخانه")]
        //[Required (ErrorMessage =" کارخانه را وارد نمائيد ")]
		public int? Id_Factory { get; set; } 
		
        [Display(Name = "تصوير")]
        //[Required (ErrorMessage =" تصوير را وارد نمائيد ")]
		public string Image { get; set; } 
		
        [Display(Name = "Creator")]
        //[Required (ErrorMessage =" Creator را وارد نمائيد ")]
		public string Creator { get; set; } 
		
        [Display(Name = "Ctime")]
        //[Required (ErrorMessage =" Ctime را وارد نمائيد ")]
		public string Ctime { get; set; } 
		
        [Display(Name = "Modifier")]
        //[Required (ErrorMessage =" Modifier را وارد نمائيد ")]
		public string Modifier { get; set; } 
		
        [Display(Name = "Mtime")]
        //[Required (ErrorMessage =" Mtime را وارد نمائيد ")]
		public string Mtime { get; set; } 
		
        [Display(Name = "فعال")]
        //[Required (ErrorMessage =" فعال را وارد نمائيد ")]
		public bool IsEnabled { get; set; } 
		
        [Display(Name = "IsDeleted")]
        //[Required (ErrorMessage =" IsDeleted را وارد نمائيد ")]
		public bool IsDeleted { get; set; } 
		
   }
 }


