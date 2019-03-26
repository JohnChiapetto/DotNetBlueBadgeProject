using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class RoleDelete
    {
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }

        public RoleDelete(IdentityRole role)
        {
            this.RoleID = Guid.Parse(role.Id);
            this.RoleName = role.Name;
        }
    }
}
