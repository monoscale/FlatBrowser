using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatBrowser.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FolderCategories",
                columns: table => new
                {
                    FolderCategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderCategories", x => x.FolderCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "FileExtensions",
                columns: table => new
                {
                    FileExtensionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FolderCategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileExtensions", x => new { x.FileExtensionId, x.FolderCategoryId });
                    table.ForeignKey(
                        name: "FK_FileExtensions_FolderCategories_FolderCategoryId",
                        column: x => x.FolderCategoryId,
                        principalTable: "FolderCategories",
                        principalColumn: "FolderCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    FolderId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FolderCategoryId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => new { x.FolderId, x.FolderCategoryId });
                    table.ForeignKey(
                        name: "FK_Folders_FolderCategories_FolderCategoryId",
                        column: x => x.FolderCategoryId,
                        principalTable: "FolderCategories",
                        principalColumn: "FolderCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileExtensions_FolderCategoryId",
                table: "FileExtensions",
                column: "FolderCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_FolderCategoryId",
                table: "Folders",
                column: "FolderCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileExtensions");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "FolderCategories");
        }
    }
}
