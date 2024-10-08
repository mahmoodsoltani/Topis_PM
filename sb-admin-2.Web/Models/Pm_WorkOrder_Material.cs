
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(Pm_WorkOrder_MaterialMetaData))]
  public partial class Pm_WorkOrder_Material
   {
   }
   public class Pm_WorkOrder_MaterialMetaData
    {
        [Display(Name = "PM_WorkOrder_MaterialID")]
        //[Required (ErrorMessage =" PM_WorkOrder_MaterialID را وارد نمائيد ")]
		public int PM_WorkOrder_MaterialID { get; set; }

        [Display(Name = "Id_Material")]
        //[Required (ErrorMessage =" Id_Material را وارد نمائيد ")]
        public int? Id_Material { get; set; }

        [Display(Name = "ماده مصرفی")]
        //[Required (ErrorMessage =" Id_Material را وارد نمائيد ")]
        public string MaterialName { get; set; }
        [Display(Name = "مقدار")]
        //[Required (ErrorMessage =" Amount را وارد نمائيد ")]
        public string Amount { get; set; }
        public string Description { get; set; }

        [Display(Name = "Id_WorkOrderReport")]
        //[Required (ErrorMessage =" Id_WorkOrderReport را وارد نمائيد ")]
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


