
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  
  public class PM_RepairOrderFaultController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_RepairOrderFault
        public ActionResult Index(int id)
        {
		 try
           {
                PMService.PM_RepairOrder PM_RepairOrderServiceObj = dboService.PM_RepairOrderSelect(id, -1, "-1", "-1", "-1", -1, -1, "-1", "-1", "-1").First();
                if (PM_RepairOrderServiceObj != null)
                    ViewBag.repairOrderNumber = PM_RepairOrderServiceObj.RepairOrderNumber;
                IList< PMService.PM_RepairOrderFault> PM_RepairOrderFaultServiceObj=dboService.PM_RepairOrderFaultSelect(-1,id,-1,"-1","-1","-1","-1","-1","-1","-1");
            IList<PM.Models.PM_RepairOrderFaultMetaData> PM_RepairOrderFaultModelList = PM_RepairOrderFaultServiceObj.OfType<PM.Models.PM_RepairOrderFaultMetaData>().ToList();
            PM.Models.PM_RepairOrderFaultMetaData PM_RepairOrderFaultModelObj = new Models.PM_RepairOrderFaultMetaData();
            foreach (PMService.PM_RepairOrderFault ww in PM_RepairOrderFaultServiceObj)
             {
                 PM_RepairOrderFaultModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RepairOrderFaultMetaData>(JsonConvert.SerializeObject(ww));
                 PM_RepairOrderFaultModelList.Add(PM_RepairOrderFaultModelObj);
             }
                ViewBag.Id_RepairOrder = id;
                return View(PM_RepairOrderFaultModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_RepairOrderFault/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_RepairOrderFault PM_RepairOrderFaultServiceObj = dboService.PM_RepairOrderFaultSelect(id,-1,-1,"-1","-1","-1","-1","-1","-1","-1").First();
            PM.Models.PM_RepairOrderFaultMetaData PM_RepairOrderFaultModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RepairOrderFaultMetaData>(JsonConvert.SerializeObject(PM_RepairOrderFaultServiceObj));
            return View(PM_RepairOrderFaultModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_RepairOrderFault/Create
        public ActionResult Create(int  id )
        { 
		 try
           {
                ViewBag.Id_RepairOrder = id;
                ViewBag.Fault = PM_FaultController.GetDropdownlist();
                return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_RepairOrderFault/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_RepairOrderFaultMetaData PM_RepairOrderFaultModelObj = new Models.PM_RepairOrderFaultMetaData();  
				TryUpdateModel(PM_RepairOrderFaultModelObj);          
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
						    PM_RepairOrderFaultModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                PM_RepairOrderFaultModelObj.IsDeleted = false;                
                PM_RepairOrderFaultModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RepairOrderFaultModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RepairOrderFaultModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_RepairOrderFaultModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PM_RepairOrderFaultModelObj.IsEnabled = true;

                    PMService.PM_RepairOrderFault PM_RepairOrderFaultServiceObj = new PMService.PM_RepairOrderFault();
                    PM_RepairOrderFaultServiceObj = JsonConvert.DeserializeObject<PMService.PM_RepairOrderFault>(JsonConvert.SerializeObject(PM_RepairOrderFaultModelObj));
                    if ( dboService.PM_RepairOrderFaultInsert(PM_RepairOrderFaultServiceObj) > 0 )					                   
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;

                    return RedirectToAction("Index", new { id = PM_RepairOrderFaultServiceObj.Id_RepairOrder });
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

        ////// GET: PM_RepairOrderFault/Edit/5
        public ActionResult Edit(int id)
        {
		try{
                ViewBag.Fault = PM_FaultController.GetDropdownlist();

                PMService.PM_RepairOrderFault PM_RepairOrderFaultServiceObj =  dboService.PM_RepairOrderFaultSelect(id,-1,-1,"-1","-1","-1","-1","-1","-1","-1").First();
            PM.Models.PM_RepairOrderFaultMetaData PM_RepairOrderFaultModelObj= JsonConvert.DeserializeObject<PM.Models.PM_RepairOrderFaultMetaData>(JsonConvert.SerializeObject(PM_RepairOrderFaultServiceObj));
            return View(PM_RepairOrderFaultModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_RepairOrderFault/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_RepairOrderFaultMetaData PM_RepairOrderFaultModelObj)
        {
            try
            {                
                if (ModelState.IsValid)
                {
				
				PM_RepairOrderFaultModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RepairOrderFaultModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_RepairOrderFault PM_RepairOrderFaultServiceObj = new PMService.PM_RepairOrderFault();
                    PM_RepairOrderFaultServiceObj = JsonConvert.DeserializeObject<PMService.PM_RepairOrderFault>(JsonConvert.SerializeObject(PM_RepairOrderFaultModelObj));
                    if ( dboService.PM_RepairOrderFaultUpdate(PM_RepairOrderFaultServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index",new { id= PM_RepairOrderFaultServiceObj.Id_RepairOrder });
                }

                // TODO: Add update logic here
				ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
				ViewBag.Enab = new SelectList(new List<SelectListItem>
                        {
                         new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                         new SelectListItem { Text = "غير فعال", Value = "0"},
                        }, "Value", "Text");
					Session["Edited"] = false;
                return View(PM_RepairOrderFaultModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_RepairOrderFaultModelObj);
            }
        }

        //GET: PM_RepairOrderFault/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id,int id_RepaireOrder)
        {
            try
            {

                if (dboService.PM_RepairOrderFaultDelete(id) > 0)
                    Session["Deleted"] = true;
                else
                    Session["Deleted"] = false;

                return RedirectToAction("Index", new { id = id_RepaireOrder });
                // TODO: Add update logic here                
            }
            catch
            {
                Session["Deleted"] = false;
                return RedirectToAction("Index",new { id= id_RepaireOrder });
            }
        }
  
        ///// POST: PM_RepairOrderFault/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_RepairOrderFault PM_RepairOrderFaultServiceObj = dboService.PM_RepairOrderFaultSelect(id,-1,-1,"-1","-1","-1","-1","-1","-1","-1").First();
                PM_RepairOrderFaultServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RepairOrderFaultServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_RepairOrderFaultServiceObj.IsDeleted = true;               
                if ( dboService.PM_RepairOrderFaultUpdate(PM_RepairOrderFaultServiceObj) >0 )
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


   


