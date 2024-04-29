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
            var messageList = db.TblMessage.ToList();
            return View(messageList);
        }
        public ActionResult DeleteMessage(int id)
        {
            var entity = db.TblMessage.Find(id);
            db.TblMessage.Remove(entity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}