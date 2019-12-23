using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICoreWeb.Data.Identity.Db.Changes
{
    public partial class DbPermissionsReferencesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionCategories_CategoryId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_CategoryId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Permissions");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permissions",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "PermissionCategories",
                newName: "PermissionCategories",
                newSchema: "Security");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Security",
                table: "Permissions",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedTime",
                schema: "Security",
                table: "Permissions",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 23, 1, 37, 13, 239, DateTimeKind.Utc).AddTicks(4611),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Security",
                table: "Permissions",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                schema: "Security",
                table: "Permissions",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 23, 1, 37, 13, 233, DateTimeKind.Utc).AddTicks(4082),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Security",
                table: "PermissionCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Security_Permissions_Id",
                schema: "Security",
                table: "Permissions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "UK_Security_Permissions_CategoryId_Name",
                schema: "Security",
                table: "Permissions",
                columns: new[] { "CateogoryId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Security_PermissionCategory_Name",
                schema: "Security",
                table: "PermissionCategories",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Security_Permissions_Id_PermissionCategories_Id",
                schema: "Security",
                table: "Permissions",
                column: "CateogoryId",
                principalSchema: "Security",
                principalTable: "PermissionCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Security_Permissions_Id_PermissionCategories_Id",
                schema: "Security",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Security_Permissions_Id",
                schema: "Security",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "UK_Security_Permissions_CategoryId_Name",
                schema: "Security",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "UK_Security_PermissionCategory_Name",
                schema: "Security",
                table: "PermissionCategories");

            migrationBuilder.RenameTable(
                name: "Permissions",
                schema: "Security",
                newName: "Permissions");

            migrationBuilder.RenameTable(
                name: "PermissionCategories",
                schema: "Security",
                newName: "PermissionCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedTime",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 12, 23, 1, 37, 13, 239, DateTimeKind.Utc).AddTicks(4611));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 12, 23, 1, 37, 13, 233, DateTimeKind.Utc).AddTicks(4082));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PermissionCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_CategoryId",
                table: "Permissions",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionCategories_CategoryId",
                table: "Permissions",
                column: "CategoryId",
                principalTable: "PermissionCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
