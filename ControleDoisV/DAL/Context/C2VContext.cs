using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
namespace DAL.Context
{
    public class C2VContext : DbContext
    {
        public DbSet<Bem> Bens { get; set; }
        public DbSet<GrupoBem> GrupoBens { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<OperacaoBem> OperacaoBens { get; set; }

        public C2VContext(DbContextOptions<C2VContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BemOperacaoBem>()
                .HasKey(bo => new { bo.BemID, bo.OperacaoBemID });
            modelBuilder.Entity<BemOperacaoBem>()
                .HasOne(x => x.Bem)
                .WithMany(x => x.Operacoes)
                .HasForeignKey(x => x.BemID);

            modelBuilder.Entity<BemOperacaoBem>()
                .HasOne(b => b.OperacaoBem)
                .WithMany(b => b.Bens)
               .HasForeignKey(b => b.OperacaoBemID);

        }
    }
}
