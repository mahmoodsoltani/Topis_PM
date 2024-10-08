
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MRKHTV.Models  
{
  [MetadataType(typeof(sysdiagramsMetaData))]
  public partial class sysdiagrams
   {
   }
   public class sysdiagramsMetaData
    {
        [Display(Name = "name")]
        //[Required (ErrorMessage =" name را وارد نمائيد ")]
		public UNKNOWN_sysname name { get; set; } 
		
        [Display(Name = "principal_id")]
        //[Required (ErrorMessage =" principal_id را وارد نمائيد ")]
		public int principal_id { get; set; } 
		
        [Display(Name = "diagram_id")]
        //[Required (ErrorMessage =" diagram_id را وارد نمائيد ")]
		public int diagram_id { get; set; } 
		
        [Display(Name = "version")]
        //[Required (ErrorMessage =" version را وارد نمائيد ")]
		public int? version { get; set; } 
		
        [Display(Name = "definition")]
        //[Required (ErrorMessage =" definition را وارد نمائيد ")]
		public byte[] definition { get; set; } 
		
   }
 }


