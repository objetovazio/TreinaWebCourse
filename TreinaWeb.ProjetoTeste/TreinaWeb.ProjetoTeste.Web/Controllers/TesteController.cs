using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.ProjetoTeste.Web.Models;

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
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Exclude = "IsAtivo")]Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                return View("Saudacao", pessoa);
            }
            else
            {
                return View(pessoa);
            }
        }
    }
}