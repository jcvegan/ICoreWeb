using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICoreWeb.Data.Identity.Db.Changes
{
    public partial class AddingColorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedTime",
                schema: "Security",
                table: "Permissions",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 26, 12, 57, 10, 86, DateTimeKind.Utc).AddTicks(9726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 12, 23, 1, 37, 13, 239, DateTimeKind.Utc).AddTicks(4611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                schema: "Security",
                table: "Permissions",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 26, 12, 57, 10, 82, DateTimeKind.Utc).AddTicks(1289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 12, 23, 1, 37, 13, 233, DateTimeKind.Utc).AddTicks(4082));

            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "Security",
                table: "PermissionCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                schema: "Security",
                table: "PermissionCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedTime",
                schema: "Security",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 23, 1, 37, 13, 239, DateTimeKind.Utc).AddTicks(4611),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 12, 26, 12, 57, 10, 86, DateTimeKind.Utc).AddTicks(9726));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                schema: "Security",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 23, 1, 37, 13, 233, DateTimeKind.Utc).AddTicks(4082),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 12, 26, 12, 57, 10, 82, DateTimeKind.Utc).AddTicks(1289));
        }
    }
}
