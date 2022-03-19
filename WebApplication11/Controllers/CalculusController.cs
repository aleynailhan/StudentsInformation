using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication11.Controllers
{
    public class CalculusController : Controller
    {
        // GET: Calculus
        public ActionResult Index(int number1=0,int number2=0)
        {
            int result = number1 + number2;
            ViewBag.rslt = result;
            return View();
        }
    }
}