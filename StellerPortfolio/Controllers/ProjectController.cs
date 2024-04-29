using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly StellerAcunMedyaDbEntities db = new StellerAcunMedyaDbEntities();

        public ActionResult Index()
        {
            var aboutList = db.TblProject.ToList();
            return View(aboutList);
        }
        public ActionResult DeleteProject(int id)
        {
            var deleteEntity = db.TblProject.Find(id);
            db.TblProject.Remove(deleteEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(TblProject tblProject)
        {
            db.TblProject.Add(tblProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var entity = db.TblProject.Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject tblProject)
        {
            var updateEntity = db.TblProject.Find(tblProject.ProjectID);

            updateEntity.Title=tblProject.Title;
            updateEntity.ProjectName=tblProject.ProjectName;
            updateEntity.Description=tblProject.Description;
            updateEntity.ImageUrl=tblProject.ImageUrl;
            updateEntity.ProjectLinkUrl=tblProject.ProjectLinkUrl;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}