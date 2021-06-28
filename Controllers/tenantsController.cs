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
    public class tenantsController : Controller
    {
        List<tenant> tntList;
        private FinalDatabaseEntities4 db = new FinalDatabaseEntities4();

        // GET: tenants
        public ActionResult Index()


        {

            
            var tenants = db.tenants.Include(t => t.manager);
            return View(tenants.ToList());
        }

        // GET: tenants/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tenant tenant = db.tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // GET: tenants/Create
        public ActionResult Create()
        {
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName");
            return View();
        }

        // POST: tenants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,firstName,lastName,phoneNumber,email,password,managerId")] tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.tenants.Add(tenant);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", tenant.managerId);
            return RedirectToAction("Index", "Home");
        }

        // GET: tenants/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tenant tenant = db.tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", tenant.managerId);
            return View(tenant);
        }

        // POST: tenants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,firstName,lastName,phoneNumber,email,password,managerId")] tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", tenant.managerId);
            return View(tenant);
        }

        // GET: tenants/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tenant tenant = db.tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // POST: tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tenant tenant = db.tenants.Find(id);
            db.tenants.Remove(tenant);
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

        public ActionResult SendMessage(string userName, string password)
        {
              
            return RedirectToAction("Index", "apointements");
        }
    }
}
