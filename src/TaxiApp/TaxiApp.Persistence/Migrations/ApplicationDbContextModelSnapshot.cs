﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaxiApp.Persistence;

#nullable disable

namespace TaxiApp.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TaxiApp.Domain.Entities.Drive", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Distance")
                        .HasColumnType("integer");

                    b.Property<int>("DriveTime")
                        .HasColumnType("integer");

                    b.Property<int>("DriverArrivingTime")
                        .HasColumnType("integer");

                    b.Property<Guid?>("DriverId")
                        .HasColumnType("uuid");

                    b.Property<string>("FromAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("ToAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("UserId");

                    b.ToTable("Drive");
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8797c05d-8cb6-41e1-a245-bc4f0532140e"),
                            Name = "RoleAdmin"
                        },
                        new
                        {
                            Id = new Guid("da5c7776-ac69-4a61-b07e-a3e956c1bf7f"),
                            Name = "CanViewAllUsers"
                        },
                        new
                        {
                            Id = new Guid("9da94be2-688d-4c20-b8ca-4b34cc1a0571"),
                            Name = "CanViewAllDrives"
                        },
                        new
                        {
                            Id = new Guid("c1704856-9e13-4153-9341-4aafaa69afe2"),
                            Name = "CanRequestDrive"
                        },
                        new
                        {
                            Id = new Guid("78b13f2b-5f1e-4f08-b0d1-c8bfb5c4c672"),
                            Name = "CanAcceptDrive"
                        },
                        new
                        {
                            Id = new Guid("be703bae-8cf4-47f2-9aee-b41644687bbe"),
                            Name = "CanViewHisDrives"
                        },
                        new
                        {
                            Id = new Guid("fec26708-6a3d-4bb2-a592-865af8307141"),
                            Name = "CanUpdateProfile"
                        });
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("4f47fb30-3091-4adf-80c1-27c03743628b"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("adecac2c-fb63-469b-b29b-02e964d702af"),
                            Name = "User"
                        },
                        new
                        {
                            Id = new Guid("352f88bc-cfc3-4fe6-a3b7-815aa3b5c5d1"),
                            Name = "Driver"
                        });
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId", "PermissionId")
                        .IsUnique();

                    b.ToTable("RolePermission");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce8ff09b-63f0-4060-a493-96ba3ff2c215"),
                            PermissionId = new Guid("8797c05d-8cb6-41e1-a245-bc4f0532140e"),
                            RoleId = new Guid("4f47fb30-3091-4adf-80c1-27c03743628b")
                        },
                        new
                        {
                            Id = new Guid("eab2cc36-a7d8-4a88-993d-d6f372b5111f"),
                            PermissionId = new Guid("da5c7776-ac69-4a61-b07e-a3e956c1bf7f"),
                            RoleId = new Guid("4f47fb30-3091-4adf-80c1-27c03743628b")
                        },
                        new
                        {
                            Id = new Guid("8f09172c-05d2-4004-aa84-3e73eeade3e7"),
                            PermissionId = new Guid("9da94be2-688d-4c20-b8ca-4b34cc1a0571"),
                            RoleId = new Guid("4f47fb30-3091-4adf-80c1-27c03743628b")
                        },
                        new
                        {
                            Id = new Guid("5c9fef07-60f0-473a-a501-a1e004ff0076"),
                            PermissionId = new Guid("fec26708-6a3d-4bb2-a592-865af8307141"),
                            RoleId = new Guid("4f47fb30-3091-4adf-80c1-27c03743628b")
                        },
                        new
                        {
                            Id = new Guid("cb5ac612-ffdd-4a7d-bd1b-05ae699e8f89"),
                            PermissionId = new Guid("fec26708-6a3d-4bb2-a592-865af8307141"),
                            RoleId = new Guid("adecac2c-fb63-469b-b29b-02e964d702af")
                        },
                        new
                        {
                            Id = new Guid("4556c35a-ada6-4598-a7d0-43d0890a2ee5"),
                            PermissionId = new Guid("c1704856-9e13-4153-9341-4aafaa69afe2"),
                            RoleId = new Guid("adecac2c-fb63-469b-b29b-02e964d702af")
                        },
                        new
                        {
                            Id = new Guid("5a4e4de5-fc3c-44dd-b8a8-7a2f75a7130e"),
                            PermissionId = new Guid("be703bae-8cf4-47f2-9aee-b41644687bbe"),
                            RoleId = new Guid("adecac2c-fb63-469b-b29b-02e964d702af")
                        },
                        new
                        {
                            Id = new Guid("c1a40028-b1ef-4992-a82b-1f6e5fbae042"),
                            PermissionId = new Guid("fec26708-6a3d-4bb2-a592-865af8307141"),
                            RoleId = new Guid("352f88bc-cfc3-4fe6-a3b7-815aa3b5c5d1")
                        },
                        new
                        {
                            Id = new Guid("a0603e9c-a449-4562-91d9-98a149bea5c3"),
                            PermissionId = new Guid("78b13f2b-5f1e-4f08-b0d1-c8bfb5c4c672"),
                            RoleId = new Guid("352f88bc-cfc3-4fe6-a3b7-815aa3b5c5d1")
                        },
                        new
                        {
                            Id = new Guid("b088dd56-ac5d-4928-a2d8-bcad8d8512d6"),
                            PermissionId = new Guid("be703bae-8cf4-47f2-9aee-b41644687bbe"),
                            RoleId = new Guid("352f88bc-cfc3-4fe6-a3b7-815aa3b5c5d1")
                        });
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("23b84b94-3e64-4063-ae4f-20951a0dd30c"),
                            Address = "address",
                            DateOfBirth = new DateTime(1997, 1, 18, 23, 40, 0, 0, DateTimeKind.Utc),
                            Email = "admintaxiapp@yopmail.com",
                            IsEmailVerified = true,
                            Name = "admin",
                            Password = "w18sTtz2B0L0xtlle9xi3A==;7C7r8AaAq4VGSTzu1yE0b/WJh4PcVwlgnPxKZk6y5Ko=",
                            Surname = "admin",
                            UserStatus = 1,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique();

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d5dcf103-9334-400d-92b1-4fa1cb02cea7"),
                            RoleId = new Guid("4f47fb30-3091-4adf-80c1-27c03743628b"),
                            UserId = new Guid("23b84b94-3e64-4063-ae4f-20951a0dd30c")
                        });
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.VerificationToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("TokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("VerificationTokens", (string)null);
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.Drive", b =>
                {
                    b.HasOne("TaxiApp.Domain.Entities.User", "Driver")
                        .WithMany("DrivesDriver")
                        .HasForeignKey("DriverId");

                    b.HasOne("TaxiApp.Domain.Entities.User", "User")
                        .WithMany("DrivesPassanger")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("TaxiApp.Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.RolePermission", b =>
                {
                    b.HasOne("TaxiApp.Domain.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxiApp.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("TaxiApp.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxiApp.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.VerificationToken", b =>
                {
                    b.HasOne("TaxiApp.Domain.Entities.User", "User")
                        .WithMany("VerificationTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaxiApp.Domain.Entities.User", b =>
                {
                    b.Navigation("DrivesDriver");

                    b.Navigation("DrivesPassanger");

                    b.Navigation("RefreshTokens");

                    b.Navigation("VerificationTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
