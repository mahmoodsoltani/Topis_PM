
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
 
namespace PM.Controllers
{
    public class ReportMaterail
    {
        public string reportid;
        public string materialid;
        public string amount;
        public string disc;
    }
    public class Pm_WorkOrder_MaterialController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();
   
		///////// GET: Pm_WorkOrder_Material
        public ActionResult Index(int id)
        {
		 try
           {
		    IList< PMService.Pm_WorkOrder_Material> Pm_WorkOrder_MaterialServiceObj=dboService.Pm_WorkOrder_MaterialSelect(-1,-1,-1,id,"-1","-1");
            IList<PM.Models.Pm_WorkOrder_MaterialMetaData> Pm_WorkOrder_MaterialModelList = Pm_WorkOrder_MaterialServiceObj.OfType<PM.Models.Pm_WorkOrder_MaterialMetaData>().ToList();
            PM.Models.Pm_WorkOrder_MaterialMetaData Pm_WorkOrder_MaterialModelObj = new Models.Pm_WorkOrder_MaterialMetaData();
            foreach (PMService.Pm_WorkOrder_Material ww in Pm_WorkOrder_MaterialServiceObj)
             {
                 Pm_WorkOrder_MaterialModelObj = JsonConvert.DeserializeObject<PM.Models.Pm_WorkOrder_MaterialMetaData>(JsonConvert.SerializeObject(ww));
                 Pm_WorkOrder_MaterialModelList.Add(Pm_WorkOrder_MaterialModelObj);
             }
             return View(Pm_WorkOrder_MaterialModelList);
           }
		 catch
             {
                return View();
             }
	    }

		///////// GET: Pm_WorkOrder_Material/Details/5
        public ActionResult Details(int id)
        {
		 try
           {
            PMService.Pm_WorkOrder_Material Pm_WorkOrder_MaterialServiceObj = dboService.Pm_WorkOrder_MaterialSelect(id,-1,-1,-1,"-1","-1").First();
            PM.Models.Pm_WorkOrder_MaterialMetaData Pm_WorkOrder_MaterialModelObj = JsonConvert.DeserializeObject<PM.Models.Pm_WorkOrder_MaterialMetaData>(JsonConvert.SerializeObject(Pm_WorkOrder_MaterialServiceObj));
            return View(Pm_WorkOrder_MaterialModelObj);
		   }
		 catch
             {
                return View();
             }            
        }

		 ////// GET: Pm_WorkOrder_Material/Create
        public ActionResult Create()
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
 
        ///// POST: Pm_WorkOrder_Material/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try
            {    
			    PM.Models.Pm_WorkOrder_MaterialMetaData Pm_WorkOrder_MaterialModelObj = new Models.Pm_WorkOrder_MaterialMetaData();  
				TryUpdateModel(Pm_WorkOrder_MaterialModelObj);          
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
						    Pm_WorkOrder_MaterialModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
              */		               
               
                Pm_WorkOrder_MaterialModelObj.IsDeleted = false;                
                Pm_WorkOrder_MaterialModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                Pm_WorkOrder_MaterialModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                Pm_WorkOrder_MaterialModelObj.Creator = PM.GeneralController.getCurrentUser();
                Pm_WorkOrder_MaterialModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.Pm_WorkOrder_Material Pm_WorkOrder_MaterialServiceObj = new PMService.Pm_WorkOrder_Material();
                    Pm_WorkOrder_MaterialServiceObj = JsonConvert.DeserializeObject<PMService.Pm_WorkOrder_Material>(JsonConvert.SerializeObject(Pm_WorkOrder_MaterialModelObj));
                    if ( dboService.Pm_WorkOrder_MaterialInsert(Pm_WorkOrder_MaterialServiceObj) > 0 )					                   
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

        ////// GET: Pm_WorkOrder_Material/Edit/5
        public ActionResult Edit(int id)
        {
		try{
         
            PMService.Pm_WorkOrder_Material Pm_WorkOrder_MaterialServiceObj =  dboService.Pm_WorkOrder_MaterialSelect(id,-1,-1,-1,"-1","-1").First();
            PM.Models.Pm_WorkOrder_MaterialMetaData Pm_WorkOrder_MaterialModelObj= JsonConvert.DeserializeObject<PM.Models.Pm_WorkOrder_MaterialMetaData>(JsonConvert.SerializeObject(Pm_WorkOrder_MaterialServiceObj));
            return View(Pm_WorkOrder_MaterialModelObj);
           }
		catch
             {
                return View();
             }            
        }

        ////// POST: Pm_WorkOrder_Material/Edit/5
        [HttpPost]
        public ActionResult Edit(PM.Models.Pm_WorkOrder_MaterialMetaData Pm_WorkOrder_MaterialModelObj)
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
                            Pm_WorkOrder_MaterialModelObj.LanguagePhoto = System.Configuration.ConfigurationManager.AppSettings["ImagePath"] + fileName;
                            fileName = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ImagePath"]), fileName);

                            file.SaveAs(fileName);
                        }
                    }
                  */
				Pm_WorkOrder_MaterialModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                Pm_WorkOrder_MaterialModelObj.Modifier = PM.GeneralController.getCurrentUser();
                    PMService.Pm_WorkOrder_Material Pm_WorkOrder_MaterialServiceObj = new PMService.Pm_WorkOrder_Material();
                    Pm_WorkOrder_MaterialServiceObj = JsonConvert.DeserializeObject<PMService.Pm_WorkOrder_Material>(JsonConvert.SerializeObject(Pm_WorkOrder_MaterialModelObj));
                    if ( dboService.Pm_WorkOrder_MaterialUpdate(Pm_WorkOrder_MaterialServiceObj) > 0 )
                        Session["Edited"] = true;
                    else
                        Session["Edited"] = false;

                    return RedirectToAction("Index");
                }

               
					Session["Edited"] = false;
                return View(Pm_WorkOrder_MaterialModelObj);
            }
            catch
            {
                Session["Edited"] = false;
				return View(Pm_WorkOrder_MaterialModelObj);
            }
        }

        //GET: Pm_WorkOrder_Material/Delete/5
        //[HttpDelete]
        public bool Delete(InputData p)
        {
            try
            {

                if (dboService.Pm_WorkOrder_MaterialDelete(Convert.ToInt32(p.id)) > 0)
                    return true;
                else
                    return false;


                // TODO: Add update logic here                
            }
            catch
            {

                return false;
            }
        }
  
        ///// POST: Pm_WorkOrder_Material/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                PMService.Pm_WorkOrder_Material Pm_WorkOrder_MaterialServiceObj = dboService.Pm_WorkOrder_MaterialSelect(id,-1,-1,-1,"-1","-1").First();
                Pm_WorkOrder_MaterialServiceObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                Pm_WorkOrder_MaterialServiceObj.Modifier = PM.GeneralController.getCurrentUser();
                Pm_WorkOrder_MaterialServiceObj.IsDeleted = true;               
                if ( dboService.Pm_WorkOrder_MaterialUpdate(Pm_WorkOrder_MaterialServiceObj) >0 )
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


   


