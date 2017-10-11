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
    public class ShoppingListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingLists
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<ShoppingList> GetMyShoppingList()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            IEnumerable<ShoppingList> myShoppingList = db.ShoppingList.ToList().Where(x => x.User == currentUser);

            //int completeCount = 0;
            //foreach (ToDoList toDo in myToDoes)
            //{
            //    if (toDo.Completed)
            //    {
            //        completeCount++;
            //    }
            //}
            //ViewBag.Percent = Math.Round(100f * ((float)completeCount / (float)myToDoes.Count()));
            //return myToDoes;
            return db.ShoppingList.ToList().Where(x => x.User == currentUser);
        }
        public ActionResult BuildShoppingTable()
        {

            return View("_ShoppingTable", GetMyShoppingList());
        }


        // GET: ShoppingLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingList.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        // GET: ShoppingLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Item,Quantity,Buy")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingList.Add(shoppingList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXCreate([Bind(Include = "Id, Item, Quantity, Buy")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currentUserId);
                shoppingList.User = currentUser;
                shoppingList.Buy = false;
                db.ShoppingList.Add(shoppingList);
                db.SaveChanges();

            }

            return PartialView("_ShoppingTable", GetMyShoppingList());
        }


        // GET: ShoppingLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingList.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        // POST: ShoppingLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Item,Quantity,Buy")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingList);
        }

        [HttpPost]

        public ActionResult AJAXEdit(int? id, bool value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingList.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            else
            {
                shoppingList.Buy = value;
                db.Entry(shoppingList).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("_ShoppingTable", GetMyShoppingList());
            }

        }

        // GET: ShoppingLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingList.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        // POST: ShoppingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingList shoppingList = db.ShoppingList.Find(id);
            db.ShoppingList.Remove(shoppingList);
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
