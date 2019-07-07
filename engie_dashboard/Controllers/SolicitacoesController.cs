using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using engie_dashboard.Models;

namespace engie_dashboard.Controllers
{
    public class SolicitacoesController : Controller
    {
        private readonly ModelContext _context;

        public SolicitacoesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Solicitacaos
        public IActionResult Index()
        {
            var solicitacoes = _context.Solicitacao.Where(x => x.Data >= DateTime.Now.Date.AddDays(-1)).ToList();
            foreach (var item in solicitacoes)
            {
                item.Solicitante = _context.Usuario.Find(item.SolicitanteId);
                if (string.IsNullOrEmpty(item.OperadorId))
                    item.Operador = _context.Usuario.Find(item.OperadorId);
                if (string.IsNullOrEmpty(item.EncaminhadoId))
                    item.Encaminhado = _context.Usuario.Find(item.EncaminhadoId);
            }
            return View(solicitacoes);
        }

        // GET: Solicitacaos
        public IActionResult Dashboard()
        {
            var solicitacoes = _context.Solicitacao.Where(x => x.Data >= DateTime.Now.Date.AddDays(-1)).ToList();
            foreach (var item in solicitacoes)
            {
                item.Solicitante = _context.Usuario.Find(item.SolicitanteId);
                if (!string.IsNullOrEmpty(item.OperadorId))
                    item.Operador = _context.Usuario.Find(item.OperadorId);
                if (!string.IsNullOrEmpty(item.EncaminhadoId))
                    item.Encaminhado = _context.Usuario.Find(item.EncaminhadoId);
            }
            return View(solicitacoes);
        }

        // GET: Solicitacaos/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacao = _context.Solicitacao.FirstOrDefault(m => m.Id == id);
            if (solicitacao == null)
            {
                return NotFound();
            }
            solicitacao.Solicitante = _context.Usuario.Find(solicitacao.SolicitanteId);
            if (!string.IsNullOrEmpty(solicitacao.OperadorId))
                solicitacao.Operador = _context.Usuario.Find(solicitacao.OperadorId);
            if (!string.IsNullOrEmpty(solicitacao.EncaminhadoId))
                solicitacao.Encaminhado = _context.Usuario.Find(solicitacao.EncaminhadoId);

            return View(solicitacao);
        }

        // GET: Solicitacaos/Create
        public IActionResult Create()
        {
            var UsuarioLogado = User.Identity.Name.Split("@")[0];
            string idCl;
            if (UsuarioLogado.Equals("Pedro"))
                idCl = "AF5D235F-AA87-4550-9C50-1C1D714861F2";
            else
                idCl = "C004750C-B424-4CC3-80F6-34F3ED52860C";
            
            var teste = User.Identity.Name;
            //ViewBag.TipoSolicitacao = EnumHelper.ToList<TipoSolicitacaoEnum>().Select(x => new SelectListItem { Text = x.Value, Value = x.Key });
            //ViewBag.EstadoOperacional = EnumHelper.ToList<EstadoOperacionalEnum>().Select(x => new SelectListItem { Text = x.Value, Value = x.Key });
            //ViewBag.Usuarios = _context.Usuario.ToList().Where(x => !x.NomeCompleto.Contains(UsuarioLogado)).Select(x => new SelectListItem { Text = x.NomeCompleto + " ("+ x.Empresa +")", Value = x.Id }) ;
            //ViewBag.ComandoDePotencia = EnumHelper.ToList<ComandoDePotenciaEnum>().Select(x => new SelectListItem { Text = x.Value, Value = x.Key });
            //ViewBag.TipoDePotencia = EnumHelper.ToList<TipoDePotenciaEnum>().Select(x => new SelectListItem { Text = x.Value, Value = x.Key });

            return View();
        }

        // POST: Solicitacaos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                solicitacao.Id = Guid.NewGuid().ToString();
                solicitacao.Data = DateTime.Now;
                var UsuarioLogado = User.Identity.Name.Split("@")[0];
                if (UsuarioLogado.Equals("Pedro"))
                    solicitacao.SolicitanteId = "AF5D235F-AA87-4550-9C50-1C1D714861F2";
                else
                    solicitacao.SolicitanteId = "C004750C-B424-4CC3-80F6-34F3ED52860C";
                _context.Add(solicitacao);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // GET: Solicitacaos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacao = await _context.Solicitacao.FindAsync(id);
            if (solicitacao == null)
            {
                return NotFound();
            }
            return View(solicitacao);
        }

        // POST: Solicitacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,TipoSolicitacao,Usina,UG,HoraSolicitacao,Valor,UnidadeMedida,OperadorId,VerificadorId,EncaminhadoId,StatusSolicitacao,EstadoOperacional")] Solicitacao solicitacao)
        {
            if (id != solicitacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitacaoExists(solicitacao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(solicitacao);
        }

        // GET: Solicitacaos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacao = await _context.Solicitacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitacao == null)
            {
                return NotFound();
            }

            return View(solicitacao);
        }

        // POST: Solicitacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var solicitacao = await _context.Solicitacao.FindAsync(id);
            _context.Solicitacao.Remove(solicitacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitacaoExists(string id)
        {
            return _context.Solicitacao.Any(e => e.Id == id);
        }
    }
}
