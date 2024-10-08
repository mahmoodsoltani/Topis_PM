
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_DepartmentMetaData))]
  public partial class PM_Department
   {
   }
   public class PM_DepartmentMetaData
    {
        [Display(Name = "PM_DepartmentID")]
        //[Required (ErrorMessage =" PM_DepartmentID را وارد نمائيد ")]
		public int PM_DepartmentID { get; set; } 
		
        [Display(Name = "نام")]
        [Required (ErrorMessage =" نام را وارد نمائيد ")]
		public string Name { get; set; } 
		
        [Display(Name = "کارخانه")]
     //   [Required (ErrorMessage =" کارخانه را وارد نمائيد ")]
		public int? ID_Factory { get; set; }

        [Display(Name = "نام کارخانه")]
        //[Required (ErrorMessage =" کارخانه را وارد نمائيد ")]
        public string  FactoryName { get; set; }

        [Display(Name = "آدرس")]
        //[Required (ErrorMessage =" آدرس را وارد نمائيد ")]
		public string Address { get; set; } 
		
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


