using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Data;

namespace WebApplication.BLL
{
    public class BLLFuncionario
    {
        private DAL.DALFuncionario DALFuncionario { get; set; }
        public BLLDependentes BLLDependentes { get; private set; }

        public BLLFuncionario(WebAppContextDB context)
        {
            this.DALFuncionario = new DAL.DALFuncionario(context);
            this.BLLDependentes = new BLLDependentes(context);
        }


        public List<Models.Funcionario> GetFuncionarios()
        {

            var lstFuncionarios = this.DALFuncionario.GetAll();
            List<Models.Funcionario> saida = new List<Models.Funcionario>();
            foreach (var item in lstFuncionarios)
            {
                saida.Add(new Models.Funcionario()
                {
                    ID = item.ID,
                    Ativo = item.Ativo,
                    Cpf = item.Cpf,
                    DataDeNascimiento = item.DataDeNascimiento.Date,
                    Endereco = item.Endereco,
                    Nome = item.Nome,
                    Sexo = item.Sexo.ToString(),
                });
            }

            return saida;
        }

        public List<Models.Dependente> GetFuncionarioDependente(int funcionarioID)
        {
            if (this.BLLDependentes.DependenteExists(funcionarioID)) {
                List<Models.Dependente> saida = this.BLLDependentes.GetDependenteByIDFuncionario(funcionarioID);
                return saida;
            };

            return null;
        }

        public int Create(Models.Funcionario funcionario)
        {
            if (ValidarDados(funcionario))
            {
                return this.DALFuncionario.Insert(new Funcionario()
                {
                    Ativo = funcionario.Ativo,
                    Cpf = funcionario.Cpf,
                    DataDeNascimiento = funcionario.DataDeNascimiento.Value,
                    Endereco = funcionario.Endereco,
                    Nome = funcionario.Nome,
                    Sexo = funcionario.Sexo.ToString()[0]
                });
            }

            return -1;
        }

        public Models.Dependente CreateDependente(Models.Dependente dependente)
        {
            var saida = BLLDependentes.Create(dependente);
            if (saida.Status.Mensagem == "Sucesso") 
            {
                return saida;
            
            }

            return saida;
            
            
        }

        public  void Delete(int id)
        {
            try
            {
                this.DALFuncionario.Delete(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public Models.Funcionario GetFuncionarioByID(int id)
        {
            var resultado = this.DALFuncionario.GetAFuncionariosById(id);
            var saida = new Models.Funcionario()
            {
                Ativo = resultado.Ativo,
                Cpf = resultado.Cpf,
                DataDeNascimiento = resultado.DataDeNascimiento,
                Endereco = resultado.Endereco,
                ID = resultado.ID,
                Nome = resultado.Nome,
                Sexo = resultado.Sexo.Equals('M') ? "Masculinho" : "Feminino"

            };

            return saida;
        }

        public bool Updade(Models.Funcionario funcionario)
        {
            try
            {
                if (FuncionarioExists(funcionario.ID))
                {
                    this.DALFuncionario.Update(new Funcionario()
                    {
                        Ativo = funcionario.Ativo,
                        Cpf = funcionario.Cpf,
                        DataDeNascimiento = funcionario.DataDeNascimiento.Value,
                        Endereco = funcionario.Endereco,
                        Nome = funcionario.Nome,
                        Sexo = funcionario.Sexo[0],
                        ID = funcionario.ID
                    });

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private bool FuncionarioExists(int id)
        {
            return this.DALFuncionario.FuncionarioExists(id);
        }

        private bool ValidarDados(Models.Funcionario funcionario)
        {
            return true;
        }
    }
}
