using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxiApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PBAC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RoleId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0cf61428-0fe3-4838-97f6-c074fd1db5ce"), "RoleAdmin" },
                    { new Guid("24060b7b-074d-4bf6-93b3-15d9908e22bf"), "TestPermission" },
                    { new Guid("607ca526-2364-4e02-aba0-9ed9feb5b9f3"), "CanViewAllUsers" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("16ee26f7-4147-4779-a4e5-5ecc5b9dca70"), "Driver" },
                    { new Guid("22d07e09-0793-48a8-a81b-43efca2d39ce"), "Admin" },
                    { new Guid("3ae6caf7-6914-4eaa-aaad-b2566dddd5c3"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Name", "Password", "Surname", "UserRole", "Username" },
                values: new object[] { new Guid("2493845b-8ae8-42bf-a33f-d068d490ee10"), "address", new DateTime(2024, 6, 2, 17, 45, 0, 359, DateTimeKind.Utc).AddTicks(324), "admin@admin.com", "admin", "password12345", "admin", 1, "admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("24060b7b-074d-4bf6-93b3-15d9908e22bf"), new Guid("16ee26f7-4147-4779-a4e5-5ecc5b9dca70") },
                    { new Guid("0cf61428-0fe3-4838-97f6-c074fd1db5ce"), new Guid("22d07e09-0793-48a8-a81b-43efca2d39ce") },
                    { new Guid("24060b7b-074d-4bf6-93b3-15d9908e22bf"), new Guid("22d07e09-0793-48a8-a81b-43efca2d39ce") },
                    { new Guid("607ca526-2364-4e02-aba0-9ed9feb5b9f3"), new Guid("22d07e09-0793-48a8-a81b-43efca2d39ce") },
                    { new Guid("24060b7b-074d-4bf6-93b3-15d9908e22bf"), new Guid("3ae6caf7-6914-4eaa-aaad-b2566dddd5c3") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2493845b-8ae8-42bf-a33f-d068d490ee10"));
        }
    }
}
