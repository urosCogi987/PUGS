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
                    DriverRating = table.Column<int>(type: "integer", nullable: true),
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
                    { new Guid("12bbfa2b-6118-4f71-a479-a1702fc93b4c"), "CanAcceptDrive" },
                    { new Guid("3a61c85c-d618-471e-8bc5-da659fc9f742"), "CanViewDriveDetails" },
                    { new Guid("4bc3b1d0-8788-40a1-9a47-79d596968840"), "CanRequestDrive" },
                    { new Guid("816e0256-4e12-46b8-b7d9-f67693af7783"), "CanUpdateProfile" },
                    { new Guid("8ee96c9a-bfea-4aa7-8ec3-d1e884290ff1"), "CanViewNewDrives" },
                    { new Guid("9326d669-6135-4c4a-92fe-cde94f2adc1d"), "CanViewHisDrives" },
                    { new Guid("beffbc9e-e38d-4041-8ea4-0fac9c722bd9"), "CanViewNewDrives" },
                    { new Guid("c2726432-32f0-4f52-86c1-54352a103ef1"), "CanViewAllUsers" },
                    { new Guid("d5004688-545c-4ab1-b9f3-99ea961ba1e7"), "RoleAdmin" },
                    { new Guid("f2a67262-c8c9-4e67-ad86-051cfc12a2b0"), "CanViewAllDrives" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("683903ee-0186-46bd-9cca-ec872d7bd226"), "Driver" },
                    { new Guid("6b057c54-316a-4d59-98e8-436e587c9bd8"), "Admin" },
                    { new Guid("8aee69d1-961a-48de-8c57-fd6986462d9a"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "IsEmailVerified", "Name", "Password", "Surname", "UserStatus", "Username" },
                values: new object[] { new Guid("5a8af3ca-8719-4f48-bbf7-e4e5e5f825fa"), "address", new DateTime(1997, 1, 18, 23, 40, 0, 0, DateTimeKind.Utc), "admintaxiapp@yopmail.com", true, "admin", "w18sTtz2B0L0xtlle9xi3A==;7C7r8AaAq4VGSTzu1yE0b/WJh4PcVwlgnPxKZk6y5Ko=", "admin", 1, "admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0eb118b9-0a78-4795-adb9-134464dce8da"), new Guid("3a61c85c-d618-471e-8bc5-da659fc9f742"), new Guid("8aee69d1-961a-48de-8c57-fd6986462d9a") },
                    { new Guid("24780673-60d2-44aa-97f1-65206545bc3c"), new Guid("816e0256-4e12-46b8-b7d9-f67693af7783"), new Guid("683903ee-0186-46bd-9cca-ec872d7bd226") },
                    { new Guid("379c256b-a3b3-494e-9843-7b2761c75d60"), new Guid("4bc3b1d0-8788-40a1-9a47-79d596968840"), new Guid("8aee69d1-961a-48de-8c57-fd6986462d9a") },
                    { new Guid("3c1003b3-7f37-4476-9fcf-e4a75a03d822"), new Guid("8ee96c9a-bfea-4aa7-8ec3-d1e884290ff1"), new Guid("683903ee-0186-46bd-9cca-ec872d7bd226") },
                    { new Guid("3e755cf0-a069-4226-b993-7852e6bcf28a"), new Guid("12bbfa2b-6118-4f71-a479-a1702fc93b4c"), new Guid("683903ee-0186-46bd-9cca-ec872d7bd226") },
                    { new Guid("402bbebb-84d3-4f78-9741-3a540f475875"), new Guid("8ee96c9a-bfea-4aa7-8ec3-d1e884290ff1"), new Guid("6b057c54-316a-4d59-98e8-436e587c9bd8") },
                    { new Guid("5d1ce379-3ce8-4c22-97fb-dc97d0e43513"), new Guid("816e0256-4e12-46b8-b7d9-f67693af7783"), new Guid("6b057c54-316a-4d59-98e8-436e587c9bd8") },
                    { new Guid("697a03ec-f175-497f-a3bd-39e5950c3fec"), new Guid("c2726432-32f0-4f52-86c1-54352a103ef1"), new Guid("6b057c54-316a-4d59-98e8-436e587c9bd8") },
                    { new Guid("a77c8e6b-ceaa-4fcb-8167-ee42029585dc"), new Guid("f2a67262-c8c9-4e67-ad86-051cfc12a2b0"), new Guid("6b057c54-316a-4d59-98e8-436e587c9bd8") },
                    { new Guid("c448a3e6-f806-46e4-858d-8b903fcaf5b9"), new Guid("816e0256-4e12-46b8-b7d9-f67693af7783"), new Guid("8aee69d1-961a-48de-8c57-fd6986462d9a") },
                    { new Guid("d9de5905-b513-4382-a341-89b003b02d71"), new Guid("9326d669-6135-4c4a-92fe-cde94f2adc1d"), new Guid("683903ee-0186-46bd-9cca-ec872d7bd226") },
                    { new Guid("da87f952-820b-4de7-b45a-823976f24e40"), new Guid("3a61c85c-d618-471e-8bc5-da659fc9f742"), new Guid("6b057c54-316a-4d59-98e8-436e587c9bd8") },
                    { new Guid("de25bffd-ee8a-4962-9fe7-69723bc27b02"), new Guid("3a61c85c-d618-471e-8bc5-da659fc9f742"), new Guid("683903ee-0186-46bd-9cca-ec872d7bd226") },
                    { new Guid("e84f7244-5447-4631-92a8-721555298e19"), new Guid("d5004688-545c-4ab1-b9f3-99ea961ba1e7"), new Guid("6b057c54-316a-4d59-98e8-436e587c9bd8") },
                    { new Guid("fd9b3e8f-9a55-44d8-b70b-0c4ea2e0d822"), new Guid("9326d669-6135-4c4a-92fe-cde94f2adc1d"), new Guid("8aee69d1-961a-48de-8c57-fd6986462d9a") }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("4117d841-ff32-4a1e-9eab-1f7d604089a1"), new Guid("6b057c54-316a-4d59-98e8-436e587c9bd8"), new Guid("5a8af3ca-8719-4f48-bbf7-e4e5e5f825fa") });

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
