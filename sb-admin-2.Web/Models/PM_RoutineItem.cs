
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_RoutineItemMetaData))]
  public partial class PM_RoutineItem
   {
   }
   public class PM_RoutineItemMetaData
    {
        [Display(Name = "PM_RoutineItemID")]
        //[Required (ErrorMessage =" PM_RoutineItemID را وارد نمائيد ")]
		public int PM_RoutineItemID { get; set; } 
		
        [Display(Name = "آيتم")]
        //[Required (ErrorMessage =" آيتم را وارد نمائيد ")]
		public int? Id_Item { get; set; } 
		
        [Display(Name = "روتين")]
        //[Required (ErrorMessage =" روتين را وارد نمائيد ")]
		public int? Id_Routine { get; set; } 
		
        [Display(Name = "Creator")]
        //[Required (ErrorMessage =" Creator را وارد نمائيد ")]
		public string Creator { get; set; } 
		public string ItemName { get; set; } 
		
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


