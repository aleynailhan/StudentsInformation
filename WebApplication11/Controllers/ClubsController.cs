using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models.EntityFramework;
namespace WebApplication11.Controllers
{
    public class ClubsController : Controller
    {
        // GET: Clubs
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        public ActionResult Index()
        {
            var clubs = db.tbl_clubs.ToList();
            return View(clubs);
        }
        [HttpGet]
        public ActionResult NewClub()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewClub(tbl_clubs p)
        {
            db.tbl_clubs.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult RemoveClub(int id)
        {
            var clb = db.tbl_clubs.Find(id);
            db.tbl_clubs.Remove(clb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringClub(int id)
        {
            var clb = db.tbl_clubs.Find(id);
            return View("BringClub",clb);
        }
        public ActionResult Update(tbl_clubs t)
        {
            var clb = db.tbl_clubs.Find(t.CLUBID);
            clb.CLUBNAME = t.CLUBNAME;
            db.SaveChanges();
            return RedirectToAction("Index", "Clubs");
        }
    }
}