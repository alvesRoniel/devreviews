using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevReviews.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PRODUCTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    REGISTERED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT_REVIEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AUTHOR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RATING = table.Column<int>(type: "int", nullable: false),
                    COMMENTS = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    REGISTERED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT_REVIEW", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PRODUCT_REVIEW_TB_PRODUCTS_Productid",
                        column: x => x.Productid,
                        principalTable: "TB_PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUCT_REVIEW_Productid",
                table: "TB_PRODUCT_REVIEW",
                column: "Productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PRODUCT_REVIEW");

            migrationBuilder.DropTable(
                name: "TB_PRODUCTS");
        }
    }
}
