using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSale.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangingField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValueInStock",
                table: "Products",
                newName: "AmountInStock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountInStock",
                table: "Products",
                newName: "ValueInStock");
        }
    }
}
