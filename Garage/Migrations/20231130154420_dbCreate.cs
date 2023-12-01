using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysAPI.Migrations
{
    /// <inheritdoc />
    public partial class dbCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco_1aHora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco_HorasExtra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco_Mensalista = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Codigo);
                });

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

            migrationBuilder.CreateTable(
                name: "PaymentFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentFormats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "Passes");

            migrationBuilder.DropTable(
                name: "PaymentFormats");
        }
    }
}
