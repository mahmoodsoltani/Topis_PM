
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_EquipmentMetaData))]
  public partial class PM_Equipment
   {
   }
   public class PM_EquipmentMetaData
    {
        [Display(Name = "PM_EquipmentID")]
        //[Required (ErrorMessage =" PM_EquipmentID را وارد نمائيد ")]
		public int PM_EquipmentID { get; set; } 
		
        [Display(Name = "دستگاه")]
        //[Required (ErrorMessage =" دستگاه را وارد نمائيد ")]
		public int? ID_Device { get; set; } 
		
        [Display(Name = "نام فارسي")]
        //[Required (ErrorMessage =" نام فارسي را وارد نمائيد ")]
		public string Fa_Name { get; set; } 
		
        [Display(Name = "نام انگليسي")]
        //[Required (ErrorMessage =" نام انگليسي را وارد نمائيد ")]
		public string En_Name { get; set; } 
		
        [Display(Name = "تگ")]
        //[Required (ErrorMessage =" تگ را وارد نمائيد ")]
		public string Tag { get; set; }

        [Display(Name = "توضيحات")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
        public string Description { get; set; }

        [Display(Name = "دستگاه")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
        public string DeviceName { get; set; }

        [Display(Name = "نوع")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
        public string TypeName { get; set; }

        [Display(Name = "وضعیت")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
        public string StatusName { get; set; }

        [Display(Name = "وضعيت")]
        //[Required (ErrorMessage =" وضعيت را وارد نمائيد ")]
		public int? ID_EquipmentSatus { get; set; } 
		
        [Display(Name = "نام سازنده")]
        //[Required (ErrorMessage =" نام سازنده را وارد نمائيد ")]
		public string FactoryName { get; set; } 
		
        [Display(Name = "نوع")]
        //[Required (ErrorMessage =" نوع را وارد نمائيد ")]
		public int? ID_EquipmentType { get; set; } 
		
        [Display(Name = "شماره خريد")]
        //[Required (ErrorMessage =" شماره خريد را وارد نمائيد ")]
		public string OrderNumber { get; set; } 
		
        [Display(Name = "شماره سريال")]
        //[Required (ErrorMessage =" شماره سريال را وارد نمائيد ")]
		public string SerialNumber { get; set; } 
		
        [Display(Name = "تاريخ نصب")]
        //[Required (ErrorMessage =" تاريخ نصب را وارد نمائيد ")]
		public string InstalDate { get; set; } 
		
        [Display(Name = "توان")]
        //[Required (ErrorMessage =" توان را وارد نمائيد ")]
		public string HoursPower { get; set; } 
		
        [Display(Name = "فاز")]
        //[Required (ErrorMessage =" فاز را وارد نمائيد ")]
		public int? Phase { get; set; } 
		
        [Display(Name = "سرعت")]
        //[Required (ErrorMessage =" سرعت را وارد نمائيد ")]
		public int? Speed { get; set; } 
		
        [Display(Name = "مصرف برق")]
        //[Required (ErrorMessage =" مصرف برق را وارد نمائيد ")]
		public int? power_consumption { get; set; } 
		
        [Display(Name = "دور موتور")]
        //[Required (ErrorMessage =" دور موتور را وارد نمائيد ")]
		public int? Cycle { get; set; } 
		
        [Display(Name = "فاکتور توان")]
        //[Required (ErrorMessage =" فاکتور توان را وارد نمائيد ")]
		public int? Power_Factor { get; set; } 
		
        [Display(Name = "نوع نصب")]
        //[Required (ErrorMessage =" نوع نصب را وارد نمائيد ")]
		public int? Instalation_type { get; set; } 
		
        [Display(Name = "کلاس")]
        //[Required (ErrorMessage =" کلاس را وارد نمائيد ")]
		public string Class { get; set; } 
		
        [Display(Name = "توضيخات HSE")]
        //[Required (ErrorMessage =" توضيخات HSE را وارد نمائيد ")]
		public string HSE_Note { get; set; } 
		
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


