using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Access.Layer.Migrations
{
    public partial class LibraryWebApplicationMigrations_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTransactions_Books_ISBN",
                table: "BookTransactions");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "BookTransactions",
                newName: "BookID");

            migrationBuilder.RenameIndex(
                name: "IX_BookTransactions_ISBN",
                table: "BookTransactions",
                newName: "IX_BookTransactions_BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTransactions_Books_BookID",
                table: "BookTransactions",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTransactions_Books_BookID",
                table: "BookTransactions");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "BookTransactions",
                newName: "ISBN");

            migrationBuilder.RenameIndex(
                name: "IX_BookTransactions_BookID",
                table: "BookTransactions",
                newName: "IX_BookTransactions_ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTransactions_Books_ISBN",
                table: "BookTransactions",
                column: "ISBN",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
