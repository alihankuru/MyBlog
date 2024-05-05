using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.DataAccessLayer.Migrations
{
    public partial class mig13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTag_Articles_ArticleId",
                table: "ArticleTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTag_Tags_TagId",
                table: "ArticleTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTag",
                table: "ArticleTag");

            migrationBuilder.RenameTable(
                name: "ArticleTag",
                newName: "ArticleTags");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTag_TagId",
                table: "ArticleTags",
                newName: "IX_ArticleTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTag_ArticleId",
                table: "ArticleTags",
                newName: "IX_ArticleTags_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags",
                column: "ArticleTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTags_Articles_ArticleId",
                table: "ArticleTags",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTags_Tags_TagId",
                table: "ArticleTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTags_Articles_ArticleId",
                table: "ArticleTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTags_Tags_TagId",
                table: "ArticleTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags");

            migrationBuilder.RenameTable(
                name: "ArticleTags",
                newName: "ArticleTag");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTag",
                newName: "IX_ArticleTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTags_ArticleId",
                table: "ArticleTag",
                newName: "IX_ArticleTag_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTag",
                table: "ArticleTag",
                column: "ArticleTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Articles_ArticleId",
                table: "ArticleTag",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Tags_TagId",
                table: "ArticleTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
