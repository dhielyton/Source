using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupoBens",
                columns: table => new
                {
                    Status = table.Column<int>(nullable: false),
                    GrupoBemID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoBens", x => x.GrupoBemID);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Status = table.Column<int>(nullable: false),
                    PessoaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaID);
                });

            migrationBuilder.CreateTable(
                name: "Bens",
                columns: table => new
                {
                    Status = table.Column<int>(nullable: false),
                    BemID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    GrupoBemID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bens", x => x.BemID);
                    table.ForeignKey(
                        name: "FK_Bens_GrupoBens_GrupoBemID",
                        column: x => x.GrupoBemID,
                        principalTable: "GrupoBens",
                        principalColumn: "GrupoBemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperacaoBens",
                columns: table => new
                {
                    Status = table.Column<int>(nullable: false),
                    OperacaoBemID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoOperacaoBem = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: true),
                    BemID = table.Column<long>(nullable: true),
                    TomadorPessoaID = table.Column<int>(nullable: true),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacaoBens", x => x.OperacaoBemID);
                    table.ForeignKey(
                        name: "FK_OperacaoBens_Bens_BemID",
                        column: x => x.BemID,
                        principalTable: "Bens",
                        principalColumn: "BemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperacaoBens_Pessoas_TomadorPessoaID",
                        column: x => x.TomadorPessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bens_GrupoBemID",
                table: "Bens",
                column: "GrupoBemID");

            migrationBuilder.CreateIndex(
                name: "IX_OperacaoBens_BemID",
                table: "OperacaoBens",
                column: "BemID");

            migrationBuilder.CreateIndex(
                name: "IX_OperacaoBens_TomadorPessoaID",
                table: "OperacaoBens",
                column: "TomadorPessoaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperacaoBens");

            migrationBuilder.DropTable(
                name: "Bens");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "GrupoBens");
        }
    }
}
