using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class BaseModel
    {        
        public Status Status {get; set; }
    }
    
    public class Status
    {
        [Key]
        public int ID { get; set; }
        public int CodigoError { get; set; }
        public string Mensagem { get; set; }

        public string LogMensagem { get; set; }
    }
}
