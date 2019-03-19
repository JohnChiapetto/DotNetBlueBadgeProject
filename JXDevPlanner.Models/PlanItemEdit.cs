using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PlanItemEdit
    {
        public Guid ProjectID { get; set; }
        public Guid PlanID { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        public PlanItemEdit() { }
        public PlanItemEdit(PlanItem item) {
            this.ProjectID = item.ProjectID;
            this.PlanID = item.PlanItemID;
            this.Detail = item.Details;
            this.Name = item.Name;
        }
    }
}
