using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class ProjectListItem
    {
        public Guid ProjectID { get; set; }
        public string Title { get; set; }
        [Display(Name="Description")]
        public string Desc { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
