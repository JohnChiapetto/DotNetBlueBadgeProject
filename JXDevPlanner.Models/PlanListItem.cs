using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PlanListItem
    {
        public string Name { get; set; }
        public string CreatorName { get; set; }
        public Guid Creator { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }

        public PlanListItem(PlanItem item) {
            this.Name = item.Name;
            this.Creator = item.CreatorID;
            this.CreatedUTC = item.CreatedUTC;
        }
    }
}
