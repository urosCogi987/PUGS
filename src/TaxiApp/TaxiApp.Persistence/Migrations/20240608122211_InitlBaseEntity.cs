using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxiApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitlBaseEntity : Migration
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: false),
                    IsAdminApproved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
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
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    TokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId_PermissionId",
                table: "RolePermission",
                columns: new[] { "RoleId", "PermissionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId_RoleId",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
