
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace PM.Controllers
{
  public class PM_WorkOrderItemController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();


        ///////// GET: PM_WorkOrderItem
        public ActionResult Index(int id)
        {
		 try
           {
                PMService.PM_WorkOrder PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect(id, -1, -1, "-1", "-1", -1, -1, -1, -1, -1, -1, -1, "-1", "-1").First();
                ViewBag.WorkOrderNumebr = PM_WorkOrderServiceObj.WorkOrdernumber;
                ViewBag.Id_WorkOrder = id;
                ViewBag.Item = PM_ItemController.GetDropdownlist();
                IList< PMService.PM_WorkOrderItem> PM_WorkOrderItemServiceObj=dboService.PM_WorkOrderItemSelect(-1,-1,id,"-1","-1");
            IList<PM.Models.PM_WorkOrderItemMetaData> PM_WorkOrderItemModelList = PM_WorkOrderItemServiceObj.OfType<PM.Models.PM_WorkOrderItemMetaData>().ToList();
            PM.Models.PM_WorkOrderItemMetaData PM_WorkOrderItemModelObj = new Models.PM_WorkOrderItemMetaData();
            foreach (PMService.PM_WorkOrderItem ww in PM_WorkOrderItemServiceObj)
             {
                 PM_WorkOrderItemModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderItemMetaData>(JsonConvert.SerializeObject(ww));
                 PM_WorkOrderItemModelList.Add(PM_WorkOrderItemModelObj);
             }
             return View(PM_WorkOrderItemModelList);
           }
		 catch
             {
                return View();
             }
	    }
        public ActionResult EditIndex(int id)
        {
            try
            {
                PMService.PM_WorkOrder PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect(id, -1, -1, "-1", "-1", -1, -1, -1, -1, -1, -1, -1, "-1", "-1").First();
                ViewBag.WorkOrderNumebr = PM_WorkOrderServiceObj.WorkOrdernumber;
                ViewBag.Id_WorkOrder = id;
                ViewBag.Item = PM_ItemController.GetDropdownlist();
                IList<PMService.PM_WorkOrderItem> PM_WorkOrderItemServiceObj = dboService.PM_WorkOrderItemSelect(-1, -1, id, "-1", "-1");
                IList<PM.Models.PM_WorkOrderItemMetaData> PM_WorkOrderItemModelList = PM_WorkOrderItemServiceObj.OfType<PM.Models.PM_WorkOrderItemMetaData>().ToList();
                PM.Models.PM_WorkOrderItemMetaData PM_WorkOrderItemModelObj = new Models.PM_WorkOrderItemMetaData();
                foreach (PMService.PM_WorkOrderItem ww in PM_WorkOrderItemServiceObj)
                {
                    PM_WorkOrderItemModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderItemMetaData>(JsonConvert.SerializeObject(ww));
                    PM_WorkOrderItemModelList.Add(PM_WorkOrderItemModelObj);
                }
                return View(PM_WorkOrderItemModelList);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public void EditIndex(IEnumerable<PM.Models.PM_WorkOrderItemMetaData> WorkOrderItems)
        {
            try
            {
                PMService.PM_WorkOrderItem PM_WorkOrderItemServiceObj = new PMService.PM_WorkOrderItem();
                foreach (PM.Models.PM_WorkOrderItemMetaData WOI in WorkOrderItems)
                {
                    PM_WorkOrderItemServiceObj.PM_WorkOrderItemID = WOI.PM_WorkOrderItemID;
                    PM_WorkOrderItemServiceObj.Id_Item = WOI.Id_Item;
                    PM_WorkOrderItemServiceObj.Id_WorkOrder = WOI.Id_WorkOrder;
                    PM_WorkOrderItemServiceObj.Description = WOI.Description;
                    PM_WorkOrderItemServiceObj.Creator = WOI.Creator;
                    PM_WorkOrderItemServiceObj.Ctime = WOI.Ctime;
                    PM_WorkOrderItemServiceObj.Mtime = WOI.Mtime;
                    PM_WorkOrderItemServiceObj.Modifier = WOI.Modifier;
                    PM_WorkOrderItemServiceObj.IsDeleted = WOI.IsDeleted;
                    PM_WorkOrderItemServiceObj.IsEnabled = WOI.IsEnabled;
                    dboService.PM_WorkOrderItemUpdate(PM_WorkOrderItemServiceObj);
                    Session["Inserted"] = true;
                }
            }
            catch
            {
                Session["Inserted"] = false;
            }
        }
        ///////// GET: PM_WorkOrderItem/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.PM_WorkOrderItem PM_WorkOrderItemServiceObj = dboService.PM_WorkOrderItemSelect(id,-1,-1,"-1","-1").First();
            PM.Models.PM_WorkOrderItemMetaData PM_WorkOrderItemModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderItemMetaData>(JsonConvert.SerializeObject(PM_WorkOrderItemServiceObj));
            return View(PM_WorkOrderItemModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

        ////// GET: PM_WorkOrderItem/Create
        public ActionResult Create(int id)
        {
            try
            {
                PMService.PM_WorkOrder PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect(id, -1, -1, "-1", "-1", -1, -1, -1, -1, -1, -1, -1, "-1", "-1").First();
                ViewBag.WorkOrderNumebr = PM_WorkOrderServiceObj.WorkOrdernumber;
                ViewBag.Id_WorkOrder = id;
                ViewBag.Item = PM_ItemController.GetDropdownlist();
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Add( int id)
        {
            try
            {
                ViewBag.Id_WorkOrder = id;
                ViewBag.Item = PM_ItemController.GetDropdownlist();
                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ActionName("Add")]
        public ActionResult Add_Post()
        {
            try
            {
                PM.Models.PM_WorkOrderItemMetaData PM_WorkOrderItemModelObj = new Models.PM_WorkOrderItemMetaData();
                TryUpdateModel(PM_WorkOrderItemModelObj);
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
                                    PM_WorkOrderItemModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                                    fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                                    file.SaveAs(fileName);
                                }
                            }
                      */

                    PM_WorkOrderItemModelObj.IsDeleted = false;
                    PM_WorkOrderItemModelObj.IsEnabled = true;
                    PM_WorkOrderItemModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderItemModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderItemModelObj.Creator = PM.GeneralController.getCurrentUser();
                    PM_WorkOrderItemModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_WorkOrderItem PM_WorkOrderItemServiceObj = new PMService.PM_WorkOrderItem();
                    PM_WorkOrderItemServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrderItem>(JsonConvert.SerializeObject(PM_WorkOrderItemModelObj));
                    if (dboService.PM_WorkOrderItemInsert(PM_WorkOrderItemServiceObj) > 0)
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;

                    return RedirectToAction("index", "PM_WorkOrder");
                }
                // TODO: Add insert logic here


                Session["Inserted"] = false;

                return RedirectToAction("Add");
            }
            catch
            {
                Session["Inserted"] = false;
                return RedirectToAction("Add");
            }
        }

        ///// POST: PM_WorkOrderItem/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.PM_WorkOrderItemMetaData PM_WorkOrderItemModelObj = new Models.PM_WorkOrderItemMetaData();  
				TryUpdateModel(PM_WorkOrderItemModelObj);          
                if (ModelState.IsValid)
                {
				
                PM_WorkOrderItemModelObj.IsDeleted = false;                
                PM_WorkOrderItemModelObj.IsEnabled = true ;                
                PM_WorkOrderItemModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderItemModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderItemModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_WorkOrderItemModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_WorkOrderItem PM_WorkOrderItemServiceObj = new PMService.PM_WorkOrderItem();
                    PM_WorkOrderItemServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrderItem>(JsonConvert.SerializeObject(PM_WorkOrderItemModelObj));
                    if ( dboService.PM_WorkOrderItemInsert(PM_WorkOrderItemServiceObj) > 0 )					                   
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;

                    return RedirectToAction("Index",new { id = PM_WorkOrderItemModelObj.Id_WorkOrder });
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

        ////// GET: PM_WorkOrderItem/Edit/5
        public ActionResult Edit(int id,int Id_WorkOrder)
        {
		try{
               
                PMService.PM_WorkOrderItem PM_WorkOrderItemServiceObj =  dboService.PM_WorkOrderItemSelect(id,-1,-1,"-1","-1").First();
                ViewBag.Item = PM_ItemController.GetDropdownlist();
                ViewBag.Id_WorkOrder = Id_WorkOrder;
                PM.Models.PM_WorkOrderItemMetaData PM_WorkOrderItemModelObj= JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderItemMetaData>(JsonConvert.SerializeObject(PM_WorkOrderItemServiceObj));
            return View(PM_WorkOrderItemModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: PM_WorkOrderItem/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_WorkOrderItemMetaData PM_WorkOrderItemModelObj)
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
                               PM_WorkOrderItemModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                               fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                               file.SaveAs(fileName);
                           }
                       }
                     */
                    ViewBag.Id_WorkOrder = PM_WorkOrderItemModelObj.Id_WorkOrder;

                PM_WorkOrderItemModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderItemModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_WorkOrderItem PM_WorkOrderItemServiceObj = new PMService.PM_WorkOrderItem();
                    PM_WorkOrderItemServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrderItem>(JsonConvert.SerializeObject(PM_WorkOrderItemModelObj));
                    if ( dboService.PM_WorkOrderItemUpdate(PM_WorkOrderItemServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index", new { id = PM_WorkOrderItemModelObj.Id_WorkOrder });
                }

                // TODO: Add update logic here
				
					Session["Edited"] = false;
                return View(PM_WorkOrderItemModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_WorkOrderItemModelObj);
            }
        }

        //GET: PM_WorkOrderItem/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id, int Id_WorkOrder)
        {
            try
            {
              
                if (dboService.PM_WorkOrderItemDelete(id) > 0)
                    Session["Deleted"] = true;
                else
                    Session["Deleted"] = false;

                return RedirectToAction("Index", new { id = Id_WorkOrder });
                // TODO: Add update logic here                
            }
            catch
            {
                Session["Deleted"] = false;
                return RedirectToAction("Index",new { id= Id_WorkOrder });
            }
        }
  
        ///// POST: PM_WorkOrderItem/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_WorkOrderItem PM_WorkOrderItemServiceObj = dboService.PM_WorkOrderItemSelect(id,-1,-1,"-1","-1").First();
                PM_WorkOrderItemServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderItemServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_WorkOrderItemServiceObj.IsDeleted = true;               
                if ( dboService.PM_WorkOrderItemUpdate(PM_WorkOrderItemServiceObj) >0 )
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


   


