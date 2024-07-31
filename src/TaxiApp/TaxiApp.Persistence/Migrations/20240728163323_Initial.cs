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
                    Distance = table.Column<int>(type: "integer", nullable: false),
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
                    { new Guid("78b13f2b-5f1e-4f08-b0d1-c8bfb5c4c672"), "CanAcceptDrive" },
                    { new Guid("8797c05d-8cb6-41e1-a245-bc4f0532140e"), "RoleAdmin" },
                    { new Guid("9da94be2-688d-4c20-b8ca-4b34cc1a0571"), "CanViewAllDrives" },
                    { new Guid("be703bae-8cf4-47f2-9aee-b41644687bbe"), "CanViewHisDrives" },
                    { new Guid("c1704856-9e13-4153-9341-4aafaa69afe2"), "CanRequestDrive" },
                    { new Guid("da5c7776-ac69-4a61-b07e-a3e956c1bf7f"), "CanViewAllUsers" },
                    { new Guid("fec26708-6a3d-4bb2-a592-865af8307141"), "CanUpdateProfile" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("352f88bc-cfc3-4fe6-a3b7-815aa3b5c5d1"), "Driver" },
                    { new Guid("4f47fb30-3091-4adf-80c1-27c03743628b"), "Admin" },
                    { new Guid("adecac2c-fb63-469b-b29b-02e964d702af"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "IsEmailVerified", "Name", "Password", "Surname", "UserStatus", "Username" },
                values: new object[] { new Guid("23b84b94-3e64-4063-ae4f-20951a0dd30c"), "address", new DateTime(1997, 1, 18, 23, 40, 0, 0, DateTimeKind.Utc), "admintaxiapp@yopmail.com", true, "admin", "w18sTtz2B0L0xtlle9xi3A==;7C7r8AaAq4VGSTzu1yE0b/WJh4PcVwlgnPxKZk6y5Ko=", "admin", 1, "admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("4556c35a-ada6-4598-a7d0-43d0890a2ee5"), new Guid("c1704856-9e13-4153-9341-4aafaa69afe2"), new Guid("adecac2c-fb63-469b-b29b-02e964d702af") },
                    { new Guid("5a4e4de5-fc3c-44dd-b8a8-7a2f75a7130e"), new Guid("be703bae-8cf4-47f2-9aee-b41644687bbe"), new Guid("adecac2c-fb63-469b-b29b-02e964d702af") },
                    { new Guid("5c9fef07-60f0-473a-a501-a1e004ff0076"), new Guid("fec26708-6a3d-4bb2-a592-865af8307141"), new Guid("4f47fb30-3091-4adf-80c1-27c03743628b") },
                    { new Guid("8f09172c-05d2-4004-aa84-3e73eeade3e7"), new Guid("9da94be2-688d-4c20-b8ca-4b34cc1a0571"), new Guid("4f47fb30-3091-4adf-80c1-27c03743628b") },
                    { new Guid("a0603e9c-a449-4562-91d9-98a149bea5c3"), new Guid("78b13f2b-5f1e-4f08-b0d1-c8bfb5c4c672"), new Guid("352f88bc-cfc3-4fe6-a3b7-815aa3b5c5d1") },
                    { new Guid("b088dd56-ac5d-4928-a2d8-bcad8d8512d6"), new Guid("be703bae-8cf4-47f2-9aee-b41644687bbe"), new Guid("352f88bc-cfc3-4fe6-a3b7-815aa3b5c5d1") },
                    { new Guid("c1a40028-b1ef-4992-a82b-1f6e5fbae042"), new Guid("fec26708-6a3d-4bb2-a592-865af8307141"), new Guid("352f88bc-cfc3-4fe6-a3b7-815aa3b5c5d1") },
                    { new Guid("cb5ac612-ffdd-4a7d-bd1b-05ae699e8f89"), new Guid("fec26708-6a3d-4bb2-a592-865af8307141"), new Guid("adecac2c-fb63-469b-b29b-02e964d702af") },
                    { new Guid("ce8ff09b-63f0-4060-a493-96ba3ff2c215"), new Guid("8797c05d-8cb6-41e1-a245-bc4f0532140e"), new Guid("4f47fb30-3091-4adf-80c1-27c03743628b") },
                    { new Guid("eab2cc36-a7d8-4a88-993d-d6f372b5111f"), new Guid("da5c7776-ac69-4a61-b07e-a3e956c1bf7f"), new Guid("4f47fb30-3091-4adf-80c1-27c03743628b") }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("d5dcf103-9334-400d-92b1-4fa1cb02cea7"), new Guid("4f47fb30-3091-4adf-80c1-27c03743628b"), new Guid("23b84b94-3e64-4063-ae4f-20951a0dd30c") });

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
