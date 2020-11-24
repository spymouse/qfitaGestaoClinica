using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Data
{
    public class WebAppContextDB : DbContext
    {
        public DbSet<Data.Funcionario> TBFuncionarios { get; set; }

        public DbSet<Data.Dependente> TBDependentes { get; set; }


        public WebAppContextDB(DbContextOptions<WebAppContextDB> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data.Funcionario>().ToTable("Funcionario");
            modelBuilder.Entity<Data.Dependente>().ToTable("Dependente");
        }
    }
}
