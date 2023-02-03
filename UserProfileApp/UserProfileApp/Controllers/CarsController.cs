using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserProfileApp.Controllers
{
    public class CarsController : Controller
    {
        // GET: CarsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
