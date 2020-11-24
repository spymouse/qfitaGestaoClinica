using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models.Data;
using WebApplication.ViewModel;

namespace WebApplication.Controllers
{
    public class DependentesController : Controller
    {
        private readonly WebAppContextDB _context;
        DependenteVM DependenteVM { get; set; }
        public DependentesController(WebAppContextDB context)
        {
            _context = context;
            this.DependenteVM = new ViewModel.DependenteVM(context);
        }

        // GET: Dependentes
        public async Task<IActionResult> Index(int id)
        {
            var s = _context.TBDependentes.ToListAsync();
            return View(this.DependenteVM);
        }



        // GET: Dependentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Dependentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.TBDependentes.FindAsync(id);
            if (dependente == null)
            {
                return NotFound();
            }
            return View(dependente);
        }

        // POST: Dependentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FuncionariosID,Cpf,Nome,DataDeNascimiento,Sexo")] Dependente dependente)
        {
            if (id != dependente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                this.DependenteVM.Edit(dependente);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.DependenteVM.Delete(id.Value);

            if (this.DependenteVM.Dependente == null)
            {
                return NotFound();
            }

            return View(this.DependenteVM);
        }

        // POST: Dependentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            return RedirectToAction(nameof(Index));
        }


    }
}
