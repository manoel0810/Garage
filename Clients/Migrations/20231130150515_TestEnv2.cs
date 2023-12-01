using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clients.Migrations
{
    /// <inheritdoc />
    public partial class TestEnv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Garagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarroMarca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarroModelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataHoraEntrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataHoraSaida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoTotal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passes");
        }
    }
}
