using Microsoft.EntityFrameworkCore.Migrations;

namespace XXXXX.Context.Migrations.Migrations
{
    public partial class init_admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LabelDefault",
                table: "Routes",
                newName: "DrawerLabelDefault");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Routes",
                newName: "DrawerLabel");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Routes",
                newName: "DrawerIcon");

            migrationBuilder.AddColumn<string>(
                name: "DrawerCategory",
                table: "Routes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Exact",
                table: "Routes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnDrawer",
                table: "Routes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrawerCategory",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Exact",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "ShowOnDrawer",
                table: "Routes");

            migrationBuilder.RenameColumn(
                name: "DrawerLabelDefault",
                table: "Routes",
                newName: "LabelDefault");

            migrationBuilder.RenameColumn(
                name: "DrawerLabel",
                table: "Routes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "DrawerIcon",
                table: "Routes",
                newName: "Code");
        }
    }
}
