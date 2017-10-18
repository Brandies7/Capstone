using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyPlanner.Models;
using Microsoft.AspNet.Identity;

namespace FamilyPlanner.Controllers
{
    public class ChoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Chores
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<Chores> Chores()
        {
            
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            IEnumerable<Chores> myChores = db.Chores.ToList().Where(x => x.User == currentUser);

            int completeCount = 0;
            foreach (Chores chores in myChores)
            {
                if (chores.IsDone)
                {
                    completeCount++;
                }
            }
            ViewBag.Percent = Math.Round(100f * ((float)completeCount / (float)myChores.Count()));
            
            return myChores;
            //return db.Chores.ToList().Where(x => x.User == currentUser);
        }
        public ActionResult BuildChoresTable()
        {

            return View("_ChoresTable", Chores());
        }
        // GET: Chores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chores chores = db.Chores.Find(id);
            if (chores == null)
            {
                return HttpNotFound();
            }
            return View(chores);
        }

        // GET: Chores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Chore,IsDone,PointValue")] Chores chores)
        {
            if (ModelState.IsValid)
            {
                db.Chores.Add(chores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chores);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXCreate([Bind(Include = "Id,Chore,IsDone,PointValue")] Chores chores)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currentUserId);
                chores.User = currentUser;
                chores.IsDone = false;
                db.Chores.Add(chores);
                db.SaveChanges();

            }

            return PartialView("_ChoresTable", Chores());
        }

        // GET: Chores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chores chores = db.Chores.Find(id);
            if (chores == null)
            {
                return HttpNotFound();
            }
            return View(chores);
        }

        // POST: Chores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Chore,IsDone,PointValue")] Chores chores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chores);
        }

        [HttpPost]

        public ActionResult AJAXEdit(int? id, bool value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chores choresList = db.Chores.Find(id);
            if (choresList == null)
            {
                return HttpNotFound();
            }
            else
            {
                choresList.IsDone = value;
                db.Entry(choresList).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("_ChoresTable", Chores());
            }

        }

        // GET: Chores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chores chores = db.Chores.Find(id);
            if (chores == null)
            {
                return HttpNotFound();
            }
            return View(chores);
        }

        // POST: Chores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chores chores = db.Chores.Find(id);
            db.Chores.Remove(chores);
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
