using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SW_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private meuContexto db = new meuContexto();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Produtoes.ToList());
        }
    }
}