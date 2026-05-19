using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kavita.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPageCensors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserPageCensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChapterId = table.Column<int>(type: "INTEGER", nullable: false),
                    PageIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Regions = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "[]"),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserPageCensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserPageCensor_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserPageCensor_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPageCensor_AppUserId_ChapterId_PageIndex",
                table: "AppUserPageCensor",
                columns: new[] { "AppUserId", "ChapterId", "PageIndex" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPageCensor_ChapterId",
                table: "AppUserPageCensor",
                column: "ChapterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserPageCensor");
        }
    }
}
