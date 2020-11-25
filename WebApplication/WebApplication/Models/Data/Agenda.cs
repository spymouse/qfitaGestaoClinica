using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Data
{
    public class Agenda
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "int")]
        public int ClienteID { get; set; }

        [Column(TypeName = "int")]
        public int ConvenioID { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DataHoraConsulta { get; set; }

        [Column(TypeName = "varchar(5)")]
        public bool Retorno { get; set; }
    }
}
