
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_ProductLineController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_ProductLine
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_ProductLine> PM_ProductLineServiceObj=dboService.PM_ProductLineSelect(-1,"-1",-1,"-1","-1",-1,"-1","-1");
            IList<PM.Models.PM_ProductLineMetaData> PM_ProductLineModelList = PM_ProductLineServiceObj.OfType<PM.Models.PM_ProductLineMetaData>().ToList();
            PM.Models.PM_ProductLineMetaData PM_ProductLineModelObj = new Models.PM_ProductLineMetaData();
            foreach (PMService.PM_ProductLine ww in PM_ProductLineServiceObj)
             {
                 PM_ProductLineModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ProductLineMetaData>(JsonConvert.SerializeObject(ww));
                 PM_ProductLineModelList.Add(PM_ProductLineModelObj);
             }
             return View(PM_ProductLineModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_ProductLine/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_ProductLine PM_ProductLineServiceObj = dboService.PM_ProductLineSelect(id,"-1",-1,"-1","-1",-1,"-1","-1").First();
            PM.Models.PM_ProductLineMetaData PM_ProductLineModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ProductLineMetaData>(JsonConvert.SerializeObject(PM_ProductLineServiceObj));
            return View(PM_ProductLineModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_ProductLine/Create
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
              
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                ViewBag.department = PM_DepartmentController.GetDropDownlist();
                return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_ProductLine/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_ProductLineMetaData PM_ProductLineModelObj = new Models.PM_ProductLineMetaData();  
				TryUpdateModel(PM_ProductLineModelObj);          
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
						    PM_ProductLineModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_ProductLineModelObj.IsDeleted = false;                
                PM_ProductLineModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ProductLineModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ProductLineModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_ProductLineModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_ProductLine PM_ProductLineServiceObj = new PMService.PM_ProductLine();
                    PM_ProductLineServiceObj = JsonConvert.DeserializeObject<PMService.PM_ProductLine>(JsonConvert.SerializeObject(PM_ProductLineModelObj));
                    if ( dboService.PM_ProductLineInsert(PM_ProductLineServiceObj) > 0 )					                   
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;

                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here
			
				
				Session["Inserted"] = false;

                return View();
            }
            catch
            {
			    Session["Inserted"] = false;
                return View();
            }
        }

        ////// GET: PM_ProductLine/Edit/5
        public ActionResult Edit(int id)
        {
		try{
           
            PMService.PM_ProductLine PM_ProductLineServiceObj =  dboService.PM_ProductLineSelect(id,"-1",-1,"-1","-1",-1,"-1","-1").First();
            PM.Models.PM_ProductLineMetaData PM_ProductLineModelObj= JsonConvert.DeserializeObject<PM.Models.PM_ProductLineMetaData>(JsonConvert.SerializeObject(PM_ProductLineServiceObj));
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                ViewBag.department = PM_DepartmentController.GetDropDownlist();
                return View(PM_ProductLineModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_ProductLine/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_ProductLineMetaData PM_ProductLineModelObj)
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
                            PM_ProductLineModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_ProductLineModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ProductLineModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_ProductLine PM_ProductLineServiceObj = new PMService.PM_ProductLine();
                    PM_ProductLineServiceObj = JsonConvert.DeserializeObject<PMService.PM_ProductLine>(JsonConvert.SerializeObject(PM_ProductLineModelObj));
                    if ( dboService.PM_ProductLineUpdate(PM_ProductLineServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index");
                }

                // TODO: Add update logic here
				
					Session["Edited"] = false;
                return View(PM_ProductLineModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_ProductLineModelObj);
            }
        }

        //GET: PM_ProductLine/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
               
                if (dboService.PM_ProductLineDelete(id) > 0)
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
  
        ///// POST: PM_ProductLine/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_ProductLine PM_ProductLineServiceObj = dboService.PM_ProductLineSelect(id,"-1",-1,"-1","-1",-1,"-1","-1").First();
                PM_ProductLineServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ProductLineServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_ProductLineServiceObj.IsDeleted = true;               
                if ( dboService.PM_ProductLineUpdate(PM_ProductLineServiceObj) >0 )
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
            IList<PMService.PM_ProductLine> PM_ProductlineServiceObj = dboService.PM_ProductLineSelect(-1, "-1", -1, "-1", "-1",-1, "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_ProductLine ww in PM_ProductlineServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name,
                    Value = ww.Pm_ProductLineID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
        public static string GetName (int id)
        {
            try
            {
                PMService.dboService dboService = new PMService.dboService();
                PMService.PM_ProductLine PM_ProductLineServiceObj = dboService.PM_ProductLineSelect(id, "-1", -1, "-1", "-1", -1, "-1", "-1").First();
                if (PM_ProductLineServiceObj != null)
                    return PM_ProductLineServiceObj.Name;
                return "";
            }
            catch { return ""; }
        }
    }
}


   


