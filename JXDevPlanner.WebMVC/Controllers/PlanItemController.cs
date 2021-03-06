﻿using JXDevPlanner.Data;
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
            //PlanItemService svc = CreateService();
            //return View(svc.GetPlanListItems(projectID));
            return RedirectToAction("Details","Project",new { id = projectID });
        }

        private PlanItemService CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new PlanItemService(userId);
            return svc;
        }

        public ActionResult Create(Guid projectID,bool b) {
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
                return RedirectToAction("Details","Project",new { id=model.ProjectID });
            }

            return View(model);
        }

        public ActionResult EditById(Guid id) {
            var svc = CreateService();
            var model = new PlanItemEdit(svc.GetPlanItemById(id));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PlanItemEdit model) {
            return Edit(model);
        }

        public ActionResult SaveEdits(string id,string name,string desc)
        {
            var model = new PlanItemEdit { PlanID = Guid.Parse(id),Name = name,Detail = desc };
            model.ProjectID = CreateService().GetProjectIdFor(model.PlanID);
            return Edit(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlanItemEdit model) {
            var svc = CreateService();

            if (svc.EditPlanItem(model))
            {
                TempData["SaveResult"] = "Your changes have been saved.";
                return RedirectToAction("Details","Project",new { id = model.ProjectID });
            }

            return View(model);
        }

        public ActionResult Delete(Guid id) {
            var svc = new PlanItemService(Guid.Parse(User.Identity.GetUserId()));
            return View(new PlanItemDelete(svc.GetPlanItemById(id)));
        }

        public ActionResult ConfirmedDelete(Guid id,bool confirmed) {
            var svc = CreateService();
            var pid = svc.DeletePlanItem(id);
            return RedirectToAction("Index",new { projectID = pid });
        }

        public ActionResult Details(Guid id) {
            var svc = CreateService();
            var item = svc.GetPlanItemById(id);
            var model = new PlanItemDetails(item);
            model.CreatorName = new ApplicationDbContext().Users.Where(e => e.Id == model.CreatorID.ToString()).Single().UserName;
            model.LastModifierName = new ApplicationDbContext().Users.Where(e => e.Id == model.LastModifiedBy.ToString()).Single().UserName;
            model.ProjectName = svc.GetProjectFor(id).Title;//AbstractService.Context.Projects.Where(e => e.ProjectID == model.ProjectID).Single().Title;
            return View(model);
        }
    }
}