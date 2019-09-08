using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sheet2.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(float value, float rate, float years)
        {
            //I wanted to add some data validation here and throw the ERRORs into ViewData["Error"] and display it in the view but I couldn't find how to do it.
            if (!float.TryParse(value.ToString(), out float goodValue) || goodValue >= 0) { ViewData["ValueError"] = "Invalid Value"; return View(); } else { ViewData["Value"] = goodValue; }
            if (!float.TryParse(rate.ToString(), out float goodRate) || goodRate >= 0) { ViewData["RateError"] = "Invalid Rate"; return View(); } else { ViewData["Rate"] = goodRate; }
            if (!float.TryParse(years.ToString(), out float goodYears) || goodYears >= 0) { ViewData["YearsError"] = "Invalid Years"; return View(); } else { ViewData["Years"] = goodYears; }

            ViewData["SimpleAmount"] = value + ((value * rate * years) / 100);
            ViewData["CompoundAmount"] = value * Math.Pow(1 + (rate / 100), years);

            return View();
            
        }
    }
}