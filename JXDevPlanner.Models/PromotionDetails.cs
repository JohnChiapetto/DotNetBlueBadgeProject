using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PromotionDetails
    {
        public Guid PromotionId { get; set; }
        public Guid PlanId { get; set; }
        public Guid ProjectId { get; set; }
        public int OldCategory { get; set; }
        public int NewCategory { get; set; }
        public DateTimeOffset DateImplemented { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }
        public string OldRankName { get; set; }
        public string NewRankName { get; set; }
        public string PlanItemName { get; set; }
        public string ProjectName { get; set; }

        public PromotionDetails(PlanItemPromotion promo)
        {
            this.PromotionId = promo.PromotionId;
            this.PlanId = promo.PlanId;
            this.OldCategory = promo.OldCategory;
            this.NewCategory = promo.NewCategory;
            this.DateImplemented = promo.DateImplemented;
            this.Summary = promo.Summary;
            this.Details = promo.Details;
        }
    }
}
