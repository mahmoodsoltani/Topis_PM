
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_ItemReportMetaData))]
  public partial class PM_ItemReport
   {
   }
   public class PM_ItemReportMetaData
    {
        [Display(Name = "PM_ItemReportID")]
        //[Required (ErrorMessage =" PM_ItemReportID را وارد نمائيد ")]
		public int PM_ItemReportID { get; set; } 
		
        [Display(Name = "آيتم")]
        //[Required (ErrorMessage =" آيتم را وارد نمائيد ")]
		public int? Id_Item { get; set; } 
		
        [Display(Name = "وضعيت")]
        //[Required (ErrorMessage =" وضعيت را وارد نمائيد ")]
		public int Id_ItemOrderStatus { get; set; } 
		
        [Display(Name = "توضيحات")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
		public string Description { get; set; } 
		
        [Display(Name = "دستور کار")]
        //[Required (ErrorMessage =" دستور کار را وارد نمائيد ")]
		public int? Id_WorkOrderReport { get; set; } 
		
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


