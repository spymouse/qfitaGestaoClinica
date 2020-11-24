using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Data
{
    public class Dependente
    {
        [Key]
        public int ID { get; set; }
        public int FuncionariosID { get; set; }

        [Column(TypeName = "varchar(11)")]
        public long Cpf { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Nome { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataDeNascimiento { get; set; }

        [Column(TypeName = "varchar(20)")]
        public char Sexo { get; set; }
    }
}
