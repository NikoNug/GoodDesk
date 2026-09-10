using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodDesk.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBL_M_Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "TBL_M_Categories",
                columns: new[] { "ID", "CategoryName", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Hardware", 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hardware related issues", false, null, null },
                    { 2, "Software", 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software related issues", false, null, null },
                    { 3, "Network", 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Network and connectivity related issues", false, null, null },
                    { 4, "Account", 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account and access related issues", false, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBL_M_Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TBL_M_Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TBL_M_Categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TBL_M_Categories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "TBL_M_Users",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Email", "IsActive", "PasswordHash", "RoleID", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[] { 1, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "niko@gmail.com", true, "admin", 1, null, null, "admin" });
        }
    }
}
