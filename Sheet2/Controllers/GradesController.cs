using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sheet2.Controllers
{
    public class GradesController : Controller
    {
        // GET: Grades
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            float gradesAccumulator = 0;
            for (int i = 0; i < form.Count; i++)
            {
                if (float.TryParse(form[i], out float grade) && grade >= 0 && grade <= 100) gradesAccumulator += grade;
                else { ViewData["Grade Error"] = " One of these grades is invalid, must be a number between 0 and 100."; return View(); }
            }
            float ngrade = gradesAccumulator / form.Count;
            ViewData["NGrade"] = ngrade;

            if (ngrade >= 0.0 && ngrade < 60) ViewData["CGrade"] = "F";
            else if (ngrade >= 60.0 && ngrade < 70.0) ViewData["CGrade"] = "D";
            else if (ngrade >= 70.0 && ngrade < 80.0) ViewData["CGrade"] = "C";
            else if (ngrade >= 80.0 && ngrade < 90.0) ViewData["CGrade"] = "B";
            else if (ngrade >= 90.0 && ngrade <= 100.0) ViewData["CGrade"] = "A";
            return View();
        }
    }
}