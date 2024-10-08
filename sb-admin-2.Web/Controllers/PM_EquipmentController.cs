
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_EquipmentController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_Equipment
        public ActionResult Index(int id)
        {
		 try
           {
		    IList< PMService.PM_Equipment> PM_EquipmentServiceObj=dboService.PM_EquipmentSelect(-1,id,"-1","-1","-1","-1",-1,"-1",-1,"-1","-1","-1","-1",-1,-1,-1,-1,-1,-1,"-1","-1","-1","-1");
            IList<PM.Models.PM_EquipmentMetaData> PM_EquipmentModelList = PM_EquipmentServiceObj.OfType<PM.Models.PM_EquipmentMetaData>().ToList();
            PM.Models.PM_EquipmentMetaData PM_EquipmentModelObj = new Models.PM_EquipmentMetaData();
            foreach (PMService.PM_Equipment ww in PM_EquipmentServiceObj)
             {
                 PM_EquipmentModelObj = JsonConvert.DeserializeObject<PM.Models.PM_EquipmentMetaData>(JsonConvert.SerializeObject(ww));
                 PM_EquipmentModelList.Add(PM_EquipmentModelObj);
             }
                if (Session["Device"] != null)
                    Session.Remove("Device");
                ViewBag.Id_Device = id;
                if (id != -1)
                {
                    Session["Device"] = id;
                    ViewBag.DeviceName = PM_DeviceController .GetName(id);
                }
                return View(PM_EquipmentModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_Equipment/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_Equipment PM_EquipmentServiceObj = dboService.PM_EquipmentSelect(id,-1,"-1","-1","-1","-1",-1,"-1",-1,"-1","-1","-1","-1",-1,-1,-1,-1,-1,-1,"-1","-1","-1","-1").First();
            PM.Models.PM_EquipmentMetaData PM_EquipmentModelObj = JsonConvert.DeserializeObject<PM.Models.PM_EquipmentMetaData>(JsonConvert.SerializeObject(PM_EquipmentServiceObj));
            return View(PM_EquipmentModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_Equipment/Create
        public ActionResult Create(int Id_Device)
        { 
		 try
           {
                ViewBag.StatusName = PM_EquipmentStatusController.GetDropdownlist();
                ViewBag.DeviceName = PM_DeviceController.GetDropdownlist();
                ViewBag.TypeName = PM_EquipmentTypeController.GetDropdownlist();
                ViewBag.Id_Device = Id_Device;
                return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_Equipment/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_EquipmentMetaData PM_EquipmentModelObj = new Models.PM_EquipmentMetaData();  
				TryUpdateModel(PM_EquipmentModelObj);          
                if (ModelState.IsValid)
                {
				              
                PM_EquipmentModelObj.IsDeleted = false;                
                PM_EquipmentModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_EquipmentModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Equipment PM_EquipmentServiceObj = new PMService.PM_Equipment();
                    PM_EquipmentServiceObj = JsonConvert.DeserializeObject<PMService.PM_Equipment>(JsonConvert.SerializeObject(PM_EquipmentModelObj));
                    if ( dboService.PM_EquipmentInsert(PM_EquipmentServiceObj) > 0 )					                   
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;

                    if (Session["Device"] != null)
                        return RedirectToAction("Index", new { id = PM_EquipmentModelObj.ID_Device });
                    else
                        return RedirectToAction("Index", new { id = -1 });
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

        ////// GET: PM_Equipment/Edit/5
        public ActionResult Edit(int id,int Id_Device)
        {
		try{
                ViewBag.StatusName = PM_EquipmentStatusController.GetDropdownlist();
                ViewBag.DeviceName = PM_DeviceController.GetDropdownlist();
                ViewBag.TypeName = PM_EquipmentTypeController.GetDropdownlist();
                PMService.PM_Equipment PM_EquipmentServiceObj =  dboService.PM_EquipmentSelect(id,-1,"-1","-1","-1","-1",-1,"-1",-1,"-1","-1","-1","-1",-1,-1,-1,-1,-1,-1,"-1","-1","-1","-1").First();
            PM.Models.PM_EquipmentMetaData PM_EquipmentModelObj= JsonConvert.DeserializeObject<PM.Models.PM_EquipmentMetaData>(JsonConvert.SerializeObject(PM_EquipmentServiceObj));
                ViewBag.Id_Device = Id_Device;
                return View(PM_EquipmentModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_Equipment/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_EquipmentMetaData PM_EquipmentModelObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    PM_EquipmentModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_EquipmentModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Equipment PM_EquipmentServiceObj = new PMService.PM_Equipment();
                    PM_EquipmentServiceObj = JsonConvert.DeserializeObject<PMService.PM_Equipment>(JsonConvert.SerializeObject(PM_EquipmentModelObj));
                    if (dboService.PM_EquipmentUpdate(PM_EquipmentServiceObj) > 0)
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    if (Session["Device"] != null)
                        return RedirectToAction("Index", new { id = PM_EquipmentModelObj.ID_Device });
                    else
                        return RedirectToAction("Index", new { id = -1 });
                }

                // TODO: Add update logic here

                Session["Edited"] = false;
                return View(PM_EquipmentModelObj);
            }
            catch
            {
                Session["Edited"] = false;
                return View(PM_EquipmentModelObj);
            }
        }

        //GET: PM_Equipment/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id,int Id_Device)
        {
            try
            {
               
                if (dboService.PM_EquipmentDelete(id) > 0)
                    Session["Deleted"] = true;
                else
                    Session["Deleted"] = false;

                return RedirectToAction("Index", new { id = Id_Device });
                // TODO: Add update logic here                
            }
            catch
            {
                Session["Deleted"] = false;
                return RedirectToAction("Index", new { id = Id_Device });
            }
        }
  
        ///// POST: PM_Equipment/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Equipment PM_EquipmentServiceObj = dboService.PM_EquipmentSelect(id,-1,"-1","-1","-1","-1",-1,"-1",-1,"-1","-1","-1","-1",-1,-1,-1,-1,-1,-1,"-1","-1","-1","-1").First();
                PM_EquipmentServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_EquipmentServiceObj.IsDeleted = true;               
                if ( dboService.PM_EquipmentUpdate(PM_EquipmentServiceObj) >0 )
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


   


