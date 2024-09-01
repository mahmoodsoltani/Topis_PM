using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;



namespace MRKHTV.Controllers {
    //[Common.MRKAuthorize]
    public class UCController : Controller
    {
       // PM.MRKdboService.BaseServiceClient BaseService = new PM.MRKdboService.BaseServiceClient();
        public ActionResult Index()
        {
            
            return View();

        }
     
      

    }
}