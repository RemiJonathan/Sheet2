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
        public ActionResult Index(float value, float rate, Int32 years)
        {
            ViewData["Value"] = value;
            ViewData["Rate"] = rate;
            ViewData["Years"] = years;

            ViewData["SimpleAmount"] = (value * rate * years) / 100;
            ViewData["CompoundAmount"] = value * Math.Pow(1 + (rate / 100), years);

            return View();
            
        }
    }
}