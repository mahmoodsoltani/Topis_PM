
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_WorkOrderStatusController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_WorkOrderStatus
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_WorkOrderStatus> PM_WorkOrderStatusServiceObj=dboService.PM_WorkOrderStatusSelect(-1,"-1","-1","-1");
            IList<PM.Models.PM_WorkOrderStatusMetaData> PM_WorkOrderStatusModelList = PM_WorkOrderStatusServiceObj.OfType<PM.Models.PM_WorkOrderStatusMetaData>().ToList();
            PM.Models.PM_WorkOrderStatusMetaData PM_WorkOrderStatusModelObj = new Models.PM_WorkOrderStatusMetaData();
            foreach (PMService.PM_WorkOrderStatus ww in PM_WorkOrderStatusServiceObj)
             {
                 PM_WorkOrderStatusModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderStatusMetaData>(JsonConvert.SerializeObject(ww));
                 PM_WorkOrderStatusModelList.Add(PM_WorkOrderStatusModelObj);
             }
             return View(PM_WorkOrderStatusModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_WorkOrderStatus/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_WorkOrderStatus PM_WorkOrderStatusServiceObj = dboService.PM_WorkOrderStatusSelect(id,"-1","-1","-1").First();
            PM.Models.PM_WorkOrderStatusMetaData PM_WorkOrderStatusModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderStatusMetaData>(JsonConvert.SerializeObject(PM_WorkOrderStatusServiceObj));
            return View(PM_WorkOrderStatusModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

        ////// GET: PM_WorkOrderStatus/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }

        ///// POST: PM_WorkOrderStatus/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_WorkOrderStatusMetaData PM_WorkOrderStatusModelObj = new Models.PM_WorkOrderStatusMetaData();  
				TryUpdateModel(PM_WorkOrderStatusModelObj);          
                if (ModelState.IsValid)
                {
               
                PM_WorkOrderStatusModelObj.IsDeleted = false;                
                PM_WorkOrderStatusModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderStatusModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderStatusModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_WorkOrderStatusModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_WorkOrderStatus PM_WorkOrderStatusServiceObj = new PMService.PM_WorkOrderStatus();
                    PM_WorkOrderStatusServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrderStatus>(JsonConvert.SerializeObject(PM_WorkOrderStatusModelObj));
                    if ( dboService.PM_WorkOrderStatusInsert(PM_WorkOrderStatusServiceObj) > 0 )					                   
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

        ////// GET: PM_WorkOrderStatus/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_WorkOrderStatus PM_WorkOrderStatusServiceObj =  dboService.PM_WorkOrderStatusSelect(id,"-1","-1","-1").First();
            PM.Models.PM_WorkOrderStatusMetaData PM_WorkOrderStatusModelObj= JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderStatusMetaData>(JsonConvert.SerializeObject(PM_WorkOrderStatusServiceObj));
            return View(PM_WorkOrderStatusModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_WorkOrderStatus/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_WorkOrderStatusMetaData PM_WorkOrderStatusModelObj)
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
                            PM_WorkOrderStatusModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_WorkOrderStatusModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderStatusModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_WorkOrderStatus PM_WorkOrderStatusServiceObj = new PMService.PM_WorkOrderStatus();
                    PM_WorkOrderStatusServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrderStatus>(JsonConvert.SerializeObject(PM_WorkOrderStatusModelObj));
                    if ( dboService.PM_WorkOrderStatusUpdate(PM_WorkOrderStatusServiceObj) > 0 )
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
                return View(PM_WorkOrderStatusModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_WorkOrderStatusModelObj);
            }
        }

        //GET: PM_WorkOrderStatus/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
               
                if (dboService.PM_WorkOrderStatusDelete(id) > 0)
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
  
        ///// POST: PM_WorkOrderStatus/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_WorkOrderStatus PM_WorkOrderStatusServiceObj = dboService.PM_WorkOrderStatusSelect(id,"-1","-1","-1").First();
                PM_WorkOrderStatusServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderStatusServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_WorkOrderStatusServiceObj.IsDeleted = true;               
                if ( dboService.PM_WorkOrderStatusUpdate(PM_WorkOrderStatusServiceObj) >0 )
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
            IList<PMService.PM_WorkOrderStatus> PM_StatusServiceObj = dboService.PM_WorkOrderStatusSelect(-1, "-1",  "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_WorkOrderStatus ww in PM_StatusServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name,
                    Value = ww.PM_WorkOrderStatusID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


