
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_WorkOrderTypeMetaData))]
  public partial class PM_WorkOrderType
   {
   }
   public class PM_WorkOrderTypeMetaData
    {
        [Display(Name = "PM_WorkOrderTypeID")]
        //[Required (ErrorMessage =" PM_WorkOrderTypeID را وارد نمائيد ")]
		public int PM_WorkOrderTypeID { get; set; } 
		
        [Display(Name = "name")]
        //[Required (ErrorMessage =" name را وارد نمائيد ")]
		public string name { get; set; } 
		
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


