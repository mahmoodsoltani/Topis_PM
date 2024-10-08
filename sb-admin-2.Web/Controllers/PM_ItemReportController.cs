
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_ItemReportController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_ItemReport
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_ItemReport> PM_ItemReportServiceObj=dboService.PM_ItemReportSelect(-1,-1,-1,"-1",-1,"-1","-1");
            IList<PM.Models.PM_ItemReportMetaData> PM_ItemReportModelList = PM_ItemReportServiceObj.OfType<PM.Models.PM_ItemReportMetaData>().ToList();
            PM.Models.PM_ItemReportMetaData PM_ItemReportModelObj = new Models.PM_ItemReportMetaData();
            foreach (PMService.PM_ItemReport ww in PM_ItemReportServiceObj)
             {
                 PM_ItemReportModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ItemReportMetaData>(JsonConvert.SerializeObject(ww));
                 PM_ItemReportModelList.Add(PM_ItemReportModelObj);
             }
             return View(PM_ItemReportModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_ItemReport/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_ItemReport PM_ItemReportServiceObj = dboService.PM_ItemReportSelect(id,-1,-1,"-1",-1,"-1","-1").First();
            PM.Models.PM_ItemReportMetaData PM_ItemReportModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ItemReportMetaData>(JsonConvert.SerializeObject(PM_ItemReportServiceObj));
            return View(PM_ItemReportModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_ItemReport/Create
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

        ///// POST: PM_ItemReport/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_ItemReportMetaData PM_ItemReportModelObj = new Models.PM_ItemReportMetaData();  
				TryUpdateModel(PM_ItemReportModelObj);          
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
						    PM_ItemReportModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_ItemReportModelObj.IsDeleted = false;                
                PM_ItemReportModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemReportModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemReportModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_ItemReportModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_ItemReport PM_ItemReportServiceObj = new PMService.PM_ItemReport();
                    PM_ItemReportServiceObj = JsonConvert.DeserializeObject<PMService.PM_ItemReport>(JsonConvert.SerializeObject(PM_ItemReportModelObj));
                    if ( dboService.PM_ItemReportInsert(PM_ItemReportServiceObj) > 0 )					                   
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

        ////// GET: PM_ItemReport/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_ItemReport PM_ItemReportServiceObj =  dboService.PM_ItemReportSelect(id,-1,-1,"-1",-1,"-1","-1").First();
            PM.Models.PM_ItemReportMetaData PM_ItemReportModelObj= JsonConvert.DeserializeObject<PM.Models.PM_ItemReportMetaData>(JsonConvert.SerializeObject(PM_ItemReportServiceObj));
            return View(PM_ItemReportModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_ItemReport/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_ItemReportMetaData PM_ItemReportModelObj)
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
                            PM_ItemReportModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_ItemReportModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemReportModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_ItemReport PM_ItemReportServiceObj = new PMService.PM_ItemReport();
                    PM_ItemReportServiceObj = JsonConvert.DeserializeObject<PMService.PM_ItemReport>(JsonConvert.SerializeObject(PM_ItemReportModelObj));
                    if ( dboService.PM_ItemReportUpdate(PM_ItemReportServiceObj) > 0 )
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
                return View(PM_ItemReportModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_ItemReportModelObj);
            }
        }

        //GET: PM_ItemReport/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
		try{
            PMService.PM_ItemReport PM_ItemReportServiceObj = dboService.PM_ItemReportSelect(id,-1,-1,"-1",-1,"-1","-1").First();
            PM.Models.PM_ItemReportMetaData PM_ItemReportModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ItemReportMetaData>(JsonConvert.SerializeObject(PM_ItemReportServiceObj));
            return View(PM_ItemReportModelObj);
           
           }
		catch
             {
                return View();
             }            
        }
  
        ///// POST: PM_ItemReport/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_ItemReport PM_ItemReportServiceObj = dboService.PM_ItemReportSelect(id,-1,-1,"-1",-1,"-1","-1").First();
                PM_ItemReportServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemReportServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_ItemReportServiceObj.IsDeleted = true;               
                if ( dboService.PM_ItemReportUpdate(PM_ItemReportServiceObj) >0 )
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
    }
}


   


