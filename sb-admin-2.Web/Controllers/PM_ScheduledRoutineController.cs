
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_ScheduledRoutineController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_ScheduledRoutine
        public ActionResult Index()
        {
		 try
           {
                int Id_User = -1;
                if (Session["Is_public"] != null && !(bool)Session["Is_public"])
                    Id_User = (int)(Session["UserID"]);
                IList< PMService.PM_ScheduledRoutine> PM_ScheduledRoutineServiceObj=dboService.PM_ScheduledRoutineSelect(-1,"-1",-1,-1,-1,Id_User,-1,-1,-1,-1,-1,-1,"-1","-1","-1","-1","-1","-1","-1");
            IList<PM.Models.PM_ScheduledRoutineMetaData> PM_ScheduledRoutineModelList = PM_ScheduledRoutineServiceObj.OfType<PM.Models.PM_ScheduledRoutineMetaData>().ToList();
            PM.Models.PM_ScheduledRoutineMetaData PM_ScheduledRoutineModelObj = new Models.PM_ScheduledRoutineMetaData();
            foreach (PMService.PM_ScheduledRoutine ww in PM_ScheduledRoutineServiceObj)
             {
                 PM_ScheduledRoutineModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ScheduledRoutineMetaData>(JsonConvert.SerializeObject(ww));
                 PM_ScheduledRoutineModelList.Add(PM_ScheduledRoutineModelObj);
             }
             return View(PM_ScheduledRoutineModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_ScheduledRoutine/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_ScheduledRoutine PM_ScheduledRoutineServiceObj = dboService.PM_ScheduledRoutineSelect(id,"-1",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,"-1","-1","-1","-1","-1","-1","-1").First();
            PM.Models.PM_ScheduledRoutineMetaData PM_ScheduledRoutineModelObj = JsonConvert.DeserializeObject<PM.Models.PM_ScheduledRoutineMetaData>(JsonConvert.SerializeObject(PM_ScheduledRoutineServiceObj));
            return View(PM_ScheduledRoutineModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_ScheduledRoutine/Create
        public ActionResult Create()
        { 
		 try
           {            
                ViewBag.Device = PM_DeviceController.GetDropdownlist();
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                ViewBag.OccurType = PM_OccurTypeController.GetDropdownlist();
                 ViewBag.Routine = PM_RoutineController.GetDropdownlist();
                ViewBag.DayOfWeek = PM_DayOfWeekController.GetDropdownlist();
                return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_ScheduledRoutine/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {
                PM.Models.PM_ScheduledRoutineMetaData PM_ScheduledRoutineModelObj = new Models.PM_ScheduledRoutineMetaData();
                TryUpdateModel(PM_ScheduledRoutineModelObj);
                if (ModelState.IsValid)
                {
                    PM_ScheduledRoutineModelObj.IsDeleted = false;
                    PM_ScheduledRoutineModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_ScheduledRoutineModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_ScheduledRoutineModelObj.Creator = PM.GeneralController.getCurrentUser();
                    PM_ScheduledRoutineModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_ScheduledRoutine PM_ScheduledRoutineServiceObj = new PMService.PM_ScheduledRoutine();
                    PM_ScheduledRoutineServiceObj = JsonConvert.DeserializeObject<PMService.PM_ScheduledRoutine>(JsonConvert.SerializeObject(PM_ScheduledRoutineModelObj));
                    if (PM_ScheduledRoutineServiceObj.Id_Occurtype == 1)
                    {
                        PM_ScheduledRoutineServiceObj.Month_Number = 0;
                        PM_ScheduledRoutineServiceObj.Month_Day = 0;
                        PM_ScheduledRoutineServiceObj.Week_Day = 0;
                        PM_ScheduledRoutineServiceObj.Week_Number = 0;
                    }
                    if (PM_ScheduledRoutineServiceObj.Id_Occurtype == 2)
                    {
                        PM_ScheduledRoutineServiceObj.Month_Number = 0;
                        PM_ScheduledRoutineServiceObj.Month_Day = 0;
                        PM_ScheduledRoutineServiceObj.Day_Number = 0;
                    }
                    if (PM_ScheduledRoutineServiceObj.Id_Occurtype == 3)
                    {
                        PM_ScheduledRoutineServiceObj.Day_Number = 0;
                        PM_ScheduledRoutineServiceObj.Week_Day = 0;
                        PM_ScheduledRoutineServiceObj.Week_Number = 0;
                    }
                    if (dboService.PM_ScheduledRoutineInsert(PM_ScheduledRoutineServiceObj) > 0)
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

        ////// GET: PM_ScheduledRoutine/Edit/5
        public ActionResult Edit(int id)
        {
		try{
                ViewBag.Device = PM_DeviceController.GetDropdownlist();
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                ViewBag.OccurType = PM_OccurTypeController.GetDropdownlist();
                ViewBag.Routine = PM_RoutineController.GetDropdownlist();
                ViewBag.DayOfWeek = PM_DayOfWeekController.GetDropdownlist();
                PMService.PM_ScheduledRoutine PM_ScheduledRoutineServiceObj =  dboService.PM_ScheduledRoutineSelect(id,"-1",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,"-1","-1","-1","-1","-1","-1","-1").First();
            PM.Models.PM_ScheduledRoutineMetaData PM_ScheduledRoutineModelObj= JsonConvert.DeserializeObject<PM.Models.PM_ScheduledRoutineMetaData>(JsonConvert.SerializeObject(PM_ScheduledRoutineServiceObj));
            return View(PM_ScheduledRoutineModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_ScheduledRoutine/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_ScheduledRoutineMetaData PM_ScheduledRoutineModelObj)
        {
            try
            {                
                if (ModelState.IsValid)
                {
				PM_ScheduledRoutineModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ScheduledRoutineModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_ScheduledRoutine PM_ScheduledRoutineServiceObj = new PMService.PM_ScheduledRoutine();
                   
                    PM_ScheduledRoutineServiceObj = JsonConvert.DeserializeObject<PMService.PM_ScheduledRoutine>(JsonConvert.SerializeObject(PM_ScheduledRoutineModelObj));
                    if (PM_ScheduledRoutineServiceObj.Id_Occurtype == 1)
                    {
                        PM_ScheduledRoutineServiceObj.Month_Number = 0;
                        PM_ScheduledRoutineServiceObj.Month_Day = 0;
                        PM_ScheduledRoutineServiceObj.Week_Day = 0;
                        PM_ScheduledRoutineServiceObj.Week_Number = 0;
                    }
                    if (PM_ScheduledRoutineServiceObj.Id_Occurtype == 2)
                    {
                        PM_ScheduledRoutineServiceObj.Month_Number = 0;
                        PM_ScheduledRoutineServiceObj.Month_Day = 0;
                        PM_ScheduledRoutineServiceObj.Day_Number = 0;
                    }
                    if (PM_ScheduledRoutineServiceObj.Id_Occurtype == 3)
                    {
                        PM_ScheduledRoutineServiceObj.Day_Number = 0;
                        PM_ScheduledRoutineServiceObj.Week_Day = 0;
                        PM_ScheduledRoutineServiceObj.Week_Number = 0;
                    }
                    if ( dboService.PM_ScheduledRoutineUpdate(PM_ScheduledRoutineServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index");
                }

                // TODO: Add update logic here
			
					Session["Edited"] = false;
                return View(PM_ScheduledRoutineModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_ScheduledRoutineModelObj);
            }
        }

        //GET: PM_ScheduledRoutine/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                
                if (dboService.PM_ScheduledRoutineDelete(id) > 0)
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
  
        ///// POST: PM_ScheduledRoutine/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_ScheduledRoutine PM_ScheduledRoutineServiceObj = dboService.PM_ScheduledRoutineSelect(id,"-1",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,"-1","-1","-1","-1","-1","-1","-1").First();
                PM_ScheduledRoutineServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_ScheduledRoutineServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_ScheduledRoutineServiceObj.IsDeleted = true;               
                if ( dboService.PM_ScheduledRoutineUpdate(PM_ScheduledRoutineServiceObj) >0 )
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


   


