
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_WorkOrderTypeController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_WorkOrderType
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_WorkOrderType> PM_WorkOrderTypeServiceObj=dboService.PM_WorkOrderTypeSelect(-1,"-1","-1","-1");
            IList<PM.Models.PM_WorkOrderTypeMetaData> PM_WorkOrderTypeModelList = PM_WorkOrderTypeServiceObj.OfType<PM.Models.PM_WorkOrderTypeMetaData>().ToList();
            PM.Models.PM_WorkOrderTypeMetaData PM_WorkOrderTypeModelObj = new Models.PM_WorkOrderTypeMetaData();
            foreach (PMService.PM_WorkOrderType ww in PM_WorkOrderTypeServiceObj)
             {
                 PM_WorkOrderTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderTypeMetaData>(JsonConvert.SerializeObject(ww));
                 PM_WorkOrderTypeModelList.Add(PM_WorkOrderTypeModelObj);
             }
             return View(PM_WorkOrderTypeModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_WorkOrderType/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_WorkOrderType PM_WorkOrderTypeServiceObj = dboService.PM_WorkOrderTypeSelect(id,"-1","-1","-1").First();
            PM.Models.PM_WorkOrderTypeMetaData PM_WorkOrderTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderTypeMetaData>(JsonConvert.SerializeObject(PM_WorkOrderTypeServiceObj));
            return View(PM_WorkOrderTypeModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_WorkOrderType/Create
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

        ///// POST: PM_WorkOrderType/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_WorkOrderTypeMetaData PM_WorkOrderTypeModelObj = new Models.PM_WorkOrderTypeMetaData();  
				TryUpdateModel(PM_WorkOrderTypeModelObj);          
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
						    PM_WorkOrderTypeModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_WorkOrderTypeModelObj.IsDeleted = false;                
                PM_WorkOrderTypeModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderTypeModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderTypeModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_WorkOrderTypeModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_WorkOrderType PM_WorkOrderTypeServiceObj = new PMService.PM_WorkOrderType();
                    PM_WorkOrderTypeServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrderType>(JsonConvert.SerializeObject(PM_WorkOrderTypeModelObj));
                    if ( dboService.PM_WorkOrderTypeInsert(PM_WorkOrderTypeServiceObj) > 0 )					                   
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

        ////// GET: PM_WorkOrderType/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_WorkOrderType PM_WorkOrderTypeServiceObj =  dboService.PM_WorkOrderTypeSelect(id,"-1","-1","-1").First();
            PM.Models.PM_WorkOrderTypeMetaData PM_WorkOrderTypeModelObj= JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderTypeMetaData>(JsonConvert.SerializeObject(PM_WorkOrderTypeServiceObj));
            return View(PM_WorkOrderTypeModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_WorkOrderType/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_WorkOrderTypeMetaData PM_WorkOrderTypeModelObj)
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
                            PM_WorkOrderTypeModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_WorkOrderTypeModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderTypeModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_WorkOrderType PM_WorkOrderTypeServiceObj = new PMService.PM_WorkOrderType();
                    PM_WorkOrderTypeServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrderType>(JsonConvert.SerializeObject(PM_WorkOrderTypeModelObj));
                    if ( dboService.PM_WorkOrderTypeUpdate(PM_WorkOrderTypeServiceObj) > 0 )
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
                return View(PM_WorkOrderTypeModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_WorkOrderTypeModelObj);
            }
        }

        //GET: PM_WorkOrderType/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
		try{
            PMService.PM_WorkOrderType PM_WorkOrderTypeServiceObj = dboService.PM_WorkOrderTypeSelect(id,"-1","-1","-1").First();
            PM.Models.PM_WorkOrderTypeMetaData PM_WorkOrderTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderTypeMetaData>(JsonConvert.SerializeObject(PM_WorkOrderTypeServiceObj));
            return View(PM_WorkOrderTypeModelObj);
           
           }
		catch
             {
                return View();
             }            
        }
  
        ///// POST: PM_WorkOrderType/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_WorkOrderType PM_WorkOrderTypeServiceObj = dboService.PM_WorkOrderTypeSelect(id,"-1","-1","-1").First();
                PM_WorkOrderTypeServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderTypeServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_WorkOrderTypeServiceObj.IsDeleted = true;               
                if ( dboService.PM_WorkOrderTypeUpdate(PM_WorkOrderTypeServiceObj) >0 )
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


   


