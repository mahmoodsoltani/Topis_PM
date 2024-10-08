
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_FactoryMetaData))]
  public partial class PM_Factory
   {
   }
   public class PM_FactoryMetaData
    {
        [Display(Name = "PM_FactoryID")]
        //[Required (ErrorMessage =" PM_FactoryID را وارد نمائيد ")]
		public int PM_FactoryID { get; set; } 
		
        [Display(Name = "نام کارخانه")]
        [Required (ErrorMessage =" نام کارخانه را وارد نمائيد ")]
		public string Name { get; set; } 
		
        [Display(Name = "تلفن")]
        //[Required (ErrorMessage =" تلفن را وارد نمائيد ")]
		public string Tell { get; set; } 
		
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
        //[Required (ErrorMessage =" IsEnabled را وارد نمائيد ")]
		public bool IsEnabled { get; set; } 
		
        [Display(Name = "IsDeleted")]
        //[Required (ErrorMessage =" IsDeleted را وارد نمائيد ")]
		public bool IsDeleted { get; set; } 
		
   }
 }


