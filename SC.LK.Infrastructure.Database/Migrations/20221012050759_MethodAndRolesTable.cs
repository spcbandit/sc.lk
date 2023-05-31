using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.LK.Infrastructure.Database.Migrations
{
    public partial class MethodAndRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AvailableRoles",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "AvailableRolesEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleType = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PermissionName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PermissionType = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableRolesEntities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MethodAccessTypeEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MethodName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodAccessTypeEntities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AvailableRolesEntityMethodAccessTypeEntity",
                columns: table => new
                {
                    AccessTypesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MethodAccessTypeEntitiesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableRolesEntityMethodAccessTypeEntity", x => new { x.AccessTypesId, x.MethodAccessTypeEntitiesId });
                    table.ForeignKey(
                        name: "FK_AvailableRolesEntityMethodAccessTypeEntity_AvailableRolesEnt~",
                        column: x => x.AccessTypesId,
                        principalTable: "AvailableRolesEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableRolesEntityMethodAccessTypeEntity_MethodAccessTypeE~",
                        column: x => x.MethodAccessTypeEntitiesId,
                        principalTable: "MethodAccessTypeEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableRolesEntityMethodAccessTypeEntity_MethodAccessTypeE~",
                table: "AvailableRolesEntityMethodAccessTypeEntity",
                column: "MethodAccessTypeEntitiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableRolesEntityMethodAccessTypeEntity");

            migrationBuilder.DropTable(
                name: "AvailableRolesEntities");

            migrationBuilder.DropTable(
                name: "MethodAccessTypeEntities");

            migrationBuilder.DropColumn(
                name: "AvailableRoles",
                table: "Users");
        }
    }
}
