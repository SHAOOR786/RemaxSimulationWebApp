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
    public class tenantManagerMessagesController : Controller
    {
        private FinalDatabaseEntities4 db = new FinalDatabaseEntities4();

        // GET: tenantManagerMessages
        public ActionResult Index()
        {
            var tenantManagerMessages = db.tenantManagerMessages.Include(t => t.manager).Include(t => t.tenant);
            return View(tenantManagerMessages.ToList());
        }

        // GET: tenantManagerMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tenantManagerMessage tenantManagerMessage = db.tenantManagerMessages.Find(id);
            if (tenantManagerMessage == null)
            {
                return HttpNotFound();
            }
            return View(tenantManagerMessage);
        }

        // GET: tenantManagerMessages/Create
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
            
                    ViewBag.tenantId = new SelectList(tens);
                }
                   
                
            }
            foreach (var tenent in tenants)
            {
                if (tenent == id)
                {

                    ViewBag.tenantId = new SelectList(tenants);
                    var mans = from man in db.tenants
                               where man.userId == tenent
                               select man.managerId;
                    ViewBag.managerId = new SelectList(mans);
                }

            }

            return View();
        }

        // POST: tenantManagerMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "messageId,managerId,tenantId,message")] tenantManagerMessage tenantManagerMessage)
        {
            if (ModelState.IsValid)
            {
                db.tenantManagerMessages.Add(tenantManagerMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            
                    ViewBag.tenantId = new SelectList(tens);
                }
                   
                
            }
            foreach (var tenent in tenants)
            {
                if (tenent == id)
                {

                    ViewBag.tenantId = new SelectList(tenants);
                    var mans = from man in db.tenants
                               where man.userId == tenent
                               select man.managerId;
                    ViewBag.managerId = new SelectList(mans);
                }

            }
            return View(tenantManagerMessage);
        }

        // GET: tenantManagerMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tenantManagerMessage tenantManagerMessage = db.tenantManagerMessages.Find(id);
            if (tenantManagerMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", tenantManagerMessage.managerId);
            ViewBag.tenantId = new SelectList(db.tenants, "userId", "firstName", tenantManagerMessage.tenantId);
            return View(tenantManagerMessage);
        }

        // POST: tenantManagerMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "messageId,managerId,tenantId,message")] tenantManagerMessage tenantManagerMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenantManagerMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", tenantManagerMessage.managerId);
            ViewBag.tenantId = new SelectList(db.tenants, "userId", "firstName", tenantManagerMessage.tenantId);
            return View(tenantManagerMessage);
        }

        // GET: tenantManagerMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tenantManagerMessage tenantManagerMessage = db.tenantManagerMessages.Find(id);
            if (tenantManagerMessage == null)
            {
                return HttpNotFound();
            }
            return View(tenantManagerMessage);
        }

        // POST: tenantManagerMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tenantManagerMessage tenantManagerMessage = db.tenantManagerMessages.Find(id);
            db.tenantManagerMessages.Remove(tenantManagerMessage);
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
