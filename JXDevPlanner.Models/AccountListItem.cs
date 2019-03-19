using JXDevPlanner.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class AccountListItem
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public List<IdentityUserRole> Roles { get; set; }
        public string RolesString {
            get {
                var str = "";
                for (int i = 0; i < Roles.Count; i++) {
                    if (str != "") str += " ";
                    str += Roles[i].ToString();
                }
                return str;
            }
        }

        public AccountListItem(ApplicationUser user) {
            this.UserID = Guid.Parse(user.Id);
            this.UserName = user.UserName;
            this.Roles = new List<IdentityUserRole>();
            var rolz = user.Roles;
            foreach (IdentityUserRole k in rolz)
            {
                this.Roles.Add(k);
            }
        }
    }
}
