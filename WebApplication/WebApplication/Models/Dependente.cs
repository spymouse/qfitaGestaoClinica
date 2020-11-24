using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Dependente : BaseModel
    {
        public int ID { get; set; }
        public int FuncionariosID { get; set; }

        [Display(Name = "CPF")]
        public long Cpf { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data De Nascimiento")]
        public DateTime DataDeNascimiento { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

    }
}
