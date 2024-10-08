
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_OccurTypeController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_OccurType
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_OccurType> PM_OccurTypeServiceObj=dboService.PM_OccurTypeSelect(-1,"-1","-1","-1");
            IList<PM.Models.PM_OccurTypeMetaData> PM_OccurTypeModelList = PM_OccurTypeServiceObj.OfType<PM.Models.PM_OccurTypeMetaData>().ToList();
            PM.Models.PM_OccurTypeMetaData PM_OccurTypeModelObj = new Models.PM_OccurTypeMetaData();
            foreach (PMService.PM_OccurType ww in PM_OccurTypeServiceObj)
             {
                 PM_OccurTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_OccurTypeMetaData>(JsonConvert.SerializeObject(ww));
                 PM_OccurTypeModelList.Add(PM_OccurTypeModelObj);
             }
             return View(PM_OccurTypeModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_OccurType/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_OccurType PM_OccurTypeServiceObj = dboService.PM_OccurTypeSelect(id,"-1","-1","-1").First();
            PM.Models.PM_OccurTypeMetaData PM_OccurTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_OccurTypeMetaData>(JsonConvert.SerializeObject(PM_OccurTypeServiceObj));
            return View(PM_OccurTypeModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_OccurType/Create
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

        ///// POST: PM_OccurType/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_OccurTypeMetaData PM_OccurTypeModelObj = new Models.PM_OccurTypeMetaData();  
				TryUpdateModel(PM_OccurTypeModelObj);          
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
						    PM_OccurTypeModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_OccurTypeModelObj.IsDeleted = false;                
                PM_OccurTypeModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_OccurTypeModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_OccurTypeModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_OccurTypeModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_OccurType PM_OccurTypeServiceObj = new PMService.PM_OccurType();
                    PM_OccurTypeServiceObj = JsonConvert.DeserializeObject<PMService.PM_OccurType>(JsonConvert.SerializeObject(PM_OccurTypeModelObj));
                    if ( dboService.PM_OccurTypeInsert(PM_OccurTypeServiceObj) > 0 )					                   
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

        ////// GET: PM_OccurType/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_OccurType PM_OccurTypeServiceObj =  dboService.PM_OccurTypeSelect(id,"-1","-1","-1").First();
            PM.Models.PM_OccurTypeMetaData PM_OccurTypeModelObj= JsonConvert.DeserializeObject<PM.Models.PM_OccurTypeMetaData>(JsonConvert.SerializeObject(PM_OccurTypeServiceObj));
            return View(PM_OccurTypeModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_OccurType/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_OccurTypeMetaData PM_OccurTypeModelObj)
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
                            PM_OccurTypeModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_OccurTypeModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_OccurTypeModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_OccurType PM_OccurTypeServiceObj = new PMService.PM_OccurType();
                    PM_OccurTypeServiceObj = JsonConvert.DeserializeObject<PMService.PM_OccurType>(JsonConvert.SerializeObject(PM_OccurTypeModelObj));
                    if ( dboService.PM_OccurTypeUpdate(PM_OccurTypeServiceObj) > 0 )
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
                return View(PM_OccurTypeModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_OccurTypeModelObj);
            }
        }

        //GET: PM_OccurType/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
		try{
            PMService.PM_OccurType PM_OccurTypeServiceObj = dboService.PM_OccurTypeSelect(id,"-1","-1","-1").First();
            PM.Models.PM_OccurTypeMetaData PM_OccurTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_OccurTypeMetaData>(JsonConvert.SerializeObject(PM_OccurTypeServiceObj));
            return View(PM_OccurTypeModelObj);
           
           }
		catch
             {
                return View();
             }            
        }
  
        ///// POST: PM_OccurType/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_OccurType PM_OccurTypeServiceObj = dboService.PM_OccurTypeSelect(id,"-1","-1","-1").First();
                PM_OccurTypeServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_OccurTypeServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_OccurTypeServiceObj.IsDeleted = true;               
                if ( dboService.PM_OccurTypeUpdate(PM_OccurTypeServiceObj) >0 )
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
            IList<PMService.PM_OccurType> PM_DccurTypeServiceObj = dboService.PM_OccurTypeSelect(-1, "-1","true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_OccurType ww in PM_DccurTypeServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name,
                    Value = ww.Pm_OccurTypeID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


