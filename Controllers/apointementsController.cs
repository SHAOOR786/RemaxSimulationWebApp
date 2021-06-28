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
    public class apointementsController : Controller
    {
        
        private FinalDatabaseEntities4 db = new FinalDatabaseEntities4();

        
        // GET: apointements
        public ActionResult Index()
        {
            var apointements = db.apointements.Include(a => a.manager).Include(a => a.tenant);
            return View(apointements.ToList());
        }

        // GET: apointements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apointement apointement = db.apointements.Find(id);
            if (apointement == null)
            {
                return HttpNotFound();
            }
            return View(apointement);
        }

        // GET: apointements/Create
        public ActionResult Create()

        {
           
            string id = staticclass.name;
            var managers = from manager in db.managers
                           where manager.managerId == id
                           select manager.managerId;
            var tenants = from tenant in db.tenants
                           where tenant.userId == id
                           select tenant.userId;

            foreach (var item in managers)
            {
                if(item==id)
                {
                    var tens = from man in db.tenants
                               where man.managerId == item
                               select man.userId;
                    ViewBag.managerId = new SelectList(managers);
            
                    ViewBag.tenentId = new SelectList(tens);
                }
                   
                
            }
            foreach (var tenent in tenants)
            {
                if (tenent == id)
                {

                    ViewBag.tenentId = new SelectList(tenants);
                    var mans = from man in db.tenants
                               where man.userId == tenent
                               select man.managerId;
                    ViewBag.managerId = new SelectList(mans);
                }

            }




            return View();
        }
     

        // POST: apointements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "apointmentId,date,time,managerId,tenentId")] apointement apointement)
        {
            if (ModelState.IsValid)
            {
                db.apointements.Add(apointement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            string id = staticclass.name;
            var managers = from manager in db.managers
                           where manager.managerId == id
                           select manager.managerId;
            var tenents = from tenant in db.tenants
                          where tenant.userId == id
                          select tenant.userId;

            foreach (var item in managers)
            {
                if (item == id)
                {
                    var tens = from man in db.tenants
                               where man.managerId == item
                               select man.userId;
                    ViewBag.managerId = new SelectList(managers);

                    ViewBag.tenentId = new SelectList(tens);
                }
              
                    
                
            }
            foreach (var tenent in tenents)
            {
                if (tenent == id)
                {

                    ViewBag.tenentId = new SelectList(tenents);
                    var mans = from man in db.tenants
                               where man.userId == tenent
                               select man.managerId;
                    ViewBag.managerId = new SelectList(mans);
                }

            }


            return View(apointement);
        }

        // GET: apointements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apointement apointement = db.apointements.Find(id);
            if (apointement == null)
            {
                return HttpNotFound();
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", apointement.managerId);
            ViewBag.tenentId = new SelectList(db.tenants, "userId", "firstName", apointement.tenentId);
            return View(apointement);
        }

        // POST: apointements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "apointmentId,date,time,managerId,tenentId")] apointement apointement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apointement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", apointement.managerId);
            ViewBag.tenentId = new SelectList(db.tenants, "userId", "firstName", apointement.tenentId);
            return View(apointement);
        }

        // GET: apointements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apointement apointement = db.apointements.Find(id);
            if (apointement == null)
            {
                return HttpNotFound();
            }
            return View(apointement);
        }

        // POST: apointements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            apointement apointement = db.apointements.Find(id);
            db.apointements.Remove(apointement);
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
