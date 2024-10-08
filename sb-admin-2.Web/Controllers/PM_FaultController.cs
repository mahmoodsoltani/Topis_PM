
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_FaultController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Fault
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Fault> PM_FaultServiceObj=dboService.PM_FaultSelect(-1,"-1","-1","-1","-1");
            IList<PM.Models.PM_FaultMetaData> PM_FaultModelList = PM_FaultServiceObj.OfType<PM.Models.PM_FaultMetaData>().ToList();
            PM.Models.PM_FaultMetaData PM_FaultModelObj = new Models.PM_FaultMetaData();
            foreach (PMService.PM_Fault ww in PM_FaultServiceObj)
             {
                 PM_FaultModelObj = JsonConvert.DeserializeObject<PM.Models.PM_FaultMetaData>(JsonConvert.SerializeObject(ww));
                 PM_FaultModelList.Add(PM_FaultModelObj);
             }
             return View(PM_FaultModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Fault/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Fault PM_FaultServiceObj = dboService.PM_FaultSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_FaultMetaData PM_FaultModelObj = JsonConvert.DeserializeObject<PM.Models.PM_FaultMetaData>(JsonConvert.SerializeObject(PM_FaultServiceObj));
            return View(PM_FaultModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Fault/Create
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

        ///// POST: PM_Fault/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_FaultMetaData PM_FaultModelObj = new Models.PM_FaultMetaData();  
				TryUpdateModel(PM_FaultModelObj);          
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
						    PM_FaultModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_FaultModelObj.IsDeleted = false;                
                PM_FaultModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_FaultModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_FaultModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_FaultModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Fault PM_FaultServiceObj = new PMService.PM_Fault();
                    PM_FaultServiceObj = JsonConvert.DeserializeObject<PMService.PM_Fault>(JsonConvert.SerializeObject(PM_FaultModelObj));
                    if ( dboService.PM_FaultInsert(PM_FaultServiceObj) > 0 )					                   
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

        ////// GET: PM_Fault/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_Fault PM_FaultServiceObj =  dboService.PM_FaultSelect(id,"-1","-1","-1","-1").First();
            PM.Models.PM_FaultMetaData PM_FaultModelObj= JsonConvert.DeserializeObject<PM.Models.PM_FaultMetaData>(JsonConvert.SerializeObject(PM_FaultServiceObj));
            return View(PM_FaultModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Fault/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_FaultMetaData PM_FaultModelObj)
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
                            PM_FaultModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_FaultModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_FaultModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Fault PM_FaultServiceObj = new PMService.PM_Fault();
                    PM_FaultServiceObj = JsonConvert.DeserializeObject<PMService.PM_Fault>(JsonConvert.SerializeObject(PM_FaultModelObj));
                    if ( dboService.PM_FaultUpdate(PM_FaultServiceObj) > 0 )
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
                return View(PM_FaultModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_FaultModelObj);
            }
        }

        //GET: PM_Fault/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {

                if (dboService.PM_FaultDelete(id) > 0)
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

        ///// POST: PM_Fault/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Fault PM_FaultServiceObj = dboService.PM_FaultSelect(id,"-1","-1","-1","-1").First();
                PM_FaultServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_FaultServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_FaultServiceObj.IsDeleted = true;               
                if ( dboService.PM_FaultUpdate(PM_FaultServiceObj) >0 )
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
            IList<PMService.PM_Fault> PM_FaultServiceObj = dboService.PM_FaultSelect(-1, "-1", "-1", "-1", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Fault ww in PM_FaultServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name ,
                    Value = ww.PM_FaultID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


