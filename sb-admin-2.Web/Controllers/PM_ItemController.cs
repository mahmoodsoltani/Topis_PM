
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_ItemController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Item
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Item> PM_ItemServiceObj=dboService.PM_ItemSelect(-1,"-1","-1",-1,"-1","-1");
            IList<PM.Models.PM_ItemMetaData> PM_ItemModelList = PM_ItemServiceObj.OfType<PM.Models.PM_ItemMetaData>().ToList();
            PM.Models.PM_ItemMetaData PM_ItemModelObj = new Models.PM_ItemMetaData();
            foreach (PMService.PM_Item ww in PM_ItemServiceObj)
             {
                 PM_ItemModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ItemMetaData>(JsonConvert.SerializeObject(ww));
                 PM_ItemModelList.Add(PM_ItemModelObj);
             }
             return View(PM_ItemModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Item/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Item PM_ItemServiceObj = dboService.PM_ItemSelect(id,"-1","-1",-1,"-1","-1").First();
            PM.Models.PM_ItemMetaData PM_ItemModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ItemMetaData>(JsonConvert.SerializeObject(PM_ItemServiceObj));
            return View(PM_ItemModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Item/Create
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

        ///// POST: PM_Item/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_ItemMetaData PM_ItemModelObj = new Models.PM_ItemMetaData();  
				TryUpdateModel(PM_ItemModelObj);          
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
						    PM_ItemModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_ItemModelObj.IsDeleted = false;                
                PM_ItemModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_ItemModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Item PM_ItemServiceObj = new PMService.PM_Item();
                    PM_ItemServiceObj = JsonConvert.DeserializeObject<PMService.PM_Item>(JsonConvert.SerializeObject(PM_ItemModelObj));
                    if ( dboService.PM_ItemInsert(PM_ItemServiceObj) > 0 )					                   
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

        ////// GET: PM_Item/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_Item PM_ItemServiceObj =  dboService.PM_ItemSelect(id,"-1","-1",-1,"-1","-1").First();
            PM.Models.PM_ItemMetaData PM_ItemModelObj= JsonConvert.DeserializeObject<PM.Models.PM_ItemMetaData>(JsonConvert.SerializeObject(PM_ItemServiceObj));
            return View(PM_ItemModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Item/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_ItemMetaData PM_ItemModelObj)
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
                            PM_ItemModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_ItemModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Item PM_ItemServiceObj = new PMService.PM_Item();
                    PM_ItemServiceObj = JsonConvert.DeserializeObject<PMService.PM_Item>(JsonConvert.SerializeObject(PM_ItemModelObj));
                    if ( dboService.PM_ItemUpdate(PM_ItemServiceObj) > 0 )
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
                return View(PM_ItemModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_ItemModelObj);
            }
        }

        //GET: PM_Item/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
               
                if (dboService.PM_ItemDelete(id) > 0)
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
  
        ///// POST: PM_Item/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Item PM_ItemServiceObj = dboService.PM_ItemSelect(id,"-1","-1",-1,"-1","-1").First();
                PM_ItemServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ItemServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_ItemServiceObj.IsDeleted = true;               
                if ( dboService.PM_ItemUpdate(PM_ItemServiceObj) >0 )
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
            IList<PMService.PM_Item> PM_ItemServiceObj = dboService.PM_ItemSelect(-1, "-1", "-1", -1, "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Item ww in PM_ItemServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name ,
                    Value = ww.Pm_ItemID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


