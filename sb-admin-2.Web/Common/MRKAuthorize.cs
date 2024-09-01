using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace MRKHTV.Common
{
    public class MRKAuthorize : ActionFilterAttribute
    //AuthorizeAttribute
    {
        //public class RoleProvider
        //{
        //    public string[] Get(string controller, string action)
        //    {
        //        // get your roles based on the controller and the action name 
        //        // wherever you want such as db
        //        // I hardcoded for the sake of simplicity 
        //        return new string[] { "City", "Index" };
        //    }
        //}
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    RoleProvider _rolesProvider = new RoleProvider();
        //    var controller = httpContext.Request.RequestContext
        //        .RouteData.GetRequiredString("controller");
        //    var action = httpContext.Request.RequestContext
        //        .RouteData.GetRequiredString("action");
        //    // feed the roles here
        //    Roles = string.Join(",", _rolesProvider.Get(controller, action));
        //    return base.AuthorizeCore(httpContext);
        //}



        private string ActionKey;


        //sample data for the roles of the application
        //public   Dictionary<string, List<string>> AllRoles =
        //           new Dictionary<string, List<string>>();

        //protected void initRoles()
        //{
        //    try
        //    {
        //        List<string> permission = new List<string>();
        //        MRKdboService.BaseServiceClient s = new MRKdboService.BaseServiceClient("WSHttpBinding_IBaseService");
        //        MRKdboService.VwUserController[] usercontroller = s.VwUserControllerSelect(-1, userID, -1, 1, 0);
        //        if (usercontroller.Length > 0)
        //        {

        //            foreach (MRKdboService.VwUserController item in usercontroller)
        //            {
        //                permission.Add(item.ControllerName.ToString() + '-' + item.ActionName.ToString());
        //            }

        //        }
        //        usercontroller = s.VwUserControllerSelect(-1, "-1", Convert.ToInt32(role), 1, 0);
        //        if (usercontroller.Length > 0)
        //        {

        //            foreach (MRKdboService.VwUserController item in usercontroller)
        //            {
        //                permission.Add(item.ControllerName.ToString() + '-' + item.ActionName.ToString());
        //            }

        //        }
        //        AllRoles.Add(userID, permission);
        //        //    AllRoles.Add("admin",)
        //        //    AllRoles.Add("admin2", new List<string>() { "CityController-View",
        //        //"CityController-Create", "CityController-Edit", "CityController-Delete" });
        //        //    AllRoles.Add("admin", new List<string>() { "City-Details", "City-Create" });

        //        //    AllRoles.Add("role3", new List<string>() { "CityController-View" });
        //    }
        //    catch (Exception e) { }
        //    }

        //sample data for the pages that need authorization
        //List<string> NeedAuthenticationActions =
        //  new List<string>() { "City-Edit", "City-Delete","City-Create" };


        //
        // Summary:
        //     Called by the ASP.NET MVC framework after the action method executes.
        //
        // Parameters:
        //   filterContext:
        //     The filter context.

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //HttpSessionStateBase session = filterContext.HttpContext.Session;
            //Controller controller = filterContext.Controller as Controller;

            //if (controller != null)
            //{
            //    if (session != null && session["authstatus"] == null)
            //    {
            //        filterContext.Result =
            //               new RedirectToRouteResult(
            //                   new RouteValueDictionary{{ "controller", "Login" },
            //                              { "action", "Index" }

            //                                                 });
            //    }
            //}

            //base.OnActionExecuting(filterContext);
        
            if (HttpContext.Current.Session["UserID"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
           new RouteValueDictionary {
              {"controller","Login" },
              {"action","Index"} ,
              {"querystring","" }
           });
            }
            else
            {
                string userID = HttpContext.Current.Session["UserID"].ToString();//getting the current userID
                string role = HttpContext.Current.Session["Roles"].ToString();//getting the current role

                Dictionary<string, List<string>> AllRoles = new Dictionary<string, List<string>>();
                AllRoles = (Dictionary<string, List<string>>)HttpContext.Current.Session["AllRole"];
                //     if (!string.IsNullOrEmpty( HttpContext.Current.Session["AllRole"] as string))
                //  if (AllRoles.Count < 1)
                //{
                //    initRoles();
                //}
                if (AllRoles.Count < 1)
                {
                    string redirectUrl = string.Format("?returnUrl={0}",
                               filterContext.HttpContext.Request.Url.PathAndQuery);
                    filterContext.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl + redirectUrl, true);
                }
                else
                {
                    //protected void OnAuthorization(AuthorizationContext filterContext)
                    //{
                    ActionKey = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +
                                       "-" + filterContext.ActionDescriptor.ActionName;



                    //if (NeedAuthenticationActions.Any(s => s.Equals(ActionKey, StringComparison.OrdinalIgnoreCase)))
                    //{
                    if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                    {
                        string redirectUrl = string.Format("?returnUrl={0}",
                                filterContext.HttpContext.Request.Url.PathAndQuery);
                        //  filterContext.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl + redirectUrl, true);
                        filterContext.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl + redirectUrl, true);
                    }
                    else //check role
                    {
                        try
                        {
                            if (!(AllRoles[userID].Contains(ActionKey)))

                            {
                                //   filterContext.HttpContext.Response.Redirect("~/NoAccess.html", true);
                                //filterContext.HttpContext.Response.Redirect(url)
                                filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary {
              {"controller","Home" },
              {"action","AccessDeny"} ,
              {"querystring","" }
                      //{ Constants.AREA, Constants.Areas.ERRORS },
                      //{ Constants.CONTROLLER, "UserError" },
                      //{ Constants.ACTION, "InvalidContest" }
                  });
                                //     filterContext.Result= new RedirectResult()
                            }
                        }

                        catch (Exception ee)
                        { }
                    }
                    ////}
                }
            }
        }
    }
}