using JXDevPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXDevPlanner.WebMVC.Controllers
{
    public class ProjectController : Controller
    {

        public ActionResult Index()
        {
            var model = new ProjectListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}