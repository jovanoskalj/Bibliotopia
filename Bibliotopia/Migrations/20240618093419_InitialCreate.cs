using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibliotopia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Books_Author_AuthorId",
                table: "Author_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Author_Books_Book_BookId",
                table: "Author_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookPublisher_PublisherId",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookPublisher",
                table: "BookPublisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author_Books",
                table: "Author_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "BookPublisher",
                newName: "BookPublishers");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "Author_Books",
                newName: "AuthorsBooks");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Book_PublisherId",
                table: "Books",
                newName: "IX_Books_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Author_Books_BookId",
                table: "AuthorsBooks",
                newName: "IX_AuthorsBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookPublishers",
                table: "BookPublishers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorsBooks",
                table: "AuthorsBooks",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsBooks_Authors_AuthorId",
                table: "AuthorsBooks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsBooks_Books_BookId",
                table: "AuthorsBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookPublishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "BookPublishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsBooks_Authors_AuthorId",
                table: "AuthorsBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsBooks_Books_BookId",
                table: "AuthorsBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookPublishers_PublisherId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookPublishers",
                table: "BookPublishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorsBooks",
                table: "AuthorsBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "BookPublishers",
                newName: "BookPublisher");

            migrationBuilder.RenameTable(
                name: "AuthorsBooks",
                newName: "Author_Books");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PublisherId",
                table: "Book",
                newName: "IX_Book_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorsBooks_BookId",
                table: "Author_Books",
                newName: "IX_Author_Books_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookPublisher",
                table: "BookPublisher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author_Books",
                table: "Author_Books",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Books_Author_AuthorId",
                table: "Author_Books",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Books_Book_BookId",
                table: "Author_Books",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookPublisher_PublisherId",
                table: "Book",
                column: "PublisherId",
                principalTable: "BookPublisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
