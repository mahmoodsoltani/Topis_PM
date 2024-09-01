
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class Pm_ItemReportStatusController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: Pm_ItemReportStatus
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.Pm_ItemReportStatus> Pm_ItemReportStatusServiceObj=dboService.Pm_ItemReportStatusSelect(-1,"-1","-1","-1","-1");
            IList<PM.Models.Pm_ItemReportStatusMetaData> Pm_ItemReportStatusModelList = Pm_ItemReportStatusServiceObj.OfType<PM.Models.Pm_ItemReportStatusMetaData>().ToList();
            PM.Models.Pm_ItemReportStatusMetaData Pm_ItemReportStatusModelObj = new Models.Pm_ItemReportStatusMetaData();
            foreach (PMService.Pm_ItemReportStatus ww in Pm_ItemReportStatusServiceObj)
             {
                 Pm_ItemReportStatusModelObj = JsonConvert.DeserializeObject<PM.Models.Pm_ItemReportStatusMetaData>(JsonConvert.SerializeObject(ww));
                 Pm_ItemReportStatusModelList.Add(Pm_ItemReportStatusModelObj);
             }
             return View(Pm_ItemReportStatusModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: Pm_ItemReportStatus/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.Pm_ItemReportStatus Pm_ItemReportStatusServiceObj = dboService.Pm_ItemReportStatusSelect(id,"-1","-1","-1","-1").First();
            PM.Models.Pm_ItemReportStatusMetaData Pm_ItemReportStatusModelObj = JsonConvert.DeserializeObject<PM.Models.Pm_ItemReportStatusMetaData>(JsonConvert.SerializeObject(Pm_ItemReportStatusServiceObj));
            return View(Pm_ItemReportStatusModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: Pm_ItemReportStatus/Create
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

        ///// POST: Pm_ItemReportStatus/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.Pm_ItemReportStatusMetaData Pm_ItemReportStatusModelObj = new Models.Pm_ItemReportStatusMetaData();  
				TryUpdateModel(Pm_ItemReportStatusModelObj);          
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
						    Pm_ItemReportStatusModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                Pm_ItemReportStatusModelObj.IsDeleted = false;                
                Pm_ItemReportStatusModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                Pm_ItemReportStatusModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                Pm_ItemReportStatusModelObj.Creator = PM.GeneralController.getCurrentUser();
                Pm_ItemReportStatusModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.Pm_ItemReportStatus Pm_ItemReportStatusServiceObj = new PMService.Pm_ItemReportStatus();
                    Pm_ItemReportStatusServiceObj = JsonConvert.DeserializeObject<PMService.Pm_ItemReportStatus>(JsonConvert.SerializeObject(Pm_ItemReportStatusModelObj));
                    if ( dboService.Pm_ItemReportStatusInsert(Pm_ItemReportStatusServiceObj) > 0 )					                   
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

        ////// GET: Pm_ItemReportStatus/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.Pm_ItemReportStatus Pm_ItemReportStatusServiceObj =  dboService.Pm_ItemReportStatusSelect(id,"-1","-1","-1","-1").First();
            PM.Models.Pm_ItemReportStatusMetaData Pm_ItemReportStatusModelObj= JsonConvert.DeserializeObject<PM.Models.Pm_ItemReportStatusMetaData>(JsonConvert.SerializeObject(Pm_ItemReportStatusServiceObj));
            return View(Pm_ItemReportStatusModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: Pm_ItemReportStatus/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.Pm_ItemReportStatusMetaData Pm_ItemReportStatusModelObj)
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
                            Pm_ItemReportStatusModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				Pm_ItemReportStatusModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                Pm_ItemReportStatusModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.Pm_ItemReportStatus Pm_ItemReportStatusServiceObj = new PMService.Pm_ItemReportStatus();
                    Pm_ItemReportStatusServiceObj = JsonConvert.DeserializeObject<PMService.Pm_ItemReportStatus>(JsonConvert.SerializeObject(Pm_ItemReportStatusModelObj));
                    if ( dboService.Pm_ItemReportStatusUpdate(Pm_ItemReportStatusServiceObj) > 0 )
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
                return View(Pm_ItemReportStatusModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(Pm_ItemReportStatusModelObj);
            }
        }

        //GET: Pm_ItemReportStatus/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
		try{
            PMService.Pm_ItemReportStatus Pm_ItemReportStatusServiceObj = dboService.Pm_ItemReportStatusSelect(id,"-1","-1","-1","-1").First();
            PM.Models.Pm_ItemReportStatusMetaData Pm_ItemReportStatusModelObj = JsonConvert.DeserializeObject<PM.Models.Pm_ItemReportStatusMetaData>(JsonConvert.SerializeObject(Pm_ItemReportStatusServiceObj));
            return View(Pm_ItemReportStatusModelObj);
           
           }
		catch
             {
                return View();
             }            
        }
  
        ///// POST: Pm_ItemReportStatus/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.Pm_ItemReportStatus Pm_ItemReportStatusServiceObj = dboService.Pm_ItemReportStatusSelect(id,"-1","-1","-1","-1").First();
                Pm_ItemReportStatusServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                Pm_ItemReportStatusServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                Pm_ItemReportStatusServiceObj.IsDeleted = true;               
                if ( dboService.Pm_ItemReportStatusUpdate(Pm_ItemReportStatusServiceObj) >0 )
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


   


