using JXDevPlanner.Data;
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

        public ActionResult Details(Guid id) {
            var service = CreateProjectService();
            var model = service.GetProjectById(id);
            return View(model);
        }

        public ActionResult Delete(Guid id,bool conf) {
            ProjectService svc = CreateProjectService();

            if (conf)
            {
                return View(svc.CreateProjectDeleteModel(id));
            }
            else
            {
                if (svc.DeleteProject(id))
                {
                    TempData["deleteStatus"] = "Your Project was Deleted Successfully!";
                }
                else
                {
                    TempData["deleteStatus"] = "There was a problem deleting your project.";
                }
                return RedirectToAction("Index");
            }
        }

    }
}