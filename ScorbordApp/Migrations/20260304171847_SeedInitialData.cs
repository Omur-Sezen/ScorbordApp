using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScorbordApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 1, "Türkiye", "Trendyol Süper Lig" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "City", "LeagueId", "Name" },
                values: new object[] { 1, "Trabzon", 1, "Trabzonspor" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "Name", "Position", "TeamId" },
                values: new object[] { 1, 29, "Uğurcan Çakır", "Kaleci", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
