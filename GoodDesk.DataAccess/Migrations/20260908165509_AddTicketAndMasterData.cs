using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodDesk.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketAndMasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_M_Users_TBL_M_Roles_TBLMRoleID",
                table: "TBL_M_Users");

            migrationBuilder.DropIndex(
                name: "IX_TBL_M_Users_TBLMRoleID",
                table: "TBL_M_Users");

            migrationBuilder.DropColumn(
                name: "TBLMRoleID",
                table: "TBL_M_Users");

            migrationBuilder.CreateTable(
                name: "TBL_M_Priorities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriorityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_M_Priorities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_M_Statuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_M_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_T_Tickets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequesterID = table.Column<int>(type: "int", nullable: false),
                    AssignedToID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    PriorityID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_T_Tickets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBL_T_Tickets_TBL_M_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "TBL_M_Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_T_Tickets_TBL_M_Priorities_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "TBL_M_Priorities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_T_Tickets_TBL_M_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "TBL_M_Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_T_Tickets_TBL_M_Users_AssignedToID",
                        column: x => x.AssignedToID,
                        principalTable: "TBL_M_Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_T_Tickets_TBL_M_Users_RequesterID",
                        column: x => x.RequesterID,
                        principalTable: "TBL_M_Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TBL_M_Priorities",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Description", "IsActive", "Level", "PriorityName", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Low priority", true, 1, "Low", null, null },
                    { 2, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium priority", true, 2, "Medium", null, null },
                    { 3, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High priority", true, 3, "High", null, null },
                    { 4, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Critical priority", true, 4, "Critical", null, null }
                });

            migrationBuilder.InsertData(
                table: "TBL_M_Statuses",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Description", "IsActive", "Level", "StatusName", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket has been created", true, 1, "Open", null, null },
                    { 2, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket is being worked on", true, 2, "In Progress", null, null },
                    { 3, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket is waiting for additional information or action", true, 3, "Pending", null, null },
                    { 4, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Issue has been resolved", true, 4, "Resolved", null, null },
                    { 5, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket has been closed", true, 5, "Closed", null, null }
                });

            migrationBuilder.InsertData(
                table: "TBL_M_Users",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Email", "IsActive", "PasswordHash", "RoleID", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[] { 1, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "niko@gmail.com", true, "admin", 1, null, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_T_Tickets_AssignedToID",
                table: "TBL_T_Tickets",
                column: "AssignedToID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_T_Tickets_CategoryID",
                table: "TBL_T_Tickets",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_T_Tickets_PriorityID",
                table: "TBL_T_Tickets",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_T_Tickets_RequesterID",
                table: "TBL_T_Tickets",
                column: "RequesterID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_T_Tickets_StatusID",
                table: "TBL_T_Tickets",
                column: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_T_Tickets");

            migrationBuilder.DropTable(
                name: "TBL_M_Priorities");

            migrationBuilder.DropTable(
                name: "TBL_M_Statuses");

            migrationBuilder.DeleteData(
                table: "TBL_M_Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "TBLMRoleID",
                table: "TBL_M_Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_M_Users_TBLMRoleID",
                table: "TBL_M_Users",
                column: "TBLMRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_M_Users_TBL_M_Roles_TBLMRoleID",
                table: "TBL_M_Users",
                column: "TBLMRoleID",
                principalTable: "TBL_M_Roles",
                principalColumn: "ID");
        }
    }
}
