using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace diarioOnlineAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBDIWish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "DiaryEntries",
                newName: "DiaryEntries",
                newSchema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "DiaryEntries",
                schema: "dbo",
                newName: "DiaryEntries");
        }
    }
}
