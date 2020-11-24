using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Funcionario 
    {
        public int ID { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Digite um CPF Válido.")]
        [RegularExpression(@"^-?[0-9][0-9,\.]+$", ErrorMessage = "Digite um CPF Válido.")]
        public long Cpf { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data De Nascimiento")]
        [Required(ErrorMessage = "Data de Nascimento é obrigado.")]
        public DateTime? DataDeNascimiento { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Display(Name = "Endereco")]
        public string Endereco { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        public List<Dependente> LstDependentes { get; set; }
    }
}
