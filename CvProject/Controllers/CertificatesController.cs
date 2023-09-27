using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class CertificatesController : Controller
    {
        // GET: Certificates
        public ActionResult Index()
        {
            return View();
        }
    }
}