using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PromotionCreate
    {
        public string Summary { get; set; }
        [Display(Name="Details")]
        public string Detail { get; set; }
        public Guid PlanId { get; set; }
        public int FromCategory { get; set; }
        [Display(Name = "Promote To")]
        public int ToCategory { get; set; }

        public PromotionCreate() { }
        public PromotionCreate(Guid pid) { this.PlanId = pid; }
        public PromotionCreate(Guid planID,int category,int to,string summary,string detail) : this(planID)
        {
            FromCategory = category;
            ToCategory = to;
            Summary = summary;
            Detail = detail;
        }
    }
}
