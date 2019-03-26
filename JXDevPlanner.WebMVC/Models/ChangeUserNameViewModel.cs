using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JXDevPlanner.WebMVC.Models
{
    public class ChangeUserNameViewModel
    {
        public Guid UserID { get; set; }
        public string NewUsername { get; set; }
    }
}