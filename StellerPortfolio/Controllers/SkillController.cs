﻿using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class SkillController : Controller
    {
        private readonly StellerAcunMedyaDbEntities db = new StellerAcunMedyaDbEntities();

        public ActionResult Index()
        {
            var skillList = db.TblSkills.ToList();
            return View(skillList);
        }
        public ActionResult DeleteSkill(int id)
        {
            var deleteEntity = db.TblSkills.Find(id);
            db.TblSkills.Remove(deleteEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkills TblSkills)
        {
            db.TblSkills.Add(TblSkills);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var entity = db.TblSkills.Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult UpdateSkill(TblSkills TblSkills)
        {
            var updateEntity = db.TblSkills.Find(TblSkills.SkillID);

            updateEntity.SkillName= TblSkills.SkillName;
            updateEntity.Value= TblSkills.Value;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}