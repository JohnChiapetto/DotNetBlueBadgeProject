using JXDevPlanner.Models;
using JXDevPlanner.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXDevPlanner.WebMVC.Controllers
{
    public class PlanItemController : Controller
    {

        // GET: PlanItem
        public ActionResult Index(Guid projectID)
        {
            PlanItemService svc = CreateService();
            return View(svc.GetPlanListItems(projectID));
        }

        private PlanItemService CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new PlanItemService(userId);
            return svc;
        }

        public ActionResult Create(Guid projectID) {
            var model = new PlanItemCreate(projectID);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateService();

            if (service.CreatePlanItem(model))
            {
                TempData["SaveResult"] = "Your PlanItem was created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}