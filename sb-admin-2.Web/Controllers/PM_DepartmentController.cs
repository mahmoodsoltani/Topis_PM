
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace PM.Controllers
{
  public class PM_DepartmentController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Department
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Department> PM_DepartmentServiceObj=dboService.PM_DepartmentSelect(-1,"-1",-1,"-1","-1","false");
            IList<PM.Models.PM_DepartmentMetaData> PM_DepartmentModelList = PM_DepartmentServiceObj.OfType<PM.Models.PM_DepartmentMetaData>().ToList();
            PM.Models.PM_DepartmentMetaData PM_DepartmentModelObj = new Models.PM_DepartmentMetaData();
            foreach (PMService.PM_Department ww in PM_DepartmentServiceObj)
             {
                 PM_DepartmentModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DepartmentMetaData>(JsonConvert.SerializeObject(ww));
                 PM_DepartmentModelList.Add(PM_DepartmentModelObj);
             }
             return View(PM_DepartmentModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Department/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Department PM_DepartmentServiceObj = dboService.PM_DepartmentSelect(id,"-1",-1,"-1","-1","-1").First();
            PM.Models.PM_DepartmentMetaData PM_DepartmentModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DepartmentMetaData>(JsonConvert.SerializeObject(PM_DepartmentServiceObj));
            return View(PM_DepartmentModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Department/Create
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
                ViewBag.Factory = PM_FactoryController.GetDropdownlist();
                return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_Department/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_DepartmentMetaData PM_DepartmentModelObj = new Models.PM_DepartmentMetaData();  
				TryUpdateModel(PM_DepartmentModelObj);          
                if (ModelState.IsValid)
                {

                PM_DepartmentModelObj.IsDeleted = false;                
                PM_DepartmentModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_DepartmentModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_DepartmentModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_DepartmentModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Department PM_DepartmentServiceObj = new PMService.PM_Department();
                    PM_DepartmentServiceObj = JsonConvert.DeserializeObject<PMService.PM_Department>(JsonConvert.SerializeObject(PM_DepartmentModelObj));
                    if ( dboService.PM_DepartmentInsert(PM_DepartmentServiceObj) > 0 )					                   
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

        ////// GET: PM_Department/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
                ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
                PMService.PM_Department PM_DepartmentServiceObj = dboService.PM_DepartmentSelect(id, "-1", -1, "-1", "-1", "-1").First();
                PM.Models.PM_DepartmentMetaData PM_DepartmentModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DepartmentMetaData>(JsonConvert.SerializeObject(PM_DepartmentServiceObj));
                IList<PMService.PM_Factory> PM_FactoryServiceObj = dboService.PM_FactorySelect(-1, "-1", "-1", "-1", "-1", "-1");
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (PMService.PM_Factory ww in PM_FactoryServiceObj)
                {

                    items.Add(new SelectListItem
                    {
                        Text = ww.Name,
                        Value = ww.PM_FactoryID.ToString(),
                        // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                    });

                }

                ViewBag.Factory = items;
                return View(PM_DepartmentModelObj);
            }
            catch
            {
                return View();
            }            
        }

        ////// POST: PM_Department/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_DepartmentMetaData PM_DepartmentModelObj)
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
                            PM_DepartmentModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_DepartmentModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_DepartmentModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Department PM_DepartmentServiceObj = new PMService.PM_Department();
                    PM_DepartmentServiceObj = JsonConvert.DeserializeObject<PMService.PM_Department>(JsonConvert.SerializeObject(PM_DepartmentModelObj));
                    if ( dboService.PM_DepartmentUpdate(PM_DepartmentServiceObj) > 0 )
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
                return View(PM_DepartmentModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_DepartmentModelObj);
            }
        }

        //GET: PM_Department/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
		try{
                //PMService.PM_Department PM_DepartmentServiceObj = dboService.PM_DepartmentSelect(id, "-1", -1, "-1", "-1", "-1").First();
                //PM_DepartmentServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                //PM_DepartmentServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                //PM_DepartmentServiceObj.IsDeleted = true;
                if (dboService.PM_DepartmentDelete(id) > 0)
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
  
        ///// POST: PM_Department/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Department PM_DepartmentServiceObj = dboService.PM_DepartmentSelect(id,"-1",-1,"-1","-1","-1").First();
                PM_DepartmentServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_DepartmentServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_DepartmentServiceObj.IsDeleted = true;               
                if ( dboService.PM_DepartmentUpdate(PM_DepartmentServiceObj) >0 )
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
        public static List<SelectListItem> GetDropDownlist()
        {
            PMService.dboService dboService = new PMService.dboService();

            IList<PMService.PM_Department> PM_DepartmentServiceObj = dboService.PM_DepartmentSelect(-1, "-1",-1, "-1", "True", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Department ww in PM_DepartmentServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name+"_"+ww.FactoryName,
                    Value = ww.PM_DepartmentID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }
            return items;
        }
        public static List<SelectListItem> SimpleGetDropDownlist()
        {
            PMService.dboService dboService = new PMService.dboService();

            IList<PMService.PM_Department> PM_DepartmentServiceObj = dboService.PM_DepartmentSelect(-1, "-1", -1, "-1", "True", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Department ww in PM_DepartmentServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name,
                    Value = ww.PM_DepartmentID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }
            return items;
        }
    }
}


   


