using JXDevPlanner.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Threading.Tasks;
using System.Web;

namespace JXDevPlanner.Models
{
    public class AccountListItem
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string[] Roles { get; set; }
        public string RolesString {
            get {
                if (Roles == null) return "";
                var str = "";
                for (int i = 0; i < Roles.Length; i++)
                {
                    if (str != "") str += " ";
                    str += Roles[i];
                }
                return str;
            }
        }

        public AccountListItem(ApplicationUser user) {
            this.UserID = Guid.Parse(user.Id);
            this.UserName = user.UserName;
        }
    }
}
