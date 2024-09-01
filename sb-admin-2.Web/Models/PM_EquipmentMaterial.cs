
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_EquipmentMaterialMetaData))]
  public partial class PM_EquipmentMaterial
   {
   }
   public class PM_EquipmentMaterialMetaData
    {
        [Display(Name = "PM_EquipmentMaterialID")]
        //[Required (ErrorMessage =" PM_EquipmentMaterialID را وارد نمائيد ")]
		public int PM_EquipmentMaterialID { get; set; } 
		
        [Display(Name = "قطعه")]
        //[Required (ErrorMessage =" قطعه را وارد نمائيد ")]
		public int? Id_Material { get; set; } 
		
        [Display(Name = "قطعه")]
        //[Required (ErrorMessage =" تجهيز را وارد نمائيد ")]
		public int? Id_Equipment { get; set; }

        [Display(Name = "قطعه")]
        public string MaterialName { get; set; }

        [Display(Name = "تجهيز")]
        public string EquipmentName { get; set; }

        [Display(Name = "تعداد")]
        //[Required (ErrorMessage =" تعداد را وارد نمائيد ")]
		public float? MCount { get; set; } 
		
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


