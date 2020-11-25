using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models.Data;

namespace WebApplication.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly WebAppContextDB _context;
        public ViewModel.FuncionarioVM FuncionarioVM { get; set; }


        public FuncionariosController(WebAppContextDB context)
        {
            _context = context;
            this.FuncionarioVM = new ViewModel.FuncionarioVM(_context);
        }

        // GET: Funcionarios
        public IActionResult Index()
        {
            this.FuncionarioVM.GetFuncionariosAll();
            return View(this.FuncionarioVM);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.FuncionarioVM.GetFuncionarioByID(id.Value);
            this.FuncionarioVM.GetDependente(id.Value);

            return View(this.FuncionarioVM);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Cpf,Nome,DataDeNascimiento,Sexo,Endereco,Ativo")] Models.Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var funcionarioID = this.FuncionarioVM.Create(funcionario);
                return RedirectToRoute(new { controller = "Funcionarios", action = "Details", id = funcionarioID });
            }
            return View(this.FuncionarioVM);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            this.FuncionarioVM.GetFuncionarioByID(id.Value);
            return View(this.FuncionarioVM);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Cpf,Nome,DataDeNascimiento,Sexo,Endereco,Ativo")] Models.Funcionario funcionario)
        {
            if (id != funcionario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                this.FuncionarioVM.Update(funcionario);
                return RedirectToAction(nameof(Index));
            }
            return View(this.FuncionarioVM);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.FuncionarioVM.GetFuncionarioByID(id.Value);

            if (this.FuncionarioVM.Funcionario == null)
            {
                return NotFound();
            }

            return View(this.FuncionarioVM);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            this.FuncionarioVM.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.TBFuncionarios.Any(e => e.ID == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDependente([Bind("ID,FuncionariosID,Cpf,Nome,DataDeNascimiento,Sexo")] Models.Dependente dependente)
        {
            string campo = string.Empty;
            if (ModelState.IsValid)
            {
                this.FuncionarioVM.CreateDependente(dependente);
                return RedirectToRoute(new { controller = "Funcionarios", action = "Details", id = dependente.FuncionariosID });
            }
            else
            {
                if (ModelState.GetFieldValidationState("dependente.Cpf") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    campo += "CPF - ";
                }
                if (ModelState.GetFieldValidationState("dependente.Nome") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    campo += "Nome - ";
                }
                if (ModelState.GetFieldValidationState("dependente.DataDeNascimiento") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    campo += "Data De Nascimiento - ";
                }

                this.FuncionarioVM.GetFuncionarioByID(dependente.FuncionariosID);

                ViewBag.Message = $"Algo de Errado não está certo campo(s) '{campo.Substring(0, campo.Length - 2)}' :O, verifique as informações inserida no Formulario de Dependentes";
            }

            return View("Details", this.FuncionarioVM);
        }
    }
}
