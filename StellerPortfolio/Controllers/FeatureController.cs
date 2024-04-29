using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        private readonly StellerAcunMedyaDbEntities db = new StellerAcunMedyaDbEntities();
        public ActionResult Index()
        {
            var featureList = db.TblFeatures.ToList();

            return View(featureList);
        }
        public ActionResult DeleteFeature(int id)
        {
            var deleteEntity = db.TblFeatures.Find(id);
            db.TblFeatures.Remove(deleteEntity);
            db.SaveChanges();
            return RedirectToAction("Index");  
        }
        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(TblFeatures tblFeatures)
        {
            db.TblFeatures.Add(tblFeatures);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
           var entity = db.TblFeatures.Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeatures tblFeatures)
        {
            var updatedEntity = db.TblFeatures.Find(tblFeatures.FeatureID);

            updatedEntity.FirstName=tblFeatures.FirstName;
            updatedEntity.LastName=tblFeatures.LastName;
            updatedEntity.Job=tblFeatures.Job;
            updatedEntity.Title=tblFeatures.Title;
            updatedEntity.CvDownloadUrl=tblFeatures.CvDownloadUrl;
            updatedEntity.ImageUrl=tblFeatures.ImageUrl;

            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}