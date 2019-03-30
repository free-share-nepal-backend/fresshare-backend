using Profile.Models;
using Profile.Models.Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Profile.Controllers
{
    public class AdminController : Controller
    {
        Dbmodel dbmodel = new Dbmodel();
        // GET: Admin
        public ActionResult Index()
        {
            if (!(Convert.ToInt32(Session["userId"]) > 0))
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.breadcumb = "Dashboard";
            return View();
        }

        public ActionResult Login()
        {

            //Remember me
            UserInfoModel model = new UserInfoModel();
            if (Request.Cookies["Login"] != null)
            {
                model.Username = Request.Cookies["Login"].Values["Username"];
                model.Password = Request.Cookies["Login"].Values["Password"];
                return View(model);
            }

            if (Convert.ToInt32(Session["userId"]) > 0)
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserInfoModel data)
        {
            if (ModelState.IsValid)
            {
                var user = from ui in dbmodel.User_Info
                           where ui.Username == data.Username
                           && ui.Password == data.Password
                           select ui;

                if (user.Any())
                {
                    Session["userId"] = user.Select(x => x.UserId).FirstOrDefault();
                    Session["fullName"] = user.Select(x => x.FullName).FirstOrDefault();

                    // check if checkbox is checked or not
                    if (data.Remember)
                    {
                        HttpCookie cookie = new HttpCookie("Login");
                        cookie.Values.Add("Username", data.Username);
                        cookie.Values.Add("Password", data.Password);
                        cookie.Expires = DateTime.Now.AddDays(10);
                        Response.Cookies.Add(cookie);
                    }
                    return RedirectToAction("Index", "Admin");
                }

                else
                {
                    ViewBag.Error = "Invalid Username and Password";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }

        public string ChangePassword(int userId, string oldPassword, string newPassword)
        {
            try
            {
                 User_Info user = (from ui in dbmodel.User_Info
                                  where ui.UserId == userId
                                  && ui.Password == oldPassword
                                  select ui).FirstOrDefault();

                if (user == null)
                {
                    return "Invalid Password";
                }

                user.Password = newPassword;
                dbmodel.SaveChanges();
                ModelState.Clear();
                return "success";
            }
            catch (Exception e)
            {
                return "Fail";
            }

        }

        public ActionResult AboutMe()
        {
            ViewBag.breadcumb = "About Me";
            return View();
        }

        public ActionResult ClientInfo()
        {
            ViewBag.breadcumb = "Introduction";
            return View();
        }

        public ActionResult Skill()
        {
            ViewBag.breadcumb = "Skill";
            return View();
        }

        public ActionResult Experience()
        {
            ViewBag.breadcumb = "Experience";
            return View();
        }

        public ActionResult Education()
        {
            ViewBag.breadcumb = "Education";
            return View();
        }

        public ActionResult Work()
        {
            ViewBag.breadcumb = "Work";
            return View();
        }

    }
}