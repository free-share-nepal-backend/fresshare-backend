using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Profile.Models
{
    public class ExperienceModel
    {
        public int Id { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        [Required]
        public string Post { get; set; }

        [Required]
        public string OfficeName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string OfficeDetails { get; set; }

        [Required]
        public int Status { get; set; }
    }
}