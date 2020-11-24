using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL;
using WebApplication.DAL;
using WebApplication.Models.Data;

namespace WebApplication.ViewModel
{
    public class DependenteVM : Base.ViewModelBase
    {
        public Models.Dependente Dependente {get;set;}
        public List<Models.Dependente> LstDependentes { get; set; }
        
        public BLLDependentes BLLDependentes { get;set; }

        public DependenteVM(WebAppContextDB context):base(context)
        {
            this.LstDependentes = new List<Models.Dependente>();
            this.Dependente = new Models.Dependente();
            this.BLLDependentes = new BLLDependentes(context);
        }


        public void GetAllDependentes()
        {
            this.LstDependentes = this.BLLDependentes.GetAll();  
        }
        

        public void Delete(int Id)
        {
            this.BLLDependentes.Delete(Id);
        }

        public void Edit(Dependente dependente)
        {
            this.BLLDependentes.Update(dependente);
        }
    }
}
