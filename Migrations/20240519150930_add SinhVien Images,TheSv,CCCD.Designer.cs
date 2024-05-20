﻿// <auto-generated />
using System;
using CSharp_FinalExam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSharp_FinalExam.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240519150930_add SinhVien Images,TheSv,CCCD")]
    partial class addSinhVienImagesTheSvCCCD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CSharp_FinalExam.Models.DangKyHocPhan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LopHocPhanId")
                        .HasColumnType("int");

                    b.Property<int>("SinhVienId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "LopHocPhanId", "SinhVienId");

                    b.HasIndex("SinhVienId");

                    b.HasIndex("LopHocPhanId", "SinhVienId")
                        .IsUnique();

                    b.ToTable("DangKyHocPhans");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.GiaoVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("KhoaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KhoaId");

                    b.ToTable("GiaoViens");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.Identity.ApplicationIdentityUser", b =>
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

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

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

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.Khoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("NgayThanhLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TruongId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TruongId");

                    b.ToTable("Khoas");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.LopHocPhan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GiaoVienId")
                        .HasColumnType("int");

                    b.Property<int>("HocKy")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoTinChi")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GiaoVienId");

                    b.ToTable("LopHocPhans");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.LopSinhHoat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GiaoVienChuNhiemId")
                        .HasColumnType("int");

                    b.Property<int>("HocKy")
                        .HasColumnType("int");

                    b.Property<int>("KhoaId")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GiaoVienChuNhiemId");

                    b.HasIndex("KhoaId");

                    b.ToTable("LopSinhHoats");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.SinhVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LopSinhHoatId")
                        .HasColumnType("int");

                    b.Property<string>("MaSinhVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LopSinhHoatId");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.SinhVienCCCD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SinhVienId")
                        .HasColumnType("int");

                    b.Property<string>("TheSVUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SinhVienId");

                    b.ToTable("SinhVienCccds");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.SinhVienImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SinhVienId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SinhVienId");

                    b.ToTable("SinhVienImages");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.SinhVienTheSV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SinhVienId")
                        .HasColumnType("int");

                    b.Property<string>("TheSVUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SinhVienId");

                    b.ToTable("SinhVienTheSvs");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.Truong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenTruong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Truong");
                });

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.DangKyHocPhan", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.LopHocPhan", "LopHocPhan")
                        .WithMany("DangKyHocPhans")
                        .HasForeignKey("LopHocPhanId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CSharp_FinalExam.Models.SinhVien", "SinhVien")
                        .WithMany("DangKyHocPhans")
                        .HasForeignKey("SinhVienId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("LopHocPhan");

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.GiaoVien", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.Khoa", "Khoa")
                        .WithMany("GiaoViens")
                        .HasForeignKey("KhoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.Khoa", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.Truong", "Truong")
                        .WithMany("Khoas")
                        .HasForeignKey("TruongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Truong");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.LopHocPhan", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.GiaoVien", "GiaoVien")
                        .WithMany()
                        .HasForeignKey("GiaoVienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GiaoVien");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.LopSinhHoat", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.GiaoVien", "GiaoVien")
                        .WithMany()
                        .HasForeignKey("GiaoVienChuNhiemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSharp_FinalExam.Models.Khoa", "Khoa")
                        .WithMany("LopSinhHoats")
                        .HasForeignKey("KhoaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GiaoVien");

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.SinhVien", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.LopSinhHoat", "LopSinhHoat")
                        .WithMany("SinhViens")
                        .HasForeignKey("LopSinhHoatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LopSinhHoat");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.SinhVienCCCD", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("SinhVienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.SinhVienImage", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("SinhVienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.SinhVienTheSV", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("SinhVienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SinhVien");
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
                    b.HasOne("CSharp_FinalExam.Models.Identity.ApplicationIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.Identity.ApplicationIdentityUser", null)
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

                    b.HasOne("CSharp_FinalExam.Models.Identity.ApplicationIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CSharp_FinalExam.Models.Identity.ApplicationIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.Khoa", b =>
                {
                    b.Navigation("GiaoViens");

                    b.Navigation("LopSinhHoats");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.LopHocPhan", b =>
                {
                    b.Navigation("DangKyHocPhans");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.LopSinhHoat", b =>
                {
                    b.Navigation("SinhViens");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.SinhVien", b =>
                {
                    b.Navigation("DangKyHocPhans");
                });

            modelBuilder.Entity("CSharp_FinalExam.Models.Truong", b =>
                {
                    b.Navigation("Khoas");
                });
#pragma warning restore 612, 618
        }
    }
}
