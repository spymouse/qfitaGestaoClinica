using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Data
{
    public class Cliente    
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(1)")]
        public string Sexo { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string RG { get; set; }

        [Column(TypeName = "varchar(11)")]
        public string CPF { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Endereco { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Bairro { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Cidade { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Estado { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string TelefoneCelular1 { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string TelefoneCelular2 { get; set; }
    }
}
