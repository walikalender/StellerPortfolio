using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class AboutController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
        public ActionResult Index()
        {

            var aboutList = db.TblAbouts.ToList();
            return View(aboutList);
        }
        public ActionResult DeleteAbout(int id)
        {
            var deletedEntity = db.TblAbouts.Find(id);
            db.TblAbouts.Remove(deletedEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}