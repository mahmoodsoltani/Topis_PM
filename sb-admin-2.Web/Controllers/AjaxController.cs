using System.Web.Security;
using System.Text;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace PM.Controllers
{
    public class InputData
    {
        public string id { get; set; }

    }
    public class ReportPerson
    {
        public string reportid;
        public string personid;
        public string pph;
        public string disc;
    }
    public class PersonDepartment
    {
        public string departmentid;
        public string personid;
    }
    public class RoleAction
    {
        public string roleid;
        public string actionlistid;
        public string is_check;

    }
    [Serializable]
    public class ReportItem
    {
        public string Id;
        public string Desc;
        public string Is_Check;
    }

    public class ChangePass
    {
        public string id_user;
        public string lastPass;
        public string NewPass;
    }
    public class AjaxController : ApiController
    {
        [HttpPost]
        public int ChangeActionList(RoleAction action)
        {
            try
            {
                if (Convert.ToBoolean(action.is_check))
                {
                    PMService.dboService dboService = new PMService.dboService();
                    PM.Models.PM_Role_ActionMetaData Pm_RoleMenuModelObj = new Models.PM_Role_ActionMetaData();
                    Pm_RoleMenuModelObj.Id_Role = Convert.ToInt32(action.roleid);
                    Pm_RoleMenuModelObj.Id_ActionList = Convert.ToInt32(action.actionlistid.Substring(0, action.actionlistid.IndexOf('_')));
                    Pm_RoleMenuModelObj.IsDeleted = false;
                    Pm_RoleMenuModelObj.IsEnabled = true;
                    Pm_RoleMenuModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    Pm_RoleMenuModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    Pm_RoleMenuModelObj.Creator = PM.GeneralController.getCurrentUser();
                    Pm_RoleMenuModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Role_Action PM_Role_MenuServiceObj = new PMService.PM_Role_Action();
                    PM_Role_MenuServiceObj = JsonConvert.DeserializeObject<PMService.PM_Role_Action>(JsonConvert.SerializeObject(Pm_RoleMenuModelObj));
                    int a = dboService.PM_Role_ActionInsert(PM_Role_MenuServiceObj);
                    if (a > 0)
                        return a;
                    else
                        return 0;
                }
                else
                {
                    PMService.dboService dboService = new PMService.dboService();
                    return dboService.PM_Role_ActionDelete(Convert.ToInt32(action.roleid), Convert.ToInt32(action.actionlistid.Substring(0, action.actionlistid.IndexOf('_'))));
                }
            }
            catch
            {
                return 0;
            }
        }
        [HttpPost]
        public string GetFaultOFRepaireOrder(InputData person)
        {
            try
            {
                PMService.dboService dboService = new PMService.dboService();
                IList<PMService.PM_RepairOrderFault> PM_RepairOrderFaultServiceObj = dboService.PM_RepairOrderFaultSelect(-1, convert(person.id), -1, "-1", "-1", "-1", "-1", "-1", "-1", "-1");
                return JsonConvert.SerializeObject(PM_RepairOrderFaultServiceObj);
            }
            catch
            {
                return "";
            }
        }
        [HttpPost]
        public string GetItemOfWorkOrder(InputData person)
        {
            try
            {
                PMService.dboService dboService = new PMService.dboService();
                IList<PMService.PM_WorkOrderItem> PM_RepairOrderFaultServiceObj = dboService.PM_WorkOrderItemSelect(-1, -1, convert(person.id), "-1", "-1");
                return JsonConvert.SerializeObject(PM_RepairOrderFaultServiceObj);
            }
            catch
            {
                return "";
            }
        }

        [HttpPost]
        public int InsertReportPerson(ReportPerson r)
        {
            try
            {
                PMService.dboService dboService = new PMService.dboService();
                PM.Models.PM_Workorder_PersonMetaData PM_Workorder_PersonModelObj = new Models.PM_Workorder_PersonMetaData();
                PM_Workorder_PersonModelObj.Id_WorkOrderReport = Convert.ToInt32(r.reportid);
                PM_Workorder_PersonModelObj.Id_Person = Convert.ToInt32(r.personid);
                PM_Workorder_PersonModelObj.PersonPerHour = r.pph;
                PM_Workorder_PersonModelObj.Description = r.disc;
                PM_Workorder_PersonModelObj.IsDeleted = false;
                PM_Workorder_PersonModelObj.IsEnabled = true;
                PM_Workorder_PersonModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Workorder_PersonModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Workorder_PersonModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_Workorder_PersonModelObj.Modifier = PM.GeneralController.getCurrentUser();

                PMService.PM_Workorder_Person PM_Workorder_PersonServiceObj = new PMService.PM_Workorder_Person();
                PM_Workorder_PersonServiceObj = JsonConvert.DeserializeObject<PMService.PM_Workorder_Person>(JsonConvert.SerializeObject(PM_Workorder_PersonModelObj));
                int a = dboService.PM_Workorder_PersonInsert(PM_Workorder_PersonServiceObj);
                if (a > 0)
                    return a;
                else
                    return 0;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPost]
        public int ChangePass(ChangePass  r)
        {
            try
            {
                int a = 0;
                PMService.dboService dboService = new PMService.dboService();
                PMService.PM_User PM_UserServiceObj = dboService.PM_UserSelect(Convert.ToInt32( r.id_user),"-1","-1", -1,-1,"true", "false").First();
                if (PM_UserServiceObj== null || PM_UserServiceObj.PassWord != sha1(r.lastPass))
                    return -1;
                else
                     a = dboService.PM_UserChangePass(Convert.ToInt32(r.id_user), sha1(r.NewPass));
                return a;
            }
            catch
            {
                return 0;
            }
        }
        public int InsertPersonDepartment(PersonDepartment  r)
        {
            try
            {
                PMService.dboService dboService = new PMService.dboService();
                PM.Models.PM_PersonDepartmentMetaData PM_PersonDepartmentModelObj = new Models.PM_PersonDepartmentMetaData();
                PM_PersonDepartmentModelObj.ID_Person  = Convert.ToInt32(r.personid);
                PM_PersonDepartmentModelObj.ID_Department = Convert.ToInt32(r.departmentid);
                PM_PersonDepartmentModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_PersonDepartmentModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_PersonDepartmentModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_PersonDepartmentModelObj.Modifier = PM.GeneralController.getCurrentUser();

                PMService.PM_PersonDepartment PM_PersonDepartmentServiceObj = new PMService.PM_PersonDepartment();
                PM_PersonDepartmentServiceObj = JsonConvert.DeserializeObject<PMService.PM_PersonDepartment>(JsonConvert.SerializeObject(PM_PersonDepartmentModelObj));
                int a = dboService.PM_PersonDepartmentInsert (PM_PersonDepartmentServiceObj);
                if (a > 0)
                    return a;
                else
                    return 0;

            }
            catch
            {
                return 0;
            }
        }
        [HttpPost]
        public int InsertReportItem(PMService.ReportItem[] Items)
        {
            try
            {
                if (Items != null && Items.Count() > 0)
                {
                    PMService.dboService dboService = new PMService.dboService();
                    return dboService.Pm_WorkOrderItemInsertAll(Items);
                }
                else
                    return 0;
            }
            catch { return 0; }

        }
        public int InsertReportMaterial(ReportMaterail r)
        {
            try
            {
                PMService.dboService dboService = new PMService.dboService();
                PM.Models.Pm_WorkOrder_MaterialMetaData PM_Workorder_PersonModelObj = new Models.Pm_WorkOrder_MaterialMetaData();
                PM_Workorder_PersonModelObj.Id_WorkOrderReport = Convert.ToInt32(r.reportid);
                PM_Workorder_PersonModelObj.Id_Material = Convert.ToInt32(r.materialid);
                PM_Workorder_PersonModelObj.Amount = r.amount;
                PM_Workorder_PersonModelObj.Description = r.disc;
                PM_Workorder_PersonModelObj.IsDeleted = false;
                PM_Workorder_PersonModelObj.IsEnabled = true;
                PM_Workorder_PersonModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Workorder_PersonModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Workorder_PersonModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_Workorder_PersonModelObj.Modifier = PM.GeneralController.getCurrentUser();

                PMService.Pm_WorkOrder_Material PM_Workorder_MaterialServiceObj = new PMService.Pm_WorkOrder_Material();
                PM_Workorder_MaterialServiceObj = JsonConvert.DeserializeObject<PMService.Pm_WorkOrder_Material>(JsonConvert.SerializeObject(PM_Workorder_PersonModelObj));
                int a = dboService.Pm_WorkOrder_MaterialInsert(PM_Workorder_MaterialServiceObj);
                if (a > 0)
                    return a;
                else
                    return 0;

            }
            catch
            {
                return 0;
            }
        }
        [Serializable]
        public class WorkOrderReportItem
        {
            public string fromdate;
            public string todate;
            public string id_user;
            public string id_status;
            public string id_equipment;
            public string id_device;
        }
        [HttpPost]
        // public string WorkOrderReport(string fromdate,string todate,string id_user,string id_status,string id_equipment,string id_device)
        public string WorkOrderReport(WorkOrderReportItem data)
        {
            try
            {
                string fromdate = "-1";
                string todate = "-1";
                if (data.fromdate != "-1" && data.todate == "-1")
                { fromdate = data.fromdate; todate = data.fromdate; }
                else if (data.fromdate != "-1" && data.todate != "-1")
                { fromdate = data.fromdate; todate = data.todate; }

                PMService.dboService dboService = new PMService.dboService();
                IList<PMService.PM_WorkOrder> PM_workorderServiceObj = dboService.PM_WorkOrderSelect(-1, -1, -1, fromdate, todate, Convert.ToInt32(data.id_status), Convert.ToInt32(data.id_user), Convert.ToInt32(data.id_equipment), Convert.ToInt32(data.id_device), -1, -1, -1, "-1", "-1");
                return JsonConvert.SerializeObject(PM_workorderServiceObj.ToList());
            
            }
            catch
            {
                return "";
            }
        }
        public int convert(string number)
        {
            int temp = 0;
            int k = 1;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                temp += (number[i] - 1776) * k;
                k *= 10;
            }
            return temp;
        }
        static public string sha1(string value)
        {
            try
            {
                var sha1 = System.Security.Cryptography.SHA1.Create();
                var inputBytes = Encoding.ASCII.GetBytes(value);
                var hash = sha1.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (var i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}
