
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_WorkOrderItemMetaData))]
  public partial class PM_WorkOrderItem
   {
   }
   public class PM_WorkOrderItemMetaData
    {
        [Display(Name = "PM_WorkOrderItem")]
        //[Required (ErrorMessage =" PM_WorkOrderItem را وارد نمائيد ")]
		public int PM_WorkOrderItemID { get; set; } 
		
        [Display(Name = "Id_Item")]
        //[Required (ErrorMessage =" Id_Item را وارد نمائيد ")]
		public int? Id_Item { get; set; } 
		
        [Display(Name = "Id_WorkOrder")]
        //[Required (ErrorMessage =" Id_WorkOrder را وارد نمائيد ")]
		public int? Id_WorkOrder { get; set; } 
		
        [Display(Name = "Description")]
        //[Required (ErrorMessage =" Description را وارد نمائيد ")]

		public string Description { get; set; }


        [Display(Name = "وضعیت انجام")]
        //[Required (ErrorMessage =" IsDeleted را وارد نمائيد ")]
        public bool Is_Checked { get; set; }

        [Display(Name = "توضیحات انجام")]
        //[Required (ErrorMessage =" Description را وارد نمائيد ")]

        public string DownDescription { get; set; }
        [Display(Name = "عنوان آیتم")]

        public string ItemName { get; set; } 
		
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


