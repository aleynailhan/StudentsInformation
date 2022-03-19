using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models.EntityFramework;

namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        public ActionResult Index()
        {
            var dersler = db.tbl_lessons.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult NewLesson()
        {

            return View();
        
        }
        [HttpPost]
        public ActionResult NewLesson(tbl_lessons p)
        {
            db.tbl_lessons.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult RemoveLesson(int id)
        {
            var ls = db.tbl_lessons.Find(id);
            db.tbl_lessons.Remove(ls);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringLesson(int id)
        {
            var ls = db.tbl_lessons.Find(id);

            return View("BringLesson",ls);
        }
        public ActionResult Update(tbl_lessons t)
        {
            var ls = db.tbl_lessons.Find(t.LESSONID);
            ls.LESSONNAME = t.LESSONNAME;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    
    }
}