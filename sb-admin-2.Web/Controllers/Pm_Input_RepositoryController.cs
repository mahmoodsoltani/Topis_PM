
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_Input_RepositoryController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Input_Repository
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Input_Repository> PM_Input_RepositoryServiceObj=dboService.PM_Input_RepositorySelect(-1,-1,-1,"-1","-1","-1","-1");
            IList<PM.Models.PM_Input_RepositoryMetaData> PM_Input_RepositoryModelList = PM_Input_RepositoryServiceObj.OfType<PM.Models.PM_Input_RepositoryMetaData>().ToList();
            PM.Models.PM_Input_RepositoryMetaData PM_Input_RepositoryModelObj = new Models.PM_Input_RepositoryMetaData();
            foreach (PMService.PM_Input_Repository ww in PM_Input_RepositoryServiceObj)
             {
                 PM_Input_RepositoryModelObj = JsonConvert.DeserializeObject<PM.Models.PM_Input_RepositoryMetaData>(JsonConvert.SerializeObject(ww));
                 PM_Input_RepositoryModelList.Add(PM_Input_RepositoryModelObj);
             }
             return View(PM_Input_RepositoryModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Input_Repository/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Input_Repository PM_Input_RepositoryServiceObj = dboService.PM_Input_RepositorySelect(id,-1,-1,"-1","-1","-1","-1").First();
            PM.Models.PM_Input_RepositoryMetaData PM_Input_RepositoryModelObj = JsonConvert.DeserializeObject<PM.Models.PM_Input_RepositoryMetaData>(JsonConvert.SerializeObject(PM_Input_RepositoryServiceObj));
            return View(PM_Input_RepositoryModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Input_Repository/Create
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

        ///// POST: PM_Input_Repository/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_Input_RepositoryMetaData PM_Input_RepositoryModelObj = new Models.PM_Input_RepositoryMetaData();  
				TryUpdateModel(PM_Input_RepositoryModelObj);          
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
						    PM_Input_RepositoryModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_Input_RepositoryModelObj.IsDeleted = false;                
                PM_Input_RepositoryModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Input_RepositoryModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Input_RepositoryModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_Input_RepositoryModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Input_Repository PM_Input_RepositoryServiceObj = new PMService.PM_Input_Repository();
                    PM_Input_RepositoryServiceObj = JsonConvert.DeserializeObject<PMService.PM_Input_Repository>(JsonConvert.SerializeObject(PM_Input_RepositoryModelObj));
                    if ( dboService.PM_Input_RepositoryInsert(PM_Input_RepositoryServiceObj) > 0 )					                   
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

        ////// GET: PM_Input_Repository/Edit/5
        public ActionResult Edit(int id)
        {
		try{
          
            PMService.PM_Input_Repository PM_Input_RepositoryServiceObj =  dboService.PM_Input_RepositorySelect(id,-1,-1,"-1","-1","-1","-1").First();
            PM.Models.PM_Input_RepositoryMetaData PM_Input_RepositoryModelObj= JsonConvert.DeserializeObject<PM.Models.PM_Input_RepositoryMetaData>(JsonConvert.SerializeObject(PM_Input_RepositoryServiceObj));
            return View(PM_Input_RepositoryModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Input_Repository/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_Input_RepositoryMetaData PM_Input_RepositoryModelObj)
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
                            PM_Input_RepositoryModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_Input_RepositoryModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Input_RepositoryModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Input_Repository PM_Input_RepositoryServiceObj = new PMService.PM_Input_Repository();
                    PM_Input_RepositoryServiceObj = JsonConvert.DeserializeObject<PMService.PM_Input_Repository>(JsonConvert.SerializeObject(PM_Input_RepositoryModelObj));
                    if ( dboService.PM_Input_RepositoryUpdate(PM_Input_RepositoryServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index");
                }

                // TODO: Add update logic here
				
					Session["Edited"] = false;
                return View(PM_Input_RepositoryModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_Input_RepositoryModelObj);
            }
        }

        //GET: PM_Input_Repository/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
		try{
            PMService.PM_Input_Repository PM_Input_RepositoryServiceObj = dboService.PM_Input_RepositorySelect(id,-1,-1,"-1","-1","-1","-1").First();
            PM.Models.PM_Input_RepositoryMetaData PM_Input_RepositoryModelObj = JsonConvert.DeserializeObject<PM.Models.PM_Input_RepositoryMetaData>(JsonConvert.SerializeObject(PM_Input_RepositoryServiceObj));
            return View(PM_Input_RepositoryModelObj);
           
           }
		catch
             {
                return View();
             }            
        }
  
        ///// POST: PM_Input_Repository/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Input_Repository PM_Input_RepositoryServiceObj = dboService.PM_Input_RepositorySelect(id,-1,-1,"-1","-1","-1","-1").First();
                PM_Input_RepositoryServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Input_RepositoryServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_Input_RepositoryServiceObj.IsDeleted = true;               
                if ( dboService.PM_Input_RepositoryUpdate(PM_Input_RepositoryServiceObj) >0 )
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


   


