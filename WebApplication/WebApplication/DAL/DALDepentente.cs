using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL.Interface;
using WebApplication.Models.Data;

namespace WebApplication.DAL
{
    public class DALDepentente: Interface.IDados<Models.Data.Dependente>
    {

        private readonly WebAppContextDB _context;

        public Models.Data.Dependente Dependente { get; set; }
        public DALDepentente(WebAppContextDB context)
        {
            this._context = context;
            this.Dependente = new Dependente();
        }

        public bool DependenteExists(int FuncionariosID)
        {
            return this._context.TBDependentes.Any(d => d.FuncionariosID == FuncionariosID);
        }

        public int Insert(Dependente entrada)
        {
            try
            {
                this._context.TBDependentes.Add(entrada);
                int n = this._context.TBDependentes.Count();
                this._context.SaveChanges();

                return this._context.TBDependentes.ToList()[n].ID;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public Dependente Updade(Dependente entrada)
        {
            try
            {
                this._context.TBDependentes.Update(entrada);
                this._context.SaveChanges();
                return entrada;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                var dependente = _context.TBDependentes.Find(id);
                this._context.TBDependentes.Remove(dependente);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Dependente> Consult(Dependente entrada)
        {
            List<Dependente> saida = new List<Dependente>(this._context.TBDependentes.Where(f => f.FuncionariosID == entrada.FuncionariosID));
            return saida;
        }

        public List<Models.Data.Dependente> GetAll()
        {
            return  this._context.TBDependentes.ToList();
        }

        public Models.Data.Dependente FindByID(int id)
        {
            return this._context.TBDependentes.Find(id);
        }
    }
}
