using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
namespace DAL.Context
{
    public class C2VContext:DbContext
    {
        public DbSet<Bem> Bens { get; set; }
        public DbSet<GrupoBem> GrupoBens { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<OperacaoBem> OperacaoBens { get; set; }

        public C2VContext(DbContextOptions<C2VContext> options):base(options)
        {

        }
    }
}
