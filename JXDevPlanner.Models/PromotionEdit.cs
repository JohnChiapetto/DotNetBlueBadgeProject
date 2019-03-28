using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PromotionEdit
    {
        public Guid PromotionId { get; set; }
        [Display(Name="Summary")]
        public string NewSummary { get; set; }
        [Display(Name="Details")]
        public string NewDetails { get; set; }

        public PromotionEdit() { }
        public PromotionEdit(Guid PromotionId) : this() { this.PromotionId = PromotionId; }
        public PromotionEdit(PlanItemPromotion promotion) : this(promotion.PromotionId)
        {
            this.NewSummary = promotion.Summary;
            this.NewDetails = promotion.Details;
        }
    }
}
