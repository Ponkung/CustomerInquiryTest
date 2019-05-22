using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerInquiry.Migrations
{
    public partial class updateModelJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomersId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "Transactions",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CustomersId",
                table: "Transactions",
                newName: "IX_Transactions_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Transactions",
                newName: "CustomersId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                newName: "IX_Transactions_CustomersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomersId",
                table: "Transactions",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
