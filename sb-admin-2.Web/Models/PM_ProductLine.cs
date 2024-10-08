
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_ProductLineMetaData))]
  public partial class PM_ProductLine
   {
   }
   public class PM_ProductLineMetaData
    {
        [Display(Name = "Pm_ProductLineID")]
        //[Required (ErrorMessage =" Pm_ProductLineID را وارد نمائيد ")]
		public int Pm_ProductLineID { get; set; } 
		
        [Display(Name = "عنوان")]
        //[Required (ErrorMessage =" عنوان را وارد نمائيد ")]
		public string Name { get; set; } 
		
        [Display(Name = "ساختمان")]
        //[Required (ErrorMessage =" ساختمان را وارد نمائيد ")]
		public int? Id_Department { get; set; }
        [Display(Name = "ساختمان")]
        //[Required (ErrorMessage =" ساختمان را وارد نمائيد ")]
        public string DepartmentName { get; set; }

        [Display(Name = "محصول توليدي")]
        //[Required (ErrorMessage =" محصول توليدي را وارد نمائيد ")]
		public string Product { get; set; } 
		
        [Display(Name = "تاريخ راه اندازي")]
        //[Required (ErrorMessage =" تاريخ راه اندازي را وارد نمائيد ")]
		public string Startdate { get; set; } 
		
        [Display(Name = "مسئول")]
        //[Required (ErrorMessage =" مسئول را وارد نمائيد ")]
		public int? Id_Supervisor { get; set; }

        [Display(Name = "مسئول")]
        //[Required (ErrorMessage =" مسئول را وارد نمائيد ")]
        public string SupervisorName { get; set; }

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


