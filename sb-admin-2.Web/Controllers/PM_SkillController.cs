
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_SkillController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Skill
        public ActionResult Index()
        {
		 try
           {
		    IList< PMService.PM_Skill> PM_SkillServiceObj=dboService.PM_SkillSelect(-1,"-1","-1","-1");
            IList<PM.Models.PM_SkillMetaData> PM_SkillModelList = PM_SkillServiceObj.OfType<PM.Models.PM_SkillMetaData>().ToList();
            PM.Models.PM_SkillMetaData PM_SkillModelObj = new Models.PM_SkillMetaData();
            foreach (PMService.PM_Skill ww in PM_SkillServiceObj)
             {
                 PM_SkillModelObj = JsonConvert.DeserializeObject<PM.Models.PM_SkillMetaData>(JsonConvert.SerializeObject(ww));
                 PM_SkillModelList.Add(PM_SkillModelObj);
             }
             return View(PM_SkillModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Skill/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Skill PM_SkillServiceObj = dboService.PM_SkillSelect(id,"-1","-1","-1").First();
            PM.Models.PM_SkillMetaData PM_SkillModelObj = JsonConvert.DeserializeObject<PM.Models.PM_SkillMetaData>(JsonConvert.SerializeObject(PM_SkillServiceObj));
            return View(PM_SkillModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Skill/Create
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

        ///// POST: PM_Skill/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_SkillMetaData PM_SkillModelObj = new Models.PM_SkillMetaData();  
				TryUpdateModel(PM_SkillModelObj);          
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
						    PM_SkillModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_SkillModelObj.IsDeleted = false;                
                PM_SkillModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_SkillModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_SkillModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_SkillModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Skill PM_SkillServiceObj = new PMService.PM_Skill();
                    PM_SkillServiceObj = JsonConvert.DeserializeObject<PMService.PM_Skill>(JsonConvert.SerializeObject(PM_SkillModelObj));
                    if ( dboService.PM_SkillInsert(PM_SkillServiceObj) > 0 )					                   
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

        ////// GET: PM_Skill/Edit/5
        public ActionResult Edit(int id)
        {
		try{
            ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
			ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
            PMService.PM_Skill PM_SkillServiceObj =  dboService.PM_SkillSelect(id,"-1","-1","-1").First();
            PM.Models.PM_SkillMetaData PM_SkillModelObj= JsonConvert.DeserializeObject<PM.Models.PM_SkillMetaData>(JsonConvert.SerializeObject(PM_SkillServiceObj));
            return View(PM_SkillModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Skill/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_SkillMetaData PM_SkillModelObj)
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
                            PM_SkillModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_SkillModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_SkillModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Skill PM_SkillServiceObj = new PMService.PM_Skill();
                    PM_SkillServiceObj = JsonConvert.DeserializeObject<PMService.PM_Skill>(JsonConvert.SerializeObject(PM_SkillModelObj));
                    if ( dboService.PM_SkillUpdate(PM_SkillServiceObj) > 0 )
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
                return View(PM_SkillModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_SkillModelObj);
            }
        }

        //GET: PM_Skill/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {

            try
            {
                //PMService.PM_Skill PM_SkillServiceObj = dboService.PM_SkillSelect(id, "-1", "-1", "-1").First();
                //PM_SkillServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                //PM_SkillServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                //PM_SkillServiceObj.IsDeleted = true;
                if (dboService.PM_SkillDelete(id) > 0)
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
  
        ///// POST: PM_Skill/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Skill PM_SkillServiceObj = dboService.PM_SkillSelect(id,"-1","-1","-1").First();
                PM_SkillServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_SkillServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_SkillServiceObj.IsDeleted = true;               
                if ( dboService.PM_SkillUpdate(PM_SkillServiceObj) >0 )
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
            IList<PMService.PM_Skill> PM_SkillServiceObj = dboService.PM_SkillSelect(-1, "-1", "True", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Skill ww in PM_SkillServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.name,
                    Value = ww.PM_SkillID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
    }
}


   


