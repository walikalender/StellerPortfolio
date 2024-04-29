using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly StellerAcunMedyaDbEntities db = new StellerAcunMedyaDbEntities();

        public ActionResult Index()
        {
            var socialMediaList = db.TblSocialMedias.ToList();
            return View(socialMediaList);
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var deleteEntity = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(deleteEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedias tblSocialMedias)
        {
            db.TblSocialMedias.Add(tblSocialMedias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var entity = db.TblSocialMedias.Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedias tblSocialMedias)
        {
            var updateEntity = db.TblSocialMedias.Find(tblSocialMedias.SocialMediaID);

            updateEntity.SocialMediaName = tblSocialMedias.SocialMediaName;
            updateEntity.Icon=tblSocialMedias.Icon;
            updateEntity.LinkUrl= tblSocialMedias.LinkUrl;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}