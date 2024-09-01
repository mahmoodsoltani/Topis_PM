using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models
{
    [MetadataType(typeof(VwUserMenuMetaData))]
    public partial class VwUserMenu
    {
    }
    public class VwUserMenuMetaData
    {
        [Display(Name = "ControllerID")]
        //[Required (ErrorMessage =" ControllerID را وارد نمائيد ")]
        public int ControllerID { get; set; }

        [Display(Name = "ControllerName")]
        //[Required (ErrorMessage =" ControllerName را وارد نمائيد ")]
        public string ControllerName { get; set; }

        [Display(Name = "ControllerDesc")]
        //[Required (ErrorMessage =" ControllerDesc را وارد نمائيد ")]
        public string ControllerDesc { get; set; }

        [Display(Name = "ControllerImg")]
        //[Required (ErrorMessage =" ControllerImg را وارد نمائيد ")]
        public string ControllerImg { get; set; }

        [Display(Name = "IsController")]
        //[Required (ErrorMessage =" IsController را وارد نمائيد ")]
        public bool IsController { get; set; }

        [Display(Name = "IsMenu")]
        //[Required (ErrorMessage =" IsMenu را وارد نمائيد ")]
        public bool IsMenu { get; set; }

        [Display(Name = "ControllerStatus")]
        //[Required (ErrorMessage =" ControllerStatus را وارد نمائيد ")]
        public bool ControllerStatus { get; set; }

        [Display(Name = "DefaultAction")]
        //[Required (ErrorMessage =" DefaultAction را وارد نمائيد ")]
        public string DefaultAction { get; set; }

        [Display(Name = "IsParent")]
        //[Required (ErrorMessage =" IsParent را وارد نمائيد ")]
        public bool IsParent { get; set; }

        [Display(Name = "ParetnID")]
        //[Required (ErrorMessage =" ParetnID را وارد نمائيد ")]
        public int? ParetnID { get; set; }

        [Display(Name = "MenuOrder")]
        //[Required (ErrorMessage =" MenuOrder را وارد نمائيد ")]
        public int? MenuOrder { get; set; }

         [Display(Name = "فعال")]
        //[Required (ErrorMessage =" IsEnabled را وارد نمائيد ")]
        public int IsEnabled { get; set; }

        [Display(Name = "IsDeleted")]
        //[Required (ErrorMessage =" IsDeleted را وارد نمائيد ")]
        public int IsDeleted { get; set; }

        [Display(Name = "UserID")]
        //[Required (ErrorMessage =" UserID را وارد نمائيد ")]
        public string UserID { get; set; }

        [Display(Name = "RoleID")]
        //[Required (ErrorMessage =" RoleID را وارد نمائيد ")]
        public int? RoleID { get; set; }

        [Display(Name = "ActionID")]
        //[Required (ErrorMessage =" ActionID را وارد نمائيد ")]
        public int? ActionID { get; set; }

        [Display(Name = "MenuPermission")]
        //[Required (ErrorMessage =" MenuPermission را وارد نمائيد ")]
        public bool MenuPermission { get; set; }

        [Display(Name = "UserControllerIsEnabled")]
        //[Required (ErrorMessage =" UserControllerIsEnabled را وارد نمائيد ")]
        public int UserControllerIsEnabled { get; set; }

        [Display(Name = "UserControllerIsDeleted")]
        //[Required (ErrorMessage =" UserControllerIsDeleted را وارد نمائيد ")]
        public int UserControllerIsDeleted { get; set; }

    }
}
