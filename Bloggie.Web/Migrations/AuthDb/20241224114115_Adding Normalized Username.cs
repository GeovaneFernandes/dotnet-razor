using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddingNormalizedUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f663ed14-3d8e-40b5-adc0-46e71725edd0",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b884ab-41b9-434f-8714-935111ac8bcc", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAEAP1BhxEMJ07hTagNio7e7AfNhYJ3WKWAvRn6wXgyTyWQXYWZvKpnT4l2cX1TEvuug==", "29e142b0-1811-4970-a93a-6fef689a312b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f663ed14-3d8e-40b5-adc0-46e71725edd0",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ae9391c-22ee-477f-a56e-2730f2cbbe71", null, null, "AQAAAAIAAYagAAAAEDU5sfbRAMZIdqrktezWRk0FWeU/L4BWv4QAqQ1g8q1rd4lgn6DsVlCVcLkRpntMhQ==", "f7194b39-888b-407b-9683-b4d7d06218bc" });
        }
    }
}
