using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using finalProject.Models;

namespace finalProject.Controllers
{
    public class managerOwnerMessagesController : Controller
    {
        private FinalDatabaseEntities4 db = new FinalDatabaseEntities4();

        // GET: managerOwnerMessages
        public ActionResult Index()
        {
            var managerOwnerMessages = db.managerOwnerMessages.Include(m => m.manager).Include(m => m.owner);
            return View(managerOwnerMessages.ToList());
        }

        // GET: managerOwnerMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            managerOwnerMessage managerOwnerMessage = db.managerOwnerMessages.Find(id);
            if (managerOwnerMessage == null)
            {
                return HttpNotFound();
            }
            return View(managerOwnerMessage);
        }

        // GET: managerOwnerMessages/Create
        public ActionResult Create()
        {
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName");
            ViewBag.ownerId = new SelectList(db.owners, "ownerId", "firstName");
            return View();
        }

        // POST: managerOwnerMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "messageId,managerId,ownerId,message")] managerOwnerMessage managerOwnerMessage)
        {
            if (ModelState.IsValid)
            {
                db.managerOwnerMessages.Add(managerOwnerMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", managerOwnerMessage.managerId);
            ViewBag.ownerId = new SelectList(db.owners, "ownerId", "firstName", managerOwnerMessage.ownerId);
            return View(managerOwnerMessage);
        }

        // GET: managerOwnerMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            managerOwnerMessage managerOwnerMessage = db.managerOwnerMessages.Find(id);
            if (managerOwnerMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", managerOwnerMessage.managerId);
            ViewBag.ownerId = new SelectList(db.owners, "ownerId", "firstName", managerOwnerMessage.ownerId);
            return View(managerOwnerMessage);
        }

        // POST: managerOwnerMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "messageId,managerId,ownerId,message")] managerOwnerMessage managerOwnerMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(managerOwnerMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", managerOwnerMessage.managerId);
            ViewBag.ownerId = new SelectList(db.owners, "ownerId", "firstName", managerOwnerMessage.ownerId);
            return View(managerOwnerMessage);
        }

        // GET: managerOwnerMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            managerOwnerMessage managerOwnerMessage = db.managerOwnerMessages.Find(id);
            if (managerOwnerMessage == null)
            {
                return HttpNotFound();
            }
            return View(managerOwnerMessage);
        }

        // POST: managerOwnerMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            managerOwnerMessage managerOwnerMessage = db.managerOwnerMessages.Find(id);
            db.managerOwnerMessages.Remove(managerOwnerMessage);
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
