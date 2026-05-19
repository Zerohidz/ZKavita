using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kavita.Database.Migrations
{
    /// <inheritdoc />
    public partial class MakePageCensorsGlobal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserPageCensor_AspNetUsers_AppUserId",
                table: "AppUserPageCensor");

            migrationBuilder.DropIndex(
                name: "IX_AppUserPageCensor_AppUserId_ChapterId_PageIndex",
                table: "AppUserPageCensor");

            migrationBuilder.DropIndex(
                name: "IX_AppUserPageCensor_ChapterId",
                table: "AppUserPageCensor");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AppUserPageCensor");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPageCensor_ChapterId_PageIndex",
                table: "AppUserPageCensor",
                columns: new[] { "ChapterId", "PageIndex" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUserPageCensor_ChapterId_PageIndex",
                table: "AppUserPageCensor");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "AppUserPageCensor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPageCensor_AppUserId_ChapterId_PageIndex",
                table: "AppUserPageCensor",
                columns: new[] { "AppUserId", "ChapterId", "PageIndex" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPageCensor_ChapterId",
                table: "AppUserPageCensor",
                column: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserPageCensor_AspNetUsers_AppUserId",
                table: "AppUserPageCensor",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
