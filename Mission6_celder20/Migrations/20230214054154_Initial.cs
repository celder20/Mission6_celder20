using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6_celder20.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    AppId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.AppId);
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "AppId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Musical", "Kenny Ortega", false, null, null, "PG", "High School Musical", 2006 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "AppId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Sports", "Boaz Yakin", false, "Jason Thompson", "The best sports movie!", "PG", "Remember the Titans", 2000 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "AppId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 4, "Suspense/Drama", "Christopher Nolan", false, null, null, "PG-13", "Interstellar", 2014 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
