
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
    public class PM_PersonController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();

        ///////// GET: PM_Person
        public ActionResult Index()
        {
            try
            {
                IList<PMService.PM_Person> PM_PersonServiceObj = dboService.PM_PersonSelect(-1, "-1", "-1", -1, "-1", -1, "-1", "-1", "-1");
                IList<PM.Models.PM_PersonMetaData> PM_PersonModelList = PM_PersonServiceObj.OfType<PM.Models.PM_PersonMetaData>().ToList();
                PM.Models.PM_PersonMetaData PM_PersonModelObj = new Models.PM_PersonMetaData();
                foreach (PMService.PM_Person ww in PM_PersonServiceObj)
                {
                    PM_PersonModelObj = JsonConvert.DeserializeObject<PM.Models.PM_PersonMetaData>(JsonConvert.SerializeObject(ww));
                    PM_PersonModelList.Add(PM_PersonModelObj);
                }
                return View(PM_PersonModelList);
            }
            catch
            {
                return View();
            }
        }

        ///////// GET: PM_Person/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PMService.PM_Person PM_PersonServiceObj = dboService.PM_PersonSelect(id, "-1", "-1", -1, "-1", -1, "-1", "-1", "-1").First();
                PM.Models.PM_PersonMetaData PM_PersonModelObj = JsonConvert.DeserializeObject<PM.Models.PM_PersonMetaData>(JsonConvert.SerializeObject(PM_PersonServiceObj));
                return View(PM_PersonModelObj);
            }
            catch
            {
                return View();
            }
        }

        ////// GET: PM_Person/Create
        public ActionResult Create()
        {
            try
            {
                //   ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
                //   ViewBag.Enab = new SelectList(new List<SelectListItem>
                //               {
                //                new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                //                new SelectListItem { Text = "غير فعال", Value = "0"},
                //                }, "Value", "Text");
                ViewBag.Skill = PM_SkillController.GetDropdownlist();
                return View();
            }
            catch
            {
                return View();
            }
        }

        ///// POST: PM_Person/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {
                PM.Models.PM_PersonMetaData PM_PersonModelObj = new Models.PM_PersonMetaData();
                TryUpdateModel(PM_PersonModelObj);
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
                                    PM_PersonModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                                    fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                                    file.SaveAs(fileName);
                                }
                            }
                      */

                    PM_PersonModelObj.IsDeleted = false;
                    PM_PersonModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_PersonModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_PersonModelObj.Creator = PM.GeneralController.getCurrentUser();
                    PM_PersonModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_Person PM_PersonServiceObj = new PMService.PM_Person();
                    PM_PersonServiceObj = JsonConvert.DeserializeObject<PMService.PM_Person>(JsonConvert.SerializeObject(PM_PersonModelObj));
                    if (dboService.PM_PersonInsert(PM_PersonServiceObj) > 0)
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

        ////// GET: PM_Person/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Skill = PM_SkillController.GetDropdownlist();
                PMService.PM_Person PM_PersonServiceObj = dboService.PM_PersonSelect(id, "-1", "-1", -1, "-1", -1, "-1", "-1", "-1").First();
                PM.Models.PM_PersonMetaData PM_PersonModelObj = JsonConvert.DeserializeObject<PM.Models.PM_PersonMetaData>(JsonConvert.SerializeObject(PM_PersonServiceObj));
                return View(PM_PersonModelObj);
            }
            catch
            {
                return View();
            }
        }

        ////// POST: PM_Person/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_PersonMetaData PM_PersonModelObj)
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
                               PM_PersonModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                               fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                               file.SaveAs(fileName);
                           }
                       }
                     */
                    PM_PersonModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_PersonModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.PM_Person PM_PersonServiceObj = new PMService.PM_Person();
                    PM_PersonServiceObj = JsonConvert.DeserializeObject<PMService.PM_Person>(JsonConvert.SerializeObject(PM_PersonModelObj));
                    if (dboService.PM_PersonUpdate(PM_PersonServiceObj) > 0)
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
                return View(PM_PersonModelObj);
            }
            catch
            {
                Session["Edited"] = false;
                return View(PM_PersonModelObj);
            }
        }

        //GET: PM_Person/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                //PMService.PM_Person PM_PersonServiceObj = dboService.PM_PersonSelect(id, "-1", "-1", -1, "-1", -1, "-1", "-1", "-1").First();
                //PM_PersonServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                //PM_PersonServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                //PM_PersonServiceObj.IsDeleted = true;
                if (dboService.PM_PersonDelete(id) > 0)
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

        ///// POST: PM_Person/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.PM_Person PM_PersonServiceObj = dboService.PM_PersonSelect(id, "-1", "-1", -1, "-1", -1, "-1", "-1", "-1").First();
                PM_PersonServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_PersonServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_PersonServiceObj.IsDeleted = true;
                if (dboService.PM_PersonUpdate(PM_PersonServiceObj) > 0)
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
        public static List<SelectListItem> GetDropDownlist()
        {
            PMService.dboService dboService = new PMService.dboService();
            IList<PMService.PM_Person> PM_PersonServiceObj = dboService.PM_PersonSelect(-1, "-1", "-1", -1, "-1", -1, "-1", "True", "-1");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (PMService.PM_Person ww in PM_PersonServiceObj)
            {

                items.Add(new SelectListItem
                {
                    Text = ww.Name + " - " + ww.family,
                    Value = ww.PM_PersonID.ToString(),
                    // Selected = ww.PM_FactoryID == PM_DepartmentModelObj.Id_factory ? true : false
                });

            }
            return items;
        }
    }
}


   


