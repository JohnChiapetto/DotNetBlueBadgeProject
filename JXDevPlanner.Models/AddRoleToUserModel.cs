using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class AddRoleToUserModel
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }

        public AddRoleToUserModel(Guid user) { this.UserID = user; }
    }
}
