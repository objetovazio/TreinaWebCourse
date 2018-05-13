using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreinaWeb.ProjetoTeste.Web.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            return View();
        }
    }
}