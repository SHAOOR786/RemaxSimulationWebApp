using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using finalProject.Models;

namespace finalProject.Controllers
{
    public class HomeController : Controller
    {
        private FinalDatabaseEntities4 db = new FinalDatabaseEntities4();
        public ActionResult Index(string search)
        {
            var Appartements = from appartement in db.appartements
                           join building in db.buildings on appartement.buildingNo equals building.buildingNo
                           where appartement.buildingNo ==search 
                           select appartement;


            return View(Appartements.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login(string userName, string password)
        {
            var users = from user in db.tenants
                               select user;
            var managers = from manager in db.managers
                           select manager;
            var owners = from owner in db.owners
                           select owner;

            foreach (var user in users)
            {
                if (user.userId==userName && user.password==password)
                {
                    staticclass.name = userName;
                   
                    
                    return RedirectToAction("Index", "apointements");
                }
            }
            foreach (var owner in owners)
            {
                if (owner.ownerId == userName && owner.password == password)
                {
                    staticclass.name = userName;
                    return RedirectToAction("welcomeOwner", "owners");
                }
            }
            foreach (var manager in managers)
            {
                if (manager.managerId == userName && manager.password == password)
                {
                    staticclass.name = userName;
                    return RedirectToAction("Index", "managerOwnerMessages");
                }
            }

            return View();
        }
        public ActionResult AppartementDetail(int? id)
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

    }
}