
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_RoutineItemController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_RoutineItem
        public ActionResult Index(int id)
        {
		 try
           {
                PMService.PM_Routine PM_RoutineServiceObj = dboService.PM_RoutineSelect(id, "-1", "-1", "-1", "-1").First();
                ViewBag.Id_Routine = id;
                ViewBag.RoutineNmae = PM_RoutineServiceObj.Name;
                IList< PMService.PM_RoutineItem> PM_RoutineItemServiceObj=dboService.PM_RoutineItemSelect(-1,-1,id,"-1","-1");
            IList<PM.Models.PM_RoutineItemMetaData> PM_RoutineItemModelList = PM_RoutineItemServiceObj.OfType<PM.Models.PM_RoutineItemMetaData>().ToList();
            PM.Models.PM_RoutineItemMetaData PM_RoutineItemModelObj = new Models.PM_RoutineItemMetaData();
            foreach (PMService.PM_RoutineItem ww in PM_RoutineItemServiceObj)
             {
                 PM_RoutineItemModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RoutineItemMetaData>(JsonConvert.SerializeObject(ww));
                 PM_RoutineItemModelList.Add(PM_RoutineItemModelObj);
             }
             return View(PM_RoutineItemModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_RoutineItem/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_RoutineItem PM_RoutineItemServiceObj = dboService.PM_RoutineItemSelect(id,-1,-1,"-1","-1").First();
            PM.Models.PM_RoutineItemMetaData PM_RoutineItemModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RoutineItemMetaData>(JsonConvert.SerializeObject(PM_RoutineItemServiceObj));
            return View(PM_RoutineItemModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_RoutineItem/Create
        public ActionResult Create(int id)
        { 
		 try
           {
                ViewBag.Id_Routine = id;
                ViewBag.Item = PM_ItemController.GetDropdownlist();

                return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_RoutineItem/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_RoutineItemMetaData PM_RoutineItemModelObj = new Models.PM_RoutineItemMetaData();  
				TryUpdateModel(PM_RoutineItemModelObj);          
                if (ModelState.IsValid)
                {
			
                PM_RoutineItemModelObj.IsDeleted = false;                
                PM_RoutineItemModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoutineItemModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoutineItemModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_RoutineItemModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_RoutineItem PM_RoutineItemServiceObj = new PMService.PM_RoutineItem();
                    PM_RoutineItemServiceObj = JsonConvert.DeserializeObject<PMService.PM_RoutineItem>(JsonConvert.SerializeObject(PM_RoutineItemModelObj));
                    if ( dboService.PM_RoutineItemInsert(PM_RoutineItemServiceObj) > 0 )					                   
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;

                    return RedirectToAction("Index",new { id = PM_RoutineItemModelObj.Id_Routine });
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

        ////// GET: PM_RoutineItem/Edit/5
        public ActionResult Edit(int id, int Id_Routine)
        {
		try
            {
                ViewBag.Id_Routine = Id_Routine;
                ViewBag.Item = PM_ItemController.GetDropdownlist();

                PMService.PM_RoutineItem PM_RoutineItemServiceObj =  dboService.PM_RoutineItemSelect(id,-1,-1,"-1","-1").First();
            PM.Models.PM_RoutineItemMetaData PM_RoutineItemModelObj= JsonConvert.DeserializeObject<PM.Models.PM_RoutineItemMetaData>(JsonConvert.SerializeObject(PM_RoutineItemServiceObj));
            return View(PM_RoutineItemModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_RoutineItem/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_RoutineItemMetaData PM_RoutineItemModelObj)
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
                            PM_RoutineItemModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_RoutineItemModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoutineItemModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_RoutineItem PM_RoutineItemServiceObj = new PMService.PM_RoutineItem();
                    PM_RoutineItemServiceObj = JsonConvert.DeserializeObject<PMService.PM_RoutineItem>(JsonConvert.SerializeObject(PM_RoutineItemModelObj));
                    if ( dboService.PM_RoutineItemUpdate(PM_RoutineItemServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index", new { id = PM_RoutineItemServiceObj.Id_Routine });
                }

                // TODO: Add update logic here
				ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
				ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
					Session["Edited"] = false;
                return View(PM_RoutineItemModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_RoutineItemModelObj);
            }
        }

        //GET: PM_RoutineItem/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id, int Id_Routine)
        {
            try
            {
               
                if (dboService.PM_RoutineItemDelete(id) > 0)
                    Session["Deleted"] = true;
                else
                    Session["Deleted"] = false;

                return RedirectToAction("Index", new {id = Id_Routine });
                // TODO: Add update logic here                
            }
            catch
            {
                Session["Deleted"] = false;
                return RedirectToAction("Index");
            }
        }
  
        ///// POST: PM_RoutineItem/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_RoutineItem PM_RoutineItemServiceObj = dboService.PM_RoutineItemSelect(id,-1,-1,"-1","-1").First();
                PM_RoutineItemServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RoutineItemServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_RoutineItemServiceObj.IsDeleted = true;               
                if ( dboService.PM_RoutineItemUpdate(PM_RoutineItemServiceObj) >0 )
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


   


