using Microsoft.EntityFrameworkCore.Migrations;

namespace Gukki.Migrations
{
    public partial class MapsContactsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maps_url",
                table: "Places");

            migrationBuilder.AddColumn<int>(
                name: "MapsContactId",
                table: "Places",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MapsContactModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    maps_url = table.Column<string>(type: "text", nullable: false),
                    full_address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapsContactModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_MapsContactId",
                table: "Places",
                column: "MapsContactId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_MapsContactModel_MapsContactId",
                table: "Places",
                column: "MapsContactId",
                principalTable: "MapsContactModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_MapsContactModel_MapsContactId",
                table: "Places");

            migrationBuilder.DropTable(
                name: "MapsContactModel");

            migrationBuilder.DropIndex(
                name: "IX_Places_MapsContactId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "MapsContactId",
                table: "Places");

            migrationBuilder.AddColumn<string>(
                name: "maps_url",
                table: "Places",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
