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
    public class SelectFilterDeviceController : Controller
    {
        // GET: Navbar
        public ActionResult Index(int id_user)
        {
            IList<PMService.SelectEquipment> x = PMService.dboService.Pm_SelectEquipmentByUser(-1, -1 , -1, -1,id_user);
            IList<PM.Models.SelectEquipment> y = x.OfType<PM.Models.SelectEquipment>().ToList();
            PM.Models.SelectEquipment z = new Models.SelectEquipment();
            foreach (PMService.SelectEquipment ww in x)
            {
                z = JsonConvert.DeserializeObject<PM.Models.SelectEquipment>(JsonConvert.SerializeObject(ww));
                y.Add(z);
            }
            return PartialView("_SelectDevice", y);
        }
    }
}