using JXDevPlanner.Data;
using System;

namespace JXDevPlanner.Models
{
    public class UserRoleListItem
    {
        public Guid RoleID { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }

        public UserRoleListItem(UserRole role)
        {
            this.RoleID = role.RoleID;
            this.UserID = role.UserID;
        }
    }
}