using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxiApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class VerificationTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("3e38445e-f2bd-4401-87bc-965be021986a"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("82462bf1-1e4c-4411-b2be-d54f1bc189ff"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("aba0cf99-774f-43b4-9e96-962300efe1eb"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("abf957eb-6a90-4d86-8079-c0cd706b585b"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("d32e16c9-d602-4566-96ee-75ba1982515c"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("152b4ff9-e634-494e-977d-e9c74cf87036"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("26305348-2ed8-46e3-b383-797e563867e5"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("eaab42eb-83d0-42c8-9c00-ab22545b5486"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f2f170d7-1f4b-4260-9842-c7413a2af712"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("16f6db69-ba8e-4e6d-b4cf-c11fdd5bf6c6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4085460e-9191-4791-af80-bfbc78ceb429"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cf1f3d92-61db-4fe4-a53c-9247379a6a16"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("391139b0-150b-48a8-992c-fd3d3db2f4b2"));

            migrationBuilder.CreateTable(
                name: "VerificationTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    TokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificationTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("38310945-9ff8-441a-83e0-ddd43d9ae876"), "TestPermission" },
                    { new Guid("58238749-8a6f-4a6f-b668-f530d85d78e9"), "CanViewAllUsers" },
                    { new Guid("97ed1ace-4e75-4aa0-a265-2ad03bb7eead"), "RoleAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("29647412-68af-417a-bddd-c102c6fbf476"), "User" },
                    { new Guid("7fba78ba-e33b-418d-9503-b93f887b315a"), "Driver" },
                    { new Guid("98dcd037-c73d-4046-95dc-a423c02cf2de"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "IsAdminApproved", "IsEmailVerified", "Name", "Password", "Surname", "Username" },
                values: new object[] { new Guid("c6899967-8c86-4fae-8404-5c07420a8d88"), "address", new DateTime(1997, 1, 18, 23, 40, 0, 0, DateTimeKind.Utc), "admin@admin.com", true, true, "admin", "w18sTtz2B0L0xtlle9xi3A==;7C7r8AaAq4VGSTzu1yE0b/WJh4PcVwlgnPxKZk6y5Ko=", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("32090c89-ffac-4551-96c8-aea8fd7b1ffb"), new Guid("38310945-9ff8-441a-83e0-ddd43d9ae876"), new Guid("98dcd037-c73d-4046-95dc-a423c02cf2de") },
                    { new Guid("5cbe0d81-9dcb-42db-a46d-857d8d655346"), new Guid("38310945-9ff8-441a-83e0-ddd43d9ae876"), new Guid("7fba78ba-e33b-418d-9503-b93f887b315a") },
                    { new Guid("79853258-488a-41ec-8a00-74722b8f50a9"), new Guid("97ed1ace-4e75-4aa0-a265-2ad03bb7eead"), new Guid("98dcd037-c73d-4046-95dc-a423c02cf2de") },
                    { new Guid("9e572743-706b-459b-80bb-ef139716d8ac"), new Guid("38310945-9ff8-441a-83e0-ddd43d9ae876"), new Guid("29647412-68af-417a-bddd-c102c6fbf476") },
                    { new Guid("a851c7d6-ea7f-4e78-8fac-80bf0d8f68ed"), new Guid("58238749-8a6f-4a6f-b668-f530d85d78e9"), new Guid("98dcd037-c73d-4046-95dc-a423c02cf2de") }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("11f9327b-edd1-46db-85ae-f2886b4c9149"), new Guid("98dcd037-c73d-4046-95dc-a423c02cf2de"), new Guid("c6899967-8c86-4fae-8404-5c07420a8d88") });

            migrationBuilder.CreateIndex(
                name: "IX_VerificationTokens_UserId",
                table: "VerificationTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerificationTokens");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("32090c89-ffac-4551-96c8-aea8fd7b1ffb"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("5cbe0d81-9dcb-42db-a46d-857d8d655346"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("79853258-488a-41ec-8a00-74722b8f50a9"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("9e572743-706b-459b-80bb-ef139716d8ac"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("a851c7d6-ea7f-4e78-8fac-80bf0d8f68ed"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("11f9327b-edd1-46db-85ae-f2886b4c9149"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("38310945-9ff8-441a-83e0-ddd43d9ae876"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("58238749-8a6f-4a6f-b668-f530d85d78e9"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("97ed1ace-4e75-4aa0-a265-2ad03bb7eead"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("29647412-68af-417a-bddd-c102c6fbf476"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7fba78ba-e33b-418d-9503-b93f887b315a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("98dcd037-c73d-4046-95dc-a423c02cf2de"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c6899967-8c86-4fae-8404-5c07420a8d88"));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("26305348-2ed8-46e3-b383-797e563867e5"), "CanViewAllUsers" },
                    { new Guid("eaab42eb-83d0-42c8-9c00-ab22545b5486"), "TestPermission" },
                    { new Guid("f2f170d7-1f4b-4260-9842-c7413a2af712"), "RoleAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("16f6db69-ba8e-4e6d-b4cf-c11fdd5bf6c6"), "Admin" },
                    { new Guid("4085460e-9191-4791-af80-bfbc78ceb429"), "Driver" },
                    { new Guid("cf1f3d92-61db-4fe4-a53c-9247379a6a16"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "IsAdminApproved", "IsEmailVerified", "Name", "Password", "Surname", "Username" },
                values: new object[] { new Guid("391139b0-150b-48a8-992c-fd3d3db2f4b2"), "address", new DateTime(1997, 1, 18, 23, 40, 0, 0, DateTimeKind.Utc), "admin@admin.com", true, true, "admin", "w18sTtz2B0L0xtlle9xi3A==;7C7r8AaAq4VGSTzu1yE0b/WJh4PcVwlgnPxKZk6y5Ko=", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("3e38445e-f2bd-4401-87bc-965be021986a"), new Guid("eaab42eb-83d0-42c8-9c00-ab22545b5486"), new Guid("16f6db69-ba8e-4e6d-b4cf-c11fdd5bf6c6") },
                    { new Guid("82462bf1-1e4c-4411-b2be-d54f1bc189ff"), new Guid("26305348-2ed8-46e3-b383-797e563867e5"), new Guid("16f6db69-ba8e-4e6d-b4cf-c11fdd5bf6c6") },
                    { new Guid("aba0cf99-774f-43b4-9e96-962300efe1eb"), new Guid("eaab42eb-83d0-42c8-9c00-ab22545b5486"), new Guid("4085460e-9191-4791-af80-bfbc78ceb429") },
                    { new Guid("abf957eb-6a90-4d86-8079-c0cd706b585b"), new Guid("eaab42eb-83d0-42c8-9c00-ab22545b5486"), new Guid("cf1f3d92-61db-4fe4-a53c-9247379a6a16") },
                    { new Guid("d32e16c9-d602-4566-96ee-75ba1982515c"), new Guid("f2f170d7-1f4b-4260-9842-c7413a2af712"), new Guid("16f6db69-ba8e-4e6d-b4cf-c11fdd5bf6c6") }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("152b4ff9-e634-494e-977d-e9c74cf87036"), new Guid("16f6db69-ba8e-4e6d-b4cf-c11fdd5bf6c6"), new Guid("391139b0-150b-48a8-992c-fd3d3db2f4b2") });
        }
    }
}
