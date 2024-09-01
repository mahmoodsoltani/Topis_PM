using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace PM.Models
{
    public class ResetPasswordViewModel
    {
        [Required]      
        [Display(Name = "کد کاربری")]
        public string userID { get; set; }

        [Required]
        [Display(Name = "نام کاربری")]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور فعلی")]
        public string oldPassword { get; set; } 

        [Required]
        [StringLength(100, ErrorMessage = " {0}می بایست حداقل {2} کرکتر  باشد ", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور جدید")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("Password", ErrorMessage = "کلمه عبور جدید و تکرار آن تطبیق ندارند")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "خطای ورود")]
        
        public string LoginErrorMessage { get; set; }


    }
}