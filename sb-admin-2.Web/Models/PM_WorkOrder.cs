
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models
{
    [MetadataType(typeof(PM_WorkOrderMetaData))]
    public partial class PM_WorkOrder
    {
    }
    public class PM_WorkOrderMetaData
    {
        [Display(Name = "PM_WorkOrderID")]
        //[Required (ErrorMessage =" PM_WorkOrderID را وارد نمائيد ")]
        public int PM_WorkOrderID { get; set; }

        [Display(Name = "روتين")]
        //[Required (ErrorMessage =" روتين را وارد نمائيد ")]
        public int? Id_ScheduledRoutine { get; set; }

        [Display(Name = "شماره دستور کار")]
        //[Required (ErrorMessage =" شماره دستور کار را وارد نمائيد ")]
        public int? WorkOrdernumber { get; set; }

        [Display(Name = "تاريخ دستورکار")]
        //[Required (ErrorMessage =" تاريخ دستو رکار را وارد نمائيد ")]
        public string WorkOrder_Date { get; set; }
        [Display(Name = "تاريخ ارجاع")]
        //[Required (ErrorMessage =" تاريخ دستو رکار را وارد نمائيد ")]
        public string WorkOrder_ForwardDate { get; set; }
        public string DeviceName { get; set; }
        public int? RepairOrderNumber { get; set; }
        public string EquipmentName { get; set; }
        public string PersonName { get; set; }
        public string Status { get; set; }

        [Display(Name = "وضعيت")]
        //[Required (ErrorMessage =" وضعيت را وارد نمائيد ")]
        public int? Id_WorkOrderStatus { get; set; }

        [Display(Name = "مسئول")]
        //[Required (ErrorMessage =" مسئوا را وارد نمائيد ")]
        public int? Id_User { get; set; }

        [Display(Name = "تجهيز")]
        //[Required (ErrorMessage =" تجهيز را وارد نمائيد ")]
        public int? Id_Equipment { get; set; }

        [Display(Name = "دستگاه")]
        //[Required (ErrorMessage =" دستگاه را وارد نمائيد ")]
        public int? Id_Device { get; set; }

        [Display(Name = "روتين")]
        //[Required (ErrorMessage =" روتين را وارد نمائيد ")]
        public int? Id_Routine { get; set; }

        [Display(Name = "شماره درخواست تعميرات")]
        //[Required (ErrorMessage =" شماره درخواست تعميرات را وارد نمائيد ")]
        public int? Id_RepairOrder { get; set; }

        [Display(Name = "نوع دستور کار")]
        //[Required (ErrorMessage =" نوع دستور کار را وارد نمائيد ")]
        public int? Id_WorkOrderType { get; set; }

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


