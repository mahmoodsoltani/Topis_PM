
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_HolidayController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Holiday
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Holiday> PM_HolidayServiceObj=dboService.PM_HolidaySelect(-1,"-1","-1",-1,"True","-1");
            IList<PM.Models.PM_HolidayMetaData> PM_HolidayModelList = PM_HolidayServiceObj.OfType<PM.Models.PM_HolidayMetaData>().ToList();
            PM.Models.PM_HolidayMetaData PM_HolidayModelObj = new Models.PM_HolidayMetaData();
            foreach (PMService.PM_Holiday ww in PM_HolidayServiceObj)
             {
                 PM_HolidayModelObj = JsonConvert.DeserializeObject<PM.Models.PM_HolidayMetaData>(JsonConvert.SerializeObject(ww));
                 PM_HolidayModelList.Add(PM_HolidayModelObj);
             }
             return View(PM_HolidayModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Holiday/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Holiday PM_HolidayServiceObj = dboService.PM_HolidaySelect(id,"-1","-1",-1,"-1","-1").First();
            PM.Models.PM_HolidayMetaData PM_HolidayModelObj = JsonConvert.DeserializeObject<PM.Models.PM_HolidayMetaData>(JsonConvert.SerializeObject(PM_HolidayServiceObj));
            return View(PM_HolidayModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Holiday/Create
        public ActionResult Create()
        { 
		 try
           {
                ViewBag.Type = PM_HolidayController.GetDropdownlist();
                return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_Holiday/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_HolidayMetaData PM_HolidayModelObj = new Models.PM_HolidayMetaData();  
				TryUpdateModel(PM_HolidayModelObj);
                var errors = ModelState.Values.SelectMany(v => v.Errors);
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
						    PM_HolidayModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_HolidayModelObj.IsDeleted = false;                
                PM_HolidayModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_HolidayModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_HolidayModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_HolidayModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Holiday PM_HolidayServiceObj = new PMService.PM_Holiday();
                    PM_HolidayServiceObj = JsonConvert.DeserializeObject<PMService.PM_Holiday>(JsonConvert.SerializeObject(PM_HolidayModelObj));
                    if ( dboService.PM_HolidayInsert(PM_HolidayServiceObj) > 0 )					                   
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

        ////// GET: PM_Holiday/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
                ViewBag.Type = PM_HolidayController.GetDropdownlist();
                PMService.PM_Holiday PM_HolidayServiceObj =  dboService.PM_HolidaySelect(id,"-1","-1",-1,"-1","-1").First();
            PM.Models.PM_HolidayMetaData PM_HolidayModelObj= JsonConvert.DeserializeObject<PM.Models.PM_HolidayMetaData>(JsonConvert.SerializeObject(PM_HolidayServiceObj));
            return View(PM_HolidayModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Holiday/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_HolidayMetaData PM_HolidayModelObj)
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
                            PM_HolidayModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_HolidayModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_HolidayModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Holiday PM_HolidayServiceObj = new PMService.PM_Holiday();
                    PM_HolidayServiceObj = JsonConvert.DeserializeObject<PMService.PM_Holiday>(JsonConvert.SerializeObject(PM_HolidayModelObj));
                    if ( dboService.PM_HolidayUpdate(PM_HolidayServiceObj) > 0 )
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
                return View(PM_HolidayModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_HolidayModelObj);
            }
        }

        //GET: PM_Holiday/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
               
                if (dboService.PM_HolidayDelete(id) > 0)
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
  
        ///// POST: PM_Holiday/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Holiday PM_HolidayServiceObj = dboService.PM_HolidaySelect(id,"-1","-1",-1,"-1","-1").First();
                PM_HolidayServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_HolidayServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_HolidayServiceObj.IsDeleted = true;               
                if ( dboService.PM_HolidayUpdate(PM_HolidayServiceObj) >0 )
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
           
            List<SelectListItem> items = new List<SelectListItem>();
            

                items.Add(new SelectListItem
                {
                    Text = "رسمی",
                    Value = "1",
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });
            items.Add(new SelectListItem
            {
                Text = "غیررسمی",
                Value = "2",
                // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
            });


            return items;
        }
    }
}


   


