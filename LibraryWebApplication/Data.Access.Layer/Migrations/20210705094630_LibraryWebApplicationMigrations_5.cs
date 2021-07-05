using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Access.Layer.Migrations
{
    public partial class LibraryWebApplicationMigrations_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
