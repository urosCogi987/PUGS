﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaxiApp.Persistence;

#nullable disable

namespace TaxiApp.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240618120700_DriveEntity")]
    partial class DriveEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("0010b5d1-dbbb-47da-8a53-94d510fd9463"),
                            Name = "RoleAdmin"
                        },
                        new
                        {
                            Id = new Guid("c115ef09-0891-40c3-92a2-bfc38f213ca8"),
                            Name = "CanViewAllUsers"
                        },
                        new
                        {
                            Id = new Guid("ccae34e0-a8cf-407a-996f-ccf0e014a308"),
                            Name = "CanViewAllDrives"
                        },
                        new
                        {
                            Id = new Guid("ce14a253-f422-49e1-8b14-a43aab4d15c5"),
                            Name = "CanRequestDrive"
                        },
                        new
                        {
                            Id = new Guid("cb852d8a-763e-42a1-9f9f-cac6806af838"),
                            Name = "CanAcceptDrive"
                        },
                        new
                        {
                            Id = new Guid("94ecddb9-de75-4810-ab47-8a64830c916f"),
                            Name = "CanViewHisDrives"
                        },
                        new
                        {
                            Id = new Guid("c1a60cce-5232-4940-8f9a-4c0befc006d7"),
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
                            Id = new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("24e11c70-3b4d-4497-9998-2e6225505dc9"),
                            Name = "User"
                        },
                        new
                        {
                            Id = new Guid("38ee5a93-9cf2-4457-bf6e-3e715e7dc29a"),
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
                            Id = new Guid("92b9f6d5-8039-444b-b3df-5970f1446f5a"),
                            PermissionId = new Guid("0010b5d1-dbbb-47da-8a53-94d510fd9463"),
                            RoleId = new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08")
                        },
                        new
                        {
                            Id = new Guid("417edcd8-dd27-4318-966a-bd091ca4a7bf"),
                            PermissionId = new Guid("c115ef09-0891-40c3-92a2-bfc38f213ca8"),
                            RoleId = new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08")
                        },
                        new
                        {
                            Id = new Guid("5dcb3beb-4b0f-4f56-b803-ae6f7ba05545"),
                            PermissionId = new Guid("ccae34e0-a8cf-407a-996f-ccf0e014a308"),
                            RoleId = new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08")
                        },
                        new
                        {
                            Id = new Guid("7f382a7f-6ef0-4543-b643-cf0dcad2b7be"),
                            PermissionId = new Guid("c1a60cce-5232-4940-8f9a-4c0befc006d7"),
                            RoleId = new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08")
                        },
                        new
                        {
                            Id = new Guid("2f85575a-cebb-4ace-bef6-2ab638cba013"),
                            PermissionId = new Guid("c1a60cce-5232-4940-8f9a-4c0befc006d7"),
                            RoleId = new Guid("24e11c70-3b4d-4497-9998-2e6225505dc9")
                        },
                        new
                        {
                            Id = new Guid("855629a1-2d73-498b-9d12-26fada4cbe6f"),
                            PermissionId = new Guid("ce14a253-f422-49e1-8b14-a43aab4d15c5"),
                            RoleId = new Guid("24e11c70-3b4d-4497-9998-2e6225505dc9")
                        },
                        new
                        {
                            Id = new Guid("d0d554b7-fc98-4f31-ba24-8aa1516c526e"),
                            PermissionId = new Guid("94ecddb9-de75-4810-ab47-8a64830c916f"),
                            RoleId = new Guid("24e11c70-3b4d-4497-9998-2e6225505dc9")
                        },
                        new
                        {
                            Id = new Guid("a6874f99-b55a-4f64-8774-0b1321e36669"),
                            PermissionId = new Guid("c1a60cce-5232-4940-8f9a-4c0befc006d7"),
                            RoleId = new Guid("38ee5a93-9cf2-4457-bf6e-3e715e7dc29a")
                        },
                        new
                        {
                            Id = new Guid("7e20bdd4-ec47-45cb-bac4-e2d711043f7e"),
                            PermissionId = new Guid("cb852d8a-763e-42a1-9f9f-cac6806af838"),
                            RoleId = new Guid("38ee5a93-9cf2-4457-bf6e-3e715e7dc29a")
                        },
                        new
                        {
                            Id = new Guid("8fd21ab8-2d2f-4088-850f-cc4b3a9c3777"),
                            PermissionId = new Guid("94ecddb9-de75-4810-ab47-8a64830c916f"),
                            RoleId = new Guid("38ee5a93-9cf2-4457-bf6e-3e715e7dc29a")
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
                            Id = new Guid("39a62e0a-abd4-461c-a6ea-561bea8036f5"),
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
                            Id = new Guid("76f0cb0c-5322-4d08-8381-2e71c8754293"),
                            RoleId = new Guid("c6d9d9c8-777d-4d65-a7dd-eb7aea755c08"),
                            UserId = new Guid("39a62e0a-abd4-461c-a6ea-561bea8036f5")
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