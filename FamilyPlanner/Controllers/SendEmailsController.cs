using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyPlanner.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;
using System.Net.Mail;
using Postal;

namespace FamilyPlanner.Controllers
{
    public class SendEmailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: SendEmails
        public ActionResult Index(FamilyPlanner.Models.SendEmail model)
        {

            dynamic email = new Postal.Email("SendEmails");
            email.To = model.To;
            email.From = model.From;
            email.Text = model.Text;

            //email.FunnyLink = DB.GetRandomLolcatLink();
            email.Send();
            //return View();

            return View(db.SendEmail.ToList());
        }



        //public static IRestResponse SendSimpleMessage(FamilyPlanner.Models.SendEmail model)
        //{
        //    RestClient client = new RestClient();
        //    client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        //    client.Authenticator =
        //        new HttpBasicAuthenticator("api",
        //                                    "key-3e36e3044866ef2dafbb2aa51e996fb9");
        //    RestRequest request = new RestRequest();
        //    request.AddParameter("domain", "sandbox7b6a18890e5145a69f4c05300155c892.mailgun.org", ParameterType.UrlSegment);
        //    request.Resource = "{domain}/messages";
        //    request.AddParameter("from", model.From);
        //    request.AddParameter("to", model.To);
        //    //request.AddParameter("to", "YOU@YOUR_DOMAIN_NAME");
        //    //request.AddParameter("subject", model.Text);
        //    request.AddParameter("text", model.Text);
        //    request.Method = Method.POST;
        //    return client.Execute(request);
        //}

        //public ActionResult Index()
        //{
        //    return View(db.SendEmail.ToList());
        //}

        //[HttpPost]
        //public ActionResult Index(FamilyPlanner.Models.SendEmail model)
        //{
        //    ApplicationUser user = new ApplicationUser();
        //    MailMessage mm = new MailMessage(user.Email, model.To);
        //    mm.Body = model.Text;
        //    mm.IsBodyHtml = false;

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.EnableSsl = true;

        //    NetworkCredential nc = new NetworkCredential(user.Email, user.PasswordHash);
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = nc;
        //    smtp.Send(mm);
        //    ViewBag.Message = "Mail has been sent!";
        //    return View();
        //}
        // GET: SendEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.SendEmail sendEmail = db.SendEmail.Find(id);
            if (sendEmail == null)
            {
                return HttpNotFound();
            }
            return View(sendEmail);
        }

        // GET: SendEmails/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: SendEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,From,To,Text")] Models.SendEmail sendEmail)
        {
            
            Index(sendEmail);
            if (ModelState.IsValid)
            {
                db.SendEmail.Add(sendEmail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sendEmail);
        }

        // GET: SendEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.SendEmail sendEmail = db.SendEmail.Find(id);
            if (sendEmail == null)
            {
                return HttpNotFound();
            }
            return View(sendEmail);
        }

        // POST: SendEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,From,To,Text")] Models.SendEmail sendEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sendEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sendEmail);
        }

        // GET: SendEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.SendEmail sendEmail = db.SendEmail.Find(id);
            if (sendEmail == null)
            {
                return HttpNotFound();
            }
            return View(sendEmail);
        }

        // POST: SendEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.SendEmail sendEmail = db.SendEmail.Find(id);
            db.SendEmail.Remove(sendEmail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
