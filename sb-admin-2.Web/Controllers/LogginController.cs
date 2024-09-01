using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MRKHTV.Controllers {  [Common.MRKAuthorize]
    public class LogginController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(PM.Models.UserMetaData model, string returnUrl)
        {

            //sample data
            Dictionary<string, string> users = new Dictionary<string, string>();
            users.Add("admin", "admin-pass");

            string roles;
            //string returnUrl1="";
            if (users[model.username] == model.password)
            {
                Session["User"] = model.username;
                roles = "admin;customer";
                // put the roles of the user in the Session            
                Session["Roles"] = roles;

                HttpContext.Items.Add("roles", roles);

                //Let us now set the authentication cookie so that we can use that later.
                FormsAuthentication.SetAuthCookie(model.username, false);



                //Login successful lets put him to requested page
                //  returnUrl = "~//Home/Login";//
                returnUrl = Request.QueryString["ReturnUrl"] as string;

                return RedirectToRoute(returnUrl);
                
                if (returnUrl != null)
                {
                    Response.Redirect(returnUrl);
                }
                else
                {
                    //no return URL specified so lets kick him to home page
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                // If we got this far, something failed, redisplay form
                ModelState.AddModelError("",
                  "The user name or password provided is incorrect");
                return View(model);
            }
        }

        public class ControllerBase : Controller
        {
            private string ActionKey;

            //sample data for the roles of the application
            Dictionary<string, List<string>> AllRoles =
                       new Dictionary<string, List<string>>();

            protected void initRoles()
            {
                AllRoles.Add("role1", new List<string>() { "Controller1-View",
      "Controller1-Create", "Controller1-Edit", "Controller1-Delete" });
                AllRoles.Add("role2", new List<string>() { "Controller1-View", "Controller1-Create" });
                AllRoles.Add("role3", new List<string>() { "Controller1-View" });
            }
            //sample data for the pages that need authorization
            List<string> NeedAuthenticationActions =
              new List<string>() { "Controller1-Edit", "Controller1-Delete" };


            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                ActionKey = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +
                                   "-" + filterContext.ActionDescriptor.ActionName;

                string role = Session["Roles"].ToString();//getting the current role
                if (NeedAuthenticationActions.Any(s => s.Equals(ActionKey, StringComparison.OrdinalIgnoreCase)))
                {
                    if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                    {
                        string redirectUrl = string.Format("?returnUrl={0}",
                                filterContext.HttpContext.Request.Url.PathAndQuery);
                        //  filterContext.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl + redirectUrl, true);
                        filterContext.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl + redirectUrl, true);
                    }
                    else //check role
                    {
                        if (!AllRoles[role].Contains(ActionKey))
                        {
                            filterContext.HttpContext.Response.Redirect("~/NoAccess", true);
                        }
                    }
                }
            }

        }
    }
}

/*

    [HttpPost]
[AllowAnonymous]
[ValidateAntiForgeryToken]
public ActionResult Login(LoginModel model, string returnUrl)
{
    //sample data
    Dictionary<string, string> users = new Dictionary<string, string>();
    users.Add("admin", "admin-pass");
    
    string roles;

    if (users[model.UserName] == model.Password)
    {
        Session["User"] = model.UserName;
        roles = "admin;customer";                
        // put the roles of the user in the Session            
        Session["Roles"] = roles;

        HttpContext.Items.Add("roles", roles);

        //Let us now set the authentication cookie so that we can use that later.
        FormsAuthentication.SetAuthCookie(model.UserName, false);

        //Login successful lets put him to requested page
        string returnUrl = Request.QueryString["ReturnUrl"] as string;

        return RedirectToLocal(returnUrl);

        if (returnUrl != null)
        {
            Response.Redirect(returnUrl);
        }
        else
        {
            //no return URL specified so lets kick him to home page
            Response.Redirect("Default.aspx");
        }
    }
    else
    {
        // If we got this far, something failed, redisplay form
        ModelState.AddModelError("", 
          "The user name or password provided is incorrect");
        return View(model);
    }
}

*/
