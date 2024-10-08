
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_MaterialTypeController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_MaterialType
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_MaterialType> PM_MaterialTypeServiceObj=dboService.PM_MaterialTypeSelect(-1,"-1","-1","-1","-1");
            IList<PM.Models.PM_MaterialTypeMetaData> PM_MaterialTypeModelList = PM_MaterialTypeServiceObj.OfType<PM.Models.PM_MaterialTypeMetaData>().ToList();
            PM.Models.PM_MaterialTypeMetaData PM_MaterialTypeModelObj = new Models.PM_MaterialTypeMetaData();
            foreach (PMService.PM_MaterialType ww in PM_MaterialTypeServiceObj)
             {
                 PM_MaterialTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_MaterialTypeMetaData>(JsonConvert.SerializeObject(ww));
                 PM_MaterialTypeModelList.Add(PM_MaterialTypeModelObj);
             }
             return View(PM_MaterialTypeModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_MaterialType/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_MaterialType PM_MaterialTypeServiceObj = dboService.PM_MaterialTypeSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_MaterialTypeMetaData PM_MaterialTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_MaterialTypeMetaData>(JsonConvert.SerializeObject(PM_MaterialTypeServiceObj));
            return View(PM_MaterialTypeModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_MaterialType/Create
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

        ///// POST: PM_MaterialType/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_MaterialTypeMetaData PM_MaterialTypeModelObj = new Models.PM_MaterialTypeMetaData();  
				TryUpdateModel(PM_MaterialTypeModelObj);          
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
						    PM_MaterialTypeModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_MaterialTypeModelObj.IsDeleted = false;                
                PM_MaterialTypeModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_MaterialTypeModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_MaterialTypeModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_MaterialTypeModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_MaterialType PM_MaterialTypeServiceObj = new PMService.PM_MaterialType();
                    PM_MaterialTypeServiceObj = JsonConvert.DeserializeObject<PMService.PM_MaterialType>(JsonConvert.SerializeObject(PM_MaterialTypeModelObj));
                    if ( dboService.PM_MaterialTypeInsert(PM_MaterialTypeServiceObj) > 0 )					                   
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

        ////// GET: PM_MaterialType/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_MaterialType PM_MaterialTypeServiceObj =  dboService.PM_MaterialTypeSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_MaterialTypeMetaData PM_MaterialTypeModelObj= JsonConvert.DeserializeObject<PM.Models.PM_MaterialTypeMetaData>(JsonConvert.SerializeObject(PM_MaterialTypeServiceObj));
            return View(PM_MaterialTypeModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_MaterialType/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_MaterialTypeMetaData PM_MaterialTypeModelObj)
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
                            PM_MaterialTypeModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_MaterialTypeModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_MaterialTypeModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_MaterialType PM_MaterialTypeServiceObj = new PMService.PM_MaterialType();
                    PM_MaterialTypeServiceObj = JsonConvert.DeserializeObject<PMService.PM_MaterialType>(JsonConvert.SerializeObject(PM_MaterialTypeModelObj));
                    if ( dboService.PM_MaterialTypeUpdate(PM_MaterialTypeServiceObj) > 0 )
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
                return View(PM_MaterialTypeModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_MaterialTypeModelObj);
            }
        }

        //GET: PM_MaterialType/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                
                if (dboService.PM_MaterialTypeDelete(id) > 0)
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
  
        ///// POST: PM_MaterialType/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_MaterialType PM_MaterialTypeServiceObj = dboService.PM_MaterialTypeSelect(id,"-1","-1","-1","-1").First();
                PM_MaterialTypeServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_MaterialTypeServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_MaterialTypeServiceObj.IsDeleted = true;               
                if ( dboService.PM_MaterialTypeUpdate(PM_MaterialTypeServiceObj) >0 )
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
            IList<PMService.PM_MaterialType> PM_DeviceServiceObj = dboService.PM_MaterialTypeSelect(-1, "-1","-1", "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_MaterialType ww in PM_DeviceServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name,
                    Value = ww.PM_MaterialTypeID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


