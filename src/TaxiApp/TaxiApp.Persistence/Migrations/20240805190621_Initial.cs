using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxiApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    UserStatus = table.Column<int>(type: "integer", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "Drive",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DriverId = table.Column<Guid>(type: "uuid", nullable: true),
                    FromAddress = table.Column<string>(type: "text", nullable: false),
                    ToAddress = table.Column<string>(type: "text", nullable: false),
                    DriveTime = table.Column<int>(type: "integer", nullable: false),
                    DriverArrivingTime = table.Column<int>(type: "integer", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drive_Users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Drive_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    { new Guid("161e3029-24be-4f0d-8c50-922f6c5d18ac"), "CanViewHisDrives" },
                    { new Guid("387b822b-90f2-4207-b5ab-3a880ac2a785"), "CanViewNewDrives" },
                    { new Guid("3fb866b7-4097-4cae-9621-374243dfaa2f"), "RoleAdmin" },
                    { new Guid("539af748-b396-4a71-bf90-851bf6b8a6d1"), "CanAcceptDrive" },
                    { new Guid("64d7e4fa-5405-4ff8-aace-8bc9000b4020"), "CanRequestDrive" },
                    { new Guid("8b86659d-a84c-42e2-bd09-c657517d40bf"), "CanViewDriveDetails" },
                    { new Guid("c01380e9-99c3-42e7-9765-17d57a4c3775"), "CanViewAllUsers" },
                    { new Guid("c07e3032-baab-4b17-b6d5-3533ddc967e7"), "CanViewAllDrives" },
                    { new Guid("e5d3bb9d-7ae6-41c9-9ef4-4497ea4514ac"), "CanViewNewDrives" },
                    { new Guid("fb82cbe9-ff63-4751-9d3b-5884187a6fa8"), "CanUpdateProfile" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0560ff95-2448-4e64-9e4d-459a3af8cddd"), "Driver" },
                    { new Guid("1812c7bc-372d-4609-b141-6bdc4976e5e0"), "User" },
                    { new Guid("d7176096-04c9-4056-975b-aab00fd571e2"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "IsEmailVerified", "Name", "Password", "Surname", "UserStatus", "Username" },
                values: new object[] { new Guid("fff9ce2e-f83b-4ae9-a490-ecf1bea6adcd"), "address", new DateTime(1997, 1, 18, 23, 40, 0, 0, DateTimeKind.Utc), "admintaxiapp@yopmail.com", true, "admin", "w18sTtz2B0L0xtlle9xi3A==;7C7r8AaAq4VGSTzu1yE0b/WJh4PcVwlgnPxKZk6y5Ko=", "admin", 1, "admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0b738161-2ddd-4d66-a8b8-c8e45d1f3f82"), new Guid("64d7e4fa-5405-4ff8-aace-8bc9000b4020"), new Guid("1812c7bc-372d-4609-b141-6bdc4976e5e0") },
                    { new Guid("1ed5e0ca-0b8c-4458-8d86-57724038f365"), new Guid("161e3029-24be-4f0d-8c50-922f6c5d18ac"), new Guid("1812c7bc-372d-4609-b141-6bdc4976e5e0") },
                    { new Guid("337d11a0-7d3c-4cad-a750-300456bff9c0"), new Guid("8b86659d-a84c-42e2-bd09-c657517d40bf"), new Guid("d7176096-04c9-4056-975b-aab00fd571e2") },
                    { new Guid("4d0ea509-f5a8-4db3-9224-dc207dc5127a"), new Guid("fb82cbe9-ff63-4751-9d3b-5884187a6fa8"), new Guid("0560ff95-2448-4e64-9e4d-459a3af8cddd") },
                    { new Guid("5012eac8-84ea-45d0-b38d-a46ffd4163d3"), new Guid("539af748-b396-4a71-bf90-851bf6b8a6d1"), new Guid("0560ff95-2448-4e64-9e4d-459a3af8cddd") },
                    { new Guid("570c6300-adb6-4599-a965-acce068fa8be"), new Guid("8b86659d-a84c-42e2-bd09-c657517d40bf"), new Guid("0560ff95-2448-4e64-9e4d-459a3af8cddd") },
                    { new Guid("791bdfaf-ce04-46ca-9aee-786253b5e397"), new Guid("161e3029-24be-4f0d-8c50-922f6c5d18ac"), new Guid("0560ff95-2448-4e64-9e4d-459a3af8cddd") },
                    { new Guid("7d0e9685-1a0f-4104-b84c-6c30ac29dc07"), new Guid("c01380e9-99c3-42e7-9765-17d57a4c3775"), new Guid("d7176096-04c9-4056-975b-aab00fd571e2") },
                    { new Guid("7fe3a356-1a7e-4243-9d7e-8ee861d40858"), new Guid("fb82cbe9-ff63-4751-9d3b-5884187a6fa8"), new Guid("1812c7bc-372d-4609-b141-6bdc4976e5e0") },
                    { new Guid("83f6b197-95c4-414b-b7a8-d3db04316b99"), new Guid("387b822b-90f2-4207-b5ab-3a880ac2a785"), new Guid("d7176096-04c9-4056-975b-aab00fd571e2") },
                    { new Guid("85ba7f05-0ca0-4e22-bff0-8a719bf08ec8"), new Guid("3fb866b7-4097-4cae-9621-374243dfaa2f"), new Guid("d7176096-04c9-4056-975b-aab00fd571e2") },
                    { new Guid("94d7e0b9-3e05-47d1-beea-ce3b4ce6ad74"), new Guid("8b86659d-a84c-42e2-bd09-c657517d40bf"), new Guid("1812c7bc-372d-4609-b141-6bdc4976e5e0") },
                    { new Guid("99066e74-51a7-447a-aa91-fc48c1ebc190"), new Guid("fb82cbe9-ff63-4751-9d3b-5884187a6fa8"), new Guid("d7176096-04c9-4056-975b-aab00fd571e2") },
                    { new Guid("c62241dc-6ccd-41bc-bb7d-b7b15e5a5162"), new Guid("387b822b-90f2-4207-b5ab-3a880ac2a785"), new Guid("0560ff95-2448-4e64-9e4d-459a3af8cddd") },
                    { new Guid("fe6f4424-f980-4548-81c4-edebf1ce4747"), new Guid("c07e3032-baab-4b17-b6d5-3533ddc967e7"), new Guid("d7176096-04c9-4056-975b-aab00fd571e2") }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("8aed2356-9af6-4338-9d7f-c9afbc820135"), new Guid("d7176096-04c9-4056-975b-aab00fd571e2"), new Guid("fff9ce2e-f83b-4ae9-a490-ecf1bea6adcd") });

            migrationBuilder.CreateIndex(
                name: "IX_Drive_DriverId",
                table: "Drive",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Drive_UserId",
                table: "Drive",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_VerificationTokens_UserId",
                table: "VerificationTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drive");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "VerificationTokens");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
