using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodDesk.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixUsernameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "TBL_M_Users",
                newName: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "TBL_M_Users",
                newName: "username");
        }
    }
}
