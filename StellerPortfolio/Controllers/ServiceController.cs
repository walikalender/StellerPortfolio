using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();

        public ActionResult Index()
        {
            var serviceList = db.TblServices.ToList();
            return View(serviceList);
        }
        public ActionResult DeleteService(int id)
        {
            var deleteEntity = db.TblServices.Find(id);
            db.TblServices.Remove(deleteEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblServices tblServices)
        {
            db.TblServices.Add(tblServices);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var entity = db.TblServices.Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult UpdateService(TblServices tblServices)
        {
            var updateEntity = db.TblServices.Find(tblServices.ServiceID);

            updateEntity.ServiceName=tblServices.ServiceName;
            updateEntity.ServiceIconUrl=tblServices.ServiceIconUrl;
            updateEntity.ServiceStatus=tblServices.ServiceStatus;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}