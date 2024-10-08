
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text;


namespace PM.Controllers
{
  public class PM_UserController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_User
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_User> PM_UserServiceObj=dboService.PM_UserSelect(-1,"-1","-1",-1,-1,"-1","-1");
            IList<PM.Models.PM_UserMetaData> PM_UserModelList = PM_UserServiceObj.OfType<PM.Models.PM_UserMetaData>().ToList();
            PM.Models.PM_UserMetaData PM_UserModelObj = new Models.PM_UserMetaData();
            foreach (PMService.PM_User ww in PM_UserServiceObj)
             {
                 PM_UserModelObj = JsonConvert.DeserializeObject<PM.Models.PM_UserMetaData>(JsonConvert.SerializeObject(ww));
                 PM_UserModelList.Add(PM_UserModelObj);
             }
             return View(PM_UserModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_User/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_User PM_UserServiceObj = dboService.PM_UserSelect(id,"-1","-1",-1,-1,"-1","-1").First();
            PM.Models.PM_UserMetaData PM_UserModelObj = JsonConvert.DeserializeObject<PM.Models.PM_UserMetaData>(JsonConvert.SerializeObject(PM_UserServiceObj));
            return View(PM_UserModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_User/Create
        public ActionResult Create()
        { 
		 try
           {
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                ViewBag.Role = PM_RoleController.GetDropdownlist();
                return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_User/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_UserMetaData PM_UserModelObj = new Models.PM_UserMetaData();  
				TryUpdateModel(PM_UserModelObj);          
                if (ModelState.IsValid)
                {
                    PMService.PM_Person PM_PersonServiceObj = dboService.PM_PersonSelect((int)PM_UserModelObj.ID_Person, "-1", "-1", -1, "-1", -1, "-1", "-1", "-1").First();
                    if (PM_PersonServiceObj == null)
                    {
                        Session["Inserted"] = false;
                        return RedirectToAction("Index");
                    }
                    PM_UserModelObj.IsDeleted = false;                
                PM_UserModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_UserModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_UserModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_UserModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PM_UserModelObj.PassWord =sha1( PM_PersonServiceObj.Personalcode);
                    PMService.PM_User PM_UserServiceObj = new PMService.PM_User();
                    PM_UserServiceObj = JsonConvert.DeserializeObject<PMService.PM_User>(JsonConvert.SerializeObject(PM_UserModelObj));
                    if ( dboService.PM_UserInsert(PM_UserServiceObj) > 0 )					                   
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;

                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here
				
                return View();
            }
            catch
            {
			    Session["Inserted"] = false;
                return View();
            }
        }

        ////// GET: PM_User/Edit/5
        public ActionResult ResetPass(int id)
        {
            try
            {
                PMService.PM_User PM_UserServiceObj = dboService.PM_UserSelect(id, "-1", "-1", -1, -1, "-1", "-1").First();
                if (PM_UserServiceObj!= null)
                {
                    PMService.PM_Person PM_PersonServiceObj = dboService.PM_PersonSelect((int)PM_UserServiceObj.ID_Person, "-1", "-1", -1, "-1", -1, "-1", "-1", "-1").First();
                    if (PM_PersonServiceObj == null)
                    {
                        Session["Edited"] = false;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        PM_UserServiceObj.PassWord = sha1(PM_PersonServiceObj.Personalcode);
                        if (dboService.PM_UserUpdate(PM_UserServiceObj) > 0)
                            Session["Edited"] = true;
                        else
                            Session["Edited"] = false;
                        return RedirectToAction("Index");
                    }
                }
                Session["Edited"] = false;
                return RedirectToAction("Index");
            }
            catch {
                Session["Edited"] = false;
                return RedirectToAction("Index");
            }
        }
         public ActionResult Edit(int id)
        {
		try{
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                ViewBag.Role = PM_RoleController.GetDropdownlist();
                ViewBag.department = PM_DepartmentController.SimpleGetDropDownlist();

                PMService.PM_User PM_UserServiceObj = dboService.PM_UserSelect(id, "-1", "-1", -1, -1, "-1", "-1").First();
                PM.Models.PM_UserMetaData PM_UserModelObj = JsonConvert.DeserializeObject<PM.Models.PM_UserMetaData>(JsonConvert.SerializeObject(PM_UserServiceObj));
                return View(PM_UserModelObj);
           }
		catch
             {
                return View();
             }            
        }
        public ActionResult EditPass()
        {
            try
            {
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                ViewBag.Role = PM_RoleController.GetDropdownlist();
             

                PMService.PM_User PM_UserServiceObj = dboService.PM_UserSelect(Convert.ToInt32(Session["Id_User"].ToString()), "-1", "-1", -1, -1, "-1", "-1").First();
                PM.Models.PM_UserMetaData PM_UserModelObj = JsonConvert.DeserializeObject<PM.Models.PM_UserMetaData>(JsonConvert.SerializeObject(PM_UserServiceObj));
                return View(PM_UserModelObj);
            }
            catch
            {
                return View();
            }
        }

        ////// POST: PM_User/Edit/5

        [HttpPost]
        public ActionResult Edit(PM.Models.PM_UserMetaData PM_UserModelObj)
        {
            try
            {                
                if (ModelState.IsValid)
                {
				 /*
                  if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase file = Request.Files["LanguagePhoto"];
                        if (file.ContentLength > 0)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            string extention = Path.GetExtension(file.FileName);
                            fileName = fileName + '-' + FarsiLibrary.PersianDate.Now.Year.ToString() + FarsiLibrary.PersianDate.Now.Month.ToString() + FarsiLibrary.PersianDate.Now.Day.ToString() + extention;
                            PM_UserModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_UserModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_UserModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_User PM_UserServiceObj = new PMService.PM_User();
                    PM_UserServiceObj = JsonConvert.DeserializeObject<PMService.PM_User>(JsonConvert.SerializeObject(PM_UserModelObj));
                    if ( dboService.PM_UserUpdate(PM_UserServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index");
                }

                // TODO: Add update logic here
				
					Session["Edited"] = false;
                return View(PM_UserModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_UserModelObj);
            }
        }

        //GET: PM_User/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
               
                if (dboService.PM_UserDelete(id) > 0)
                    Session["Deleted"] = true;
                else
                    Session["Deleted"] = false;

                return RedirectToAction("Index");
                // TODO: Add update logic here                
            }
            catch
            {
                Session["Deleted"] = false;
                return RedirectToAction("Index");
            }
        }
  
        ///// POST: PM_User/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_User PM_UserServiceObj = dboService.PM_UserSelect(id,"-1","-1",-1,-1,"-1","-1").First();
                PM_UserServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_UserServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_UserServiceObj.IsDeleted = true;               
                if ( dboService.PM_UserUpdate(PM_UserServiceObj) >0 )
				Session["Deleted"] = true;
				else 
				Session["Deleted"] = false;

                return RedirectToAction("Index");                
                // TODO: Add update logic here                
            }
            catch
            {
                Session["Deleted"] = false;
				return RedirectToAction("Index");
            }
        }
        public static List<SelectListItem> GetDropdownlist()
        {
            PMService.dboService dboService = new PMService.dboService();
            IList<PMService.PM_User> PM_UserServiceObj = dboService.PM_UserSelect(-1, "-1", "-1",-1,-1, "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_User ww in PM_UserServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.PersonName+" ("+ww.UserName+")",
                    Value = ww.PM_UserID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
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
    }
}


   


