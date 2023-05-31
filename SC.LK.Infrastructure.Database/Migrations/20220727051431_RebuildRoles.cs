using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.LK.Infrastructure.Database.Migrations
{
    public partial class RebuildRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangingConfiguration",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "ChangingContractorProfile",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatingChangingUserProfile",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "FinanceRole",
                table: "Role");

            migrationBuilder.AddColumn<int>(
                name: "AccessType",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Role",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                table: "Role",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessType",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Role");

            migrationBuilder.AddColumn<bool>(
                name: "ChangingConfiguration",
                table: "Role",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChangingContractorProfile",
                table: "Role",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CreatingChangingUserProfile",
                table: "Role",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FinanceRole",
                table: "Role",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
