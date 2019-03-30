﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Profile.Models
{
    public class AboutMeModel
    {
        public int Id { get; set; }

        [Required]
        public string Introduction { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int Status { get; set; }
    }
}