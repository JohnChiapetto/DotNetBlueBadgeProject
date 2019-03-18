using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class ProjectEdit
    {
        public Guid ProjectID { get; set; }
        public Guid Creator { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

        public ProjectEdit() { }
        public ProjectEdit(Project project) {
            this.ProjectID = project.ProjectID;
            this.Creator = project.Creator;
            this.Title = project.Title;
            this.Desc = project.Desc;
        }
    }
}
