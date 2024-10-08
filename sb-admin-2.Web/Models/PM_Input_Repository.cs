
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_Input_RepositoryMetaData))]
  public partial class PM_Input_Repository
   {
   }
   public class PM_Input_RepositoryMetaData
    {
        [Display(Name = "PM_Input_RepositoryID")]
        //[Required (ErrorMessage =" PM_Input_RepositoryID را وارد نمائيد ")]
		public int PM_Input_RepositoryID { get; set; } 
		
        [Display(Name = "قلم کالا")]
        //[Required (ErrorMessage =" قلم کالا را وارد نمائيد ")]
		public int? Id_Material { get; set; } 
		
        [Display(Name = "مقدار")]
        //[Required (ErrorMessage =" مقدار را وارد نمائيد ")]
		public float? Amount { get; set; } 
		
        [Display(Name = "تاريخ ورود ")]
        //[Required (ErrorMessage =" تاريخ ورود  را وارد نمائيد ")]
		public string EnterDate { get; set; } 
		
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


