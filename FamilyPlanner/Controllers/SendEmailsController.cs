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
using System.Web.Helpers;

namespace FamilyPlanner.Controllers
{
    public class SendEmailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: SendEmails
        public ActionResult Index(FamilyPlanner.Models.SendEmail model)
        {

            

            return View(db.SendEmail.ToList());
        }


        public ActionResult SendEmail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(FamilyPlanner.Models.SendEmail model)
        {
            
            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "adanb82@gmail.com";
                WebMail.Password = "Crazyseven7";

                //Sender email address.  
                WebMail.From = model.From;

                //Send email  
                WebMail.Send(to: model.To, subject: model.Text, body: model.Text, from: model.From, cc: model.Text, isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
            }
            catch (Exception)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";

            }
            return View();
        }
    



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
