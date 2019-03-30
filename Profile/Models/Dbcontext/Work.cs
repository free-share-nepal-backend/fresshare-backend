using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Profile.Models.Dbcontext
{
    public class Work
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image1 { get; set; }

        [Required]
        public string Title1 { get; set; }

        [Required]
        public string Image2 { get; set; }

        [Required]
        public string Title2 { get; set; }

        [Required]
        public string Image3 { get; set; }

        [Required]
        public string Title3 { get; set; }

        [Required]
        public string Image4 { get; set; }

        [Required]
        public string Title4 { get; set; }

        [Required]
        public string Image5 { get; set; }

        [Required]
        public string Title5 { get; set; }

        [Required]
        public int Status { get; set; }
    }
}