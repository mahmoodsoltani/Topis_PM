using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Security;

using PM.Models;

namespace MRKHTV.Controllers
{
    [Authorize]

    public class AccountController : Controller
    {
        static string pass = "";

       // PM.MRKSecurService.SecurServiceClient SecureService = new PM.MRKSecurService.SecurServiceClient();


        public AccountController()
        {
        }

     
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
       
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
      
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
       
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
      //  [AllowAnonymous]
        //public ActionResult ChangePassword(string userid)
        //{
        //    //code = "admin";
        //    //return code == null ? View("Error") : View();
        //    try
        //    {
        //        userid = Session["userid"].ToString();

        //        if (!string.IsNullOrEmpty(userid))
        //        {
        //            //PM.MRKSecurService.User UserServiceObj = SecureService.UserSelect(userid, "-1", "-1", "-1", "-1", -1, -1).First();
        //            //PM.Models.ResetPasswordViewModel UserModelObj = new ResetPasswordViewModel();
        //            //UserModelObj.userID = UserServiceObj.user_id;
        //            //UserModelObj.userName = UserServiceObj.username;
        //            //UserModelObj.oldPassword = "";
        //            //pass = UserServiceObj.password;

        //          //  return View(UserModelObj);
        //        }
        //        else { return RedirectToAction("Index"); }
        //    }
        //    catch (Exception e)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //ChangePassword
        public async Task<ActionResult> ChangePassword(ResetPasswordViewModel model)
        {
            //PM.MRKSecurService.SecurServiceClient s = new PM.MRKSecurService.SecurServiceClient("WSHttpBinding_ISecurService");
            //string encryptednewpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(model.oldPassword, "SHA1");
            //if (encryptednewpassword != pass)
            //{
            //    model.LoginErrorMessage = "کلمه عبور وارد شده با کلمه عبور فعلی تطبیق ندارد";             
            //   return View(model);
            //}
            //else
            //{
            //    model.LoginErrorMessage = "";
            //}
            //if (ModelState.IsValid)
            //{
            //    // await UserManager.FindByNameAsync(model.Email);
            //    if (model.userID == null)
            //    {
            //        // Don't reveal that the user does not exist
            //       return RedirectToAction("ChangePassword", "Account");
            //     //   return RedirectToAction("ChangePassword", "Account");
            //    }
              
            //    bool ispasswordChange = SecureService.ChangeUserPasswordUsingCurrentPassword(User.Identity.Name, model.oldPassword, model.Password);
               
            //    if (ispasswordChange)
            //    {
                  

            //        return RedirectToAction("Index", "Home");
            //    }
            //}



            return View(model);
        }
        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }


        public ActionResult ExternalLoginFailure()
        {
            return View();
        }


    }
}