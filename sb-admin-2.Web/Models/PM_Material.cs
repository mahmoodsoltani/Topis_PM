
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_MaterialMetaData))]
  public partial class PM_Material
   {
   }
   public class PM_MaterialMetaData
    {
        [Display(Name = "PM_MaterialID")]
        //[Required (ErrorMessage =" PM_MaterialID را وارد نمائيد ")]
		public int PM_MaterialID { get; set; } 
		
        [Display(Name = "نام")]
        //[Required (ErrorMessage =" نام را وارد نمائيد ")]
		public string name { get; set; }


        [Display(Name = "کد")]
        //[Required (ErrorMessage =" نام را وارد نمائيد ")]
        public string Tag { get; set; }

        [Display(Name = "واحد")]
        //[Required (ErrorMessage =" واحد را وارد نمائيد ")]
		public int? Id_Unit { get; set; }
        [Display(Name = "واحد")]
        //[Required (ErrorMessage =" واحد را وارد نمائيد ")]
        public string UnitName { get; set; }

        [Display(Name = "توضيحات")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
		public string Description { get; set; } 
		
        [Display(Name = "نوع")]
        //[Required (ErrorMessage =" توضيحات را وارد نمائيد ")]
		public string MaterialTypeName { get; set; }

        [Display(Name = "Id_MaterialType")]
        //[Required (ErrorMessage =" Id_MaterialType را وارد نمائيد ")]
		public int? Id_MaterialType { get; set; } 
		
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


