using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PlanItemDelete
    {
        public Guid ProjectId { get; set; }
        public Guid PlanItemId { get; set; }
        public string Name { get; set; }

        public PlanItemDelete() {
            var s = $"{this.PlanItemId}";
        }
        public PlanItemDelete(PlanItem item)
        {
            this.ProjectId = item.ProjectID;
            this.PlanItemId = Guid.Parse(item.PlanItemID.ToString());
            this.Name = item.Name;
        }
        public PlanItemDelete(PlanItemDelete model)
        {
            this.ProjectId = model.ProjectId;
            this.PlanItemId = model.ProjectId;
            this.Name = model.Name;
        }
    }
}
