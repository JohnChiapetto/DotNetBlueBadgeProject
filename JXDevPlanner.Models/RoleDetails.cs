using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class RoleDetails
    {
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public UserRoleListItem[] Users { get; set; }
    }
}
