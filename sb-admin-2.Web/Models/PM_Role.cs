
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_RoleMetaData))]
  public partial class PM_Role
   {
   }
   public class PM_RoleMetaData
    {
        [Display(Name = "PM_RoleID")]
        //[Required (ErrorMessage =" PM_RoleID را وارد نمائيد ")]
		public int PM_RoleID { get; set; } 
		
        [Display(Name = "عنوان")]
        //[Required (ErrorMessage =" عنوان را وارد نمائيد ")]
		public string Name { get; set; } 
		
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
		
         [Display(Name = "دسترسی کلی")]
        //[Required (ErrorMessage =" IsEnabled را وارد نمائيد ")]
		public bool Is_Public { get; set; } 
 [Display(Name = "فعال")]
        //[Required (ErrorMessage =" IsEnabled را وارد نمائيد ")]
		public bool IsEnabled { get; set; } 		
        [Display(Name = "IsDeleted")]
        //[Required (ErrorMessage =" IsDeleted را وارد نمائيد ")]
		public bool IsDeleted { get; set; } 
		
   }
 }


