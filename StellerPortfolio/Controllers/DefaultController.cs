using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        private readonly StellerAcunMedyaDbEntities db = new StellerAcunMedyaDbEntities();

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialFeature()
        {
            ViewBag.project=db.TblProject.Count();
            ViewBag.testimoinal=db.TblTestimonials.Count();
            ViewBag.skill=db.TblSkills.Count();
            var result = db.TblFeatures.ToList();
            return PartialView(result);
        }
        public PartialViewResult PartialAbout()
        {
            var result = db.TblAbouts.ToList();
            return PartialView(result);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {

            return PartialView();


        }
        [HttpPost]
        public ActionResult SendMessage(TblMessage message)
        {
            db.TblMessage.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialService()
        {
            var result = db.TblServices.Where(s => s.ServiceStatus==true).ToList();
            return PartialView(result);
        }
        public PartialViewResult PartialSkill()
        {
            var result = db.TblSkills.ToList();
            return PartialView(result);
        }
        public PartialViewResult PartialProject()
        {
            var result = db.TblProject.ToList();
            return PartialView(result);
        } 
        public PartialViewResult PartialTestimonail()
        {
            var result = db.TblTestimonials.ToList();
            return PartialView(result);
        } 
        public PartialViewResult PartialContact()
        {
            var result = db.TblContact.ToList();
            return PartialView(result);
        }
        public PartialViewResult PartialFooter()
        {
            var result = db.TblSocialMedias.ToList();
            return PartialView(result);
        }
    }
}