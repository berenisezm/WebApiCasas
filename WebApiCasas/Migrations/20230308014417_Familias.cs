using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCasas.Migrations
{
    /// <inheritdoc />
    public partial class Familias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num_integrantes = table.Column<int>(type: "int", nullable: false),
                    CasaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Familias_Casas_CasaId",
                        column: x => x.CasaId,
                        principalTable: "Casas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Familias_CasaId",
                table: "Familias",
                column: "CasaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Familias");
        }
    }
}
