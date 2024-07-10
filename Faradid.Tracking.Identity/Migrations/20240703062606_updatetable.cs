using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Faradid.Tracking.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updatetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "CustomRole", "Administrator", "ADMINISTRATOR" },
                    { 2, null, "CustomRole", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0d4f1fa3-7c5a-4480-abe1-d0037c69de14", "AQAAAAIAAYagAAAAEC9HhGFGt49L4xzJ4ZZcPa6krTAC4J3ThiTZ2mqLYvcMIYYUhK2rawcyGBwpRLrQzA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a4f364b7-481d-4800-b250-fdc8b121ab3b", "AQAAAAIAAYagAAAAEMs6Gpu8CGbvWhYuwWcP+3jWMqyfNkBwPs/Op/Oi+bx+aZsNBEYcUcHwG+JdMEgLmg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17148a62-58bc-42a3-89d8-923d7f8756fd", "AQAAAAIAAYagAAAAEJssUk+2f5PRdQrTb7oEVW6iBqr/4F2vH50p6lo+pX6W6m1I6oJTTPnw2fJ+Pjh0xA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c945b022-de3e-4377-9100-3517ebaf5bf9", "AQAAAAIAAYagAAAAEN1wpn5GhksUo++UmBfFJLgzz832GKY/f5wimGiDvqpGvocfTOBNYtIfRF/AgF6/ig==" });
        }
    }
}
