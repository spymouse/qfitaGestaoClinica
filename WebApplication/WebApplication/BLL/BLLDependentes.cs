using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;
using WebApplication.Models.Data;

namespace WebApplication.BLL
{
    public class BLLDependentes
    {
        private readonly WebAppContextDB _context;        
        private DAL.DALDepentente DALDepentente { get; set; }


        public BLLDependentes(WebAppContextDB context)
        {
            this._context = context;
            this.DALDepentente = new DALDepentente(context);
        }


        public bool DependenteExists(int funcionarioID)
        {
            return this.DALDepentente.DependenteExists(funcionarioID);
        }

        public List<Models.Dependente> GetDependenteByIDFuncionario(int funcionarioID)
        {
            var resultado = this.DALDepentente.Consult(new Dependente() { FuncionariosID = funcionarioID });
            List<Models.Dependente> saida = new List<Models.Dependente>();
            foreach (var item in resultado)
            {
                saida.Add(new Models.Dependente()
                {
                    FuncionariosID = item.FuncionariosID,
                    Cpf = item.Cpf,
                    DataDeNascimiento = item.DataDeNascimiento,
                    ID = item.ID,
                    Nome = item.Nome,
                    Sexo = item.Sexo.Equals('M') ? "Masculinho" : "Feminino"
                }); 
            }

            return saida;

        }

        internal Models.Dependente FindByID(int id)
        {
            var resultado = this.DALDepentente.FindByID(id);
            return new Models.Dependente()
            {
                Cpf = resultado.Cpf,
                DataDeNascimiento = resultado.DataDeNascimiento,
                FuncionariosID = resultado.FuncionariosID,
                ID = resultado.ID,
                Nome = resultado.Nome,
                Sexo = resultado.Sexo == 'M' ? "Masculino" : "Feminino",
                Status = new Models.Status() { Mensagem = "Sucesso" }
            };
        }

        internal bool Update(Dependente dependente)
        {
            var resultado = this.DALDepentente.FindByID(dependente.ID);
            if(resultado != null)
            {
                this.DALDepentente.Updade(new Dependente()
                {
                    Cpf = dependente.Cpf,
                    DataDeNascimiento = dependente.DataDeNascimiento,
                    FuncionariosID = dependente.FuncionariosID,
                    ID = dependente.ID,
                    Nome = dependente.Nome,
                    Sexo = dependente.Sexo
                });

                return true;
            }

            return false;
        }

        internal Models.Dependente Delete(int id)
        {
            Models.Dependente resultado = this.FindByID(id);
            if (this.DALDepentente.Delete(id))
            {                
                return resultado;
            }
            return null;
        }

        public List<Models.Dependente> GetAll()
        {
            List<Models.Dependente> saida = new List<Models.Dependente>();
            var resultado = this.DALDepentente.GetAll();
            foreach (var item in resultado)
            {
                saida.Add(new Models.Dependente()
                {
                    Cpf = item.Cpf,
                    DataDeNascimiento = item.DataDeNascimiento.Date,
                    FuncionariosID = item.FuncionariosID,
                    Nome = item.Nome,
                    ID = item.ID,
                    Sexo = item.Sexo.Equals('M') ? "Masculino" : "Feminino"

                });

            }

            return saida;
        }

        public Models.Dependente Create(Models.Dependente entrada)
        {
            var saida = new Models.Dependente();
            if (ValidarDados(entrada))
            {
                try
                {
                    DALDepentente.Insert(new Dependente()
                    {
                        Cpf = entrada.Cpf,
                        DataDeNascimiento = entrada.DataDeNascimiento.Date,
                        FuncionariosID = entrada.FuncionariosID,
                        Nome = entrada.Nome,
                        Sexo = entrada.Sexo[0]
                         
                    });

                    saida = new Models.Dependente()
                    {
                        Status = new Models.Status()
                        {
                            CodigoError = 0,
                            ID = 0,
                            Mensagem = "Sucesso"
                        }
                    };

                    return saida;
                   
                }
                catch(Exception ex)
                {
                     saida = new Models.Dependente()
                    {
                        Status = new Models.Status()
                        {
                            CodigoError = 0,
                            ID = 0,
                            Mensagem = "Error",
                            LogMensagem = ex.Message
                        }
                    };

                    return saida;
                }                
            }

            return saida;
 
        }
        
        private bool ValidarDados(Models.Dependente dependente)
        {
            //TODO: VALIDAR DADOS DE ENTRADA
            return true;
        }
    }
}
