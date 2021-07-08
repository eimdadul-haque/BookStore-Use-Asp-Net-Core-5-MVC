using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Migrations
{
    public partial class languageandcategorytableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "books");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "books");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "languageId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageGallary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGallary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageGallary_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_categoryId",
                table: "books",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_books_languageId",
                table: "books",
                column: "languageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageGallary_BookId",
                table: "ImageGallary",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_categories_categoryId",
                table: "books",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_books_languages_languageId",
                table: "books",
                column: "languageId",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_categoryId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_languages_languageId",
                table: "books");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "ImageGallary");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropIndex(
                name: "IX_books_categoryId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_languageId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "languageId",
                table: "books");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
