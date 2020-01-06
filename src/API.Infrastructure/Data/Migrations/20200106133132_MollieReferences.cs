using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Infrastructure.Data.Migrations
{
    public partial class MollieReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MolliePayment_MollieResponse_ResponseId",
                table: "MolliePayment");

            migrationBuilder.DropIndex(
                name: "IX_MolliePayment_ResponseId",
                table: "MolliePayment");

            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "MolliePayment");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "MollieResponse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MollieResponse_PaymentId",
                table: "MollieResponse",
                column: "PaymentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MollieResponse_MolliePayment_PaymentId",
                table: "MollieResponse",
                column: "PaymentId",
                principalTable: "MolliePayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MollieResponse_MolliePayment_PaymentId",
                table: "MollieResponse");

            migrationBuilder.DropIndex(
                name: "IX_MollieResponse_PaymentId",
                table: "MollieResponse");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "MollieResponse");

            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "MolliePayment",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MolliePayment_ResponseId",
                table: "MolliePayment",
                column: "ResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_MolliePayment_MollieResponse_ResponseId",
                table: "MolliePayment",
                column: "ResponseId",
                principalTable: "MollieResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
