using Profile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Profile.Controllers.Api
{
    public class ProfileController : ApiController
    {
        Dbmodel dbmodel = new Dbmodel();

        [System.Web.Http.HttpGet]
        public HttpResponseMessage About_Me()
        {
            var obj = dbmodel.About_Me.ToList();
            return Request.CreateResponse(obj);
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage Client_Info()
        {
            var obj = dbmodel.Client_Info.ToList();
            return Request.CreateResponse(obj);
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage Skill()
        {
            var obj = dbmodel.Skill.ToList();
            return Request.CreateResponse(obj);
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage Experience()
        {
            var obj = dbmodel.Experience.ToList();
            return Request.CreateResponse(obj);
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage Education()
        {
            var obj = dbmodel.Education.ToList();
            return Request.CreateResponse(obj); 
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage Work()
        {
            var obj = dbmodel.Work.ToList();
            return Request.CreateResponse(obj);
        }
    }
}
