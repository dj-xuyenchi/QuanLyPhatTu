using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS_Infrastructure.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayThanhLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TruTri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapNhat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chua", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KieuThanhVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKieu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KieuThanhVien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhatTu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhapDanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhChup = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayXuatGia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaHoanTuc = table.Column<bool>(type: "bit", nullable: false),
                    NgayHoanTuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    KieuThanhVienId = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChuaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhatTu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhatTu_Chua_ChuaId",
                        column: x => x.ChuaId,
                        principalTable: "Chua",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhatTu_KieuThanhVien_KieuThanhVienId",
                        column: x => x.KieuThanhVienId,
                        principalTable: "KieuThanhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DaoTrang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiToChuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoThanhVienThamGia = table.Column<int>(type: "int", nullable: false),
                    NguoiChuTriId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianToChuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaKetThuc = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaoTrang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaoTrang_PhatTu_NguoiChuTriId",
                        column: x => x.NguoiChuTriId,
                        principalTable: "PhatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonDangKy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhatTuId = table.Column<int>(type: "int", nullable: false),
                    TrangThaiDon = table.Column<int>(type: "int", nullable: false),
                    NgayGuiDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySuLy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiSuLyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDangKy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonDangKy_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhatTuDaoTrang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhatTuId = table.Column<int>(type: "int", nullable: true),
                    DaoTrangId = table.Column<int>(type: "int", nullable: false),
                    DaThamGia = table.Column<bool>(type: "bit", nullable: false),
                    LyDoKhongThamGia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhatTuDaoTrang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhatTuDaoTrang_DaoTrang_DaoTrangId",
                        column: x => x.DaoTrangId,
                        principalTable: "DaoTrang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhatTuDaoTrang_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaoTrang_NguoiChuTriId",
                table: "DaoTrang",
                column: "NguoiChuTriId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKy_PhatTuId",
                table: "DonDangKy",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTu_ChuaId",
                table: "PhatTu",
                column: "ChuaId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTu_KieuThanhVienId",
                table: "PhatTu",
                column: "KieuThanhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTuDaoTrang_DaoTrangId",
                table: "PhatTuDaoTrang",
                column: "DaoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTuDaoTrang_PhatTuId",
                table: "PhatTuDaoTrang",
                column: "PhatTuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonDangKy");

            migrationBuilder.DropTable(
                name: "PhatTuDaoTrang");

            migrationBuilder.DropTable(
                name: "DaoTrang");

            migrationBuilder.DropTable(
                name: "PhatTu");

            migrationBuilder.DropTable(
                name: "Chua");

            migrationBuilder.DropTable(
                name: "KieuThanhVien");
        }
    }
}
