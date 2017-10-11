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
    public class ToDoListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToDoLists
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<ToDoList> GetMyToDoes()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == currentUserId);
            return db.ToDo.ToList().Where(x => x.User == currentUser);
        }
        public ActionResult BuildToDoTable()
        {
            
            return View("_ToDoTable", GetMyToDoes());
        }

        // GET: ToDoLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDo.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return View(toDoList);
        }

        // GET: ToDoLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MyToDoList,Completed")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currentUserId);
                toDoList.User = currentUser;
                    
                db.ToDo.Add(toDoList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDoList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXCreate([Bind(Include = "Id,MyToDoList")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currentUserId);
                toDoList.User = currentUser;
                toDoList.Completed = false;
                db.ToDo.Add(toDoList);
                db.SaveChanges();

            }

            return PartialView("_ToDoTable", GetMyToDoes());
        }

        // GET: ToDoLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDo.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }

            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            if (toDoList.User != currentUser)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(toDoList);
        }

        // POST: ToDoLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MyToDoList,Completed")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDoList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoList);
        }

        [HttpPost]
 
        public ActionResult AJAXEdit(int? id, bool value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDo.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            else
            {
                toDoList.Completed = value;
                db.Entry(toDoList).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("_ToDoTable", GetMyToDoes());
            }
            
        }

        // GET: ToDoLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDo.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return View(toDoList);
        }

        // POST: ToDoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoList toDoList = db.ToDo.Find(id);
            db.ToDo.Remove(toDoList);
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
