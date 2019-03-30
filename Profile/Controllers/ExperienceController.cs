using Profile.Models;
using Profile.Models.Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Profile.Controllers
{
    public class ExperienceController : Controller
    {
        Dbmodel dbmodel = new Dbmodel();
        
        [HttpPost]
        public string InsertExperience(ExperienceModel experienceModel)
        {
            try
            {
                Experience obj = new Experience();
                obj.StartDate = experienceModel.StartDate;
                obj.EndDate = experienceModel.EndDate;
                obj.Post = experienceModel.Post;
                obj.OfficeName = experienceModel.OfficeName;
                obj.Address = experienceModel.Address;
                obj.OfficeDetails = experienceModel.OfficeDetails;
                dbmodel.Experience.Add(obj);
                dbmodel.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }

        }

        [HttpPut]
        public string UpdateExperience(ExperienceModel experienceModel)
        {
            try
            {
                Experience obj = (from ui in dbmodel.Experience where ui.Id == experienceModel.Id select ui).FirstOrDefault();
                obj.StartDate = experienceModel.StartDate;
                obj.EndDate = experienceModel.EndDate;
                obj.Post = experienceModel.Post;
                obj.OfficeName = experienceModel.OfficeName;
                obj.Address = experienceModel.Address;
                obj.OfficeDetails = experienceModel.OfficeDetails;
                dbmodel.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        [HttpDelete]
        public string DeleteExperience(int id)
        {
            try
            {
                Experience obj = (from ui in dbmodel.Experience where ui.Id == id select ui).FirstOrDefault();
                if (obj.Status==1)
                {
                    return "fail";
                }
                else
                {
                    dbmodel.Experience.Remove(obj);
                    dbmodel.SaveChanges();
                    return "success";
                }
            }
            catch (Exception e)
            {
                return "fail";
            }


        }

        [HttpPut]
        public string PreviewExperience(int id)
        {
            try
            {
                Experience experience = (from ui in dbmodel.Experience where ui.Id == id select ui).FirstOrDefault();
                experience.Status = 1;
                dbmodel.SaveChanges();
                return "success";

            }
            catch (Exception e)
            {
                return "fail";
            }
        }

        [HttpPut]
        public string HideExperience(int id)
        {
            try
            {
                Experience experience = (from ui in dbmodel.Experience where ui.Id == id select ui).FirstOrDefault();
                experience.Status = 0;
                dbmodel.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }
        }
    }
}