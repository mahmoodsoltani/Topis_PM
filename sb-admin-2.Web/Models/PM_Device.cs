
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_DeviceMetaData))]
  public partial class PM_Device
   {
   }
   public class PM_DeviceMetaData
    {
        [Display(Name = "PM_DeviceID")]
        //[Required (ErrorMessage =" PM_DeviceID را وارد نمائيد ")]
		public int PM_DeviceID { get; set; } 
		
        [Display(Name = "نام")]
        //[Required (ErrorMessage =" نام را وارد نمائيد ")]
		public string Name { get; set; }

        [Display(Name = "کد")]
        //[Required (ErrorMessage =" تگ را وارد نمائيد ")]
        public string Tag { get; set; }

        [Display(Name = "شماره شناسنامه")]
        //[Required (ErrorMessage =" تگ را وارد نمائيد ")]
        public string Number { get; set; }

        [Display(Name = "خط توليد")]
        //[Required (ErrorMessage =" خط توليد را وارد نمائيد ")]
		public int? ID_ProductLine { get; set; } 

	[Display(Name = "خط توليد")]
        //[Required (ErrorMessage =" خط توليد را وارد نمائيد ")]
		public string  ProductLineName { get; set; } 	
        [Display(Name = "تاريخ نصب")]
        //[Required (ErrorMessage =" تاريخ نصب را وارد نمائيد ")]
		public string InstallDate { get; set; } 
		
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
        //[Required (ErrorMessage =" فعال را وارد نمائيد ")]
		public bool IsEnabled { get; set; } 
		
        [Display(Name = "IsDeleted")]
        //[Required (ErrorMessage =" IsDeleted را وارد نمائيد ")]
		public bool IsDeleted { get; set; } 
		
   }
 }


