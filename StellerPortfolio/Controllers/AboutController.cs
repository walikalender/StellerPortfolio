﻿using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class AboutController : Controller
    {
       private readonly StellerAcunMedyaDbEntities db = new StellerAcunMedyaDbEntities();
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
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(TblAbouts tblAbouts)
        {
            db.TblAbouts.Add(tblAbouts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var entity = db.TblAbouts.Find(id);
            return View(entity); // View'e ilgili varlığı gönder
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbouts tblAbouts)
        {
            var updatedAbout = db.TblAbouts.Find(tblAbouts.AboutID);

            updatedAbout.FirstName = tblAbouts.FirstName;
            updatedAbout.LastName = tblAbouts.LastName;
            updatedAbout.Description = tblAbouts.Description;
            updatedAbout.Job = tblAbouts.Job;
            updatedAbout.CvDownloadUrl = tblAbouts.CvDownloadUrl;
            updatedAbout.ImageUrl = tblAbouts.ImageUrl;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}