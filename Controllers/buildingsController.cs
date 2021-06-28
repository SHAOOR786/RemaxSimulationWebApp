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
    public class buildingsController : Controller
    {
        private FinalDatabaseEntities4 db = new FinalDatabaseEntities4();

        // GET: buildings
        List<building> buildinglist;
        public ActionResult Index()
        {
            var buildingss = from build in db.buildings
                            where build.ownerId == staticclass.name
                            select build;

            foreach (var buil in buildingss)
            {
                if (buil.ownerId==staticclass.name)
                {
                    buildinglist = new List<building>();
                    buildinglist.Add(buil);
                        return View(buildinglist);
                }
            }
            var buildings = db.buildings.Include(b => b.manager).Include(b => b.owner);
            return View(buildings.ToList());
        }

        // GET: buildings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            building building = db.buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // GET: buildings/Create
        public ActionResult Create()
        {
            building building = new building();
            string id = staticclass.name;
            var managers = from buil in db.buildings
                           where buil.managerId == id
                           select buil.managerId;
            var owners = from buil in db.buildings
                         where buil.ownerId == id
                         select buil.ownerId;

            foreach (var managerId in managers)
            {
                if (managerId == id)
                {
                    ViewBag.managerId = new SelectList(managers);

                    ViewBag.ownerId = new SelectList(db.owners, "ownerId", "firstName", building.ownerId);

                }


            }
            foreach (var ownerId in owners)
            {
                if (ownerId == id)
                {

                    ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", building.managerId);

                    ViewBag.ownerId = new SelectList(owners);
                }

            }


            return View();
        }

        // POST: buildings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "buildingNo,streetName,postalCode,city,province,ownerId,managerId")] building building)
        {
            if (ModelState.IsValid)
            {
                db.buildings.Add(building);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            string id = staticclass.name;
            var managers = from buil in db.buildings
                           where buil.managerId == id
                           select buil.managerId;
            var owners = from buil in db.buildings
                          where buil.ownerId == id
                          select buil.ownerId;

            foreach (var managerId in managers)
            {
                if (managerId == id)
                {
                    ViewBag.managerId = new SelectList(managers);

                    ViewBag.ownerId = new SelectList(db.owners, "ownerId", "firstName", building.ownerId);

                }


            }
            foreach (var ownerId in owners)
            {
                if (ownerId == id)
                {

                    ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", building.managerId);

                    ViewBag.ownerId = new SelectList(owners);
                }

            }



            
            return View(building);
        }

        // GET: buildings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            building building = db.buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", building.managerId);
            ViewBag.ownerId = new SelectList(db.owners, "ownerId", "firstName", building.ownerId);
            return View(building);
        }

        // POST: buildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "buildingNo,streetName,postalCode,city,province,ownerId,managerId")] building building)
        {
            if (ModelState.IsValid)
            {
                db.Entry(building).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "firstName", building.managerId);
            ViewBag.ownerId = new SelectList(db.owners, "ownerId", "firstName", building.ownerId);
            return View(building);
        }

        // GET: buildings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            building building = db.buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            building building = db.buildings.Find(id);
            db.buildings.Remove(building);
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
