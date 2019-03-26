using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class RoleCreateAndAssignModel : RoleCreate
    {
        public Guid UserID { get; set; }

        public RoleCreateAndAssignModel() { }
        public RoleCreateAndAssignModel(Guid user) { this.UserID = user; }
    }
}
