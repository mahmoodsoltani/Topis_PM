
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_EquipmentStatusController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_EquipmentStatus
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_EquipmentStatus> PM_EquipmentStatusServiceObj=dboService.PM_EquipmentStatusSelect(-1,"-1","-1","-1","-1");
            IList<PM.Models.PM_EquipmentStatusMetaData> PM_EquipmentStatusModelList = PM_EquipmentStatusServiceObj.OfType<PM.Models.PM_EquipmentStatusMetaData>().ToList();
            PM.Models.PM_EquipmentStatusMetaData PM_EquipmentStatusModelObj = new Models.PM_EquipmentStatusMetaData();
            foreach (PMService.PM_EquipmentStatus ww in PM_EquipmentStatusServiceObj)
             {
                 PM_EquipmentStatusModelObj = JsonConvert.DeserializeObject<PM.Models.PM_EquipmentStatusMetaData>(JsonConvert.SerializeObject(ww));
                 PM_EquipmentStatusModelList.Add(PM_EquipmentStatusModelObj);
             }
             return View(PM_EquipmentStatusModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_EquipmentStatus/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_EquipmentStatus PM_EquipmentStatusServiceObj = dboService.PM_EquipmentStatusSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_EquipmentStatusMetaData PM_EquipmentStatusModelObj = JsonConvert.DeserializeObject<PM.Models.PM_EquipmentStatusMetaData>(JsonConvert.SerializeObject(PM_EquipmentStatusServiceObj));
            return View(PM_EquipmentStatusModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_EquipmentStatus/Create
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

        ///// POST: PM_EquipmentStatus/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_EquipmentStatusMetaData PM_EquipmentStatusModelObj = new Models.PM_EquipmentStatusMetaData();  
				TryUpdateModel(PM_EquipmentStatusModelObj);          
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
						    PM_EquipmentStatusModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_EquipmentStatusModelObj.IsDeleted = false;                
                PM_EquipmentStatusModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentStatusModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentStatusModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_EquipmentStatusModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_EquipmentStatus PM_EquipmentStatusServiceObj = new PMService.PM_EquipmentStatus();
                    PM_EquipmentStatusServiceObj = JsonConvert.DeserializeObject<PMService.PM_EquipmentStatus>(JsonConvert.SerializeObject(PM_EquipmentStatusModelObj));
                    if ( dboService.PM_EquipmentStatusInsert(PM_EquipmentStatusServiceObj) > 0 )					                   
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

        ////// GET: PM_EquipmentStatus/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_EquipmentStatus PM_EquipmentStatusServiceObj =  dboService.PM_EquipmentStatusSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_EquipmentStatusMetaData PM_EquipmentStatusModelObj= JsonConvert.DeserializeObject<PM.Models.PM_EquipmentStatusMetaData>(JsonConvert.SerializeObject(PM_EquipmentStatusServiceObj));
            return View(PM_EquipmentStatusModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_EquipmentStatus/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_EquipmentStatusMetaData PM_EquipmentStatusModelObj)
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
                            PM_EquipmentStatusModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_EquipmentStatusModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentStatusModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_EquipmentStatus PM_EquipmentStatusServiceObj = new PMService.PM_EquipmentStatus();
                    PM_EquipmentStatusServiceObj = JsonConvert.DeserializeObject<PMService.PM_EquipmentStatus>(JsonConvert.SerializeObject(PM_EquipmentStatusModelObj));
                    if ( dboService.PM_EquipmentStatusUpdate(PM_EquipmentStatusServiceObj) > 0 )
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
                return View(PM_EquipmentStatusModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_EquipmentStatusModelObj);
            }
        }

        //GET: PM_EquipmentStatus/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
               
                if (dboService.PM_EquipmentStatusDelete(id) > 0)
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
  
        ///// POST: PM_EquipmentStatus/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_EquipmentStatus PM_EquipmentStatusServiceObj = dboService.PM_EquipmentStatusSelect(id,"-1","-1","-1","-1").First();
                PM_EquipmentStatusServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentStatusServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_EquipmentStatusServiceObj.IsDeleted = true;               
                if ( dboService.PM_EquipmentStatusUpdate(PM_EquipmentStatusServiceObj) >0 )
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
            IList<PMService.PM_EquipmentStatus> PM_DeviceServiceObj = dboService.PM_EquipmentStatusSelect(-1, "-1", "-1", "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_EquipmentStatus ww in PM_DeviceServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name,
                    Value = ww.PM_EquipmentStatusID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


