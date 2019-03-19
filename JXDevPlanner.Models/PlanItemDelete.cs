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

        public PlanItemDelete(PlanItem item)
        {
            this.ProjectId = item.ProjectID;
            this.PlanItemId = item.PlanItemID;
            this.Name = item.Name;
        }
    }
}
