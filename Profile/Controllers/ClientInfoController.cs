using Profile.Models;
using Profile.Models.Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Profile.Controllers
{
    public class ClientInfoController : Controller
    {
        Dbmodel dbmodel = new Dbmodel();

    
        [HttpPost]
        public string InsertClientInfo(ClientInfoModel clientInfoModel)
        {
            try
            {
                Client_Info obj = new Client_Info();
                obj.name = clientInfoModel.name;
                obj.occupation = clientInfoModel.occupation;
                obj.phone = clientInfoModel.phone;
                obj.email = clientInfoModel.email;
                obj.status = 0;
                dbmodel.Client_Info.Add(obj);
                dbmodel.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }

        }

        [HttpPut]
        public string UpdateClientInfo(ClientInfoModel clientInfoModel)
        {
            try
            {
                Client_Info obj = (from ui in dbmodel.Client_Info where ui.id == clientInfoModel.id select ui).FirstOrDefault();
                obj.name = clientInfoModel.name;
                obj.occupation = clientInfoModel.occupation;
                obj.phone = clientInfoModel.phone;
                obj.email = clientInfoModel.email;
                dbmodel.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        [HttpDelete]
        public string DeleteClientInfo(int id)
        {
            try
            {
                Client_Info obj = (from ui in dbmodel.Client_Info where ui.id == id select ui).FirstOrDefault();
                if (obj.status == 1)
                {
                    return "fail";
                }
                else
                {
                    dbmodel.Client_Info.Remove(obj);
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
        public string ActivateClientInfo(int id)
        {
            try
            {
                var previousActivate = (from ui in dbmodel.Client_Info where ui.status == 1 select ui).FirstOrDefault();
                var active = (from ui in dbmodel.Client_Info where ui.id == id select ui).FirstOrDefault();

                if (previousActivate != null)
                {
                    previousActivate.status = 0;
                }
                active.status = 1;

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