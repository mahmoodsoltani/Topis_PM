using PM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web;

namespace MRKHTV.Domain
{
   
    public class Data
    {
        public static bool IsLoaded = false;
        public static List<Navbar> menu;
        //IList<MRKdboService.VwUserMenu> VwUserMenuServiceObj;
        //   PM.MRKdboService.BaseServiceClient BaseService = new PM.MRKdboService.BaseServiceClient();
       

        public static IEnumerable<Navbar> navbarItems()
        {
            PMService.dboService dboService = new PMService.dboService();
            try
            {
                if (!IsLoaded)
                {
                    menu = new List<Navbar>();

                    string userID = HttpContext.Current.Session["UserID"].ToString();//getting the current userID
                    string roleID = HttpContext.Current.Session["RoleID"].ToString();//getting the current role
                    IList<PMService.PM_MenuItem> PM_MenuItemServiceObj = dboService.PM_MenuItemSelect();

                    IList<PM.Models.PM_MenuItemMetaData> VwUserMenuModelList = PM_MenuItemServiceObj.OfType<PM.Models.PM_MenuItemMetaData>().ToList();
                    PM.Models.PM_MenuItemMetaData VwUserMenuModelObj = new PM.Models.PM_MenuItemMetaData();
                    Dictionary<string, bool> Autorize = (Dictionary<string, bool>)HttpContext.Current.Session["autorize"];
                    foreach (PMService.PM_MenuItem ww in PM_MenuItemServiceObj)
                    {
                        if ((ww.Controller == null) || (Autorize.ContainsKey(ww.Controller.ToLower() + "_" + ww.Action.ToLower()) && Autorize[ww.Controller.ToLower() + "_" + ww.Action.ToLower()]))
                            menu.Add(new Navbar { Id = (int)ww.PM_MenuItemID, nameOption = ww.NameOption, controller = ww.Controller, action = ww.Action, imageClass = ww.ImageClass, status = ww.status, isParent = ww.IsParent, parentId = (int)ww.ParentId, ActionParameter = ww.ActionParameter, functionCall = ww.FunctionCall });
                    }
                    IsLoaded = true;
                }
                return menu.ToList();
            }
            catch
            { return null; }

        }
 
            //        var menu = new List<Navbar>();
            //menu.Add(new Navbar { Id = 0, nameOption = "داشبورد", controller = "Home", action = "Index", imageClass = "nav-icon fa fa-dashboard", status = true, isParent = false, parentId = 0 });

            //menu.Add(new Navbar { Id = 1, nameOption = "اطلاعات پایه", imageClass = "fa fa-database fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 3, nameOption = "اطلاعات اولیه کارخانه", imageClass = "fa fa-home fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 2, nameOption = "تعاریف اولیه", imageClass = "fa fa-file-text-o fa-fw", status = true, isParent = true, parentId = 0 });


            //menu.Add(new Navbar { Id = 4, nameOption = "تعمیرات", imageClass = "fa fa-wrench fa-fw", status = true, isParent = true, parentId = 0 });
          
            //menu.Add(new Navbar { Id = 7, nameOption = "دستور کار", imageClass = "fa fa-list-ul fa-fw", status = true, isParent = true, parentId = 0 });

            //menu.Add(new Navbar { Id = 10, nameOption = "روتین", imageClass = "fa fa-share-alt fa-fw", status = true, isParent = true, parentId = 0 });

            //menu.Add(new Navbar { Id = 20, nameOption = "خروج",functionCall= "AlertExit();", controller = "Login", action = "Index", imageClass = "nav-icon fa fa-sign-out", status = true, isParent = false, parentId = 0 });

            //menu.Add(new Navbar { Id = 21, nameOption = "مهارت", controller = "PM_Skill", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 2 });
            //menu.Add(new Navbar { Id = 22, nameOption = "نوع قطعات و مواد", controller = "PM_MaterialType", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 2 });
            //menu.Add(new Navbar { Id = 23, nameOption = "واحد", controller = "PM_Unit", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 2 });
            //menu.Add(new Navbar { Id = 24, nameOption = "نوع تجهیزات", controller = "PM_Equipmenttype", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 2 });
            //menu.Add(new Navbar { Id = 25, nameOption = "وضعیت تجهیزات", controller = "PM_EquipmentStatus", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 2 });
            ////menu.Add(new Navbar { Id = 26, nameOption = "وضعیت دستور کار", controller = "Pm_WorkOrderStatus", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 2 });

            //menu.Add(new Navbar { Id = 11, nameOption = "کارخانه", controller = "PM_Factory", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 3 });
            //menu.Add(new Navbar { Id = 12, nameOption = "بخش ها", controller = "PM_Department", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 3 });
            //menu.Add(new Navbar { Id = 13, nameOption = "واحد ها", controller = "PM_ProductLine", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 3 });
            //menu.Add(new Navbar { Id = 14, nameOption = "دستگاه", ActionParameter= "-1", controller = "PM_device", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 3 });
            //menu.Add(new Navbar { Id = 15, nameOption = "تجهیزات", ActionParameter = "-1", controller = "PM_Equipment", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 3 });
            //menu.Add(new Navbar { Id = 16, nameOption = "قطعات و مواد مصرفی", controller = "PM_Material", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 3 });

            //menu.Add(new Navbar { Id = 17, nameOption = "پرسنل", controller = "PM_Person", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 1 });
            //menu.Add(new Navbar { Id = 10, nameOption = "کاربران", controller = "PM_User", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 1 });
            //menu.Add(new Navbar { Id = 18, nameOption = "تعطیلات", controller = "PM_holiday", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 1 });
            //menu.Add(new Navbar { Id = 19, nameOption = "عیب", controller = "PM_Fault", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 1});
            //menu.Add(new Navbar { Id = 20, nameOption = "آیتم چک", controller = "PM_Item", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 1 });
            //menu.Add(new Navbar { Id = 41, nameOption = "لیست درخواست ها", controller = "PM_RepairOrder", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 4 });
            //menu.Add(new Navbar { Id = 42, nameOption = "ثبت درخواست", controller = "PM_RepairOrder", action = "Create", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 4 });
            //menu.Add(new Navbar { Id = 71, nameOption = "لیست دستور کارها", controller = "PM_WorkOrder", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 101, nameOption = "لیست روتین ها", controller = "PM_Routine", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 10 });
            //menu.Add(new Navbar { Id = 103, nameOption = "لیست برنامه ریزی ها", controller = "PM_ScheduledRoutine", action = "index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 10 });
            //////// }
           // return menu.ToList();
        
    }
}