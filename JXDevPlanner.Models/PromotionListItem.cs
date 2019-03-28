using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PromotionListItem
    {
        public Guid PromotionId { get; set; }
        public string OldRankName { get; set; }
        public string NewRankName { get; set; }
        public DateTimeOffset DateImplemented { get; set; }
        public string ProjectName { get; set; }
        public string PlanItemName { get; set; }
        public string Summary { get; set; }
        public Guid ProjectId { get; set; }
        public Guid PlanId { get; set; }
        public DateTimeOffset PlanItemCreated { get; set; }

        public PromotionListItem(PlanItemPromotion promo)
        {
            this.PromotionId = promo.PromotionId;
            this.OldRankName = PlanItem.CategoryStr(promo.OldCategory);
            this.NewRankName = PlanItem.CategoryStr(promo.NewCategory);
            this.DateImplemented = promo.DateImplemented;
            this.Summary = promo.Summary;
            this.PlanId = promo.PlanId;
        }

        public class DateComparer : IComparer<PromotionListItem>
        {
            public bool Ascending { get; protected set; } = true;

            public DateComparer(bool a = true) { Ascending = a; }

            public int Compare(PromotionListItem x,PromotionListItem y)
            {
                bool xg = x.DateImplemented > y.DateImplemented;
                bool yg = y.DateImplemented > x.DateImplemented;
                return xg && Ascending || yg && !Ascending ? 1 : xg && !Ascending || yg && Ascending ? -1 : 0 ;
            }
        }
    }
}
