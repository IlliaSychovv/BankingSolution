using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.Solution.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamefromAccountToFromAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "toAccount",
                table: "Transactions",
                newName: "ToAccount");

            migrationBuilder.RenameColumn(
                name: "fromAccount",
                table: "Transactions",
                newName: "FromAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountNumber",
                table: "Accounts",
                column: "AccountNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountNumber",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "ToAccount",
                table: "Transactions",
                newName: "toAccount");

            migrationBuilder.RenameColumn(
                name: "FromAccount",
                table: "Transactions",
                newName: "fromAccount");
        }
    }
}
