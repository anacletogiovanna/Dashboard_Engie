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
        public async Task<IActionResult> Index()
        {
            var solicitacoes = _context.Solicitacao.Where(x => x.Data >= DateTime.Now.Date.AddDays(-1)).ToListAsync();
            return View(await solicitacoes);
        }

        // GET: Solicitacaos
        public IActionResult Dashboard()
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

        // GET: Solicitacaos/Details/5
        public async Task<IActionResult> Details(string id)
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

        // GET: Solicitacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoSolicitacao,Usina,UG,HoraSolicitacao,Valor,UnidadeMedida,OperadorId,VerificadorId,EncaminhadoId,StatusSolicitacao,EstadoOperacional")] Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitacao);
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
