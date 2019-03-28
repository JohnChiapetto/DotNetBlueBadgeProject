using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Data
{
    public class PlanItemPromotion
    {
        [Key]
        public Guid PromotionId { get; set; }

        [Required]
        public Guid PlanId { get; set; }

        [Required]
        public int OldCategory { get; set; }

        [Required]
        public int NewCategory { get; set; }

        [Required]
        public DateTimeOffset DateImplemented { get; set; }

        [Required]
        public string Summary { get; set; }
        public string Details { get; set; }

        public override string ToString() => $"[{PlanId}] \"{Summary}\"";
    }
}
