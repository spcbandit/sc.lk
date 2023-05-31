using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.LK.Infrastructure.Database.Migrations
{
    public partial class MethodWithRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                    name: "MethodWithRoles",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                        AccessTypesId = table.Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                       
                        MethodAccessTypesEntitiesId = table.Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue:false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_MethodWithRoles", x => x.Id);
                    })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.DropTable(name: "AvailableRolesEntityMethodAccessTypeEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "MethodWithRoles");
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
    }
}
