
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace PM.Controllers
{
    public class PM_PersonDepartmentController : Controller
    {
        PMService.dboService dboService = new PMService.dboService();

        public ActionResult Index(int id_Person)
        {
            try
            {
                IList<PMService.PM_PersonDepartment> PM_PersonDepartmentServiceObj = dboService.PM_PersonDepartmentSelect(-1, id_Person, -1);
                IList<PM.Models.PM_PersonDepartmentMetaData> PM_PersonDepartmentModelList = PM_PersonDepartmentServiceObj.OfType<PM.Models.PM_PersonDepartmentMetaData>().ToList();
                PM.Models.PM_PersonDepartmentMetaData PM_PersonDepartmentModelObj = new Models.PM_PersonDepartmentMetaData();

                foreach (PMService.PM_PersonDepartment ww in PM_PersonDepartmentServiceObj)
                {
                    PM_PersonDepartmentModelObj = JsonConvert.DeserializeObject<PM.Models.PM_PersonDepartmentMetaData>(JsonConvert.SerializeObject(ww));
                    PM_PersonDepartmentModelList.Add(PM_PersonDepartmentModelObj);
                }
                return View(PM_PersonDepartmentModelList);
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
                PM.Models.PM_PersonDepartmentMetaData PM_PersonDepartmentModelObj = new Models.PM_PersonDepartmentMetaData();
                TryUpdateModel(PM_PersonDepartmentModelObj);
                if (ModelState.IsValid)
                {


                    PM_PersonDepartmentModelObj.Ctime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_PersonDepartmentModelObj.Mtime = FarsiLibrary.PersianDate.Now.ToString();
                    PM_PersonDepartmentModelObj.Creator = PM.GeneralController.getCurrentUser();
                    PM_PersonDepartmentModelObj.Modifier = PM.GeneralController.getCurrentUser();

                    PMService.PM_PersonDepartment PM_PersonDepartmentServiceObj = new PMService.PM_PersonDepartment();
                    PM_PersonDepartmentServiceObj = JsonConvert.DeserializeObject<PMService.PM_PersonDepartment>(JsonConvert.SerializeObject(PM_PersonDepartmentModelObj));
                    int DeviceDocId = dboService.PM_PersonDepartmentInsert(PM_PersonDepartmentServiceObj);
                }
                Session["Inserted"] = true;

                return View();
            }
            catch
            {
                Session["Inserted"] = false;
                return View();
            }
        }

        public bool Delete(InputData p)
        {
            try
            {

                if (dboService.PM_PersonDepartmentDelete (Convert.ToInt32(p.id)) > 0)
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

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            try {
                PMService.PM_PersonDepartment PM_PErsonDepartmentServiceObj = dboService.PM_PersonDepartmentSelect(id, -1, -1).First();
                if (dboService.PM_PersonDepartmentDelete(id) > 0)
                    Session["Deleted"] = true;
                else
                    Session["Deleted"] = false;

                return RedirectToAction("Index", new { id_Person = PM_PErsonDepartmentServiceObj.ID_Person });
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


   


