using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    codPagamento = table.Column<string>(nullable: false),
                    tipoDePagamento = table.Column<string>(nullable: true),
                    valor = table.Column<double>(nullable: false),
                    statusPagamento = table.Column<string>(nullable: true),
                    dataPagamento = table.Column<DateTime>(nullable: false),
                    rastreio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.codPagamento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");
        }
    }
}
