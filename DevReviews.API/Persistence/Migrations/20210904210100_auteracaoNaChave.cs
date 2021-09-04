using Microsoft.EntityFrameworkCore.Migrations;

namespace DevReviews.API.Migrations
{
    public partial class auteracaoNaChave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUCT_REVIEW_TB_PRODUCTS_Productid",
                table: "TB_PRODUCT_REVIEW");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "TB_PRODUCT_REVIEW",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_PRODUCT_REVIEW_Productid",
                table: "TB_PRODUCT_REVIEW",
                newName: "IX_TB_PRODUCT_REVIEW_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUCT_REVIEW_TB_PRODUCTS_ProductId",
                table: "TB_PRODUCT_REVIEW",
                column: "ProductId",
                principalTable: "TB_PRODUCTS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUCT_REVIEW_TB_PRODUCTS_ProductId",
                table: "TB_PRODUCT_REVIEW");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "TB_PRODUCT_REVIEW",
                newName: "Productid");

            migrationBuilder.RenameIndex(
                name: "IX_TB_PRODUCT_REVIEW_ProductId",
                table: "TB_PRODUCT_REVIEW",
                newName: "IX_TB_PRODUCT_REVIEW_Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUCT_REVIEW_TB_PRODUCTS_Productid",
                table: "TB_PRODUCT_REVIEW",
                column: "Productid",
                principalTable: "TB_PRODUCTS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
