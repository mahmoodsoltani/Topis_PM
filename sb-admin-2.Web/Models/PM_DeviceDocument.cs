
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_DeviceDocumentMetaData))]
  public partial class PM_DeviceDocument
   {
   }
   public class PM_DeviceDocumentMetaData
    {
        [Display(Name = "PM_DeviceDocumentID")]
        //[Required (ErrorMessage =" PM_DeviceDocumentID را وارد نمائيد ")]
		public int PM_DeviceDocumentID { get; set; } 
		
        [Display(Name = "نام")]
        [Required (ErrorMessage =" نام را وارد نمائيد ")]
		public string DocName { get; set; } 
		
        [Display(Name = "دستگاه")]
     //   [Required (ErrorMessage =" کارخانه را وارد نمائيد ")]
		public int? ID_Device { get; set; }

        [Display(Name = "نام دستگاه")]
        //[Required (ErrorMessage =" کارخانه را وارد نمائيد ")]
        public string  Devicename { get; set; }
        public string  FileName { get; set; }

        [Display(Name = "توضیحات")]
        //[Required (ErrorMessage =" آدرس را وارد نمائيد ")]
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
        //[Required (ErrorMessage =" فعال را وارد نمائيد ")]
		public bool IsEnabled { get; set; } 
		
        [Display(Name = "IsDeleted")]
        //[Required (ErrorMessage =" IsDeleted را وارد نمائيد ")]
		public bool IsDeleted { get; set; } 
		
   }
 }


