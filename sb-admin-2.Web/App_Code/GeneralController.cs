using System;
using System.Web.Mvc;



namespace PM
{
    public class GeneralController : Controller
    {
        // GET: Default
        public static string getCurrentUser()
        {

            try
            {

                string UserID = string.Empty;
                if (System.Web.HttpContext.Current.Session["UserID"] != null &&
                    System.Web.HttpContext.Current.Session["UserID"].ToString() != "")

                    return System.Web.HttpContext.Current.Session["UserID"].ToString();
                else
                    return "";
            }
            catch (Exception e)
            {


            //    Logger.ErrorLog(e);
                return "";

            }
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Default/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Default/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Default/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Default/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Default/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Default/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Default/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
