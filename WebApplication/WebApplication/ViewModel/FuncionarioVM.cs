using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Data;

namespace WebApplication.ViewModel
{
    public class FuncionarioVM : Base.ViewModelBase
    {
        #region PROPRIEDADES
        public Models.Funcionario Funcionario { get; set; }
        public Models.Dependente Dependente { get; set; }
        public List<Models.Funcionario> LstFuncionarios { get; set; }

        public List<Models.Dependente> LstDependentes { get; set; }
        private BLL.BLLFuncionario bLLFuncionario { get; set; }
        #endregion

        public FuncionarioVM(WebAppContextDB context) :base(context)
        {
            
            this.Funcionario = new Models.Funcionario();
            this.LstFuncionarios = new List<Models.Funcionario>();

            this.bLLFuncionario = new BLL.BLLFuncionario(context);
        }


        public void GetFuncionariosAll()
        {
            this.LstFuncionarios = this.bLLFuncionario.GetFuncionarios();
        }       

        public int Create(Models.Funcionario funcionario)
        {
            if (ValidarDados(funcionario))
            {
                return this.bLLFuncionario.Create(funcionario);
            }

            return -1;
        }

        public async void GetFuncionarioByID(int id)
        {
           this.Funcionario = this.bLLFuncionario.GetFuncionarioByID(id); 
        }

        private bool ValidarDados(Models.Funcionario funcionario)
        {
            return true;
        }

        public bool Update(Models.Funcionario funcionario)
        {
            return this.bLLFuncionario.Updade(funcionario);           
        }

        public void Delete(int id)
        {
            try
            {
                this.bLLFuncionario.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void GetDependente(int FuncionarioID)
        {
            this.Funcionario.LstDependentes = new List<Models.Dependente>();
            this.LstDependentes = this.bLLFuncionario.GetFuncionarioDependente(FuncionarioID);
        }

        /// <summary>
        /// Cadastrar Dependentes do Funcionario
        /// </summary>
        /// <param name="dependente"></param>
        public void CreateDependente(Models.Dependente dependente)
        {
            this.bLLFuncionario.CreateDependente(dependente);
        }
    }
}
