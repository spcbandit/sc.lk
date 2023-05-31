using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.LK.Infrastructure.Database.Migrations
{
    public partial class AddParentAddChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<Guid>(
            //     name: "ParentContractorId",
            //     table: "Contractors",
            //     type: "char(36)",
            //     nullable: false,
            //     defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            //     collation: "ascii_general_ci");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_Contractors_ParentContractorId",
            //     table: "Contractors",
            //     column: "ParentContractorId");
            //
            // migrationBuilder.AddForeignKey(
            //     name: "FK_Contractors_Contractors_ParentContractorId",
            //     table: "Contractors",
            //     column: "ParentContractorId",
            //     principalTable: "Contractors",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Contractors_Contractors_ParentContractorId",
            //     table: "Contractors");
            //
            // migrationBuilder.DropIndex(
            //     name: "IX_Contractors_ParentContractorId",
            //     table: "Contractors");
            //
            // migrationBuilder.DropColumn(
            //     name: "ParentContractorId",
            //     table: "Contractors");
        }
    }
}
