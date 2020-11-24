using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Data
{
    public class DbInitializer
    {
        public static void Initialize(WebAppContextDB context)
        {
            context.Database.EnsureCreated();

            var funcionario = new Models.Data.Funcionario[]
            {
               new Funcionario(){ Ativo = true, Cpf = 32216811866, DataDeNascimiento = DateTime.Now.Date, Endereco = "Rua 12345", Nome = "Eber", Sexo = 'M'}
            };

            foreach (Funcionario item in funcionario)
            {
                context.TBFuncionarios.Add(item);
            }

            context.SaveChanges();
        }
    }
}
