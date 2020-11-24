using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.Data;

namespace WebApplication.DAL
{
    public class DALFuncionario
    {
        private readonly WebAppContextDB _context;
        
        public DALFuncionario(WebAppContextDB context)
        {
            _context = context;
        }

        /// <summary>
        /// Cadastrar Funcionarios
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public int Insert(Models.Data.Funcionario funcionario) 
        {
            try
            {
                _context.TBFuncionarios.Add(funcionario);
                int n = _context.TBFuncionarios.Count();                
                _context.SaveChanges();

                return _context.TBFuncionarios.ToList()[n].ID;
            }
            catch (Exception ex)
            {
                return -1;
                //throw new Exception(ex.Message);
            }
            
        }

        public Models.Data.Funcionario Update(Models.Data.Funcionario funcionario)
        {
            try
            {
                _context.Update(funcionario);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!FuncionarioExists(funcionario.ID))
                {
                    return null;
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        public bool FuncionarioExists(int id)
        {
            return _context.TBFuncionarios.Any(e => e.ID == id);
        }

        /// <summary>
        /// Deleta Funcionarios
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id) 
        {
            var funcionario = _context.TBFuncionarios.Find(id);
            _context.TBFuncionarios.Remove(funcionario);
            _context.SaveChanges();
            return true;

        }

        public Models.Data.Funcionario GetAFuncionariosById(int id)
        {
            return _context.TBFuncionarios.First(e => e.ID == id);
        }

        /// <summary>
        /// Retorna uma lista de funcionarios
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public List<Models.Funcionario> Consult(Models.Funcionario funcionario)
        {

            return new List<Models.Funcionario>();
        }

        /// <summary>
        /// Retorna todos os funcionarios
        /// </summary>
        /// <returns></returns>
        public List<Models.Data.Funcionario> GetAll()
        {
            return _context.TBFuncionarios.ToList();
        }

    }
}
