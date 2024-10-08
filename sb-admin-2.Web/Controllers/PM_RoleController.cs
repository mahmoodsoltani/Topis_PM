
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_RoleController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Role
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Role> PM_RoleServiceObj=dboService.PM_RoleSelect(-1,"-1","-1","-1");
            IList<PM.Models.PM_RoleMetaData> PM_RoleModelList = PM_RoleServiceObj.OfType<PM.Models.PM_RoleMetaData>().ToList();
            PM.Models.PM_RoleMetaData PM_RoleModelObj = new Models.PM_RoleMetaData();
            foreach (PMService.PM_Role ww in PM_RoleServiceObj)
             {
                 PM_RoleModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RoleMetaData>(JsonConvert.SerializeObject(ww));
                 PM_RoleModelList.Add(PM_RoleModelObj);
             }
             return View(PM_RoleModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Role/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Role PM_RoleServiceObj = dboService.PM_RoleSelect(id,"-1","-1","-1").First();
            PM.Models.PM_RoleMetaData PM_RoleModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RoleMetaData>(JsonConvert.SerializeObject(PM_RoleServiceObj));
            return View(PM_RoleModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Role/Create
        public ActionResult Create()
        { 
		 try
           {            
         //   ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
		 //   ViewBag.Enab = new SelectList(new List<SelectListItem>
         //               {
         //                new SelectListItem { Text = "فعال", Value = "1",Selected=true},
         //                new SelectListItem { Text = "غير فعال", Value = "0"},
         //                }, "Value", "Text");
            return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_Role/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_RoleMetaData PM_RoleModelObj = new Models.PM_RoleMetaData();  
				TryUpdateModel(PM_RoleModelObj);          
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
						    PM_RoleModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_RoleModelObj.IsDeleted = false;                
                PM_RoleModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoleModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoleModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_RoleModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Role PM_RoleServiceObj = new PMService.PM_Role();
                    PM_RoleServiceObj = JsonConvert.DeserializeObject<PMService.PM_Role>(JsonConvert.SerializeObject(PM_RoleModelObj));
                    if ( dboService.PM_RoleInsert(PM_RoleServiceObj) > 0 )					                   
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;

                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here
				ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
				ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
				
				Session["Inserted"] = false;

                return View();
            }
            catch
            {
			    Session["Inserted"] = false;
                return View();
            }
        }

        ////// GET: PM_Role/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_Role PM_RoleServiceObj =  dboService.PM_RoleSelect(id,"-1","-1","-1").First();
            PM.Models.PM_RoleMetaData PM_RoleModelObj= JsonConvert.DeserializeObject<PM.Models.PM_RoleMetaData>(JsonConvert.SerializeObject(PM_RoleServiceObj));
            return View(PM_RoleModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Role/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_RoleMetaData PM_RoleModelObj)
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
                            PM_RoleModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_RoleModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoleModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Role PM_RoleServiceObj = new PMService.PM_Role();
                    PM_RoleServiceObj = JsonConvert.DeserializeObject<PMService.PM_Role>(JsonConvert.SerializeObject(PM_RoleModelObj));
                    if ( dboService.PM_RoleUpdate(PM_RoleServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index");
                }

                // TODO: Add update logic here
				ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
				ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
					Session["Edited"] = false;
                return View(PM_RoleModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_RoleModelObj);
            }
        }

        //GET: PM_Role/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
              
                if (dboService.PM_RoleDelete(id) > 0)
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
  
        ///// POST: PM_Role/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Role PM_RoleServiceObj = dboService.PM_RoleSelect(id,"-1","-1","-1").First();
                PM_RoleServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoleServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_RoleServiceObj.IsDeleted = true;               
                if ( dboService.PM_RoleUpdate(PM_RoleServiceObj) >0 )
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
            IList<PMService.PM_Role> PM_RoleServiceObj = dboService.PM_RoleSelect(-1, "-1", "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Role ww in PM_RoleServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name,
                    Value = ww.PM_RoleID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


