using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class ProjectDelete
    {
        public string Title { get; set; }
        public Guid Owner { get; set; }
        public Guid ProjectID { get; set; }
        public String OwnerName { get; set; }

        public ProjectDelete(Project p) {
            this.Title = p.Title;
            this.Owner = p.Creator;
            this.ProjectID = p.ProjectID;
        }
    }
}
