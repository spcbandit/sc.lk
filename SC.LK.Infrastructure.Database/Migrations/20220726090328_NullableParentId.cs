using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.LK.Infrastructure.Database.Migrations
{
    public partial class NullableParentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Contractors_Contractors_ParentContractorId",
            //     table: "Contractors");
            //
            // migrationBuilder.AlterColumn<Guid>(
            //     name: "ParentContractorId",
            //     table: "Contractors",
            //     type: "char(36)",
            //     nullable: true,
            //     collation: "ascii_general_ci",
            //     oldClrType: typeof(Guid),
            //     oldType: "char(36)")
            //     .OldAnnotation("Relational:Collation", "ascii_general_ci");
            //
            // migrationBuilder.AddForeignKey(
            //     name: "FK_Contractors_Contractors_ParentContractorId",
            //     table: "Contractors",
            //     column: "ParentContractorId",
            //     principalTable: "Contractors",
            //     principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Contractors_Contractors_ParentContractorId",
            //     table: "Contractors");
            //
            // migrationBuilder.AlterColumn<Guid>(
            //     name: "ParentContractorId",
            //     table: "Contractors",
            //     type: "char(36)",
            //     nullable: false,
            //     defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            //     collation: "ascii_general_ci",
            //     oldClrType: typeof(Guid),
            //     oldType: "char(36)",
            //     oldNullable: true)
            //     .OldAnnotation("Relational:Collation", "ascii_general_ci");
            //
            // migrationBuilder.AddForeignKey(
            //     name: "FK_Contractors_Contractors_ParentContractorId",
            //     table: "Contractors",
            //     column: "ParentContractorId",
            //     principalTable: "Contractors",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}
