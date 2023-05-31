using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.LK.Infrastructure.Database.Migrations
{
    public partial class AddStatusAddTypeContractor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<int>(
            //     name: "Status",
            //     table: "Contractors",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);
            //
            // migrationBuilder.AddColumn<int>(
            //     name: "Type",
            //     table: "Contractors",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropColumn(
            //     name: "Status",
            //     table: "Contractors");
            //
            // migrationBuilder.DropColumn(
            //     name: "Type",
            //     table: "Contractors");
        }
    }
}
