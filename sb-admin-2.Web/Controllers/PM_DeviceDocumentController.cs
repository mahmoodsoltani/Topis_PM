
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace PM.Controllers
{
    public class PM_DeviceDocumentController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
        public ActionResult Download(string name)
        {
            return new DownloadResult
            { VirtualPath = "~/DeviceDocument/"+name, FileDownloadName = name };
        }
        ///////// GET: PM_DeviceDocument
        public ActionResult Index(int id,int id_ProductLine)
        {
            try
            {
                IList<PMService.Pm_DeviceDocument> PM_DeviceDocumentServiceObj = dboService.PM_DeviceDocumentSelect(-1, "-1", id, "-1", "-1", "false");
                IList<PM.Models.PM_DeviceDocumentMetaData> PM_DeviceDocumentModelList = PM_DeviceDocumentServiceObj.OfType<PM.Models.PM_DeviceDocumentMetaData>().ToList();
                PM.Models.PM_DeviceDocumentMetaData PM_DeviceDocumentModelObj = new Models.PM_DeviceDocumentMetaData();
                ViewBag.ID_Device = id;
                ViewBag.ID_ProductLine = id_ProductLine;
                
                    foreach (PMService.Pm_DeviceDocument ww in PM_DeviceDocumentServiceObj)
                {
                    PM_DeviceDocumentModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DeviceDocumentMetaData>(JsonConvert.SerializeObject(ww));
                    PM_DeviceDocumentModelList.Add(PM_DeviceDocumentModelObj);
                }
                return View(PM_DeviceDocumentModelList);
            }
            catch
            {
                return View();
            }
        }

        ///////// GET: PM_DeviceDocument/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PMService.Pm_DeviceDocument PM_DeviceDocumentServiceObj = dboService.PM_DeviceDocumentSelect(id, "-1", -1, "-1", "-1", "-1").First();
                PM.Models.PM_DeviceDocumentMetaData PM_DeviceDocumentModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DeviceDocumentMetaData>(JsonConvert.SerializeObject(PM_DeviceDocumentServiceObj));
                return View(PM_DeviceDocumentModelObj);
            }
            catch
            {
                return View();
            }
        }

        ////// GET: PM_DeviceDocument/Create
        public ActionResult Create(int id)
        {
            try
            {
                //   ViewBag.Lang = new SelectList(dboService.LanguageSelect("-1", "-1", 1, 0), "LanguageID", "LanguageName");
                //   ViewBag.Enab = new SelectList(new List<SelectListItem>
                //               {
                //                new SelectListItem { Text = "فعال", Value = "1",Selected=true},
                //                new SelectListItem { Text = "غير فعال", Value = "0"},
                //                }, "Value", "Text");
                ViewBag.ID_Device = id;
                return View();
            }
            catch
            {
                return View();
            }
        }

        ///// POST: PM_DeviceDocument/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {
                PM.Models.PM_DeviceDocumentMetaData PM_DeviceDocumentModelObj = new Models.PM_DeviceDocumentMetaData();
                TryUpdateModel(PM_DeviceDocumentModelObj);
                if (ModelState.IsValid)
                {
                    
                    PM_DeviceDocumentModelObj.IsDeleted = false;
                    if (Request.Files != null && Request.Files.Count == 1)
                        PM_DeviceDocumentModelObj.FileName =  Path.GetExtension(Request.Files[0].FileName);
                    else
                    {
                        Session["Inserted"] = false;
                        return View();
                    }
                    PM_DeviceDocumentModelObj.IsEnabled = true;
                    PM_DeviceDocumentModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_DeviceDocumentModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_DeviceDocumentModelObj.Creator = PM.GeneralController.getCurrentUser();
                    PM_DeviceDocumentModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.Pm_DeviceDocument PM_DeviceDocumentServiceObj = new PMService.Pm_DeviceDocument();
                    PM_DeviceDocumentServiceObj = JsonConvert.DeserializeObject<PMService.Pm_DeviceDocument>(JsonConvert.SerializeObject(PM_DeviceDocumentModelObj));
                    int DeviceDocId = dboService.PM_DeviceDocumentInsert(PM_DeviceDocumentServiceObj);
                    if (DeviceDocId > 0)
                    {
                        try
                        {
                            if (Request.Files != null && Request.Files.Count == 1)
                            {
                                string path = AppDomain.CurrentDomain.BaseDirectory + "deviceDocument/";
                                string filename = "Doc_"+DeviceDocId.ToString()+ Path.GetExtension(Request.Files[0].FileName);
                                Request.Files[0].SaveAs(Path.Combine(path, filename));
                            }
                        }
                        catch
                        {
                            dboService.PM_DeviceDocumentDelete(DeviceDocId);
                            Session["Inserted"] = false;
                            return View();
                        }
                        Session["Inserted"] = true;
                        if (Session["ProductLine"] != null)
                            return RedirectToAction("Index", new { id = PM_DeviceDocumentModelObj.ID_Device, id_ProductLine = Session["ProductLine"] });
                        else
                            return RedirectToAction("Index", new { id = PM_DeviceDocumentModelObj.ID_Device, id_ProductLine = -1 });

                    }


                    Session["Inserted"] = false;
                    return View();


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

        ////// GET: PM_DeviceDocument/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
               
                PMService.Pm_DeviceDocument PM_DeviceDocumentServiceObj = dboService.PM_DeviceDocumentSelect(id, "-1", -1, "-1", "-1", "-1").First();
                PM.Models.PM_DeviceDocumentMetaData PM_DeviceDocumentModelObj = JsonConvert.DeserializeObject<PM.Models.PM_DeviceDocumentMetaData>(JsonConvert.SerializeObject(PM_DeviceDocumentServiceObj));
                IList<PMService.PM_Factory> PM_FactoryServiceObj = dboService.PM_FactorySelect(-1, "-1", "-1", "-1", "-1", "-1");
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (PMService.PM_Factory ww in PM_FactoryServiceObj)
                {

                    items.Add(new SelectListItem
                    {
                        Text = ww.Name,
                        Value = ww.PM_FactoryID.ToString(),
                        // Selected = ww.PM_FactoryID == PM_DeviceDocumentModelObj.Id_factory ? true : false
                    });

                }

                ViewBag.Factory = items;
                return View(PM_DeviceDocumentModelObj);
            }
            catch
            {
                return View();
            }            
        }

        ////// POST: PM_DeviceDocument/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.PM_DeviceDocumentMetaData PM_DeviceDocumentModelObj)
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
                            PM_DeviceDocumentModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				PM_DeviceDocumentModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_DeviceDocumentModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.Pm_DeviceDocument PM_DeviceDocumentServiceObj = new PMService.Pm_DeviceDocument();
                    PM_DeviceDocumentServiceObj = JsonConvert.DeserializeObject<PMService.Pm_DeviceDocument>(JsonConvert.SerializeObject(PM_DeviceDocumentModelObj));
                    if ( dboService.PM_DeviceDocumentUpdate(PM_DeviceDocumentServiceObj) > 0 )
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
                return View(PM_DeviceDocumentModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(PM_DeviceDocumentModelObj);
            }
        }

        //GET: PM_DeviceDocument/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id,int id_device)
        {
		try{
                PMService.Pm_DeviceDocument PM_DeviceDocumentServiceObj = dboService.PM_DeviceDocumentSelect(id, "-1", -1, "-1", "-1", "-1").First();

                string path = AppDomain.CurrentDomain.BaseDirectory + "deviceDocument/"+ "Doc_" + id.ToString() + PM_DeviceDocumentServiceObj.FileName;
               
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                if (dboService.PM_DeviceDocumentDelete(id) > 0)
                    Session["Deleted"] = true;
                else
                    Session["Deleted"] = false;
                
                return RedirectToAction("Index",new { id = id_device, id_ProductLine=Session["ProductLine"]==null?-1: Session["ProductLine"] });
                // TODO: Add update logic here                
            }
            catch
            {
                Session["Deleted"] = false;
                return RedirectToAction("Index");
            }
        }
  
        ///// POST: PM_DeviceDocument/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.Pm_DeviceDocument PM_DeviceDocumentServiceObj = dboService.PM_DeviceDocumentSelect(id,"-1",-1,"-1","-1","-1").First();
                PM_DeviceDocumentServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                PM_DeviceDocumentServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                PM_DeviceDocumentServiceObj.IsDeleted = true;               
                if ( dboService.PM_DeviceDocumentUpdate(PM_DeviceDocumentServiceObj) >0 )
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
    public class DownloadResult : ActionResult
    {

        public DownloadResult()
        {
        }

        public DownloadResult(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        public string VirtualPath
        {
            get;
            set;
        }

        public string FileDownloadName
        {
            get;
            set;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (!String.IsNullOrEmpty(FileDownloadName))
            {
                context.HttpContext.Response.AddHeader("content-disposition",
                  "attachment; filename=" + this.FileDownloadName);
            }

            string filePath = context.HttpContext.Server.MapPath(this.VirtualPath);
            context.HttpContext.Response.TransmitFile(filePath);
        }
    }
}


   


