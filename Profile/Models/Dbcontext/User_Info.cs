using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Profile.Models.Dbcontext
{
    public class User_Info
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}