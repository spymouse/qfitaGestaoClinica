using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Data
{
    public class Convenio
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Telefone { get; set; }
    }
}
