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
    public class appartementsController : Controller
    {
        private FinalDatabaseEntities4 db = new FinalDatabaseEntities4();

        // GET: appartements
        public ActionResult Index()
        {
            var Appartements = from appartement in db.appartements
                               join building in db.buildings on appartement.buildingNo equals building.buildingNo
                               where building.managerId == finalProject.Controllers.staticclass.name
                               select appartement;
            return View(Appartements.ToList());
        }

        // GET: appartements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appartement appartement = db.appartements.Find(id);
            if (appartement == null)
            {
                return HttpNotFound();
            }
            return View(appartement);
        }

        // GET: appartements/Create
        public ActionResult Create()
        {
            ViewBag.statusId = new SelectList(db.status, "statusId", "statusId");
            ViewBag.tenantId = new SelectList(db.tenants, "userId", "firstName");
            return View();
        }

        // POST: appartements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "appartementNo,buildingNo,statusId,roomNo,washroomNo,floorNo,tenantId")] appartement appartement)
        {
            if (ModelState.IsValid)
            {
                db.appartements.Add(appartement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.statusId = new SelectList(db.status, "statusId", "statusId", appartement.statusId);
            ViewBag.tenantId = new SelectList(db.tenants, "userId", "firstName", appartement.tenantId);
            return View(appartement);
        }

        // GET: appartements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appartement appartement = db.appartements.Find(id);
            if (appartement == null)
            {
                return HttpNotFound();
            }
            ViewBag.statusId = new SelectList(db.status, "statusId", "statusId", appartement.statusId);
            ViewBag.tenantId = new SelectList(db.tenants, "userId", "firstName", appartement.tenantId);
            return View(appartement);
        }

        // POST: appartements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "appartementNo,buildingNo,statusId,roomNo,washroomNo,floorNo,tenantId")] appartement appartement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appartement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.statusId = new SelectList(db.status, "statusId", "statusId", appartement.statusId);
            ViewBag.tenantId = new SelectList(db.tenants, "userId", "firstName", appartement.tenantId);
            return View(appartement);
        }

        // GET: appartements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appartement appartement = db.appartements.Find(id);
            if (appartement == null)
            {
                return HttpNotFound();
            }
            return View(appartement);
        }

        // POST: appartements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appartement appartement = db.appartements.Find(id);
            db.appartements.Remove(appartement);
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
