using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharp_FinalExam.Migrations
{
    /// <inheritdoc />
    public partial class completedesignmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "AspNetRoles",
            //     columns: table => new
            //     {
            //         Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetUsers",
            //     columns: table => new
            //     {
            //         Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //         PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //         TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //         LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //         LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //         AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //     });

            migrationBuilder.CreateTable(
                name: "Truong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTruong = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truong", x => x.Id);
                });

            // migrationBuilder.CreateTable(
            //     name: "AspNetRoleClaims",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //             column: x => x.RoleId,
            //             principalTable: "AspNetRoles",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetUserClaims",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetUserLogins",
            //     columns: table => new
            //     {
            //         LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //         ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //         ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //         table.ForeignKey(
            //             name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetUserRoles",
            //     columns: table => new
            //     {
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //         table.ForeignKey(
            //             name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //             column: x => x.RoleId,
            //             principalTable: "AspNetRoles",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetUserTokens",
            //     columns: table => new
            //     {
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //         Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //         Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //         table.ForeignKey(
            //             name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThanhLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TruongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Khoas_Truong_TruongId",
                        column: x => x.TruongId,
                        principalTable: "Truong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaoViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    KhoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaoViens_Khoas_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHocPhans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HocKy = table.Column<int>(type: "int", nullable: false),
                    SoTinChi = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiaoVienId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHocPhans_GiaoViens_GiaoVienId",
                        column: x => x.GiaoVienId,
                        principalTable: "GiaoViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopSinhHoats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HocKy = table.Column<int>(type: "int", nullable: false),
                    GiaoVienChuNhiemId = table.Column<int>(type: "int", nullable: false),
                    KhoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopSinhHoats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopSinhHoats_GiaoViens_GiaoVienChuNhiemId",
                        column: x => x.GiaoVienChuNhiemId,
                        principalTable: "GiaoViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LopSinhHoats_Khoas_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSinhVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    LopSinhHoatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhViens_LopSinhHoats_LopSinhHoatId",
                        column: x => x.LopSinhHoatId,
                        principalTable: "LopSinhHoats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangKyHocPhans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinhVienId = table.Column<int>(type: "int", nullable: false),
                    LopHocPhanId = table.Column<int>(type: "int", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKyHocPhans", x => new { x.Id, x.LopHocPhanId, x.SinhVienId });
                    table.ForeignKey(
                        name: "FK_DangKyHocPhans_LopHocPhans_LopHocPhanId",
                        column: x => x.LopHocPhanId,
                        principalTable: "LopHocPhans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DangKyHocPhans_SinhViens_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhViens",
                        principalColumn: "Id");
                });

            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetRoleClaims_RoleId",
            //     table: "AspNetRoleClaims",
            //     column: "RoleId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "RoleNameIndex",
            //     table: "AspNetRoles",
            //     column: "NormalizedName",
            //     unique: true,
            //     filter: "[NormalizedName] IS NOT NULL");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUserClaims_UserId",
            //     table: "AspNetUserClaims",
            //     column: "UserId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUserLogins_UserId",
            //     table: "AspNetUserLogins",
            //     column: "UserId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUserRoles_RoleId",
            //     table: "AspNetUserRoles",
            //     column: "RoleId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "EmailIndex",
            //     table: "AspNetUsers",
            //     column: "NormalizedEmail");
            //
            // migrationBuilder.CreateIndex(
            //     name: "UserNameIndex",
            //     table: "AspNetUsers",
            //     column: "NormalizedUserName",
            //     unique: true,
            //     filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHocPhans_LopHocPhanId_SinhVienId",
                table: "DangKyHocPhans",
                columns: new[] { "LopHocPhanId", "SinhVienId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHocPhans_SinhVienId",
                table: "DangKyHocPhans",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoViens_KhoaId",
                table: "GiaoViens",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Khoas_TruongId",
                table: "Khoas",
                column: "TruongId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhans_GiaoVienId",
                table: "LopHocPhans",
                column: "GiaoVienId");

            migrationBuilder.CreateIndex(
                name: "IX_LopSinhHoats_GiaoVienChuNhiemId",
                table: "LopSinhHoats",
                column: "GiaoVienChuNhiemId");

            migrationBuilder.CreateIndex(
                name: "IX_LopSinhHoats_KhoaId",
                table: "LopSinhHoats",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_LopSinhHoatId",
                table: "SinhViens",
                column: "LopSinhHoatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "AspNetRoleClaims");
            //
            // migrationBuilder.DropTable(
            //     name: "AspNetUserClaims");
            //
            // migrationBuilder.DropTable(
            //     name: "AspNetUserLogins");
            //
            // migrationBuilder.DropTable(
            //     name: "AspNetUserRoles");
            //
            // migrationBuilder.DropTable(
            //     name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DangKyHocPhans");

            // migrationBuilder.DropTable(
            //     name: "AspNetRoles");
            //
            // migrationBuilder.DropTable(
            //     name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LopHocPhans");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "LopSinhHoats");

            migrationBuilder.DropTable(
                name: "GiaoViens");

            migrationBuilder.DropTable(
                name: "Khoas");

            migrationBuilder.DropTable(
                name: "Truong");
        }
    }
}
