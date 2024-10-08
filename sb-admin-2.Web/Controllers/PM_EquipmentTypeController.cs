
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_EquipmentTypeController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_EquipmentType
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_EquipmentType> PM_EquipmentTypeServiceObj=dboService.PM_EquipmentTypeSelect(-1,"-1","-1","-1","-1");
            IList<PM.Models.PM_EquipmentTypeMetaData> PM_EquipmentTypeModelList = PM_EquipmentTypeServiceObj.OfType<PM.Models.PM_EquipmentTypeMetaData>().ToList();
            PM.Models.PM_EquipmentTypeMetaData PM_EquipmentTypeModelObj = new Models.PM_EquipmentTypeMetaData();
            foreach (PMService.PM_EquipmentType ww in PM_EquipmentTypeServiceObj)
             {
                 PM_EquipmentTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_EquipmentTypeMetaData>(JsonConvert.SerializeObject(ww));
                 PM_EquipmentTypeModelList.Add(PM_EquipmentTypeModelObj);
             }
             return View(PM_EquipmentTypeModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_EquipmentType/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_EquipmentType PM_EquipmentTypeServiceObj = dboService.PM_EquipmentTypeSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_EquipmentTypeMetaData PM_EquipmentTypeModelObj = JsonConvert.DeserializeObject<PM.Models.PM_EquipmentTypeMetaData>(JsonConvert.SerializeObject(PM_EquipmentTypeServiceObj));
            return View(PM_EquipmentTypeModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_EquipmentType/Create
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

        ///// POST: PM_EquipmentType/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_EquipmentTypeMetaData PM_EquipmentTypeModelObj = new Models.PM_EquipmentTypeMetaData();  
				TryUpdateModel(PM_EquipmentTypeModelObj);          
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
						    PM_EquipmentTypeModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_EquipmentTypeModelObj.IsDeleted = false;                
                PM_EquipmentTypeModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentTypeModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentTypeModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_EquipmentTypeModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_EquipmentType PM_EquipmentTypeServiceObj = new PMService.PM_EquipmentType();
                    PM_EquipmentTypeServiceObj = JsonConvert.DeserializeObject<PMService.PM_EquipmentType>(JsonConvert.SerializeObject(PM_EquipmentTypeModelObj));
                    if ( dboService.PM_EquipmentTypeInsert(PM_EquipmentTypeServiceObj) > 0 )					                   
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

        ////// GET: PM_EquipmentType/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_EquipmentType PM_EquipmentTypeServiceObj =  dboService.PM_EquipmentTypeSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_EquipmentTypeMetaData PM_EquipmentTypeModelObj= JsonConvert.DeserializeObject<PM.Models.PM_EquipmentTypeMetaData>(JsonConvert.SerializeObject(PM_EquipmentTypeServiceObj));
            return View(PM_EquipmentTypeModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_EquipmentType/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_EquipmentTypeMetaData PM_EquipmentTypeModelObj)
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
                            PM_EquipmentTypeModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_EquipmentTypeModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentTypeModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_EquipmentType PM_EquipmentTypeServiceObj = new PMService.PM_EquipmentType();
                    PM_EquipmentTypeServiceObj = JsonConvert.DeserializeObject<PMService.PM_EquipmentType>(JsonConvert.SerializeObject(PM_EquipmentTypeModelObj));
                    if ( dboService.PM_EquipmentTypeUpdate(PM_EquipmentTypeServiceObj) > 0 )
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
                return View(PM_EquipmentTypeModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_EquipmentTypeModelObj);
            }
        }

        //GET: PM_EquipmentType/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                
                if (dboService.PM_EquipmentTypeDelete(id) > 0)
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
  
        ///// POST: PM_EquipmentType/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_EquipmentType PM_EquipmentTypeServiceObj = dboService.PM_EquipmentTypeSelect(id,"-1","-1","-1","-1").First();
                PM_EquipmentTypeServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentTypeServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_EquipmentTypeServiceObj.IsDeleted = true;               
                if ( dboService.PM_EquipmentTypeUpdate(PM_EquipmentTypeServiceObj) >0 )
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
            IList<PMService.PM_EquipmentType> PM_DeviceServiceObj = dboService.PM_EquipmentTypeSelect(-1, "-1", "-1", "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_EquipmentType ww in PM_DeviceServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name,
                    Value = ww.PM_EquqipmentTypeID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


