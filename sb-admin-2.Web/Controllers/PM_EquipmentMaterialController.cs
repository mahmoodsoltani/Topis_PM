
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
  public class PM_EquipmentMaterialController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: PM_EquipmentMaterial
        public ActionResult Index(int id)
        {
            try
            {
                IList<PMService.PM_EquipmentMaterial> PM_EquipmentMaterialServiceObj;
              
                if (id != -1)
                {
                    PM_EquipmentMaterialServiceObj = dboService.PM_EquipmentMaterialSelect(-1,-1, id, -1, "-1", "-1", "-1");
                    PMService.PM_Equipment PM_EquipmentServiceObj = dboService.PM_EquipmentSelect(id, -1, "-1", "-1", "-1", "-1", -1, "-1", -1, "-1", "-1", "-1", "-1", -1, -1, -1, -1, -1, -1, "-1", "-1", "-1", "-1").First();
                    ViewBag.Id_Equipment = id;
                    ViewBag.EquipmentName = PM_EquipmentServiceObj.Fa_Name;
                    ViewBag.DeviceName = PM_EquipmentServiceObj.DeviceName;
                    ViewBag.Id_device = PM_EquipmentServiceObj.ID_Device;
                }
                else
                    PM_EquipmentMaterialServiceObj = dboService.PM_EquipmentMaterialSelect(-1, -1, -1, -1, "-1", "-1", "-1");
                IList<PM.Models.PM_EquipmentMaterialMetaData> PM_EquipmentMaterialModelList = PM_EquipmentMaterialServiceObj.OfType<PM.Models.PM_EquipmentMaterialMetaData>().ToList();
            PM.Models.PM_EquipmentMaterialMetaData PM_EquipmentMaterialModelObj = new Models.PM_EquipmentMaterialMetaData();
            foreach (PMService.PM_EquipmentMaterial ww in PM_EquipmentMaterialServiceObj)
             {
                 PM_EquipmentMaterialModelObj = JsonConvert.DeserializeObject<PM.Models.PM_EquipmentMaterialMetaData>(JsonConvert.SerializeObject(ww));
                 PM_EquipmentMaterialModelList.Add(PM_EquipmentMaterialModelObj);
             }
               
             return View(PM_EquipmentMaterialModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: PM_EquipmentMaterial/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_EquipmentMaterial PM_EquipmentMaterialServiceObj = dboService.PM_EquipmentMaterialSelect(id,-1,-1,-1,"-1","-1","-1").First();
            PM.Models.PM_EquipmentMaterialMetaData PM_EquipmentMaterialModelObj = JsonConvert.DeserializeObject<PM.Models.PM_EquipmentMaterialMetaData>(JsonConvert.SerializeObject(PM_EquipmentMaterialServiceObj));
            return View(PM_EquipmentMaterialModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: PM_EquipmentMaterial/Create
        public ActionResult Create(int id)
        { 
		 try
           {
                ViewBag.Id_Equipment = id;
                ViewBag.Material = PM_MaterialController.GetDropdownlist();
                return View();
            }
	     catch
             {
                return View();
             }            
        }

        ///// POST: PM_EquipmentMaterial/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_EquipmentMaterialMetaData PM_EquipmentMaterialModelObj = new Models.PM_EquipmentMaterialMetaData();  
				TryUpdateModel(PM_EquipmentMaterialModelObj);          
                if (ModelState.IsValid)
                {
                    if (PMService.dboService.PM_EquipmentMaterial_IsRepeated(-1, (int)PM_EquipmentMaterialModelObj.Id_Material, (int)PM_EquipmentMaterialModelObj.Id_Equipment, -1, "-1", "-1", "-1"))
                    {
                        Session["Inserted"] = "Repeat";
                        return RedirectToAction("Create", new { id = PM_EquipmentMaterialModelObj.Id_Equipment });
                        
                    }
                        
                    PM_EquipmentMaterialModelObj.IsDeleted = false;                
                    PM_EquipmentMaterialModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_EquipmentMaterialModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_EquipmentMaterialModelObj.Creator = PM.GeneralController.getCurrentUser();
                    PM_EquipmentMaterialModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_EquipmentMaterial PM_EquipmentMaterialServiceObj = new PMService.PM_EquipmentMaterial();
                    PM_EquipmentMaterialServiceObj = JsonConvert.DeserializeObject<PMService.PM_EquipmentMaterial>(JsonConvert.SerializeObject(PM_EquipmentMaterialModelObj));
                    if ( dboService.PM_EquipmentMaterialInsert(PM_EquipmentMaterialServiceObj) > 0 )					                   
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;

                    return RedirectToAction("Index", new { id = PM_EquipmentMaterialModelObj.Id_Equipment });
                }
                // TODO: Add insert logic here
				
				Session["Inserted"] = false;

                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Material = PM_MaterialController.GetDropdownlist();
               
                Session["Inserted"] = false;
                return View();
            }
        }

        ////// GET: PM_EquipmentMaterial/Edit/5
        public ActionResult Edit(int id)
        {
		try{

               // ViewBag.Id_Equipment = id;
                ViewBag.Material = PM_MaterialController.GetDropdownlist();
                PMService.PM_EquipmentMaterial PM_EquipmentMaterialServiceObj =  dboService.PM_EquipmentMaterialSelect(id,-1,-1,-1,"-1","-1","-1").First();
            PM.Models.PM_EquipmentMaterialMetaData PM_EquipmentMaterialModelObj= JsonConvert.DeserializeObject<PM.Models.PM_EquipmentMaterialMetaData>(JsonConvert.SerializeObject(PM_EquipmentMaterialServiceObj));
            return View(PM_EquipmentMaterialModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_EquipmentMaterial/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_EquipmentMaterialMetaData PM_EquipmentMaterialModelObj)
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
                            PM_EquipmentMaterialModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_EquipmentMaterialModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentMaterialModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_EquipmentMaterial PM_EquipmentMaterialServiceObj = new PMService.PM_EquipmentMaterial();
                    PM_EquipmentMaterialServiceObj = JsonConvert.DeserializeObject<PMService.PM_EquipmentMaterial>(JsonConvert.SerializeObject(PM_EquipmentMaterialModelObj));
                    if ( dboService.PM_EquipmentMaterialUpdate(PM_EquipmentMaterialServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index", new { id = PM_EquipmentMaterialModelObj.Id_Equipment });
                }

                // TODO: Add update logic here
			
					Session["Edited"] = false;
                return View(PM_EquipmentMaterialModelObj);
            }
            catch
            {
                Session["Edited"] = false;
                ViewBag.Material = PM_MaterialController.GetDropdownlist();
                return View(PM_EquipmentMaterialModelObj);
            }
        }

        //GET: PM_EquipmentMaterial/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id, int id_Equipment)
        {
            try
            {
                
                if (dboService.PM_EquipmentMaterialDelete(id) > 0)
                    Session["Deleted"] = true;
                else
                    Session["Deleted"] = false;

                return RedirectToAction("Index", new { id = id_Equipment });
                // TODO: Add update logic here                
            }
            catch
            {
                Session["Deleted"] = false;
                return RedirectToAction("Index", new { id = id_Equipment });
            }
        }
  
        ///// POST: PM_EquipmentMaterial/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_EquipmentMaterial PM_EquipmentMaterialServiceObj = dboService.PM_EquipmentMaterialSelect(id,-1,-1,-1,"-1","-1","-1").First();
                PM_EquipmentMaterialServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_EquipmentMaterialServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_EquipmentMaterialServiceObj.IsDeleted = true;               
                if ( dboService.PM_EquipmentMaterialUpdate(PM_EquipmentMaterialServiceObj) >0 )
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


   


