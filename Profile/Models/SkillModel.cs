using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Profile.Models
{
    public class SkillModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Skills { get; set; }

        [Required]
        public string Percentage { get; set; }

        //[Required]
        //public string Skill2 { get; set; }

        //[Required]
        //public string Percentage2 { get; set; }

        //[Required]
        //public string Skill3 { get; set; }

        //[Required]
        //public string Percentage3 { get; set; }

        [Required]
        public string Status { get; set; }
    }
}