
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace PM.Controllers
{
    public class PM_DeviceController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
        public ActionResult Index(int id)
        {
            try
            {
                IList<PMService.PM_Device> PM_DeviceServiceObj = dboService.PM_DeviceSelect(-1, "-1", "-1", id, "-1", "-1", "-1", "-1");
                IList<PM.Models.PM_DeviceMetaData> PM_DeviceModelList = PM_DeviceServiceObj.OfType<PM.Models.PM_DeviceMetaData>().ToList();
                PM.Models.PM_DeviceMetaData PM_DeviceModelObj = new Models.PM_DeviceMetaData();
                foreach (PMService.PM_Device ww in PM_DeviceServiceObj)
                {
                    PM_DeviceModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DeviceMetaData>(JsonConvert.SerializeObject(ww));
                    PM_DeviceModelList.Add(PM_DeviceModelObj);
                }
                if (Session["ProductLine"] != null)
                    Session.Remove("ProductLine");
                ViewBag.Id_ProductLine = id;
                if (id != -1)
                {
                    Session["ProductLine"] = id;
                    ViewBag.ProductLineName = PM_ProductLineController.GetName(id);
                }
                return View(PM_DeviceModelList);
            }
            catch
            {
                return View();
            }
        }

        ///////// GET: PM_Device/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PMService.PM_Device PM_DeviceServiceObj = dboService.PM_DeviceSelect(id, "-1", "-1", -1, "-1", "-1", "-1", "-1").First();
                PM.Models.PM_DeviceMetaData PM_DeviceModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DeviceMetaData>(JsonConvert.SerializeObject(PM_DeviceServiceObj));
                return View(PM_DeviceModelObj);
            }
            catch
            {
                return View();
            }
        }

        ////// GET: PM_Device/Create
        public ActionResult Create(int id_ProductLine)
        {
            try
            {
                ViewBag.ProductLine = PM_ProductLineController.GetDropdownlist();
                ViewBag.id_ProductLine = id_ProductLine;
                return View();
            }
            catch
            {
                return View();
            }
        }

        ///// POST: PM_Device/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {
                PM.Models.PM_DeviceMetaData PM_DeviceModelObj = new Models.PM_DeviceMetaData();
                TryUpdateModel(PM_DeviceModelObj);
                if (ModelState.IsValid)
                {
                    PM_DeviceModelObj.IsDeleted = false;
                    PM_DeviceModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_DeviceModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_DeviceModelObj.Creator = PM.GeneralController.getCurrentUser();
                    PM_DeviceModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Device PM_DeviceServiceObj = new PMService.PM_Device();
                    PM_DeviceServiceObj = JsonConvert.DeserializeObject<PMService.PM_Device>(JsonConvert.SerializeObject(PM_DeviceModelObj));
                    if (dboService.PM_DeviceInsert(PM_DeviceServiceObj) > 0)
                        Session["Inserted"] = true;
                    else
                        Session["Inserted"] = false;
                    if (Session["ProductLine"] != null)
                        return RedirectToAction("Index", new { id = PM_DeviceModelObj.ID_ProductLine });
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

        ////// GET: PM_Device/Edit/5
        public ActionResult Edit(int id, int Id_ProductLine)
        {
            try
            {
                ViewBag.ProductLine = PM_ProductLineController.GetDropdownlist();
                PMService.PM_Device PM_DeviceServiceObj = dboService.PM_DeviceSelect(id, "-1", "-1", -1, "-1", "-1", "-1", "-1").First();
                PM.Models.PM_DeviceMetaData PM_DeviceModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DeviceMetaData>(JsonConvert.SerializeObject(PM_DeviceServiceObj));
                ViewBag.Id_ProductLine = Id_ProductLine;
                return View(PM_DeviceModelObj);
            }
            catch
            {
                return View();
            }
        }

        ////// POST: PM_Device/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_DeviceMetaData PM_DeviceModelObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PM_DeviceModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_DeviceModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Device PM_DeviceServiceObj = new PMService.PM_Device();
                    PM_DeviceServiceObj = JsonConvert.DeserializeObject<PMService.PM_Device>(JsonConvert.SerializeObject(PM_DeviceModelObj));
                    if (dboService.PM_DeviceUpdate(PM_DeviceServiceObj) > 0)
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;
                    if (Session["ProductLine"] != null)
                        return RedirectToAction("Index", new { id = PM_DeviceModelObj.ID_ProductLine });
                    else
                        return RedirectToAction("Index", new { id = -1 });

                }
                Session["Edited"] = false;
                return View(PM_DeviceModelObj);
            }
            catch
            {
                Session["Edited"] = false;
                return View(PM_DeviceModelObj);
            }
        }

        //GET: PM_Device/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id, int Id_ProductLine)
        {
            try
            {
                if (dboService.PM_DeviceDelete(id) > 0)
                    Session["Deleted"] = true;
                else
                    Session["Deleted"] = false;

                return RedirectToAction("Index", new { id = Id_ProductLine });
                // TODO: Add update logic here                
            }
            catch
            {
                Session["Deleted"] = false;
                return RedirectToAction("Index", new { id = Id_ProductLine });
            }
        }

        ///// POST: PM_Device/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public static List<SelectListItem> GetDropdownlist()
        {
            PMService.dboService dboService = new PMService.dboService();
            IList<PMService.PM_Device> PM_DeviceServiceObj = dboService.PM_DeviceSelect(-1, "-1", "-1", -1, "-1", "-1", "true", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Device ww in PM_DeviceServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name + "_" + ww.ProductLineName,
                    Value = ww.PM_DeviceID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }

            return items;
        }
        public static string GetName(int id)
        {
            try
            {
                PMService.dboService dboService = new PMService.dboService();
                PMService.PM_Device PM_DeviceServiceObj = dboService.PM_DeviceSelect(id, "-1", "-1", -1, "-1", "-1", "-1", "-1").First();
                if (PM_DeviceServiceObj != null)
                    return PM_DeviceServiceObj.Name + "(" + PM_DeviceServiceObj.ProductLineName + ")";
                return "";
            }
            catch { return ""; }
        }
    }
}





