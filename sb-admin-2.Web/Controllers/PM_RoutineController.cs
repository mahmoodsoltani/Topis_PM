
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_RoutineController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Routine
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Routine> PM_RoutineServiceObj=dboService.PM_RoutineSelect(-1,"-1","-1","-1","-1");
            IList<PM.Models.PM_RoutineMetaData> PM_RoutineModelList = PM_RoutineServiceObj.OfType<PM.Models.PM_RoutineMetaData>().ToList();
            PM.Models.PM_RoutineMetaData PM_RoutineModelObj = new Models.PM_RoutineMetaData();
            foreach (PMService.PM_Routine ww in PM_RoutineServiceObj)
             {
                 PM_RoutineModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RoutineMetaData>(JsonConvert.SerializeObject(ww));
                 PM_RoutineModelList.Add(PM_RoutineModelObj);
             }
             return View(PM_RoutineModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Routine/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Routine PM_RoutineServiceObj = dboService.PM_RoutineSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_RoutineMetaData PM_RoutineModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RoutineMetaData>(JsonConvert.SerializeObject(PM_RoutineServiceObj));
            return View(PM_RoutineModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Routine/Create
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

        ///// POST: PM_Routine/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_RoutineMetaData PM_RoutineModelObj = new Models.PM_RoutineMetaData();  
				TryUpdateModel(PM_RoutineModelObj);          
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
						    PM_RoutineModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_RoutineModelObj.IsDeleted = false;                
                PM_RoutineModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoutineModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoutineModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_RoutineModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Routine PM_RoutineServiceObj = new PMService.PM_Routine();
                    PM_RoutineServiceObj = JsonConvert.DeserializeObject<PMService.PM_Routine>(JsonConvert.SerializeObject(PM_RoutineModelObj));
                    if ( dboService.PM_RoutineInsert(PM_RoutineServiceObj) > 0 )					                   
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

        ////// GET: PM_Routine/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_Routine PM_RoutineServiceObj =  dboService.PM_RoutineSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_RoutineMetaData PM_RoutineModelObj= JsonConvert.DeserializeObject<PM.Models.PM_RoutineMetaData>(JsonConvert.SerializeObject(PM_RoutineServiceObj));
            return View(PM_RoutineModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Routine/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_RoutineMetaData PM_RoutineModelObj)
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
                            PM_RoutineModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_RoutineModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoutineModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Routine PM_RoutineServiceObj = new PMService.PM_Routine();
                    PM_RoutineServiceObj = JsonConvert.DeserializeObject<PMService.PM_Routine>(JsonConvert.SerializeObject(PM_RoutineModelObj));
                    if ( dboService.PM_RoutineUpdate(PM_RoutineServiceObj) > 0 )
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
                return View(PM_RoutineModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_RoutineModelObj);
            }
        }

        //GET: PM_Routine/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
               
                if (dboService.PM_RoutineDelete(id) > 0)
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
  
        ///// POST: PM_Routine/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Routine PM_RoutineServiceObj = dboService.PM_RoutineSelect(id,"-1","-1","-1","-1").First();
                PM_RoutineServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoutineServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_RoutineServiceObj.IsDeleted = true;               
                if ( dboService.PM_RoutineUpdate(PM_RoutineServiceObj) >0 )
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
            try
            {
                PMService.dboService dboService = new PMService.dboService();
                IList<PMService.PM_Routine> PM_RoutineServiceObj = dboService.PM_RoutineSelect(-1, "-1", "-1", "true", "-1");
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (PMService.PM_Routine ww in PM_RoutineServiceObj)
                {

                    items.Add(new SelectListItem
                    {
                        Text = ww.Name,
                        Value = ww.Pm_RoutineID.ToString(),
                        // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                    });

                }

                return items;
            }
            catch (Exception e){ return null; }
        }
    }
}


   


