using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly StellerAcunMedyaDbEntities db = new StellerAcunMedyaDbEntities();

        public ActionResult Index()
        {
            var testimonialList = db.TblTestimonials.ToList();
            return View(testimonialList);
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var deleteEntity = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(deleteEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonials testimonials)
        {
            db.TblTestimonials.Add(testimonials);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var entity = db.TblTestimonials.Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonials testimonials)
        {
            var updateEntity = db.TblTestimonials.Find(testimonials.TestimonialID);

            updateEntity.FirstName = testimonials.FirstName;
            updateEntity.LastName = testimonials.LastName;
            updateEntity.Job = testimonials.Job;
            updateEntity.Description = testimonials.Description;
            updateEntity.ImageUrl = testimonials.ImageUrl;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}