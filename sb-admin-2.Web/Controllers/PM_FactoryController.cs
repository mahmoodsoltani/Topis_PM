
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_FactoryController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Factory

        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Factory> PM_FactoryServiceObj=dboService.PM_FactorySelect(-1,"-1","-1","-1","-1","-1");
            IList<PM.Models.PM_FactoryMetaData> PM_FactoryModelList = PM_FactoryServiceObj.OfType<PM.Models.PM_FactoryMetaData>().ToList();
            PM.Models.PM_FactoryMetaData PM_FactoryModelObj = new Models.PM_FactoryMetaData();
            foreach (PMService.PM_Factory ww in PM_FactoryServiceObj)
             {
                 PM_FactoryModelObj = JsonConvert.DeserializeObject<PM.Models.PM_FactoryMetaData>(JsonConvert.SerializeObject(ww));
                 PM_FactoryModelList.Add(PM_FactoryModelObj);
             }
             return View(PM_FactoryModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Factory/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Factory PM_FactoryServiceObj = dboService.PM_FactorySelect(id,"-1","-1","-1","-1","-1").First();
            PM.Models.PM_FactoryMetaData PM_FactoryModelObj = JsonConvert.DeserializeObject<PM.Models.PM_FactoryMetaData>(JsonConvert.SerializeObject(PM_FactoryServiceObj));
            return View(PM_FactoryModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Factory/Create
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

        ///// POST: PM_Factory/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_FactoryMetaData PM_FactoryModelObj = new Models.PM_FactoryMetaData();  
				TryUpdateModel(PM_FactoryModelObj);          
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
						    PM_FactoryModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_FactoryModelObj.IsDeleted = false;                
                PM_FactoryModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_FactoryModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_FactoryModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_FactoryModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Factory PM_FactoryServiceObj = new PMService.PM_Factory();
                    PM_FactoryServiceObj = JsonConvert.DeserializeObject<PMService.PM_Factory>(JsonConvert.SerializeObject(PM_FactoryModelObj));
                    if ( dboService.PM_FactoryInsert(PM_FactoryServiceObj) > 0 )					                   
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

        ////// GET: PM_Factory/Edit/5
        public ActionResult Edit(int id)
        {
		try{
           
            PMService.PM_Factory PM_FactoryServiceObj =  dboService.PM_FactorySelect(id,"-1","-1","-1","-1","-1").First();
            PM.Models.PM_FactoryMetaData PM_FactoryModelObj= JsonConvert.DeserializeObject<PM.Models.PM_FactoryMetaData>(JsonConvert.SerializeObject(PM_FactoryServiceObj));
            return View(PM_FactoryModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Factory/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_FactoryMetaData PM_FactoryModelObj)
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
                            PM_FactoryModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_FactoryModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_FactoryModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Factory PM_FactoryServiceObj = new PMService.PM_Factory();
                    PM_FactoryServiceObj = JsonConvert.DeserializeObject<PMService.PM_Factory>(JsonConvert.SerializeObject(PM_FactoryModelObj));
                    if ( dboService.PM_FactoryUpdate(PM_FactoryServiceObj) > 0 )
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
                return View(PM_FactoryModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_FactoryModelObj);
            }
        }

        //GET: PM_Factory/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
		try{
                //PMService.PM_Factory PM_FactoryServiceObj = dboService.PM_FactorySelect(id, "-1", "-1", "-1", "-1", "-1").First();
                //PM_FactoryServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                //PM_FactoryServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                //PM_FactoryServiceObj.IsDeleted = true;
                if (dboService.PM_FactoryDelete(id) > 0)
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
  
        ///// POST: PM_Factory/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Factory PM_FactoryServiceObj = dboService.PM_FactorySelect(id,"-1","-1","-1","-1","-1").First();
                PM_FactoryServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_FactoryServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_FactoryServiceObj.IsDeleted = true;               
                if ( dboService.PM_FactoryUpdate(PM_FactoryServiceObj) >0 )
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
            IList<PMService.PM_Factory> PM_FactoryServiceObj = dboService.PM_FactorySelect(-1, "-1", "-1", "-1", "-1", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Factory ww in PM_FactoryServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name,
                    Value = ww.PM_FactoryID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


