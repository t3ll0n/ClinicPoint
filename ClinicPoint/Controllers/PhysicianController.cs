using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicPoint.Controllers
{
    public class PhysicianController : Controller
    {
        // GET: Physician
        public ActionResult Index()
        {
            return View();
        }
    }
}