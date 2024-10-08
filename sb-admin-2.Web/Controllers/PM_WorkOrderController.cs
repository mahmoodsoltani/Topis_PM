
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace PM.Controllers
{
    public class PM_WorkOrderController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();

        ///////// GET: PM_WorkOrder
        public ActionResult Index()
        {
            try
            {
                int Id_User = -1;
                if (Session["Is_public"] != null && !(bool)Session["Is_public"])
                    Id_User = (int)(Session["UserID"]);
                IList<PMService.PM_WorkOrder> PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect(-1, -1, -1, "-1", "-1", -1,Id_User, -1, -1, -1, -1, -1, "-1", "-1");
                IList<PM.Models.PM_WorkOrderMetaData> PM_WorkOrderModelList = PM_WorkOrderServiceObj.OfType<PM.Models.PM_WorkOrderMetaData>().ToList();
                PM.Models.PM_WorkOrderMetaData PM_WorkOrderModelObj = new Models.PM_WorkOrderMetaData();
                foreach (PMService.PM_WorkOrder ww in PM_WorkOrderServiceObj)
                {
                    PM_WorkOrderModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderMetaData>(JsonConvert.SerializeObject(ww));
                    PM_WorkOrderModelList.Add(PM_WorkOrderModelObj);
                }
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                return View(PM_WorkOrderModelList);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Report()
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
        public ActionResult RoutineFilterIndex(int id)
        {
            try
            {
                int Id_User = -1;
                if (Session["Is_public"] != null && !(bool)Session["Is_public"])
                    Id_User = (int)(Session["UserID"]);
                IList<PMService.PM_WorkOrder> PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect(-1,id, -1, "-1", "-1", -1, Id_User, -1, -1, -1, -1, -1, "-1", "-1");
                IList<PM.Models.PM_WorkOrderMetaData> PM_WorkOrderModelList = PM_WorkOrderServiceObj.OfType<PM.Models.PM_WorkOrderMetaData>().ToList();
                PM.Models.PM_WorkOrderMetaData PM_WorkOrderModelObj = new Models.PM_WorkOrderMetaData();
                foreach (PMService.PM_WorkOrder ww in PM_WorkOrderServiceObj)
                {
                    PM_WorkOrderModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderMetaData>(JsonConvert.SerializeObject(ww));
                    PM_WorkOrderModelList.Add(PM_WorkOrderModelObj);
                }
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                return View(PM_WorkOrderModelList);
            }
            catch
            {
                return View();
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
        public ActionResult Forward(int id, int id_person,string PPH)
        {
            PMService.PM_WorkOrder PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect(id, -1, -1, "-1", "-1", -1, -1, -1, -1, -1, -1, -1, "-1", "-1").First();
            PM_WorkOrderServiceObj.Id_User = id_person;
            PM_WorkOrderServiceObj.PPH = PPH;
            PM_WorkOrderServiceObj.WorkOrder_ForwardDate = ConvertDateToFarsi(FarsiLibrary.PersianDate.Now.ToString().Substring(0, 10));
            PM_WorkOrderServiceObj.Id_WorkOrderStatus = 2;
            if (dboService.PM_WorkOrderUpdate(PM_WorkOrderServiceObj) > 0)
                Session["Edited"] = true;
            else
                Session["Edited"] = false;
            return RedirectToAction("Index");
        }
        ///////// GET: PM_WorkOrder/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PMService.PM_WorkOrder PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect(id, -1, -1, "-1", "-1", -1, -1, -1, -1, -1, -1, -1, "-1", "-1").First();
                PM.Models.PM_WorkOrderMetaData PM_WorkOrderModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderMetaData>(JsonConvert.SerializeObject(PM_WorkOrderServiceObj));
                return View(PM_WorkOrderModelObj);
            }
            catch
            {
                return View();
            }
        }

        ////// GET: PM_WorkOrder/Create
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

        ///// POST: PM_WorkOrder/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {
                PM.Models.PM_WorkOrderMetaData PM_WorkOrderModelObj = new Models.PM_WorkOrderMetaData();
                TryUpdateModel(PM_WorkOrderModelObj);
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
                                    PM_WorkOrderModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                                    fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                                    file.SaveAs(fileName);
                                }
                            }
                      */

                    PM_WorkOrderModelObj.IsDeleted = false;
                    PM_WorkOrderModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderModelObj.Creator = PM.GeneralController.getCurrentUser();
                    PM_WorkOrderModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PM_WorkOrderModelObj.IsEnabled = true;
                    PM_WorkOrderModelObj.Id_WorkOrderStatus = 4;
                    PM_WorkOrderModelObj.Id_WorkOrderType = 2;

                    PMService.PM_WorkOrder PM_WorkOrderServiceObj = new PMService.PM_WorkOrder();
                    PM_WorkOrderServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrder>(JsonConvert.SerializeObject(PM_WorkOrderModelObj));
                    if (dboService.PM_WorkOrderInsert(PM_WorkOrderServiceObj) > 0)
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;

                    return RedirectToAction("Index");
                }

                Session["Inserted"] = false;

                return View();
            }
            catch
            {
                Session["Inserted"] = false;
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Person = PM_PersonController.GetDropDownlist();
                PMService.PM_WorkOrder PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect(id, -1, -1, "-1", "-1", -1, -1, -1, -1, -1, -1, -1, "-1", "-1").First();
                PM.Models.PM_WorkOrderMetaData PM_WorkOrderModelObj = JsonConvert.DeserializeObject<PM.Models.PM_WorkOrderMetaData>(JsonConvert.SerializeObject(PM_WorkOrderServiceObj));
                return View(PM_WorkOrderModelObj);
            }
            catch
            {
                return View();
            }
        }

        ////// POST: PM_WorkOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_WorkOrderMetaData PM_WorkOrderModelObj)
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
                               PM_WorkOrderModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                               fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                               file.SaveAs(fileName);
                           }
                       }
                     */
                    PM_WorkOrderModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_WorkOrderModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_WorkOrder PM_WorkOrderServiceObj = new PMService.PM_WorkOrder();
                    PM_WorkOrderServiceObj = JsonConvert.DeserializeObject<PMService.PM_WorkOrder>(JsonConvert.SerializeObject(PM_WorkOrderModelObj));
                    if (dboService.PM_WorkOrderUpdate(PM_WorkOrderServiceObj) > 0)
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index");
                }

                // TODO: Add update logic here

                Session["Edited"] = false;
                return View(PM_WorkOrderModelObj);
            }
            catch
            {
                Session["Edited"] = false;
                return View(PM_WorkOrderModelObj);
            }
        }

        //GET: PM_WorkOrder/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {

                if (dboService.PM_WorkOrderDelete(id) > 0)
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

        ///// POST: PM_WorkOrder/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_WorkOrder PM_WorkOrderServiceObj = dboService.PM_WorkOrderSelect(id, -1, -1, "-1", "-1", -1, -1, -1, -1, -1, -1, -1, "-1", "-1").First();
                PM_WorkOrderServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_WorkOrderServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_WorkOrderServiceObj.IsDeleted = true;
                if (dboService.PM_WorkOrderUpdate(PM_WorkOrderServiceObj) > 0)
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





