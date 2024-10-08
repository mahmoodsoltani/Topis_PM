
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_ScheduledRoutineMetaData))]
  public partial class PM_ScheduledRoutine
   {
   }
   public class PM_ScheduledRoutineMetaData
    {
        [Display(Name = "PM_ScheduledRoutineID")]
        //[Required (ErrorMessage =" PM_ScheduledRoutineID را وارد نمائيد ")]
		public int PM_ScheduledRoutineID { get; set; } 
		
        [Display(Name = "نام")]
        //[Required (ErrorMessage =" Name را وارد نمائيد ")]
		public string Name { get; set; } 
		
        [Display(Name = "روتين")]
        //[Required (ErrorMessage =" روتين را وارد نمائيد ")]
		public int? Id_Routine { get; set; } 
		
        [Display(Name = "تجهيز")]
        //[Required (ErrorMessage =" تجهيز را وارد نمائيد ")]
		public int? Id_Equipment { get; set; } 
		
        [Display(Name = "دستگاه")]
        //[Required (ErrorMessage =" دستگاه را وارد نمائيد ")]
		public int? Id_Device { get; set; }
        public string Id_Devices { get; set; } 
		
        [Display(Name = "مسئول")]
        //[Required (ErrorMessage =" مسئول را وارد نمائيد ")]
		public int? Id_User { get; set; } 
		
        [Display(Name = "نوع")]
        //[Required (ErrorMessage =" نوع تکرار را وارد نمائيد ")]
		public int? Id_Occurtype { get; set; } 
		
        [Display(Name = "چند روز")]
        //[Required (ErrorMessage =" هر چند روز را وارد نمائيد ")]
		public int? Day_Number { get; set; } 
		
        [Display(Name = "چند هفته")]
        //[Required (ErrorMessage =" چند هفته را وارد نمائيد ")]
		public int? Week_Number { get; set; } 
		
        [Display(Name = "چند ماه")]
        //[Required (ErrorMessage =" چند ماه را وارد نمائيد ")]
		public int? Month_Number { get; set; } 
		
        [Display(Name = "روز")]
        //[Required (ErrorMessage =" روز هفته را وارد نمائيد ")]
		public int? Week_Day { get; set; } 
		
        [Display(Name = "چندم ماه")]
        //[Required (ErrorMessage =" چندم ماه را وارد نمائيد ")]
		public int? Month_Day { get; set; } 
		
        [Display(Name = "ساعت")]
        //[Required (ErrorMessage =" ساعت را وارد نمائيد ")]
		public string Time { get; set; } 
		
        [Display(Name = "شروع")]
        //[Required (ErrorMessage =" تاريخ شروع روتين را وارد نمائيد ")]
		public string StartDate { get; set; }
		public string DayName    { get; set; }
		public string RoutineName { get; set; }
		public string DeviceName { get; set; }
		public string EquipmentName { get; set; }
		public string PersonName { get; set; }
        public string OccureType { get; set; } 
		
        [Display(Name = "پایان")]
        //[Required (ErrorMessage =" تاريخ اتمام روتين را وارد نمائيد ")]
		public string EndDate { get; set; } 
		
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


