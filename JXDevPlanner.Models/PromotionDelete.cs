using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PromotionDelete
    {
        public Guid PromotionId { get; set; }
        public string OldRankName { get; set; }
        public string NewRankName { get; set; }
        public DateTimeOffset ImplementedUtc { get; set; }

        public PromotionDelete() { }
        public PromotionDelete(Guid id) : this() { this.PromotionId = id; }
        public PromotionDelete(PlanItemPromotion promotion) : this(promotion.PromotionId)
        {
            this.OldRankName = PlanItem.CategoryStr(promotion.OldCategory);
            this.NewRankName = PlanItem.CategoryStr(promotion.NewCategory);
            this.ImplementedUtc = promotion.DateImplemented;
        }
    }
}
