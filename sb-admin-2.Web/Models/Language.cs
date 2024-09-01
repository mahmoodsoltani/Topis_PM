
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(LanguageMetaData))]
  public partial class Language
   {
   }
   public class LanguageMetaData
    {
        [Display(Name = "LanguageID")]
        //[Required (ErrorMessage =" LanguageID را وارد نمائيد ")]
		public string LanguageID { get; set; } 
		
        [Display(Name = "LanguageName")]
        //[Required (ErrorMessage =" LanguageName را وارد نمائيد ")]
		public string LanguageName { get; set; } 
		
        [Display(Name = "LanguageDesc")]
        //[Required (ErrorMessage =" LanguageDesc را وارد نمائيد ")]
		public string LanguageDesc { get; set; } 
		
        [Display(Name = "LanguageSimbol")]
        //[Required (ErrorMessage =" LanguageSimbol را وارد نمائيد ")]
		public string LanguageSimbol { get; set; } 
		
        [Display(Name = "LanguageDirection")]
        //[Required (ErrorMessage =" LanguageDirection را وارد نمائيد ")]
		public string LanguageDirection { get; set; } 
		
        [Display(Name = "LanguagePhoto")]
        //[Required (ErrorMessage =" LanguagePhoto را وارد نمائيد ")]
		public string LanguagePhoto { get; set; } 
		
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
		
        [Display(Name = "IsEnabled")]
        //[Required (ErrorMessage =" IsEnabled را وارد نمائيد ")]
		public int IsEnabled { get; set; } 
		
        [Display(Name = "IsDeleted")]
        //[Required (ErrorMessage =" IsDeleted را وارد نمائيد ")]
		public int IsDeleted { get; set; } 
		
   }
 }


