using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharp_FinalExam.Migrations
{
    /// <inheritdoc />
    public partial class addSinhVienImagesTheSvCCCD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDangKy",
                table: "DangKyHocPhans",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "SinhVienCccds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheSVUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SinhVienId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienCccds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVienCccds_SinhViens_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SinhVienId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVienImages_SinhViens_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienTheSvs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheSVUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SinhVienId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienTheSvs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVienTheSvs_SinhViens_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienCccds_SinhVienId",
                table: "SinhVienCccds",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienImages_SinhVienId",
                table: "SinhVienImages",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienTheSvs_SinhVienId",
                table: "SinhVienTheSvs",
                column: "SinhVienId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhVienCccds");

            migrationBuilder.DropTable(
                name: "SinhVienImages");

            migrationBuilder.DropTable(
                name: "SinhVienTheSvs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDangKy",
                table: "DangKyHocPhans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
