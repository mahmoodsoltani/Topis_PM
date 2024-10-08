
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_ItemTypeController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_ItemType
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_ItemType> PM_ItemTypeServiceObj=dboService.PM_ItemTypeSelect(-1,"-1","-1","-1","-1");
            IList<PM.Models.PM_ItemTypeMetaData> PM_ItemTypeModelList = PM_ItemTypeServiceObj.OfType<PM.Models.PM_ItemTypeMetaData>().ToList();
            PM.Models.PM_ItemTypeMetaData PM_ItemTypeModelObj = new Models.PM_ItemTypeMetaData();
            foreach (PMService.PM_ItemType ww in PM_ItemTypeServiceObj)
             {
                 PM_ItemTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ItemTypeMetaData>(JsonConvert.SerializeObject(ww));
                 PM_ItemTypeModelList.Add(PM_ItemTypeModelObj);
             }
             return View(PM_ItemTypeModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_ItemType/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_ItemType PM_ItemTypeServiceObj = dboService.PM_ItemTypeSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_ItemTypeMetaData PM_ItemTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ItemTypeMetaData>(JsonConvert.SerializeObject(PM_ItemTypeServiceObj));
            return View(PM_ItemTypeModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_ItemType/Create
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

        ///// POST: PM_ItemType/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_ItemTypeMetaData PM_ItemTypeModelObj = new Models.PM_ItemTypeMetaData();  
				TryUpdateModel(PM_ItemTypeModelObj);          
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
						    PM_ItemTypeModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_ItemTypeModelObj.IsDeleted = false;                
                PM_ItemTypeModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemTypeModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemTypeModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_ItemTypeModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_ItemType PM_ItemTypeServiceObj = new PMService.PM_ItemType();
                    PM_ItemTypeServiceObj = JsonConvert.DeserializeObject<PMService.PM_ItemType>(JsonConvert.SerializeObject(PM_ItemTypeModelObj));
                    if ( dboService.PM_ItemTypeInsert(PM_ItemTypeServiceObj) > 0 )					                   
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

        ////// GET: PM_ItemType/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_ItemType PM_ItemTypeServiceObj =  dboService.PM_ItemTypeSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_ItemTypeMetaData PM_ItemTypeModelObj= JsonConvert.DeserializeObject<PM.Models.PM_ItemTypeMetaData>(JsonConvert.SerializeObject(PM_ItemTypeServiceObj));
            return View(PM_ItemTypeModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_ItemType/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_ItemTypeMetaData PM_ItemTypeModelObj)
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
                            PM_ItemTypeModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_ItemTypeModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemTypeModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_ItemType PM_ItemTypeServiceObj = new PMService.PM_ItemType();
                    PM_ItemTypeServiceObj = JsonConvert.DeserializeObject<PMService.PM_ItemType>(JsonConvert.SerializeObject(PM_ItemTypeModelObj));
                    if ( dboService.PM_ItemTypeUpdate(PM_ItemTypeServiceObj) > 0 )
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
                return View(PM_ItemTypeModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_ItemTypeModelObj);
            }
        }

        //GET: PM_ItemType/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
		try{
            PMService.PM_ItemType PM_ItemTypeServiceObj = dboService.PM_ItemTypeSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_ItemTypeMetaData PM_ItemTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ItemTypeMetaData>(JsonConvert.SerializeObject(PM_ItemTypeServiceObj));
            return View(PM_ItemTypeModelObj);
           
           }
		catch
             {
                return View();
             }            
        }
  
        ///// POST: PM_ItemType/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_ItemType PM_ItemTypeServiceObj = dboService.PM_ItemTypeSelect(id,"-1","-1","-1","-1").First();
                PM_ItemTypeServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemTypeServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_ItemTypeServiceObj.IsDeleted = true;               
                if ( dboService.PM_ItemTypeUpdate(PM_ItemTypeServiceObj) >0 )
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


   


