using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class MessageController : Controller
    {
        private readonly StellerAcunMedyaDbEntities db = new StellerAcunMedyaDbEntities();
        public ActionResult Index()
        {
            var result = db.TblMessage.Where(m=>m.IsRead==false).ToList();
            return View(result);
        }
        public ActionResult DeleteMessage(int id)
        {
            var result = db.TblMessage.Find(id);
            db.TblMessage.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MessageDetail(int id)
        {
            var message = db.TblMessage.Find(id);
            message.IsRead = true;
            db.SaveChanges();
            return View(message);
        }
        public ActionResult ReadMessages()
        {
            var result = db.TblMessage.Where(m => m.IsRead==true).ToList();
            return View(result);
        }
    }
}