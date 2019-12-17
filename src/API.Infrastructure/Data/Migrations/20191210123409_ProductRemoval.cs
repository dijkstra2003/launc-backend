using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Infrastructure.Data.Migrations
{
    public partial class ProductRemoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductGoal");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "UserProduct");

            migrationBuilder.DropTable(
                name: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ProductDescription = table.Column<string>(type: "text", nullable: true),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGoal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    GoalFk = table.Column<int>(type: "integer", nullable: true),
                    GoalFkNavigationId = table.Column<int>(type: "integer", nullable: true),
                    ProductFk = table.Column<int>(type: "integer", nullable: true),
                    ProductFkNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGoal_Goal_GoalFkNavigationId",
                        column: x => x.GoalFkNavigationId,
                        principalTable: "Goal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductGoal_Product_ProductFkNavigationId",
                        column: x => x.ProductFkNavigationId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ProductFk = table.Column<int>(type: "integer", nullable: true),
                    ProductFkNavigationId = table.Column<int>(type: "integer", nullable: true),
                    ProductTypeFk = table.Column<int>(type: "integer", nullable: true),
                    ProductTypeFkNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductType_Product_ProductFkNavigationId",
                        column: x => x.ProductFkNavigationId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductType_ProductType_ProductTypeFkNavigationId",
                        column: x => x.ProductTypeFkNavigationId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ProductFk = table.Column<int>(type: "integer", nullable: true),
                    ProductFkNavigationId = table.Column<int>(type: "integer", nullable: true),
                    UserFk = table.Column<int>(type: "integer", nullable: true),
                    UserFkNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProduct_Product_ProductFkNavigationId",
                        column: x => x.ProductFkNavigationId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProduct_Users_UserFkNavigationId",
                        column: x => x.UserFkNavigationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGoal_GoalFkNavigationId",
                table: "ProductGoal",
                column: "GoalFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGoal_ProductFkNavigationId",
                table: "ProductGoal",
                column: "ProductFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ProductFkNavigationId",
                table: "ProductType",
                column: "ProductFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ProductTypeFkNavigationId",
                table: "ProductType",
                column: "ProductTypeFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProduct_ProductFkNavigationId",
                table: "UserProduct",
                column: "ProductFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProduct_UserFkNavigationId",
                table: "UserProduct",
                column: "UserFkNavigationId");
        }
    }
}
