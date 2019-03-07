using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class Project
    {
        [Key]
        public Guid ProjectID { get; set; }
        public Guid Creator { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTimeOffset DateCreatedUTC { get; set; }
        public DateTimeOffset DateModifiedUTC { get; set; }

        class ProjectDbContext : <Project> {
        }
    }
}
