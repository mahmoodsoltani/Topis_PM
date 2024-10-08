
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_RepairOrderMetaData))]
  public partial class PM_RepairOrder
   {
   }
   public class PM_RepairOrderMetaData
    {
        [Display(Name = "PM_RepairOrderID")]
        //[Required (ErrorMessage =" PM_RepairOrderID را وارد نمائيد ")]
		public int PM_RepairOrderID { get; set; }
        public int WOCount { get; set; } 
		
        [Display(Name = "شماره")]
        //[Required (ErrorMessage =" شماره را وارد نمائيد ")]
		public long? RepairOrderNumber { get; set; } 
		
        [Display(Name = "تاريخ درخواست")]
        //[Required (ErrorMessage =" تاريخ درخواست را وارد نمائيد ")]
		public string OrderDate { get; set; } 
		
        [Display(Name = "ساعت درخواست")]
        //[Required (ErrorMessage =" ساعت درخواست را وارد نمائيد ")]
		public string OrderTime { get; set; } 
		
        [Display(Name = "درخواست دهنده")]
        //[Required (ErrorMessage =" درخواست دهنده را وارد نمائيد ")]
		public int? Id_User { get; set; }

        [Display(Name = "درخواست دهنده")]
        //[Required (ErrorMessage =" درخواست دهنده را وارد نمائيد ")]
        public string PersonName { get; set; }

        [Display(Name = "تجهيز")]
        //[Required (ErrorMessage =" تجهيز را وارد نمائيد ")]
        public int? Id_equipment { get; set; }

        [Display(Name = "تجهيز")]
        //[Required (ErrorMessage =" تجهيز را وارد نمائيد ")]
        public string  EquipmentName { get; set; }
        [Display(Name = "دستگاه")]
        //[Required (ErrorMessage =" تجهيز را وارد نمائيد ")]
        public int? Id_Device { get; set; }

        [Display(Name = "دستگاه")]
        //[Required (ErrorMessage =" تجهيز را وارد نمائيد ")]
        public string DeviceName { get; set; }

        [Display(Name = "توضيحات")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
		public string Description { get; set; } 
		
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


