using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestJob.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clima",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperatura = table.Column<double>(type: "float", nullable: false),
                    UmidadeRelativa = table.Column<int>(type: "int", nullable: false),
                    SensacaoTermica = table.Column<double>(type: "float", nullable: false),
                    Precipitacao = table.Column<double>(type: "float", nullable: false),
                    CodigoClima = table.Column<int>(type: "int", nullable: false),
                    CoberturaNuvens = table.Column<int>(type: "int", nullable: false),
                    VelocidadeVento = table.Column<double>(type: "float", nullable: false),
                    DirecaoVento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clima", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clima");
        }
    }
}
