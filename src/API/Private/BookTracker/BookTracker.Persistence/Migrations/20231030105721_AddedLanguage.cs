using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "Book",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "Book",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_LanguageId",
                table: "Book",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_languages_LanguageId",
                table: "Book",
                column: "LanguageId",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_languages_LanguageId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropIndex(
                name: "IX_Book_LanguageId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Format",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Book");
        }
    }
}
