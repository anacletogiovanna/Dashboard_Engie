using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using engie_dashboard.Models;
using Newtonsoft.Json;

namespace engie_dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ModelContext _context;

        public HomeController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var solicitacoes = _context.Solicitacao.ToList().Where(x => x.Data >= DateTime.Now.Date.AddDays(-1));
            var countSolicitado = solicitacoes.Count(x => x.StatusSolicitacao.Equals(StatusSolicitacaoEnum.Solicitado));
            var graphJson = JsonConvert.SerializeObject(solicitacoes);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
