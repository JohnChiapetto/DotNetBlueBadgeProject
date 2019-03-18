using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class ProjectDetail
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public Guid Creator { get; set; }
        public Guid ProjectID { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
        public string CreatorName { get; set; }
        public PlanItem[] PlanItems { get; set; }

        public ProjectDetail(Project p) {
            this.Title       = p.Title;
            this.ProjectID   = p.ProjectID;
            this.Desc        = p.Desc;
            this.Creator     = p.Creator;
            this.CreatedUTC  = p.CreatedUTC;
            this.ModifiedUTC = p.ModifiedUTC;
        }
    }
}
