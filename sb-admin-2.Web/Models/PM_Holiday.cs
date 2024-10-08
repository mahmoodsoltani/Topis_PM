
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_HolidayMetaData))]
  public partial class PM_Holiday
   {
   }
   public class PM_HolidayMetaData
    {
        [Display(Name = "PM_HolidayID")]
        //[Required (ErrorMessage =" PM_HolidayID را وارد نمائيد ")]
		public int PM_HolidayID { get; set; } 
		
        [Display(Name = "تاريخ")]
        //[Required (ErrorMessage =" تاريخ را وارد نمائيد ")]
		public string Tarikh { get; set; } 
		
        [Display(Name = "مناسبت ")]
        //[Required (ErrorMessage =" مناسبت  را وارد نمائيد ")]
		public string Description { get; set; } 
		
        [Display(Name = "نوع تعطيلي")]
        //[Required (ErrorMessage =" نوع تعطيلي را وارد نمائيد ")]
		public int? Holiday_Type { get; set; } 
		
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


