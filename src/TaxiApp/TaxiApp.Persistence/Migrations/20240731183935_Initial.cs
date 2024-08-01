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
                    { new Guid("048ec5e1-833f-4a54-b292-6acd5c17f55b"), "CanAcceptDrive" },
                    { new Guid("17144e93-40cd-440b-b04e-ddc7344ef613"), "CanUpdateProfile" },
                    { new Guid("3fcd2d4e-8af1-4e8a-8910-795547d0263b"), "RoleAdmin" },
                    { new Guid("91d8185c-7aa6-4a0e-8a27-e6478f008a90"), "CanViewAllDrives" },
                    { new Guid("91e121c6-08ed-4f75-a027-1fbc8e19abf5"), "CanViewHisDrives" },
                    { new Guid("cf33c969-6d1e-4a77-b08c-46e32c2965d4"), "CanViewAllUsers" },
                    { new Guid("f0e44101-54ce-4760-b896-f6223a3ebaad"), "CanRequestDrive" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5664914f-9c21-4d11-8db7-5d983adaff51"), "Admin" },
                    { new Guid("77d5ebd4-d601-4e92-8a81-556db2fd08de"), "Driver" },
                    { new Guid("7faabc8b-aec1-41eb-a1b8-3ff59c10b860"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "IsEmailVerified", "Name", "Password", "Surname", "UserStatus", "Username" },
                values: new object[] { new Guid("2c15615c-a57e-4a1a-9a6e-dc45e88d9c42"), "address", new DateTime(1997, 1, 18, 23, 40, 0, 0, DateTimeKind.Utc), "admintaxiapp@yopmail.com", true, "admin", "w18sTtz2B0L0xtlle9xi3A==;7C7r8AaAq4VGSTzu1yE0b/WJh4PcVwlgnPxKZk6y5Ko=", "admin", 1, "admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("08da2c58-f446-4ca3-954f-bafc72cab6cc"), new Guid("3fcd2d4e-8af1-4e8a-8910-795547d0263b"), new Guid("5664914f-9c21-4d11-8db7-5d983adaff51") },
                    { new Guid("10e1253c-9673-4c56-bd49-0fdcba7065a2"), new Guid("91d8185c-7aa6-4a0e-8a27-e6478f008a90"), new Guid("5664914f-9c21-4d11-8db7-5d983adaff51") },
                    { new Guid("19747345-d16c-4592-95fc-8861da4208af"), new Guid("17144e93-40cd-440b-b04e-ddc7344ef613"), new Guid("5664914f-9c21-4d11-8db7-5d983adaff51") },
                    { new Guid("45c8069c-c2b1-4644-9fde-6dfc03e31586"), new Guid("17144e93-40cd-440b-b04e-ddc7344ef613"), new Guid("77d5ebd4-d601-4e92-8a81-556db2fd08de") },
                    { new Guid("4b78909d-3e66-4514-b2c7-994a02e6bc6d"), new Guid("f0e44101-54ce-4760-b896-f6223a3ebaad"), new Guid("7faabc8b-aec1-41eb-a1b8-3ff59c10b860") },
                    { new Guid("8a84de46-8424-4cd5-83d8-0bcb46b9cd1d"), new Guid("cf33c969-6d1e-4a77-b08c-46e32c2965d4"), new Guid("5664914f-9c21-4d11-8db7-5d983adaff51") },
                    { new Guid("8ec76ecf-0a74-4be6-bfaf-7368c232ff9c"), new Guid("048ec5e1-833f-4a54-b292-6acd5c17f55b"), new Guid("77d5ebd4-d601-4e92-8a81-556db2fd08de") },
                    { new Guid("9c6b2321-f01e-49d9-9b73-0e86ae63df2a"), new Guid("91e121c6-08ed-4f75-a027-1fbc8e19abf5"), new Guid("7faabc8b-aec1-41eb-a1b8-3ff59c10b860") },
                    { new Guid("ae1b6877-476d-4471-9091-d6fd693e6364"), new Guid("91e121c6-08ed-4f75-a027-1fbc8e19abf5"), new Guid("77d5ebd4-d601-4e92-8a81-556db2fd08de") },
                    { new Guid("c9eb2f72-6fb3-4368-ab72-2986d2720c9b"), new Guid("17144e93-40cd-440b-b04e-ddc7344ef613"), new Guid("7faabc8b-aec1-41eb-a1b8-3ff59c10b860") }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("1a211cb4-6c40-4a3f-b3dd-a2a229e6379a"), new Guid("5664914f-9c21-4d11-8db7-5d983adaff51"), new Guid("2c15615c-a57e-4a1a-9a6e-dc45e88d9c42") });

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
