
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_WorkOrderReportMetaData))]
  public partial class PM_WorkOrderReport
   {
   }
   public class PM_WorkOrderReportMetaData
    {
        [Display(Name = "PM_WorkOrderReportID")]
        //[Required (ErrorMessage =" PM_WorkOrderReportID را وارد نمائيد ")]
		public int PM_WorkOrderReportID { get; set; } 
		
        [Display(Name = "تاريخ شروع")]
        //[Required (ErrorMessage =" تاريخ شروع را وارد نمائيد ")]
		public string StartDate { get; set; } 
		
        [Display(Name = "ساعت شروع")]
        //[Required (ErrorMessage =" ساعت شروع را وارد نمائيد ")]
		public string Starttime { get; set; } 
		
        [Display(Name = "تاريخ پايان")]
        //[Required (ErrorMessage =" تاريخ پايان را وارد نمائيد ")]
		public string EndDate { get; set; } 
		
        [Display(Name = "ساعت پايان")]
        //[Required (ErrorMessage =" ساعت پايان را وارد نمائيد ")]
		public string EndTime { get; set; } 
		
        [Display(Name = "شماره درخواست کار")]
        //[Required (ErrorMessage =" شماره درخواست کار را وارد نمائيد ")]
		public int? Id_WorkOrder { get; set; } 
		
        [Display(Name = "توضيحات")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
		public string description { get; set; } 
		
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


