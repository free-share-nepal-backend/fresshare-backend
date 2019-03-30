using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Profile.Models
{
    public class UserInfoModel
    {

        [Display(Name = "Username: ")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool Remember { get; set; }
    }
}