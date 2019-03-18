using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class ProjectCreate {
        [Required]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Desc { get; set; }

        public override string ToString() => Title;
    }
}
