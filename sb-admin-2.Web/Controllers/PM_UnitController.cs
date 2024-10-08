
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_UnitController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Unit
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Unit> PM_UnitServiceObj=dboService.PM_UnitSelect(-1,"-1","-1","-1");
            IList<PM.Models.PM_UnitMetaData> PM_UnitModelList = PM_UnitServiceObj.OfType<PM.Models.PM_UnitMetaData>().ToList();
            PM.Models.PM_UnitMetaData PM_UnitModelObj = new Models.PM_UnitMetaData();
            foreach (PMService.PM_Unit ww in PM_UnitServiceObj)
             {
                 PM_UnitModelObj = JsonConvert.DeserializeObject<PM.Models.PM_UnitMetaData>(JsonConvert.SerializeObject(ww));
                 PM_UnitModelList.Add(PM_UnitModelObj);
             }
             return View(PM_UnitModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Unit/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Unit PM_UnitServiceObj = dboService.PM_UnitSelect(id,"-1","-1","-1").First();
            PM.Models.PM_UnitMetaData PM_UnitModelObj = JsonConvert.DeserializeObject<PM.Models.PM_UnitMetaData>(JsonConvert.SerializeObject(PM_UnitServiceObj));
            return View(PM_UnitModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Unit/Create
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

        ///// POST: PM_Unit/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_UnitMetaData PM_UnitModelObj = new Models.PM_UnitMetaData();  
				TryUpdateModel(PM_UnitModelObj);          
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
						    PM_UnitModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_UnitModelObj.IsDeleted = false;                
                PM_UnitModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_UnitModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_UnitModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_UnitModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Unit PM_UnitServiceObj = new PMService.PM_Unit();
                    PM_UnitServiceObj = JsonConvert.DeserializeObject<PMService.PM_Unit>(JsonConvert.SerializeObject(PM_UnitModelObj));
                    if ( dboService.PM_UnitInsert(PM_UnitServiceObj) > 0 )					                   
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

        ////// GET: PM_Unit/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_Unit PM_UnitServiceObj =  dboService.PM_UnitSelect(id,"-1","-1","-1").First();
            PM.Models.PM_UnitMetaData PM_UnitModelObj= JsonConvert.DeserializeObject<PM.Models.PM_UnitMetaData>(JsonConvert.SerializeObject(PM_UnitServiceObj));
            return View(PM_UnitModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Unit/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_UnitMetaData PM_UnitModelObj)
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
                            PM_UnitModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_UnitModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_UnitModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Unit PM_UnitServiceObj = new PMService.PM_Unit();
                    PM_UnitServiceObj = JsonConvert.DeserializeObject<PMService.PM_Unit>(JsonConvert.SerializeObject(PM_UnitModelObj));
                    if ( dboService.PM_UnitUpdate(PM_UnitServiceObj) > 0 )
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
                return View(PM_UnitModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_UnitModelObj);
            }
        }

        //GET: PM_Unit/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
               
                if (dboService.PM_UnitDelete(id) > 0)
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
  
        ///// POST: PM_Unit/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Unit PM_UnitServiceObj = dboService.PM_UnitSelect(id,"-1","-1","-1").First();
                PM_UnitServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_UnitServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_UnitServiceObj.IsDeleted = true;               
                if ( dboService.PM_UnitUpdate(PM_UnitServiceObj) >0 )
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
            IList<PMService.PM_Unit> PM_DeviceServiceObj = dboService.PM_UnitSelect(-1, "-1",  "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Unit ww in PM_DeviceServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.name,
                    Value = ww.Pm_UnitID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


