using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyPlanner;
using FamilyPlanner.Models;

namespace FamilyPlanner.Controllers
{
    public class InboxesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inboxes
        public ActionResult Index()
        {
            return View(db.Inbox.ToList());
        }

        // GET: Inboxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inbox inbox = db.Inbox.Find(id);
            if (inbox == null)
            {
                return HttpNotFound();
            }
            return View(inbox);
        }

        // GET: Inboxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inboxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,From,NewMessage")] Inbox inbox)
        {
            if (ModelState.IsValid)
            {
                db.Inbox.Add(inbox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inbox);
        }

        // GET: Inboxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inbox inbox = db.Inbox.Find(id);
            if (inbox == null)
            {
                return HttpNotFound();
            }
            return View(inbox);
        }

        // POST: Inboxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,From,NewMessage")] Inbox inbox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inbox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inbox);
        }

        // GET: Inboxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inbox inbox = db.Inbox.Find(id);
            if (inbox == null)
            {
                return HttpNotFound();
            }
            return View(inbox);
        }

        // POST: Inboxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inbox inbox = db.Inbox.Find(id);
            db.Inbox.Remove(inbox);
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
