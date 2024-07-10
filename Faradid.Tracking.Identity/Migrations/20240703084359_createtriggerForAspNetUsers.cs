using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faradid.Tracking.Identity.Migrations
{
    /// <inheritdoc />
    public partial class createtriggerForAspNetUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d869f9b-abae-4133-85fc-e917168740c0", "AQAAAAIAAYagAAAAEBm2Wqd+ZlsQLMkTpFbksdpNaEo0e7D2d3eV2//gnJUUAcNTvcT8kqRXjdv/+SrmnQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "646c1c61-9c84-4299-9d27-3f431de67093", "AQAAAAIAAYagAAAAEKdfe4KKFqmV2sigP+46MKH3DPljiogHz0MCbtbf6woqF+ic1rqrm8A+TKkpFjQDqw==" });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
