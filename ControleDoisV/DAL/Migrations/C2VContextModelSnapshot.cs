﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(C2VContext))]
    partial class C2VContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Entities.Bem", b =>
                {
                    b.Property<long>("BemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<long>("GrupoBemID");

                    b.Property<string>("Observacao");

                    b.Property<int>("Status");

                    b.HasKey("BemID");

                    b.HasIndex("GrupoBemID");

                    b.ToTable("Bens");
                });

            modelBuilder.Entity("Dominio.Entities.GrupoBem", b =>
                {
                    b.Property<long>("GrupoBemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("GrupoBemID");

                    b.ToTable("GrupoBens");
                });

            modelBuilder.Entity("Dominio.Entities.OperacaoBem", b =>
                {
                    b.Property<long>("OperacaoBemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BemID");

                    b.Property<DateTime?>("Data");

                    b.Property<string>("Observacao");

                    b.Property<int>("Status");

                    b.Property<int>("TipoOperacaoBem");

                    b.Property<int?>("TomadorPessoaID");

                    b.HasKey("OperacaoBemID");

                    b.HasIndex("BemID");

                    b.HasIndex("TomadorPessoaID");

                    b.ToTable("OperacaoBens");
                });

            modelBuilder.Entity("Dominio.Entities.Pessoa", b =>
                {
                    b.Property<int>("PessoaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Observacao");

                    b.Property<int>("Status");

                    b.HasKey("PessoaID");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Dominio.Entities.Bem", b =>
                {
                    b.HasOne("Dominio.Entities.GrupoBem", "GrupoBem")
                        .WithMany()
                        .HasForeignKey("GrupoBemID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dominio.Entities.OperacaoBem", b =>
                {
                    b.HasOne("Dominio.Entities.Bem", "Bem")
                        .WithMany("Operacoes")
                        .HasForeignKey("BemID");

                    b.HasOne("Dominio.Entities.Pessoa", "Tomador")
                        .WithMany("OperacoesBens")
                        .HasForeignKey("TomadorPessoaID");
                });
#pragma warning restore 612, 618
        }
    }
}
