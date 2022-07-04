using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamReader.Infrastruce.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "stream");

            migrationBuilder.CreateTable(
                name: "ProductView",
                schema: "stream",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Event = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MessageId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProductId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Source = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductView", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductView",
                schema: "stream");
        }
    }
}
