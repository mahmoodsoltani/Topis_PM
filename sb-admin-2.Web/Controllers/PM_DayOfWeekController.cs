
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_DayOfWeekController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_DayOfWeek
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_DayOfWeek> PM_DayOfWeekServiceObj=dboService.PM_DayOfWeekSelect(-1,"-1", "-1", "-1");
            IList<PM.Models.PM_DayOfWeekMetaData> PM_DayOfWeekModelList = PM_DayOfWeekServiceObj.OfType<PM.Models.PM_DayOfWeekMetaData>().ToList();
            PM.Models.PM_DayOfWeekMetaData PM_DayOfWeekModelObj = new Models.PM_DayOfWeekMetaData();
            foreach (PMService.PM_DayOfWeek ww in PM_DayOfWeekServiceObj)
             {
                 PM_DayOfWeekModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DayOfWeekMetaData>(JsonConvert.SerializeObject(ww));
                 PM_DayOfWeekModelList.Add(PM_DayOfWeekModelObj);
             }
             return View(PM_DayOfWeekModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_DayOfWeek/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_DayOfWeek PM_DayOfWeekServiceObj = dboService.PM_DayOfWeekSelect(id,"-1","-1","-1").First();
            PM.Models.PM_DayOfWeekMetaData PM_DayOfWeekModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DayOfWeekMetaData>(JsonConvert.SerializeObject(PM_DayOfWeekServiceObj));
            return View(PM_DayOfWeekModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_DayOfWeek/Create
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

        ///// POST: PM_DayOfWeek/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_DayOfWeekMetaData PM_DayOfWeekModelObj = new Models.PM_DayOfWeekMetaData();  
				TryUpdateModel(PM_DayOfWeekModelObj);          
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
						    PM_DayOfWeekModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_DayOfWeekModelObj.IsDeleted = false;                
                PM_DayOfWeekModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_DayOfWeekModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_DayOfWeekModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_DayOfWeekModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_DayOfWeek PM_DayOfWeekServiceObj = new PMService.PM_DayOfWeek();
                    PM_DayOfWeekServiceObj = JsonConvert.DeserializeObject<PMService.PM_DayOfWeek>(JsonConvert.SerializeObject(PM_DayOfWeekModelObj));
                    if ( dboService.PM_DayOfWeekInsert(PM_DayOfWeekServiceObj) > 0 )					                   
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

        ////// GET: PM_DayOfWeek/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_DayOfWeek PM_DayOfWeekServiceObj =  dboService.PM_DayOfWeekSelect(id,"-1", "-1", "-1").First();
            PM.Models.PM_DayOfWeekMetaData PM_DayOfWeekModelObj= JsonConvert.DeserializeObject<PM.Models.PM_DayOfWeekMetaData>(JsonConvert.SerializeObject(PM_DayOfWeekServiceObj));
            return View(PM_DayOfWeekModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_DayOfWeek/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_DayOfWeekMetaData PM_DayOfWeekModelObj)
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
                            PM_DayOfWeekModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_DayOfWeekModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_DayOfWeekModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_DayOfWeek PM_DayOfWeekServiceObj = new PMService.PM_DayOfWeek();
                    PM_DayOfWeekServiceObj = JsonConvert.DeserializeObject<PMService.PM_DayOfWeek>(JsonConvert.SerializeObject(PM_DayOfWeekModelObj));
                    if ( dboService.PM_DayOfWeekUpdate(PM_DayOfWeekServiceObj) > 0 )
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
                return View(PM_DayOfWeekModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_DayOfWeekModelObj);
            }
        }

        //GET: PM_DayOfWeek/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
		try{
            PMService.PM_DayOfWeek PM_DayOfWeekServiceObj = dboService.PM_DayOfWeekSelect(id,"-1", "-1", "-1").First();
            PM.Models.PM_DayOfWeekMetaData PM_DayOfWeekModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DayOfWeekMetaData>(JsonConvert.SerializeObject(PM_DayOfWeekServiceObj));
            return View(PM_DayOfWeekModelObj);
           
           }
		catch
             {
                return View();
             }            
        }
  
        ///// POST: PM_DayOfWeek/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_DayOfWeek PM_DayOfWeekServiceObj = dboService.PM_DayOfWeekSelect(id,"-1", "-1", "-1").First();
                PM_DayOfWeekServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_DayOfWeekServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_DayOfWeekServiceObj.IsDeleted = true;               
                if ( dboService.PM_DayOfWeekUpdate(PM_DayOfWeekServiceObj) >0 )
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
                IList<PMService.PM_DayOfWeek> PM_DeviceServiceObj = dboService.PM_DayOfWeekSelect(-1, "-1", "true", "-1");
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (PMService.PM_DayOfWeek ww in PM_DeviceServiceObj)
                {

                    items.Add(new SelectListItem
                    {
                        Text = ww.Name,
                        Value = ww.PM_DayOfWeekID.ToString(),
                    });

                }

                return items;
            }
            catch (Exception ex)
            { return null; }
        }
    }
    
}


   


