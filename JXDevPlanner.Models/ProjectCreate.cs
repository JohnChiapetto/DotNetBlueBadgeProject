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
        public string Title;
        public string Desc;

        public override string ToString() => Title;
    }
}
