using JXDevPlanner.Models;
using JXDevPlanner.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace JXDevPlanner.WebMVC.Controllers
{
    public class ProjectController : Controller
    {

        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            var model = service.GetProjects();

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
            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectService();

            if (service.CreateProject(model))
            {
                TempData["SaveResult"] = "Your Project was created.";
                //ViewBag.SaveResult = "Your Project was created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }

        public ActionResult Detail(Guid projectId) {
            var service = CreateProjectService();
            var model = service.GetProjectById(projectId);
            return View(model);
        }

    }
}