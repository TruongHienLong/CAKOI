﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QL_BanHangManh_Thang.Models;

namespace QL_BanHangManh_Thang.Migrations
{
    [DbContext(typeof(WebBanHangDBContext))]
    [Migration("20230928140813_ExtendColumnIdentityy")]
    partial class ExtendColumnIdentityy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("QL_BanHangManh_Thang.Models.DanhMucSP", b =>
                {
                    b.Property<string>("IdDanhMucSP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenDanhMucSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDanhMucSP");

                    b.ToTable("DanhMucSPs");

                    b.HasData(
                        new
                        {
                            IdDanhMucSP = "DT",
                            TenDanhMucSP = "Điện thoại"
                        },
                        new
                        {
                            IdDanhMucSP = "GM",
                            TenDanhMucSP = "Game"
                        },
                        new
                        {
                            IdDanhMucSP = "PK",
                            TenDanhMucSP = "Phụ Kiện"
                        },
                        new
                        {
                            IdDanhMucSP = "MT",
                            TenDanhMucSP = "Máy Tính"
                        });
                });

            modelBuilder.Entity("QL_BanHangManh_Thang.Models.LoaiSP", b =>
                {
                    b.Property<string>("IdLoaiSP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDanhMucSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenLoaiSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLoaiSP");

                    b.HasIndex("IdDanhMucSP");

                    b.ToTable("LoaiSPs");

                    b.HasData(
                        new
                        {
                            IdLoaiSP = "IP",
                            IdDanhMucSP = "DT",
                            TenLoaiSP = "Iphone"
                        },
                        new
                        {
                            IdLoaiSP = "Ard",
                            IdDanhMucSP = "DT",
                            TenLoaiSP = "Android"
                        },
                        new
                        {
                            IdLoaiSP = "MI",
                            IdDanhMucSP = "DT",
                            TenLoaiSP = "XiaoMi"
                        },
                        new
                        {
                            IdLoaiSP = "MTB",
                            IdDanhMucSP = "DT",
                            TenLoaiSP = "Máy tính bảng"
                        },
                        new
                        {
                            IdLoaiSP = "PS",
                            IdDanhMucSP = "GM",
                            TenLoaiSP = "Máy chơi game PlayStayion"
                        },
                        new
                        {
                            IdLoaiSP = "NTD",
                            IdDanhMucSP = "GM",
                            TenLoaiSP = "Máy chơi game NinTenDo"
                        },
                        new
                        {
                            IdLoaiSP = "CTR",
                            IdDanhMucSP = "GM",
                            TenLoaiSP = "Máy chơi game cầm tay"
                        },
                        new
                        {
                            IdLoaiSP = "TN",
                            IdDanhMucSP = "PK",
                            TenLoaiSP = "Tai nghe"
                        },
                        new
                        {
                            IdLoaiSP = "BP",
                            IdDanhMucSP = "PK",
                            TenLoaiSP = "Bàn Phím"
                        },
                        new
                        {
                            IdLoaiSP = "CH",
                            IdDanhMucSP = "PK",
                            TenLoaiSP = "Chuột"
                        },
                        new
                        {
                            IdLoaiSP = "DG",
                            IdDanhMucSP = "PK",
                            TenLoaiSP = "Đĩa Game"
                        },
                        new
                        {
                            IdLoaiSP = "LT",
                            IdDanhMucSP = "MT",
                            TenLoaiSP = "LapTop"
                        },
                        new
                        {
                            IdLoaiSP = "PC",
                            IdDanhMucSP = "MT",
                            TenLoaiSP = "Máy tính bàn"
                        });
                });

            modelBuilder.Entity("QL_BanHangManh_Thang.Models.MauSac", b =>
                {
                    b.Property<int>("IdMauSac")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenMau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMauSac");

                    b.ToTable("MauSacs");

                    b.HasData(
                        new
                        {
                            IdMauSac = 1,
                            TenMau = "Đỏ"
                        },
                        new
                        {
                            IdMauSac = 2,
                            TenMau = "Xanh"
                        });
                });

            modelBuilder.Entity("QL_BanHangManh_Thang.Models.SanPham", b =>
                {
                    b.Property<int>("IdSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Gia")
                        .HasColumnType("float");

                    b.Property<string>("IdLoaicSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdMauSac")
                        .HasColumnType("int");

                    b.Property<int>("IdSPTonKho")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSanPham");

                    b.HasIndex("IdLoaicSP");

                    b.HasIndex("IdMauSac");

                    b.HasIndex("IdSPTonKho");

                    b.ToTable("SanPhams");

                    b.HasData(
                        new
                        {
                            IdSanPham = 1,
                            Gia = 300.0,
                            IdLoaicSP = "IP",
                            IdMauSac = 1,
                            IdSPTonKho = 0,
                            SoLuong = 1,
                            TenSanPham = "Iphone 7"
                        },
                        new
                        {
                            IdSanPham = 2,
                            Gia = 300.0,
                            IdLoaicSP = "IP",
                            IdMauSac = 1,
                            IdSPTonKho = 0,
                            SoLuong = 2,
                            TenSanPham = "Iphone 8"
                        });
                });

            modelBuilder.Entity("QL_BanHangManh_Thang.Models.TonKho", b =>
                {
                    b.Property<int>("IdSPTonKho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("IdSPTonKho");

                    b.ToTable("TonKhos");

                    b.HasData(
                        new
                        {
                            IdSPTonKho = 1,
                            SoLuong = 1
                        });
                });

            modelBuilder.Entity("QL_BanHangManh_Thang.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QL_BanHangManh_Thang.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QL_BanHangManh_Thang.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QL_BanHangManh_Thang.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QL_BanHangManh_Thang.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QL_BanHangManh_Thang.Models.LoaiSP", b =>
                {
                    b.HasOne("QL_BanHangManh_Thang.Models.DanhMucSP", "DanhMucSP")
                        .WithMany()
                        .HasForeignKey("IdDanhMucSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucSP");
                });

            modelBuilder.Entity("QL_BanHangManh_Thang.Models.SanPham", b =>
                {
                    b.HasOne("QL_BanHangManh_Thang.Models.LoaiSP", "LoaiSP")
                        .WithMany()
                        .HasForeignKey("IdLoaicSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QL_BanHangManh_Thang.Models.MauSac", "MauSac")
                        .WithMany()
                        .HasForeignKey("IdMauSac")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QL_BanHangManh_Thang.Models.TonKho", "TonKho")
                        .WithMany()
                        .HasForeignKey("IdSPTonKho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSP");

                    b.Navigation("MauSac");

                    b.Navigation("TonKho");
                });
#pragma warning restore 612, 618
        }
    }
}
