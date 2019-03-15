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
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
        //public ICollection<PlanItem> Items;

        public ProjectDetail(Project p) {
            this.Title = p.Title;
            this.Desc = p.Desc;
            this.Creator = p.Creator;
            this.CreatedUTC = p.CreatedUTC;
            this.ModifiedUTC = p.ModifiedUTC;
        }
    }
}
