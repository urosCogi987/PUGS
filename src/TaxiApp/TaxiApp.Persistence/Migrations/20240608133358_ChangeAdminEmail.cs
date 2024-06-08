using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxiApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAdminEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("44800c50-67cd-48ab-9470-946b095bcb2e"), "CanViewAllUsers" },
                    { new Guid("b4397af2-3040-4750-8d2a-925c29680fec"), "TestPermission" },
                    { new Guid("cd55c0d3-8189-44cb-876f-39938b0dc438"), "RoleAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("aa98d0f5-d42b-468a-9a35-fe5bd5bbcdbf"), "User" },
                    { new Guid("ca00265d-f6e1-4837-a7ac-500ce3cb92b8"), "Admin" },
                    { new Guid("d3dca270-3cf6-459d-8019-50bbf3ef6ebf"), "Driver" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "IsAdminApproved", "IsEmailVerified", "Name", "Password", "Surname", "Username" },
                values: new object[] { new Guid("10c34b8f-a399-4451-8835-390a01da63c2"), "address", new DateTime(1997, 1, 18, 23, 40, 0, 0, DateTimeKind.Utc), "admintaxiapp@yopmail.com", true, true, "admin", "w18sTtz2B0L0xtlle9xi3A==;7C7r8AaAq4VGSTzu1yE0b/WJh4PcVwlgnPxKZk6y5Ko=", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0fbfd745-22ef-43ce-8306-95f363ec9abc"), new Guid("44800c50-67cd-48ab-9470-946b095bcb2e"), new Guid("ca00265d-f6e1-4837-a7ac-500ce3cb92b8") },
                    { new Guid("5dc66195-1e69-4a5b-8c68-aebccf64f18d"), new Guid("b4397af2-3040-4750-8d2a-925c29680fec"), new Guid("aa98d0f5-d42b-468a-9a35-fe5bd5bbcdbf") },
                    { new Guid("7dc22157-e010-4697-a307-1f0c5d2c646d"), new Guid("cd55c0d3-8189-44cb-876f-39938b0dc438"), new Guid("ca00265d-f6e1-4837-a7ac-500ce3cb92b8") },
                    { new Guid("c07e3754-4e8d-4516-ba42-67a0c095edfd"), new Guid("b4397af2-3040-4750-8d2a-925c29680fec"), new Guid("ca00265d-f6e1-4837-a7ac-500ce3cb92b8") },
                    { new Guid("e8a22e6e-7774-4b7f-be1f-049b2fd45284"), new Guid("b4397af2-3040-4750-8d2a-925c29680fec"), new Guid("d3dca270-3cf6-459d-8019-50bbf3ef6ebf") }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("26386658-7a24-47ef-ad36-f9c34a65288d"), new Guid("ca00265d-f6e1-4837-a7ac-500ce3cb92b8"), new Guid("10c34b8f-a399-4451-8835-390a01da63c2") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("0fbfd745-22ef-43ce-8306-95f363ec9abc"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("5dc66195-1e69-4a5b-8c68-aebccf64f18d"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("7dc22157-e010-4697-a307-1f0c5d2c646d"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("c07e3754-4e8d-4516-ba42-67a0c095edfd"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("e8a22e6e-7774-4b7f-be1f-049b2fd45284"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("26386658-7a24-47ef-ad36-f9c34a65288d"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("44800c50-67cd-48ab-9470-946b095bcb2e"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b4397af2-3040-4750-8d2a-925c29680fec"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("cd55c0d3-8189-44cb-876f-39938b0dc438"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("aa98d0f5-d42b-468a-9a35-fe5bd5bbcdbf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ca00265d-f6e1-4837-a7ac-500ce3cb92b8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d3dca270-3cf6-459d-8019-50bbf3ef6ebf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10c34b8f-a399-4451-8835-390a01da63c2"));

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
        }
    }
}
