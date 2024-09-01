using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Security;
using System.Reflection;
 
using PM;


namespace PM.Controllers {
    //[Common.MRKAuthorize]
    public class LoginController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
         // GET: Login
        public ActionResult Index()
        {
            if(Session["UserID"]!=null)
            { return RedirectToAction("Index", "Home"); }
            return View("Index");
        }

        public class RoleProvider
        {
            public string[] Get(string controller, string action)
            {
                // get your roles based on the controller and the action name 
                // wherever you want such as db
                // I hardcoded for the sake of simplicity 
                return new string[] { "Student", "Teacher" };
            }
        }
        
        public class DynamicRoleAuthorizeAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                RoleProvider _rolesProvider = new RoleProvider();
                var controller = httpContext.Request.RequestContext
                    .RouteData.GetRequiredString("controller");
                var action = httpContext.Request.RequestContext
                    .RouteData.GetRequiredString("action");
                // feed the roles here
                Roles = string.Join(",", _rolesProvider.Get(controller, action));
                return base.AuthorizeCore(httpContext);
            }
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
        [HttpPost]
        public ActionResult Authorize(PM.Models.PM_UserMetaData userModel)
        {
            //string s = "";
            //var controllers =Assembly.GetExecutingAssembly().GetExportedTypes().Where(t => typeof(ControllerBase).IsAssignableFrom(t)).Select(t => t);
            //foreach (Type controller in controllers)
            //{
            //    var actions = controller.GetMethods().Where(t => t.Name != "Dispose" && !t.IsSpecialName && t.DeclaringType.IsSubclassOf(typeof(ControllerBase)) && t.IsPublic && !t.IsStatic).ToList();
            //    foreach (var action in actions)
            //    {
                    
            //            s += string.Format("{0} , {1}\n", controller.Name.Replace("Controller",""),action .Name);


            //    }
            //}
            PMService.PM_User PM_UserServiceObj = null; 
            int authenticatestatus = -2;
            
            if (userModel.UserName != null && userModel.PassWord != null)
            {
                try
                {
                    PM_UserServiceObj = dboService.PM_UserSelect(-1, userModel.UserName, sha1(userModel.PassWord), -1, -1, "True", "-1").First();
                    if (PM_UserServiceObj != null)
                        if (PM_UserServiceObj.UserName != "")
                        {
                            authenticatestatus = 0;

                            
                        }
                }
                catch { }
            }
            switch (authenticatestatus)
            {
                case -1:
                    Session["Login"] = false;
                    return View("Index", userModel);
                case -2:
                    Session["Login"] = false;
                    return View("Index", userModel);
                case 0:
                    Session.Add("Deleted", "");
                    Session.Add("Inserted", "");
                    Session.Add("Edited", "");
                    Session.Add("Login", "");
                    Session.Add("RegWO", "");

                    Dictionary<string, bool> Autorize = SelectActionController.GetAutorizedAction((int)PM_UserServiceObj.Id_Role, PM_UserServiceObj.PM_UserID);
                    Session.Add("Autorize", Autorize);
                    Session["User"] = PM_UserServiceObj.UserName;
                    Session["Id_User"] = PM_UserServiceObj.PM_UserID ;
                    Session["UserID"] = PM_UserServiceObj.ID_Person;
                    Session["UserName"] = PM_UserServiceObj.PersonName;
                    Session["RoleID"] = PM_UserServiceObj.Id_Role.ToString();
                    Session["Is_public"] = PM_UserServiceObj.Is_Public;

                    return RedirectToAction("Index", "Home");
                case 1:
                case 2:
                case 3:
                case 4:
                    break;
                default:
                    break;
            }
            Session["Login"] = false;
            return View("Index", userModel);
           // return View();
        }
        public ActionResult LogOut()
        {
            // MRKHTV.Common.MRKAuthorize.AllRoles.Clear();
            Session["AllRole"] = "";
            Session["UserID"] = "";
            MRKHTV.Domain.Data.IsLoaded = false;
       //     Domain.Data.menu = null;
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();


            this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.Response.Cache.SetNoStore();
            return RedirectToAction("Index", "Login");
        }

        //public ActionResult ChangePass(string userid)
        //{
        //    try
        //    {
        //        userid = Session["userid"].ToString();
        //    //    if (!string.IsNullOrEmpty(userid))
        //    //    {
        //    ////        PM.MRKSecurService.User UserServiceObj = SecureService.UserSelect(userid,"-1","-1","-1","-1",-1,-1).First();
        //    // //       PM.Models.UserMetaData UserModelObj = JsonConvert.DeserializeObject<PM.Models.UserMetaData>(JsonConvert.SerializeObject(UserServiceObj));
        //    //       // return View(UserModelObj);
        //    //    }
        //    //    else { return RedirectToAction("Index"); }
        //    }
        //    catch(Exception e)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        //sample data for the roles of the application


        protected Dictionary<string, List<string>> initRoles()
        {
            
                string userID = HttpContext.Session["UserID"].ToString();//getting the current userID
            string role = HttpContext.Session["Roles"].ToString();//getting the current role

              Dictionary<string, List<string>> AllRoles = new Dictionary<string, List<string>>();

            try
            {


                //List<string> permission = new List<string>();
                //PM.MRKdboService.BaseServiceClient s = new PM.MRKdboService.BaseServiceClient("WSHttpBinding_IBaseService");
                //PM.MRKdboService.VwUserController[] usercontroller = s.VwUserControllerSelect(-1, userID, -1, 1, 0);
                //if (usercontroller.Length > 0)
                //{

                //    foreach (PM.MRKdboService.VwUserController item in usercontroller)
                //    {
                //        permission.Add(item.ControllerName.ToString() + '-' + item.ActionName.ToString());
                //    }

                //}
                //usercontroller = s.VwUserControllerSelect(-1, "-1", Convert.ToInt32(role), 1, 0);
                //if (usercontroller.Length > 0)
                //{

                //    foreach (PM.MRKdboService.VwUserController item in usercontroller)
                //    {
                //        permission.Add(item.ControllerName.ToString() + '-' + item.ActionName.ToString());
                //    }

                //}
                //AllRoles.Add(userID, permission);

                return AllRoles;
                //    AllRoles.Add("admin",)
                //    AllRoles.Add("admin2", new List<string>() { "CityController-View",
                //"CityController-Create", "CityController-Edit", "CityController-Delete" });
                //    AllRoles.Add("admin", new List<string>() { "City-Details", "City-Create" });

                //    AllRoles.Add("role3", new List<string>() { "CityController-View" });
            }
            catch (Exception e) {
            }
            return AllRoles;
        }

       



    }
}