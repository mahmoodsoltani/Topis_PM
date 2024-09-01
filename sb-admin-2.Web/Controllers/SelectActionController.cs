using MRKHTV.Domain;
using PM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace PM.Controllers
{
    public class SelectActionController : Controller
    {
        // GET: Navbar
        [HttpGet]
        public ActionResult Index(int roleID,int userID)
        {
            PMService.dboService dboService = new PMService.dboService();
            IList<PMService.PM_ActionList> PM_MenuItemServiceObj = dboService.PM_ActionListSelect(Convert.ToInt32(roleID), Convert.ToInt32(userID));
            IList<PM.Models.PM_ActionListMetaData> VwUserMenuModelList = PM_MenuItemServiceObj.OfType<PM.Models.PM_ActionListMetaData>().ToList();
            PM.Models.PM_ActionListMetaData VwUserMenuModelObj = new PM.Models.PM_ActionListMetaData();
            ViewBag.ID_Role = roleID;
            foreach (PMService.PM_ActionList ww in PM_MenuItemServiceObj)
            {
                    VwUserMenuModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ActionListMetaData>(JsonConvert.SerializeObject(ww));
                    VwUserMenuModelList.Add(VwUserMenuModelObj);
            }
            return PartialView("_SelectAction", VwUserMenuModelList);
        }
        public static Dictionary<string,bool> GetAutorizedAction(int roleID, int userID)
        {
            PMService.dboService dboService = new PMService.dboService();
            IList<PMService.PM_ActionList> PM_MenuItemServiceObj = dboService.PM_ActionListSelect(Convert.ToInt32(roleID), Convert.ToInt32(userID));
            PM.Models.PM_ActionListMetaData VwUserMenuModelObj = new PM.Models.PM_ActionListMetaData();
            Dictionary<string, bool> Out = new Dictionary<string, bool>();
            foreach (PMService.PM_ActionList ww in PM_MenuItemServiceObj)
            {
                VwUserMenuModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ActionListMetaData>(JsonConvert.SerializeObject(ww));
                if (VwUserMenuModelObj.Id_Role != null && VwUserMenuModelObj.Id_Role > 0)
                    Out.Add(VwUserMenuModelObj.ControllerName.ToLower().Trim() + "_" + VwUserMenuModelObj.Actionname.ToLower().Trim(), true);
                else
                    Out.Add(VwUserMenuModelObj.ControllerName.ToLower().Trim() + "_" + VwUserMenuModelObj.Actionname.ToLower().Trim(), false);

            }
            return  Out;
        }
    }
}