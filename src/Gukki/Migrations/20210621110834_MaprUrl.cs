using Microsoft.EntityFrameworkCore.Migrations;

namespace Gukki.Migrations
{
    public partial class MaprUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    city_name = table.Column<string>(type: "text", nullable: false),
                    block_name = table.Column<string>(type: "text", nullable: false),
                    maps_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PlaceId",
                table: "Contacts",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Places_PlaceId",
                table: "Contacts",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Places_PlaceId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_PlaceId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Contacts");
        }
    }
}
