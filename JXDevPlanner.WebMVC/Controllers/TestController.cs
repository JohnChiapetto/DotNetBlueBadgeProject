using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXDevPlanner.WebMVC.Controllers
{
    public class E {
        public string EHoweijgweaojgaewoifjwea { get; set; }
    }

    public class TestController : Controller
    {

        // GET: Test
        //[HttpPost]
        public ActionResult Index(string s)
        {
            if (s == null) throw new Exception("S IS NULL");
            E e = new E();
            e.EHoweijgweaojgaewoifjwea = s;
            return View(s);
        }
    }
}