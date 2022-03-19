using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models.EntityFramework;

namespace WebApplication11.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.tbl_students.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult NewStudent()
        {
            List<SelectListItem> deger = (from i in db.tbl_clubs.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CLUBNAME,
                                              Value = i.CLUBID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;

            return View();
        }
        [HttpPost]
        public ActionResult NewStudent(tbl_students p)
        {
            var klp = db.tbl_clubs.Where(m => m.CLUBID == p.tbl_clubs.CLUBID).FirstOrDefault();
            p.tbl_clubs = klp;
            db.tbl_students.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult RemoveStudent(int id)
        {
            var st = db.tbl_students.Find(id);
            db.tbl_students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
     
        public ActionResult BringStudent2(int id)
        {
            var st = db.tbl_students.Find(id);

            return View("BringStudent2", st);
        }
        public ActionResult Update(tbl_students p)
        {
            var st = db.tbl_students.Find(p.STUDENTID);
            st.STUDENTNAME = p.STUDENTNAME;
            st.STUDENTPHOTO = p.STUDENTPHOTO;
            st.STUDENTSURNAME = p.STUDENTSURNAME;
            st.STUDENTGENDER = p.STUDENTGENDER;
            st.STUDENTCLUB = p.STUDENTCLUB;
            db.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}