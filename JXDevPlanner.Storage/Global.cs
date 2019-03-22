using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Storage
{
    public class GStorage
    {
        public static GSMap Data = new GSMap();

        public class GSMap : Dictionary<string,dynamic>
        {
            public new dynamic this[string key]
            {
                get { return base.ContainsKey(key) ? base[key] : Keys.Length > 0 ? base[Keys[0]] : null ; }
                set
                {
                    if (base.ContainsKey(key))
                        base[key] = value;
                    else
                        Add(key,value);
                }
            }
            public new string[] Keys
            {
                get
                {
                    List<string> strings = new List<string>();
                    foreach (string key in ((Dictionary<string,dynamic>)this).Keys) strings.Add(key);
                    return strings.ToArray();
                }
            }
        }
    }
}
