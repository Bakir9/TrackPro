using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PaymentPurposeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purposes_Payments_PaymentId",
                table: "Purposes");

            migrationBuilder.DropIndex(
                name: "IX_Purposes_PaymentId",
                table: "Purposes");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Purposes");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentPurposeId",
                table: "Payments",
                column: "PaymentPurposeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Purposes_PaymentPurposeId",
                table: "Payments",
                column: "PaymentPurposeId",
                principalTable: "Purposes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Purposes_PaymentPurposeId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentPurposeId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Purposes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purposes_PaymentId",
                table: "Purposes",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purposes_Payments_PaymentId",
                table: "Purposes",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
