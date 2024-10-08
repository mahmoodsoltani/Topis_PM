
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_MaterialController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Material
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Material> PM_MaterialServiceObj=dboService.PM_MaterialSelect(-1,"-1","-1",-1,"-1",-1,"-1","-1");
            IList<PM.Models.PM_MaterialMetaData> PM_MaterialModelList = PM_MaterialServiceObj.OfType<PM.Models.PM_MaterialMetaData>().ToList();
            PM.Models.PM_MaterialMetaData PM_MaterialModelObj = new Models.PM_MaterialMetaData();
            foreach (PMService.PM_Material ww in PM_MaterialServiceObj)
             {
                 PM_MaterialModelObj = JsonConvert.DeserializeObject<PM.Models.PM_MaterialMetaData>(JsonConvert.SerializeObject(ww));
                 PM_MaterialModelList.Add(PM_MaterialModelObj);
             }
             return View(PM_MaterialModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Material/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Material PM_MaterialServiceObj = dboService.PM_MaterialSelect(id,"-1","-1",-1,"-1",-1,"-1","-1").First();
            PM.Models.PM_MaterialMetaData PM_MaterialModelObj = JsonConvert.DeserializeObject<PM.Models.PM_MaterialMetaData>(JsonConvert.SerializeObject(PM_MaterialServiceObj));
            return View(PM_MaterialModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Material/Create
        public ActionResult Create()
        { 
		 try
           {
                ViewBag.Unit = PM_UnitController.GetDropdownlist();
                ViewBag.MaterialType = PM_MaterialTypeController.GetDropdownlist();
                return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_Material/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_MaterialMetaData PM_MaterialModelObj = new Models.PM_MaterialMetaData();  
				TryUpdateModel(PM_MaterialModelObj);          
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
						    PM_MaterialModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_MaterialModelObj.IsDeleted = false;                
                PM_MaterialModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_MaterialModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_MaterialModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_MaterialModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Material PM_MaterialServiceObj = new PMService.PM_Material();
                    PM_MaterialServiceObj = JsonConvert.DeserializeObject<PMService.PM_Material>(JsonConvert.SerializeObject(PM_MaterialModelObj));
                    if ( dboService.PM_MaterialInsert(PM_MaterialServiceObj) > 0 )					                   
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

        ////// GET: PM_Material/Edit/5
        public ActionResult Edit(int id)
        {
		try{
                ViewBag.Unit = PM_UnitController.GetDropdownlist();
                ViewBag.MaterialType = PM_MaterialTypeController.GetDropdownlist();
                PMService.PM_Material PM_MaterialServiceObj =  dboService.PM_MaterialSelect(id,"-1","-1",-1,"-1",-1,"-1","-1").First();
            PM.Models.PM_MaterialMetaData PM_MaterialModelObj= JsonConvert.DeserializeObject<PM.Models.PM_MaterialMetaData>(JsonConvert.SerializeObject(PM_MaterialServiceObj));
            return View(PM_MaterialModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Material/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_MaterialMetaData PM_MaterialModelObj)
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
                            PM_MaterialModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_MaterialModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_MaterialModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Material PM_MaterialServiceObj = new PMService.PM_Material();
                    PM_MaterialServiceObj = JsonConvert.DeserializeObject<PMService.PM_Material>(JsonConvert.SerializeObject(PM_MaterialModelObj));
                    if ( dboService.PM_MaterialUpdate(PM_MaterialServiceObj) > 0 )
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
                return View(PM_MaterialModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_MaterialModelObj);
            }
        }

        //GET: PM_Material/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
               
                if (dboService.PM_MaterialDelete(id)> 0)
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
  
        ///// POST: PM_Material/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Material PM_MaterialServiceObj = dboService.PM_MaterialSelect(id,"-1","-1",-1,"-1",-1,"-1","-1").First();
                PM_MaterialServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_MaterialServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_MaterialServiceObj.IsDeleted = true;               
                if ( dboService.PM_MaterialUpdate(PM_MaterialServiceObj) >0 )
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
            IList<PMService.PM_Material> PM_DeviceServiceObj = dboService.PM_MaterialSelect(-1, "-1","-1",-1, "-1",-1, "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Material ww in PM_DeviceServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.name,
                    Value = ww.PM_MaterialID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


