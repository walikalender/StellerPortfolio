using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class ContactController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
        public ActionResult Index()
        {
            var contactList = db.TblContact.ToList();
            return View(contactList);
        }
        public ActionResult DeleteContact(int id)
        {
            var deletedEntity = db.TblContact.Find(id);
            db.TblContact.Remove(deletedEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(TblContact tblContact)
        {
            db.TblContact.Add(tblContact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var entity = db.TblContact.Find(id);
            return View(entity); // View'e ilgili varlığı gönder
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact tblContact)
        {
            var updateAbout = db.TblContact.Find(tblContact.ContactID);

            updateAbout.Email=tblContact.Email;
            updateAbout.Phone = tblContact.Phone;
            updateAbout.Address=tblContact.Address;
            updateAbout.MapUrl=tblContact.MapUrl;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}