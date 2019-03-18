using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PlanItemCreate
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public Guid ProjectID { get; set; }

        public PlanItemCreate(Guid id) { this.ProjectID = id; }
    }
}
