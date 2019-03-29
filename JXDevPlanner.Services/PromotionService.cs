using JXDevPlanner.Data;
using JXDevPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Services
{
    public static class ListExt {
        public static List<T> Sorted<T>(this List<T> l,IComparer<T> c)
        {
            l.Sort(c);
            return l;
        }
    }
    class PromotionDateComparer : IComparer<PlanItemPromotion>
    {
        public int Compare(PlanItemPromotion x,PlanItemPromotion y)
        {
            return x.DateImplemented > y.DateImplemented ? 1 : x.DateImplemented < y.DateImplemented ? -1 : 0 ;
        }
    }

    public class PromotionService : AbstractService
    {
        public PromotionService() : base() { }
        public PromotionService(Guid uid) : base(uid) { }

        public PlanItemPromotion GetById(Guid id) => Context.Promotions.Where(e => e.PromotionId == id).Single();
        public PlanItemPromotion[] GetByPlanId(Guid id) => Context.Promotions.Where(e => e.PlanId == id).ToList().Sorted(new PromotionDateComparer()).ToArray();
        public bool CreatePromotion(Guid planID,int to,string summary,string detail) => CreatePromotion(new PromotionCreate(planID,new PlanItemService(this._userId).GetPlanItemById(planID).Category,to,summary,detail));
        public bool CreatePromotion(PromotionCreate model)
        {
            var entity = new PlanItemPromotion
            {
                PromotionId     = Guid.NewGuid(),
                PlanId          = model.PlanId,
                Summary         = model.Summary,
                Details         = model.Detail,
                DateImplemented = DateTimeOffset.Now,
                OldCategory     = model.FromCategory,
                NewCategory     = model.ToCategory
            };

            Context.Promotions.Add(entity);
            var entx = Context.PlanItems.Where(e => e.PlanItemID == model.PlanId).Single();
            entx.Category = model.ToCategory;
            return Context.TrySave();
        }
        public void EditPromotion(PromotionEdit model)
        {
            var entity = GetById(model.PromotionId);
            entity.Summary = model.NewSummary;
            entity.Details = model.NewDetails;
        }
        public PromotionListItem[] GetPromotionListItems(Guid planID)
        {
            List<PromotionListItem> list = new List<PromotionListItem>();
            foreach (var entity in GetByPlanId(planID))
            {
                var item = new PromotionListItem(entity);
                item.ProjectName = GetProjectFor(item.PromotionId).Title;
                item.PlanItemName = GetPlanItemFor(item.PromotionId).Name;
                item.ProjectId = GetProjectFor(item.PromotionId).ProjectID;
                item.PlanItemCreated = GetPlanItemFor(item.PromotionId).CreatedUTC;
                list.Add(item);
            }
            return list.ToArray();
        }

        public Project GetProjectFor(Guid promotionId) => new PlanItemService(_userId).GetProjectFor(GetById(promotionId).PlanId);
        public PlanItem GetPlanItemFor(Guid promotionId) => new PlanItemService(_userId).GetPlanItemById(GetById(promotionId).PlanId);
    }
}
