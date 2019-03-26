using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class PlanItemDetails
    {
        
        public Guid PlanItemID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Category { get; set; }
        public Guid ProjectID { get; set; }
        public Guid CreatorID { get; set; }

        [Display(Name="Created By")]
        public string CreatorName { get; set; }

        [Display(Name="Project")]
        public string ProjectName { get; set; }

        [Display(Name = "Last Modified By")]
        public string LastModifierName { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; } = null;

        public PlanItemDetails(PlanItem item) {
            this.PlanItemID     = item.PlanItemID;
            this.Name           = item.Name;
            this.Details        = item.Details;
            this.Category       = $"{item.CategoryString}";
            this.ProjectID      = Guid.Parse(item.ProjectID.ToString());
            this.CreatorID      = item.CreatorID;
            this.LastModifiedBy = item.LastModifiedBy;
            this.CreatedUTC     = item.CreatedUTC;
            this.ModifiedUTC    = item.ModifiedUTC;
        }
    }
}
