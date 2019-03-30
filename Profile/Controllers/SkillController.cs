using Profile.Models;
using Profile.Models.Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Profile.Controllers
{
    public class SkillController : Controller
    {

        Dbmodel dbmodel = new Dbmodel();

        [HttpPost]
        public string InsertSkill(SkillModel skillModel)
        {
            try
            {
                Skill obj = new Skill();
                obj.Skills = skillModel.Skills;
                obj.Percentage = skillModel.Percentage;
                obj.Status = "0";
                dbmodel.Skill.Add(obj);
                dbmodel.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }

        }

        [HttpPut]
        public string UpdateSkill(SkillModel skillModel)
        {
            try
            {
                Skill obj = (from ui in dbmodel.Skill where ui.Id == skillModel.Id select ui).FirstOrDefault();
                obj.Skills = skillModel.Skills;
                obj.Percentage = skillModel.Percentage;
                dbmodel.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        [HttpDelete]
        public string DeleteSkill(int id)
        {
            string previous_active = "1";
            try
            {
                Skill obj = (from ui in dbmodel.Skill where ui.Id == id select ui).FirstOrDefault();
                if (obj.Status.Equals(previous_active))
                {
                    return "fail";
                }
                else
                {
                    dbmodel.Skill.Remove(obj);
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
        public string PreviewSkill(int id)
        {
            try
            {
                Skill skill = (from ui in dbmodel.Skill where ui.Id == id select ui).FirstOrDefault();
                skill.Status = "1";
                dbmodel.SaveChanges();
                return "success";

            }
            catch (Exception e)
            {
                return "fail";
            }
        }

        [HttpPut]
        public string HideSkill(int id)
        {
            try
            {
                Skill skill = (from ui in dbmodel.Skill where ui.Id == id select ui).FirstOrDefault();
                skill.Status = "0";
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