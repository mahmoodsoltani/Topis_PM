
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
   
    public class PM_Workorder_PersonController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Workorder_Person
        public ActionResult Index(int id)
        {
		 try
           {
		    IList< PMService.PM_Workorder_Person> PM_Workorder_PersonServiceObj=dboService.PM_Workorder_PersonSelect(-1,-1,-1,"-1",id,"-1","-1");
            IList<PM.Models.PM_Workorder_PersonMetaData> PM_Workorder_PersonModelList = PM_Workorder_PersonServiceObj.OfType<PM.Models.PM_Workorder_PersonMetaData>().ToList();
            PM.Models.PM_Workorder_PersonMetaData PM_Workorder_PersonModelObj = new Models.PM_Workorder_PersonMetaData();
            foreach (PMService.PM_Workorder_Person ww in PM_Workorder_PersonServiceObj)
             {
                 PM_Workorder_PersonModelObj = JsonConvert.DeserializeObject<PM.Models.PM_Workorder_PersonMetaData>(JsonConvert.SerializeObject(ww));
                 PM_Workorder_PersonModelList.Add(PM_Workorder_PersonModelObj);
             }
             return View(PM_Workorder_PersonModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Workorder_Person/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Workorder_Person PM_Workorder_PersonServiceObj = dboService.PM_Workorder_PersonSelect(id,-1,-1,"-1",-1,"-1","-1").First();
            PM.Models.PM_Workorder_PersonMetaData PM_Workorder_PersonModelObj = JsonConvert.DeserializeObject<PM.Models.PM_Workorder_PersonMetaData>(JsonConvert.SerializeObject(PM_Workorder_PersonServiceObj));
            return View(PM_Workorder_PersonModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Workorder_Person/Create
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

        ///// POST: PM_Workorder_Person/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_Workorder_PersonMetaData PM_Workorder_PersonModelObj = new Models.PM_Workorder_PersonMetaData();  
				TryUpdateModel(PM_Workorder_PersonModelObj);          
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
						    PM_Workorder_PersonModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_Workorder_PersonModelObj.IsDeleted = false;                
                PM_Workorder_PersonModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Workorder_PersonModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Workorder_PersonModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_Workorder_PersonModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Workorder_Person PM_Workorder_PersonServiceObj = new PMService.PM_Workorder_Person();
                    PM_Workorder_PersonServiceObj = JsonConvert.DeserializeObject<PMService.PM_Workorder_Person>(JsonConvert.SerializeObject(PM_Workorder_PersonModelObj));
                    if ( dboService.PM_Workorder_PersonInsert(PM_Workorder_PersonServiceObj) > 0 )					                   
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

        ////// GET: PM_Workorder_Person/Edit/5
        public ActionResult Edit(int id)
        {
		try{
          
            PMService.PM_Workorder_Person PM_Workorder_PersonServiceObj =  dboService.PM_Workorder_PersonSelect(id,-1,-1,"-1",-1,"-1","-1").First();
            PM.Models.PM_Workorder_PersonMetaData PM_Workorder_PersonModelObj= JsonConvert.DeserializeObject<PM.Models.PM_Workorder_PersonMetaData>(JsonConvert.SerializeObject(PM_Workorder_PersonServiceObj));
            return View(PM_Workorder_PersonModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Workorder_Person/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_Workorder_PersonMetaData PM_Workorder_PersonModelObj)
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
                            PM_Workorder_PersonModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_Workorder_PersonModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Workorder_PersonModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Workorder_Person PM_Workorder_PersonServiceObj = new PMService.PM_Workorder_Person();
                    PM_Workorder_PersonServiceObj = JsonConvert.DeserializeObject<PMService.PM_Workorder_Person>(JsonConvert.SerializeObject(PM_Workorder_PersonModelObj));
                    if ( dboService.PM_Workorder_PersonUpdate(PM_Workorder_PersonServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index");
                }

                // TODO: Add update logic here
			
					Session["Edited"] = false;
                return View(PM_Workorder_PersonModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_Workorder_PersonModelObj);
            }
        }

        //GET: PM_Workorder_Person/Delete/5
        //[HttpDelete]
       
        public bool  Delete(InputData p)
        {
            try
            {

                if (dboService.PM_Workorder_PersonDelete(Convert.ToInt32( p.id)) > 0)
                    return true;
                else
                    return false;


                // TODO: Add update logic here                
            }
            catch
            {
                
                return false;
            }
        }
  
        ///// POST: PM_Workorder_Person/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Workorder_Person PM_Workorder_PersonServiceObj = dboService.PM_Workorder_PersonSelect(id,-1,-1,"-1",-1,"-1","-1").First();
                PM_Workorder_PersonServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_Workorder_PersonServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_Workorder_PersonServiceObj.IsDeleted = true;               
                if ( dboService.PM_Workorder_PersonUpdate(PM_Workorder_PersonServiceObj) >0 )
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


   


