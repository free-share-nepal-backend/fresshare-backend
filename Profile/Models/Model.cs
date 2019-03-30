using Profile.Models.Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Profile.Models
{
    public class Model
    {
        public About_Me about_me { get; set; }

        public Client_Info client_info { get; set; }

        //public ContactModel contact { get; set; }

        public Work work { get; set; }

        public List<Education> education { get; set; }

        public List<Experience> experience { get; set; }

        public List<Skill> skill { get; set; }
    }
}