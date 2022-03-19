using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models.EntityFramework;
using WebApplication11.Models;
namespace WebApplication11.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        public ActionResult Index()
        {
            var note = db.tbl_notes.ToList();
            return View(note);
        }
        [HttpGet]
        public ActionResult NewNote()
        {
            return View();
        
        }
        [HttpPost]
        public ActionResult NewNote(tbl_notes p)
        {
            db.tbl_notes.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult  BringNote(int id)
        {
            var nt = db.tbl_notes.Find(id);
            return View("BringNote", nt);
        }
        [HttpPost]
        public ActionResult BringNote(Class1 model,tbl_notes p, int exam1=0, int exam2=0, int exam3=0, int project=0)
        {
            if(model.islem=="HESAPLA")
            {
                int ort = (exam1 + exam2 + exam3 + project) / 4;
                ViewBag.o = ort;
            }
            if(model.islem=="GUNCELLE")
            {
                var nt = db.tbl_notes.Find(p.NOTEID);
                nt.EXAM1 = p.EXAM1;
                nt.EXAM2 = p.EXAM2;
                nt.EXAM3 = p.EXAM3;
                nt.PROJECT = p.PROJECT;
                nt.AVERAGE = p.AVERAGE;
                db.SaveChanges();
                return RedirectToAction("Index", "Notes");

            }
            return View();
        }
        public ActionResult Remove(int id)
        {
            var nt = db.tbl_notes.Find(id);
            db.tbl_notes.Remove(nt);
            db.SaveChanges();
            return RedirectToAction("Index", "Notes");
        }
    }
}