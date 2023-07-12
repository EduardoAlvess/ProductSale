using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSale.Migrations
{
    /// <inheritdoc />
    public partial class CreateIsDeletedColumnInProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Products",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Products");
        }
    }
}
