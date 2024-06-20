using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxiApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DriveEntity : Migration
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
                    { new Guid("0010b5d1-dbbb-47da-8a53-94d510fd9463"), "RoleAdmin" },
                    { new Guid("94ecddb9-de75-4810-ab47-8a64830c916f"), "CanViewHisDrives" },
                    { new Guid("c115ef09-0891-40c3-92a2-bfc38f213ca8"), "CanViewAllUsers" },
                    { new Guid("c1a60cce-5232-4940-8f9a-4c0befc006d7"), "CanUpdateProfile" },
                    { new Guid("cb852d8a-763e-42a1-9f9f-cac6806af838"), "CanAcceptDrive" },
                    { new Guid("ccae34e0-a8cf-407a-996f-ccf0e014a308"), "CanViewAllDrives" },
                    { new Guid("ce14a253-f422-49e1-8b14-a43aab4d15c5"), "CanRequestDrive" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24e11c70-3b4d-4497-9998-2e6225505dc9"), "User" },
                    { new Guid("38ee5a93-9cf2-4457-bf6e-3e715e7dc29a"), "Driver" },
                    { new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "IsEmailVerified", "Name", "Password", "Surname", "UserStatus", "Username" },
                values: new object[] { new Guid("39a62e0a-abd4-461c-a6ea-561bea8036f5"), "address", new DateTime(1997, 1, 18, 23, 40, 0, 0, DateTimeKind.Utc), "admintaxiapp@yopmail.com", true, "admin", "w18sTtz2B0L0xtlle9xi3A==;7C7r8AaAq4VGSTzu1yE0b/WJh4PcVwlgnPxKZk6y5Ko=", "admin", 1, "admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("2f85575a-cebb-4ace-bef6-2ab638cba013"), new Guid("c1a60cce-5232-4940-8f9a-4c0befc006d7"), new Guid("24e11c70-3b4d-4497-9998-2e6225505dc9") },
                    { new Guid("417edcd8-dd27-4318-966a-bd091ca4a7bf"), new Guid("c115ef09-0891-40c3-92a2-bfc38f213ca8"), new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08") },
                    { new Guid("5dcb3beb-4b0f-4f56-b803-ae6f7ba05545"), new Guid("ccae34e0-a8cf-407a-996f-ccf0e014a308"), new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08") },
                    { new Guid("7e20bdd4-ec47-45cb-bac4-e2d711043f7e"), new Guid("cb852d8a-763e-42a1-9f9f-cac6806af838"), new Guid("38ee5a93-9cf2-4457-bf6e-3e715e7dc29a") },
                    { new Guid("7f382a7f-6ef0-4543-b643-cf0dcad2b7be"), new Guid("c1a60cce-5232-4940-8f9a-4c0befc006d7"), new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08") },
                    { new Guid("855629a1-2d73-498b-9d12-26fada4cbe6f"), new Guid("ce14a253-f422-49e1-8b14-a43aab4d15c5"), new Guid("24e11c70-3b4d-4497-9998-2e6225505dc9") },
                    { new Guid("8fd21ab8-2d2f-4088-850f-cc4b3a9c3777"), new Guid("94ecddb9-de75-4810-ab47-8a64830c916f"), new Guid("38ee5a93-9cf2-4457-bf6e-3e715e7dc29a") },
                    { new Guid("92b9f6d5-8039-444b-b3df-5970f1446f5a"), new Guid("0010b5d1-dbbb-47da-8a53-94d510fd9463"), new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08") },
                    { new Guid("a6874f99-b55a-4f64-8774-0b1321e36669"), new Guid("c1a60cce-5232-4940-8f9a-4c0befc006d7"), new Guid("38ee5a93-9cf2-4457-bf6e-3e715e7dc29a") },
                    { new Guid("d0d554b7-fc98-4f31-ba24-8aa1516c526e"), new Guid("94ecddb9-de75-4810-ab47-8a64830c916f"), new Guid("24e11c70-3b4d-4497-9998-2e6225505dc9") }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("76f0cb0c-5322-4d08-8381-2e71c8754293"), new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08"), new Guid("39a62e0a-abd4-461c-a6ea-561bea8036f5") });

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
