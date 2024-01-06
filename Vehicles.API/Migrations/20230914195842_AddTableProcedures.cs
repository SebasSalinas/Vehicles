using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicles.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTableProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prodedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodedures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prodedures_Description",
                table: "Prodedures",
                column: "Description",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prodedures");
        }
    }
}
