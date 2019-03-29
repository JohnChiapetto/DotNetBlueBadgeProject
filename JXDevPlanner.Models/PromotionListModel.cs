using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PromotionListModel : List<PromotionListItem>
    {
        public Guid PlanId { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public PromotionListModel(PlanItem item,PromotionListItem[] items)
        {
            PlanId = item.PlanItemID;
            DateCreated = item.CreatedUTC;
            foreach (var itemk in items) Add(itemk);
        }
    }
}
