using MRKHTV.Domain;
using PM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRKHTV.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        public ActionResult Index()
        {            
            return PartialView("_Navbar", Data.navbarItems().ToList());
        }
    }
}