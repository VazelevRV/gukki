using Microsoft.EntityFrameworkCore.Migrations;

namespace Gukki.Migrations
{
    public partial class MapsContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_MapsContactModel_MapsContactId",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapsContactModel",
                table: "MapsContactModel");

            migrationBuilder.RenameTable(
                name: "MapsContactModel",
                newName: "MapContacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapContacts",
                table: "MapContacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_MapContacts_MapsContactId",
                table: "Places",
                column: "MapsContactId",
                principalTable: "MapContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_MapContacts_MapsContactId",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapContacts",
                table: "MapContacts");

            migrationBuilder.RenameTable(
                name: "MapContacts",
                newName: "MapsContactModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapsContactModel",
                table: "MapsContactModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_MapsContactModel_MapsContactId",
                table: "Places",
                column: "MapsContactId",
                principalTable: "MapsContactModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
