using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Profile.Models
{
    public class ClientInfoModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string occupation { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public int status { get; set; }
    }
}