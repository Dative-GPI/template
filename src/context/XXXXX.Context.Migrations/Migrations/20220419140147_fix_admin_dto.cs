using Microsoft.EntityFrameworkCore.Migrations;

namespace XXXXX.Context.Migrations.Migrations
{
    public partial class fix_admin_dto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrawerLabel",
                table: "Routes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrawerLabel",
                table: "Routes",
                type: "text",
                nullable: true);
        }
    }
}
