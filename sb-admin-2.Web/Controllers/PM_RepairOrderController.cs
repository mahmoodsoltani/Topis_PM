
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace PM.Controllers
{
    public class PM_RepairOrderController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();

        ///////// GET: PM_RepairOrder


        public ActionResult Index()
        {
            try
            {
                int Id_User = -1;
                if (Session["Is_public"] != null && !(bool)Session["Is_public"])
                    Id_User = (int)(Session["UserID"]);

                ViewBag.Person = PM_PersonController.GetDropDownlist();
                ViewBag.month =FarsiLibrary.PersianDate.Now.Month ;
                ViewBag.year = FarsiLibrary.PersianDate.Now.Year;
                IList<PMService.PM_RepairOrder> PM_RepairOrderServiceObj = dboService.PM_RepairOrderSelect(-1, -1, "-1", "-1", "-1", Id_User , -1, "-1", "-1", "-1");
                IList<PM.Models.PM_RepairOrderMetaData> PM_RepairOrderModelList = PM_RepairOrderServiceObj.OfType<PM.Models.PM_RepairOrderMetaData>().ToList();
                PM.Models.PM_RepairOrderMetaData PM_RepairOrderModelObj = new Models.PM_RepairOrderMetaData();
                foreach (PMService.PM_RepairOrder ww in PM_RepairOrderServiceObj)
                {
                    PM_RepairOrderModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RepairOrderMetaData>(JsonConvert.SerializeObject(ww));
                    PM_RepairOrderModelList.Add(PM_RepairOrderModelObj);
                }
                return View(PM_RepairOrderModelList);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        ///////// GET: PM_RepairOrder/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PMService.PM_RepairOrder PM_RepairOrderServiceObj = dboService.PM_RepairOrderSelect(id, -1, "-1", "-1", "-1", -1, -1, "-1", "-1", "-1").First();
                PM.Models.PM_RepairOrderMetaData PM_RepairOrderModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RepairOrderMetaData>(JsonConvert.SerializeObject(PM_RepairOrderServiceObj));
                return View(PM_RepairOrderModelObj);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteWorkorder(int id)
        {
            try
            {
                PMService.PM_WorkOrder PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect(-1, -1, -1, "-1", "-1", -1, -1, -1, -1, -1, id, -1, "-1", "-1").First();
                if (dboService.PM_WorkOrderDelete(PM_WorkOrderServiceObj.PM_WorkOrderID) > 0)
                    Session["Deleted"] = true;
                else
                    Session["Deleted"] = false;

                return RedirectToAction("Index");
            }
            catch
            {
                Session["Deleted"] = false;
                return RedirectToAction("Index");
            }
        }
        public string ConvertDateToFarsi(string InDate)
        {
            string OutDate = "";
            for (int i = 0; i < InDate.Length; i++)
            {
                if (InDate[i] > 47 && InDate[i] < 58)
                    OutDate += (char)(1776 + char.GetNumericValue(InDate[i]));
                else
                    OutDate += InDate[i];

            }
            return OutDate;
        }
        public ActionResult RegisterWorkorder(int id)
        {
            try
            {
                PMService.PM_RepairOrder PM_RepairOrderServiceObj = dboService.PM_RepairOrderSelect(id, -1, "-1", "-1", "-1", -1, -1, "-1", "-1", "-1").First();
                PM.Models.PM_WorkOrderMetaData PM_WorkOrderModelObj = new Models.PM_WorkOrderMetaData();
                TryUpdateModel(PM_WorkOrderModelObj);
                PM_WorkOrderModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString().Substring(0, 10);
                PM_WorkOrderModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString().Substring(0, 10);
                PM_WorkOrderModelObj.Creator = PM.GeneralController.getCurrentUser();
                PM_WorkOrderModelObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_WorkOrderModelObj.WorkOrder_Date = ConvertDateToFarsi(FarsiLibrary.PersianDate.Now.ToString().Substring(0, 10));
                PM_WorkOrderModelObj.Id_WorkOrderStatus = 4;
                PM_WorkOrderModelObj.Id_WorkOrderType = 3;
                //PM_WorkOrderModelObj.Id_User = -1;
                PM_WorkOrderModelObj.Id_Equipment = PM_RepairOrderServiceObj.Id_equipment;
                PM_WorkOrderModelObj.Id_Device = PM_RepairOrderServiceObj.Id_Device;
                PM_WorkOrderModelObj.Id_RepairOrder = id;
                PM_WorkOrderModelObj.IsEnabled = true;
                PMService.PM_WorkOrder PM_WorkOrderServiceObj = new PMService.PM_WorkOrder();
                PM_WorkOrderServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrder>(JsonConvert.SerializeObject(PM_WorkOrderModelObj));
                if (dboService.PM_WorkOrderInsert(PM_WorkOrderServiceObj) > 0)
                    Session["RegWO"] = true;
                else
                    Session["RegWO"] = false;

                return RedirectToAction("Index");
            }
            catch
            {
                Session["RegWO"] = false;
                return RedirectToAction("Index");
            }
        }
        ////// GET: PM_RepairOrder/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                return View();
            }
            catch
            {
                return View();
            }
        }

        ///// POST: PM_RepairOrder/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {
                PM.Models.PM_RepairOrderMetaData PM_RepairOrderModelObj = new Models.PM_RepairOrderMetaData();
                TryUpdateModel(PM_RepairOrderModelObj);
                if (ModelState.IsValid)
                {



                    PM_RepairOrderModelObj.IsDeleted = false;
                    PM_RepairOrderModelObj.RepairOrderNumber = -1;
                    PM_RepairOrderModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_RepairOrderModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_RepairOrderModelObj.Creator = PM.GeneralController.getCurrentUser();
                    PM_RepairOrderModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_RepairOrder PM_RepairOrderServiceObj = new PMService.PM_RepairOrder();
                    PM_RepairOrderServiceObj = JsonConvert.DeserializeObject<PMService.PM_RepairOrder>(JsonConvert.SerializeObject(PM_RepairOrderModelObj));
                    if (dboService.PM_RepairOrderInsert(PM_RepairOrderServiceObj) > 0)
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
            catch (Exception ex)
            {
                Session["Inserted"] = false;
                return View();
            }
        }

        ////// GET: PM_RepairOrder/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                PMService.PM_RepairOrder PM_RepairOrderServiceObj = dboService.PM_RepairOrderSelect(id, -1, "-1", "-1", "-1", -1, -1, "-1", "-1", "-1").First();
                PM.Models.PM_RepairOrderMetaData PM_RepairOrderModelObj = JsonConvert.DeserializeObject<PM.Models.PM_RepairOrderMetaData>(JsonConvert.SerializeObject(PM_RepairOrderServiceObj));
                return View(PM_RepairOrderModelObj);
            }
            catch
            {
                return View();
            }
        }

        ////// POST: PM_RepairOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_RepairOrderMetaData PM_RepairOrderModelObj)
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
                               PM_RepairOrderModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                               fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                               file.SaveAs(fileName);
                           }
                       }
                     */
                    PM_RepairOrderModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_RepairOrderModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_RepairOrder PM_RepairOrderServiceObj = new PMService.PM_RepairOrder();
                    PM_RepairOrderServiceObj = JsonConvert.DeserializeObject<PMService.PM_RepairOrder>(JsonConvert.SerializeObject(PM_RepairOrderModelObj));
                    if (dboService.PM_RepairOrderUpdate(PM_RepairOrderServiceObj) > 0)
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
                return View(PM_RepairOrderModelObj);
            }
            catch
            {
                Session["Edited"] = false;
                return View(PM_RepairOrderModelObj);
            }
        }

        //GET: PM_RepairOrder/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {

                if (dboService.PM_RepairOrderDelete(id) > 0)
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

        ///// POST: PM_RepairOrder/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_RepairOrder PM_RepairOrderServiceObj = dboService.PM_RepairOrderSelect(id, -1, "-1", "-1", "-1", -1, -1, "-1", "-1", "-1").First();
                PM_RepairOrderServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_RepairOrderServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_RepairOrderServiceObj.IsDeleted = true;
                if (dboService.PM_RepairOrderUpdate(PM_RepairOrderServiceObj) > 0)
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





