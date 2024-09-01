using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;



namespace MRKHTV.Controllers {
    //[Common.MRKAuthorize]
    public class HomeController : Controller
    {
       // PM.MRKdboService.BaseServiceClient BaseService = new PM.MRKdboService.BaseServiceClient();
        public ActionResult Index()
        {
            //////PM.MRKdboService.Dashboard dashboardObj = dboService.DashboardSelect().First();
            //////PM.Models.DashboardMetaData DashboardModelObj =JsonConvert.DeserializeObject<PM.Models.DashboardMetaData>(JsonConvert.SerializeObject(dashboardObj));


            //////return View(DashboardModelObj);
            return View();


        }
        public ActionResult AccessDeny()
        {
            return View();
        }

        public ActionResult FlotCharts()
        {
            return View("FlotCharts");
        }

        public ActionResult MorrisCharts()
        {
            return View("MorrisCharts");
        }

        public ActionResult Tables()
        {
            return View("Tables");
        }

        public ActionResult Forms()
        {
            return View("Forms");
        }

        public ActionResult Panels()
        {
            return View("Panels");
        }

        public ActionResult Buttons()
        {
            return View("Buttons");
        }

        public ActionResult Notifications()
        {
            return View("Notifications");
        }

        public ActionResult Typography()
        {
            return View("Typography");
        }

        public ActionResult Icons()
        {
            return View("Icons");
        }

        public ActionResult Grid()
        {
            return View("Grid");
        }

        public ActionResult Blank()
        {
            return View("Blank");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

      
      

    }
}