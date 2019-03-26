using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class RemoveRoleFromUserModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public RemoveRoleFromUserModel(Guid user)
        {
            this.UserId = user;
        }
    }
}
