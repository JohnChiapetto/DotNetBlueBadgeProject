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

        public ActionResult Edit(Guid id)
        {
            var svc = CreateProjectService();

            var project = svc.GetProject(id);
            var model = new ProjectEdit(project);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectEdit model) {
            if (!ModelState.IsValid) return View(model);

            var svc = CreateProjectService();

            if (svc.EditProject(model)) {
                TempData["SaveResult"] = "Your Project was updated.";
                return RedirectToAction("Index");
            }

            return View(model);
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreatePlanItem(Guid projectID) {
            return RedirectToAction("Create","PlanItem",new { projectID = projectID,b = true });
        }

        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }

        public ActionResult AddPlanItem(Guid projectID,string name,string detail,int category) {
            var pic = new PlanItemCreate(projectID);
            pic.Name = name;
            pic.Detail = detail;
            pic.Category = category;
            return RedirectToAction("Create","PlanItem",new { model = pic });
        }

        public ActionResult Details(Guid id) {
            var service = CreateProjectService();
            var model = service.GetProjectById(id);
            var svc2 = new PlanItemService(Guid.Parse(User.Identity.GetUserId()));
            model.PlanItems = svc2.GetPlanListItems(model.ProjectID);
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
                    TempData["deleteStatus"] = "Your Project was deleted.";
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