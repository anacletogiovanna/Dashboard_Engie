using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using engie_dashboard.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace engie_dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ModelContext _context;

        public HomeController(ModelContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {

            var solicitacoes = _context.Solicitacao.ToList();
            foreach (var item in solicitacoes)
            {
                item.Solicitante = _context.Usuario.Find(item.SolicitanteId);
                if (!string.IsNullOrEmpty(item.OperadorId))
                    item.Operador = _context.Usuario.Find(item.OperadorId);
                if (!string.IsNullOrEmpty(item.EncaminhadoId))
                    item.Encaminhado = _context.Usuario.Find(item.EncaminhadoId);
            }
            //var graphJson = JsonConvert.SerializeObject(solicitacoes);

            //var pieChart = GraphStatusSolicitacao(solicitacoes);

            return View(solicitacoes);
        }

        public JsonResult GraphTypes()
        {


            //var solicitacoes = _context.Solicitacao.ToList().Where(x => x.HoraSolicitacao >= DateTime.Now.Date.AddDays(-1));

            var solicitacoes = _context.Solicitacao.ToList().Where(x => x.Data >= DateTime.Now.Date.AddDays(-1));
            var countSolicitado = solicitacoes.Count(x => x.StatusSolicitacao.Equals(StatusSolicitacaoEnum.Solicitado));

            //var graphJson = JsonConvert.SerializeObject(solicitacoes);

            var pieChart = GraphStatusSolicitacao(solicitacoes);

            return Json(pieChart);
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

        private List<Array> GraphStatusSolicitacao(IEnumerable<Solicitacao> solicitacoes)
        {
            List<Array> data = new List<Array>();

            Array countConfirmado = new object[] { "Confirmado", solicitacoes.Count(x => x.StatusSolicitacao.Equals(StatusSolicitacaoEnum.Confirmado)) };
            data.Add(countConfirmado);
            Array countEncaminhado = new object[] { "Encaminhado", solicitacoes.Count(x => x.StatusSolicitacao.Equals(StatusSolicitacaoEnum.Encaminhado)) };
            data.Add(countEncaminhado);
            Array countExecutado = new object[] { "Executado", solicitacoes.Count(x => x.StatusSolicitacao.Equals(StatusSolicitacaoEnum.Executado)) };
            data.Add(countExecutado);
            Array countRejeitado = new object[] { "Rejeitado", solicitacoes.Count(x => x.StatusSolicitacao.Equals(StatusSolicitacaoEnum.Rejeitado)) };
            data.Add(countRejeitado);
            Array countSolicitado = new object[] { "Solicitado", solicitacoes.Count(x => x.StatusSolicitacao.Equals(StatusSolicitacaoEnum.Solicitado)) };
            data.Add(countSolicitado);

            //var PieChart = JsonConvert.SerializeObject(data);
            return data;
        }


    }

}
