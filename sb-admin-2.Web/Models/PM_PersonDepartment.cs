
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_PersonDepartmentMetaData))]
  public partial class PM_PersonDepartment
   {
   }
   public class PM_PersonDepartmentMetaData
    {
        [Display(Name = "PM_PersonDepartmentID")]
        //[Required (ErrorMessage =" PM_DeviceDocumentID را وارد نمائيد ")]
		public int PM_PersonDepartmentID { get; set; }

        [Display(Name = "پرسنل")]
        //   [Required (ErrorMessage =" کارخانه را وارد نمائيد ")]
        public int ID_Person { get; set; }

       
        [Display(Name = "نام پرسنل")]
        //[Required (ErrorMessage =" کارخانه را وارد نمائيد ")]
        public string  PersonName { get; set; }

        [Display(Name = "بخش")]
        //   [Required (ErrorMessage =" کارخانه را وارد نمائيد ")]
        public int ID_Department { get; set; }

        [Display(Name = "نام بخش")]
        //[Required (ErrorMessage =" کارخانه را وارد نمائيد ")]
        public string DepartmentName { get; set; }

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
		
   }
 }


