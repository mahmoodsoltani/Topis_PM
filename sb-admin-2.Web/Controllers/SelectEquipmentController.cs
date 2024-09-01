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
    public class SelectEquipmentController : Controller
    {
        // GET: Navbar
        public ActionResult Index()
        {
            IList<PMService.SelectEquipment> x = PMService.dboService.Pm_SelectEquipment(-1, -1, -1, -1);
            IList<PM.Models.SelectEquipment> y = x.OfType<PM.Models.SelectEquipment>().ToList();
            PM.Models.SelectEquipment z = new Models.SelectEquipment();
            foreach (PMService.SelectEquipment ww in x)
            {
                z = JsonConvert.DeserializeObject<PM.Models.SelectEquipment>(JsonConvert.SerializeObject(ww));
                y.Add(z);
            }
            return PartialView("_SelectEquipment", y);
        }
    }
}