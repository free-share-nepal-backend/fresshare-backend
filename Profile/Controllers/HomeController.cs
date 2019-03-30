using Profile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Profile.Controllers
{
    public class HomeController : Controller
    {
        Dbmodel dbmodel = new Dbmodel();
        public ActionResult Index()
        {
            string one = "1";
            var model = new Model
            {
                about_me = (from ui in dbmodel.About_Me where ui.Status == 1 select ui).FirstOrDefault(),
                client_info=(from ui in dbmodel.Client_Info where ui.status==1 select ui).FirstOrDefault(),
                education = (from ui in dbmodel.Education where ui.Status == 1 orderby ui.StartDate descending select ui).ToList(),
                skill =(from ui in dbmodel.Skill where ui.Status.Equals(one) select ui).ToList(),
                work = (from ui in dbmodel.Work where ui.Status == 1 select ui).FirstOrDefault(),
                experience = (from ui in dbmodel.Experience where ui.Status ==1 orderby ui.StartDate descending select ui ).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Contact(string name, string email, string subject, string message)
        {
                try
                {
                
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(email);
                    msz.To.Add("histugaya47@gmail.com");
                    msz.Subject = subject;
                    msz.Body = string.Format(body,name, email, message);
                    msz.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("histugaya47@gmail.com", "kalapana47");

                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(msz);

                //ViewBag.Sent = "Message successfully sent";
                return RedirectToAction("Index","Home");
                }
                catch (Exception exception)
                {
                //ViewBag.Sent = "Fail to send";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}