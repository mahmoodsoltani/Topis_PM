
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace PM.Controllers
{
    public class PM_WorkOrderReportController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();

        ///////// GET: PM_WorkOrderReport
        public ActionResult Index()
        {
            try
            {
                IList<PMService.PM_WorkOrderReport> PM_WorkOrderReportServiceObj = dboService.PM_WorkOrderReportSelect(-1, "-1", "-1", "-1", "-1", -1, "-1", "-1", "-1");
                IList<PM.Models.PM_WorkOrderReportMetaData> PM_WorkOrderReportModelList = PM_WorkOrderReportServiceObj.OfType<PM.Models.PM_WorkOrderReportMetaData>().ToList();
                PM.Models.PM_WorkOrderReportMetaData PM_WorkOrderReportModelObj = new Models.PM_WorkOrderReportMetaData();
                foreach (PMService.PM_WorkOrderReport ww in PM_WorkOrderReportServiceObj)
                {
                    PM_WorkOrderReportModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderReportMetaData>(JsonConvert.SerializeObject(ww));
                    PM_WorkOrderReportModelList.Add(PM_WorkOrderReportModelObj);
                }
                return View(PM_WorkOrderReportModelList);
            }
            catch
            {
                return View();
            }
        }

        ///////// GET: PM_WorkOrderReport/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PMService.PM_WorkOrderReport PM_WorkOrderReportServiceObj = dboService.PM_WorkOrderReportSelect(id, "-1", "-1", "-1", "-1", -1, "-1", "-1", "-1").First();
                PM.Models.PM_WorkOrderReportMetaData PM_WorkOrderReportModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderReportMetaData>(JsonConvert.SerializeObject(PM_WorkOrderReportServiceObj));
                return View(PM_WorkOrderReportModelObj);
            }
            catch
            {
                return View();
            }
        }

        ////// GET: PM_WorkOrderReport/Create
        public ActionResult Create(int id)
        {
            try
            {

                return View();
            }
            catch
            {
                return View();
            }
        }

        ///// POST: PM_WorkOrderReport/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {
                PM.Models.PM_WorkOrderReportMetaData PM_WorkOrderReportModelObj = new Models.PM_WorkOrderReportMetaData();
                TryUpdateModel(PM_WorkOrderReportModelObj);
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
                                    PM_WorkOrderReportModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                                    fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                                    file.SaveAs(fileName);
                                }
                            }
                      */

                    PM_WorkOrderReportModelObj.IsDeleted = false;
                    PM_WorkOrderReportModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderReportModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderReportModelObj.Creator = PM.GeneralController.getCurrentUser();
                    PM_WorkOrderReportModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_WorkOrderReport PM_WorkOrderReportServiceObj = new PMService.PM_WorkOrderReport();
                    PM_WorkOrderReportServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrderReport>(JsonConvert.SerializeObject(PM_WorkOrderReportModelObj));
                    if (dboService.PM_WorkOrderReportInsert(PM_WorkOrderReportServiceObj) > 0)
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

        ////// GET: PM_WorkOrderReport/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {


                ViewBag.Person = PM_PersonController.GetDropDownlist();
                ViewBag.Material = PM_MaterialController.GetDropdownlist();
                PMService.PM_WorkOrderReport PM_WorkOrderReportServiceObj = dboService.PM_WorkOrderReportSelect(-1, "-1", "-1", "-1", "-1", id, "-1", "-1", "-1").First();
                PM.Models.PM_WorkOrderReportMetaData PM_WorkOrderReportModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderReportMetaData>(JsonConvert.SerializeObject(PM_WorkOrderReportServiceObj));
                if (PM_WorkOrderReportModelObj == null)
                {
                    PM.Models.PM_WorkOrderReportMetaData PM_WorkOrderReportModelObj1 = new Models.PM_WorkOrderReportMetaData();
                    PM_WorkOrderReportModelObj1.IsDeleted = false;
                    PM_WorkOrderReportModelObj1.IsEnabled = true;
                    PM_WorkOrderReportModelObj1.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderReportModelObj1.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderReportModelObj1.Creator = PM.GeneralController.getCurrentUser();
                    PM_WorkOrderReportModelObj1.Modifier = PM.GeneralController.getCurrentUser();
                    PM_WorkOrderReportModelObj1.Id_WorkOrder = id;
                    PMService.PM_WorkOrderReport PM_WorkOrderReportServiceObj1 = new PMService.PM_WorkOrderReport();
                    PM_WorkOrderReportServiceObj1 = JsonConvert.DeserializeObject<PMService.PM_WorkOrderReport>(JsonConvert.SerializeObject(PM_WorkOrderReportModelObj1));
                    dboService.PM_WorkOrderReportInsert(PM_WorkOrderReportServiceObj1);
                    PM_WorkOrderReportServiceObj = dboService.PM_WorkOrderReportSelect(-1, "-1", "-1", "-1", "-1", id, "-1", "-1", "-1").First();
                    PM_WorkOrderReportModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderReportMetaData>(JsonConvert.SerializeObject(PM_WorkOrderReportServiceObj));

                }
                IList<PMService.PM_WorkOrderItem> PM_WorkOrderItemServiceObj = dboService.PM_AllWorkOrderItemSelect(id);
                if (PM_WorkOrderItemServiceObj != null)
                    foreach (PMService.PM_WorkOrderItem wi in PM_WorkOrderItemServiceObj)
                    {
                        try { PMService.PM_ItemReport PM_ItemReportServiceObj = dboService.PM_ItemReportSelect(-1, Convert.ToInt32(wi.Id_Item), -1, "-1", PM_WorkOrderReportModelObj.PM_WorkOrderReportID, "-1", "-1").First(); }
                        catch { 
                        
                            PM.Models.PM_ItemReportMetaData PM_ItemReportModelObj = new Models.PM_ItemReportMetaData();
                            PM_ItemReportModelObj.IsDeleted = false;
                            PM_ItemReportModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                            PM_ItemReportModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                            PM_ItemReportModelObj.Creator = PM.GeneralController.getCurrentUser();
                            PM_ItemReportModelObj.Modifier = PM.GeneralController.getCurrentUser();
                            PM_ItemReportModelObj.Id_WorkOrderReport = PM_WorkOrderReportModelObj.PM_WorkOrderReportID;
                            PM_ItemReportModelObj.Id_Item = wi.Id_Item;

                           
                            PMService.PM_ItemReport PM_ItemReportServiceObj1 = JsonConvert.DeserializeObject<PMService.PM_ItemReport>(JsonConvert.SerializeObject(PM_ItemReportModelObj));
                            dboService.PM_ItemReportInsert(PM_ItemReportServiceObj1);
                        }
                    }
                return View(PM_WorkOrderReportModelObj);
            }
            catch
            {
                PM.Models.PM_WorkOrderReportMetaData PM_WorkOrderReportModelObj1 = new Models.PM_WorkOrderReportMetaData();
                PM_WorkOrderReportModelObj1.IsDeleted = false;
                PM_WorkOrderReportModelObj1.IsEnabled = true;
                PM_WorkOrderReportModelObj1.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderReportModelObj1.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderReportModelObj1.Creator = PM.GeneralController.getCurrentUser();
                PM_WorkOrderReportModelObj1.Modifier = PM.GeneralController.getCurrentUser();
                PM_WorkOrderReportModelObj1.Id_WorkOrder = id;
                PMService.PM_WorkOrderReport PM_WorkOrderReportServiceObj1 = new PMService.PM_WorkOrderReport();
                PM_WorkOrderReportServiceObj1 = JsonConvert.DeserializeObject<PMService.PM_WorkOrderReport>(JsonConvert.SerializeObject(PM_WorkOrderReportModelObj1));
                dboService.PM_WorkOrderReportInsert(PM_WorkOrderReportServiceObj1);
                PMService.PM_WorkOrderReport PM_WorkOrderReportServiceObj = dboService.PM_WorkOrderReportSelect(-1, "-1", "-1", "-1", "-1", id, "-1", "-1", "-1").First();
                PM.Models.PM_WorkOrderReportMetaData PM_WorkOrderReportModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderReportMetaData>(JsonConvert.SerializeObject(PM_WorkOrderReportServiceObj));


                return View(PM_WorkOrderReportModelObj);
            }
        }

        ////// POST: PM_WorkOrderReport/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_WorkOrderReportMetaData PM_WorkOrderReportModelObj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    PM_WorkOrderReportModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderReportModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_WorkOrderReport PM_WorkOrderReportServiceObj = new PMService.PM_WorkOrderReport();
                    PM_WorkOrderReportServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrderReport>(JsonConvert.SerializeObject(PM_WorkOrderReportModelObj));
                    if (dboService.PM_WorkOrderReportUpdate(PM_WorkOrderReportServiceObj) > 0)
                    {
                        ViewBag.Person = PM_PersonController.GetDropDownlist();
                        PMService.PM_WorkOrder PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect((int)PM_WorkOrderReportServiceObj.Id_WorkOrder, -1, -1, "-1", "-1", -1, -1, -1, -1, -1, -1, -1, "-1", "-1").First();
                        PM_WorkOrderServiceObj.Id_WorkOrderStatus = 3;
                        dboService.PM_WorkOrderUpdate(PM_WorkOrderServiceObj);
                        Session["Edited"] = true;

                    }
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Edit", "Pm_WorkorderReport", new { id = PM_WorkOrderReportServiceObj.Id_WorkOrder });
                }
                Session["Edited"] = false;
                return View(PM_WorkOrderReportModelObj);
            }
            catch
            {
                Session["Edited"] = false;
                return View(PM_WorkOrderReportModelObj);
            }
        }
        [HttpPost]
        public ContentResult Edit1(PM.Models.PM_WorkOrderReportMetaData PM_WorkOrderReportModelObj)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Content("Sorry, this method can't be called only from AJAX.");
            }
            string result = "";
            try
            {

                if (ModelState.IsValid)
                {

                    PM_WorkOrderReportModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderReportModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_WorkOrderReport PM_WorkOrderReportServiceObj = new PMService.PM_WorkOrderReport();
                    PM_WorkOrderReportServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrderReport>(JsonConvert.SerializeObject(PM_WorkOrderReportModelObj));
                    if (dboService.PM_WorkOrderReportUpdate(PM_WorkOrderReportServiceObj) > 0)
                        result = "success";
                    else
                        result = "unsuccess";


                }
                return Content(result);
            }
            catch
            {
                return Content(result);

            }
        }
        //GET: PM_WorkOrderReport/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                PMService.PM_WorkOrderReport PM_WorkOrderReportServiceObj = dboService.PM_WorkOrderReportSelect(id, "-1", "-1", "-1", "-1", -1, "-1", "-1", "-1").First();
                PM.Models.PM_WorkOrderReportMetaData PM_WorkOrderReportModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderReportMetaData>(JsonConvert.SerializeObject(PM_WorkOrderReportServiceObj));
                return View(PM_WorkOrderReportModelObj);

            }
            catch
            {
                return View();
            }
        }

        ///// POST: PM_WorkOrderReport/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_WorkOrderReport PM_WorkOrderReportServiceObj = dboService.PM_WorkOrderReportSelect(id, "-1", "-1", "-1", "-1", -1, "-1", "-1", "-1").First();
                PM_WorkOrderReportServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderReportServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_WorkOrderReportServiceObj.IsDeleted = true;
                if (dboService.PM_WorkOrderReportUpdate(PM_WorkOrderReportServiceObj) > 0)
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





