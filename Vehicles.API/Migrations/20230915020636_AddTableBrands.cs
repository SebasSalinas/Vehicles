using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicles.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTableBrands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Procedures",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Procedures", x => x.Id);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Description",
                table: "Brands",
                column: "Description",
                unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Procedures_Description",
            //    table: "Procedures",
            //    column: "Description",
            //    unique: true);
        }

        /// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "Brands");

        //    migrationBuilder.DropTable(
        //        name: "Procedures");

        //    migrationBuilder.CreateTable(
        //        name: "Prodedures",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Prodedures", x => x.Id);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Prodedures_Description",
        //        table: "Prodedures",
        //        column: "Description",
        //        unique: true);
        //}
    }
}
