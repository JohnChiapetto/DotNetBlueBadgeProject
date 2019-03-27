using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Storage
{
    public class TimeTool
    {
        public static string Date(DateTimeOffset offs) => offs.ToString("MM/dd/yyyy");
        public static string Date(DateTimeOffset? offs) => offs != null ? Date((DateTimeOffset)offs) : "N/A" ;
        public static string DateTime(DateTimeOffset offs) => offs.ToString("MM/dd/yyyy @hh:mmtt");
    }
}
