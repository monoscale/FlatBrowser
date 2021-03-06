﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatBrowser.Migrations
{
    public partial class Create : Migration
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
                name: "FileExtension",
                columns: table => new
                {
                    FileExtensionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    FolderCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileExtension", x => x.FileExtensionId);
                    table.ForeignKey(
                        name: "FK_FileExtension_FolderCategories_FolderCategoryId",
                        column: x => x.FolderCategoryId,
                        principalTable: "FolderCategories",
                        principalColumn: "FolderCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Folder",
                columns: table => new
                {
                    FolderId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(nullable: true),
                    FolderCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folder", x => x.FolderId);
                    table.ForeignKey(
                        name: "FK_Folder_FolderCategories_FolderCategoryId",
                        column: x => x.FolderCategoryId,
                        principalTable: "FolderCategories",
                        principalColumn: "FolderCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileExtension_FolderCategoryId",
                table: "FileExtension",
                column: "FolderCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_FolderCategoryId",
                table: "Folder",
                column: "FolderCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileExtension");

            migrationBuilder.DropTable(
                name: "Folder");

            migrationBuilder.DropTable(
                name: "FolderCategories");
        }
    }
}
