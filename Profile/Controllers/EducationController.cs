using Profile.Models;
using Profile.Models.Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Profile.Controllers
{
    public class EducationController : Controller
    {
        Dbmodel dbmodel = new Dbmodel();

        [HttpPost]
        public string InsertEducation(EducationModel EducationModel)
        {
            try
            {
                Education obj = new Education();
                obj.StartDate = EducationModel.StartDate;
                obj.EndDate = EducationModel.EndDate;
                obj.Level = EducationModel.Level;
                obj.CollegeName = EducationModel.CollegeName;
                obj.Address = EducationModel.Address;
                obj.CollegeDetail = EducationModel.CollegeDetail;
                dbmodel.Education.Add(obj);
                dbmodel.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }

        }

        [HttpPut]
        public string UpdateEducation(EducationModel EducationModel)
        {
            try
            {
                Education obj = (from ui in dbmodel.Education where ui.Id == EducationModel.Id select ui).FirstOrDefault();
                obj.StartDate = EducationModel.StartDate;
                obj.EndDate = EducationModel.EndDate;
                obj.Level = EducationModel.Level;
                obj.CollegeName = EducationModel.CollegeName;
                obj.Address = EducationModel.Address;
                obj.CollegeDetail = EducationModel.CollegeDetail;
                dbmodel.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        [HttpDelete]
        public string DeleteEducation(int id)
        {
            try
            {
                Education obj = (from ui in dbmodel.Education where ui.Id == id select ui).FirstOrDefault();
                if (obj.Status == 1)
                {
                    return "fail";
                }
                else
                {
                    dbmodel.Education.Remove(obj);
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
        public string PreviewEducation(int id)
        {
            try
            {
                Education Education = (from ui in dbmodel.Education where ui.Id == id select ui).FirstOrDefault();
                Education.Status = 1;
                dbmodel.SaveChanges();
                return "success";

            }
            catch (Exception e)
            {
                return "fail";
            }
        }

        [HttpPut]
        public string HideEducation(int id)
        {
            try
            {
                Education Education = (from ui in dbmodel.Education where ui.Id == id select ui).FirstOrDefault();
                Education.Status = 0;
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