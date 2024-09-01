using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
namespace PM.App_Code
{
    public class PublicFunction
    {
       
        public static string ShowAlert()
        {
            if (HttpContext.Current.Session["Deleted"] != null && HttpContext.Current.Session["Deleted"].ToString() != "" && Convert.ToBoolean(HttpContext.Current.Session["Deleted"]) == true)
            {
                HttpContext.Current.Session["Deleted"] = "";
                return "  ShowAlert('SucsessDelete'); ";
            }
            else if (HttpContext.Current.Session["Deleted"] != null && HttpContext.Current.Session["Deleted"].ToString() != "" && Convert.ToBoolean(HttpContext.Current.Session["Deleted"]) == false)
            {
                HttpContext.Current.Session["Deleted"] = "";
                return " ShowAlert('UnSucsessDelete'); ";
            }
            else if ((HttpContext.Current.Session["Inserted"] != null && HttpContext.Current.Session["Inserted"].ToString() != "" && HttpContext.Current.Session["Inserted"].ToString() == "True"))
            {
                HttpContext.Current.Session["Inserted"] = "";
                return "  ShowAlert('SucsessInsert'); ";
            }
            else if ((HttpContext.Current.Session["Inserted"] != null && HttpContext.Current.Session["Inserted"].ToString() != "" && HttpContext.Current.Session["Inserted"].ToString() == "False"))
            {
                HttpContext.Current.Session["Inserted"] = "";
                return "ShowAlert('UnSucsessInsert'); ";
            }
            else if ((HttpContext.Current.Session["Inserted"] != null && HttpContext.Current.Session["Inserted"].ToString() != "" && HttpContext.Current.Session["Inserted"].ToString() == "Repeat"))
            {
                HttpContext.Current.Session["Inserted"] = "";
                return "ShowAlert('RepeatedInsert'); ";
            }
            else if ((HttpContext.Current.Session["Edited"] != null && HttpContext.Current.Session["Edited"].ToString() != "" && HttpContext.Current.Session["Edited"].ToString() == "True"))
            {
                HttpContext.Current.Session["Edited"] = "";
                return "  ShowAlert('SucsessEdit'); ";
            }
            else if ((HttpContext.Current.Session["Edited"] != null && HttpContext.Current.Session["Edited"].ToString() != "" && HttpContext.Current.Session["Edited"].ToString() == "False"))
            {
                HttpContext.Current.Session["Edited"] = "";
                return "  ShowAlert('UnSucsessEdit');";
            }
            else if ((HttpContext.Current.Session["RegWO"] != null && HttpContext.Current.Session["RegWO"].ToString() != "" && HttpContext.Current.Session["RegWO"].ToString() == "True"))
            {
                HttpContext.Current.Session["RegWO"] = "";
                return "  ShowAlert('SucsessRegWO'); ";
            }
            else if ((HttpContext.Current.Session["RegWO"] != null && HttpContext.Current.Session["RegWO"].ToString() != "" && HttpContext.Current.Session["RegWO"].ToString() == "False"))
            {
                HttpContext.Current.Session["Edited"] = "";
                return "  ShowAlert('UnSucsessRegWO');";
            }
            else if ((HttpContext.Current.Session["Login"] != null && HttpContext.Current.Session["Login"].ToString() != "" && Convert.ToBoolean(HttpContext.Current.Session["Login"]) == false))
            {
                HttpContext.Current.Session["Login"] = "";
                return "  ShowAlert('UnSucsessLogin');";
            }
            return "";
        }
    }

    
}