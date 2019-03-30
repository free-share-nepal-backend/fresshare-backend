using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Profile.Models.Dbcontext
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Dbmodel>
    {
        protected override void Seed(Dbmodel context)
        {
            User_Info userinfo = new User_Info();
            userinfo.FullName = "Sunil Maharjan";
            userinfo.Address = "Tahachal";
            userinfo.Contact = "9808035622";
            userinfo.Username = "admin";
            userinfo.Password = "admin";

            context.User_Info.Add(userinfo);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}