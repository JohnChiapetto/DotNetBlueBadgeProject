using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Data
{
    public class PlanItemPromotion
    {
        public Guid PlanId { get; set; }
        public int OldCategory { get; set; }
        public int NewCategory { get; set; }
        public DateTimeOffset DateImplemented { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }
    }
}
