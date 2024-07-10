using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faradid.Tracking.Identity.Migrations
{
    /// <inheritdoc />
    public partial class createtrigerforaspnetusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "25a828d4-87a9-4fc4-b673-c31e3f814b54", "AQAAAAIAAYagAAAAEO/U0CjBlyKxL1Yax5IxXYcw66ujeH7aGOMSyyJwgN2mgm9wO67ZB9lHUZpm6urxvQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6db7f44-177f-48b5-befb-97708500d07c", "AQAAAAIAAYagAAAAEEEe5t6GK5E2uXPdpOhu52NlZgpAqHJRn36WXRQDwkZvNOHSzEbw7VSxus23/whMJQ==" });
            migrationBuilder.Sql(@"
                CREATE TRIGGER YourTriggerName
                ON AspNetUsers
                AFTER INSERT, UPDATE, DELETE
                AS
                BEGIN
                    -- Your trigger logic here
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
