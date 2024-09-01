
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_Workorder_PersonMetaData))]
  public partial class PM_Workorder_Person
   {
   }
   public class PM_Workorder_PersonMetaData
    {
        [Display(Name = "PM_WorkOrder_PersonID")]
        //[Required (ErrorMessage =" PM_WorkOrder_PersonID را وارد نمائيد ")]
		public int PM_WorkOrder_PersonID { get; set; } 
		
        [Display(Name = "فرد")]
        //[Required (ErrorMessage =" فرد را وارد نمائيد ")]
		public int? Id_Person { get; set; } 
		
        [Display(Name = "نفر ساعت")]
        //[Required (ErrorMessage =" نفر ساعت را وارد نمائيد ")]
		public string PersonPerHour { get; set; } 
		
        [Display(Name = "فرد")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
        public string PersonName { get; set; }

        [Display(Name = "توضيحات")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
        public string Description { get; set; }

        [Display(Name = "شماره فرم درخواست کار")]
        //[Required (ErrorMessage =" شماره فرم درخواست کار را وارد نمائيد ")]
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


