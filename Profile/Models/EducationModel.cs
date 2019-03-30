using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Profile.Models
{
    public class EducationModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string CollegeName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string CollegeDetail { get; set; }

        [Required]
        public int Status { get; set; }
    }
}