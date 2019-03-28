using JXDevPlanner.Data;
using JXDevPlanner.Models;
using JXDevPlanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXDevPlanner.WebMVC.Controllers
{
    public class PromotionController : Controller
    {
        public PromotionService CreatePromotionService() => new PromotionService();

        // GET: Promotion
        public ActionResult Index(Guid planId)
        {
            var model = CreatePromotionService().GetPromotionListItems(planId).ToList().Sorted(new PromotionListItem.DateComparer());
            return View(model);
        }

        public ActionResult Create(Guid planItemId)
        {
            var model = new PromotionCreate(planItemId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PromotionCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var svc = CreatePromotionService();
            if (svc.CreatePromotion(model))
            {
                TempData["SaveResult"] = "Your PlanItem was promoted.";
                return RedirectToAction("Details","Project",new { id = new PlanItemService(Guid.Parse(UserHelper.GetUserId())).GetProjectIdFor(model.PlanId) });
            }
            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            var model = new PromotionDetails(CreatePromotionService().GetById(id));
            var svc = CreatePromotionService();
            model.ProjectId = svc.GetProjectFor(model.PromotionId).ProjectID;
            model.ProjectName = svc.GetProjectFor(model.PromotionId).Title;
            model.PlanItemName = svc.GetPlanItemFor(model.PromotionId).Name;
            model.OldRankName = PlanItem.CategoryStr(model.OldCategory);
            model.NewRankName = PlanItem.CategoryStr(model.NewCategory);
            return View(model);
        }
    }
}