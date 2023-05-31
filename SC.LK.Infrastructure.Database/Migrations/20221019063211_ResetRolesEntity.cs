using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.LK.Infrastructure.Database.Migrations
{
    public partial class ResetRolesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AvailableRolesEntities",
                newName: "AvailableRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AvailableRoles",
                newName: "AvailableRolesEntities");
        }
    }
}
