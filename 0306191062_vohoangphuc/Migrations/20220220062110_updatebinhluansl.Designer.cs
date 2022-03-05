﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _0306191062_vohoangphuc.Data;

namespace _0306191062_vohoangphuc.Migrations
{
    [DbContext(typeof(_0306191062_vohoangphucContext))]
    [Migration("20220220062110_updatebinhluansl")]
    partial class updatebinhluansl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.BinhLuan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LoiBinhLuan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("TaiKhoanId")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("SanPhamId");

                    b.HasIndex("TaiKhoanId");

                    b.ToTable("BinhLuan");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.ChiTietHoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DonGia")
                        .HasColumnType("bigint");

                    b.Property<int>("HoaDonId")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HoaDonId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("ChiTietHoaDons");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.DanhGiaKhachHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LoiDanhGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaiKhoanId")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaiKhoanId");

                    b.ToTable("DanhGiaKhachHangs");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.GioHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("TaiKhoanId")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("SanPhamId");

                    b.HasIndex("TaiKhoanId");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.HoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChiGiaoHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTaoHoaDon")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDTNguoiGiao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaiKhoanId")
                        .HasColumnType("int");

                    b.Property<string>("TenNguoiGiaoHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiNhanHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TongTien")
                        .HasColumnType("bigint");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaiKhoanId");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.LoaiSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("LoaiSanPhams");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CongSuat")
                        .HasColumnType("int");

                    b.Property<bool>("CuaSoTroi")
                        .HasColumnType("bit");

                    b.Property<string>("DongCo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Gia")
                        .HasColumnType("bigint");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiSanPhamId")
                        .HasColumnType("int");

                    b.Property<string>("MauNoiThat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TocDoTangToc")
                        .HasColumnType("real");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoaiSanPhamId");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.SlideShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("SlideShows");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.TaiKhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TaiKhoans");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.BinhLuan", b =>
                {
                    b.HasOne("_0306191062_vohoangphuc.Areas.Admin.Models.SanPham", "SanPham")
                        .WithMany("DanhGiaSanPhams")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_0306191062_vohoangphuc.Areas.Admin.Models.TaiKhoan", "TaiKhoan")
                        .WithMany("DanhGiaSanPhams")
                        .HasForeignKey("TaiKhoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.ChiTietHoaDon", b =>
                {
                    b.HasOne("_0306191062_vohoangphuc.Areas.Admin.Models.HoaDon", "HoaDon")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("HoaDonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_0306191062_vohoangphuc.Areas.Admin.Models.SanPham", "SanPham")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.DanhGiaKhachHang", b =>
                {
                    b.HasOne("_0306191062_vohoangphuc.Areas.Admin.Models.TaiKhoan", "TaiKhoan")
                        .WithMany("DanhGiaKhachHangs")
                        .HasForeignKey("TaiKhoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.GioHang", b =>
                {
                    b.HasOne("_0306191062_vohoangphuc.Areas.Admin.Models.SanPham", "SanPham")
                        .WithMany("GioHangs")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_0306191062_vohoangphuc.Areas.Admin.Models.TaiKhoan", "TaiKhoan")
                        .WithMany("GioHangs")
                        .HasForeignKey("TaiKhoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.HoaDon", b =>
                {
                    b.HasOne("_0306191062_vohoangphuc.Areas.Admin.Models.TaiKhoan", "TaiKhoan")
                        .WithMany("HoaDons")
                        .HasForeignKey("TaiKhoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.SanPham", b =>
                {
                    b.HasOne("_0306191062_vohoangphuc.Areas.Admin.Models.LoaiSanPham", "LoaiSanPham")
                        .WithMany("SanPhams")
                        .HasForeignKey("LoaiSanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSanPham");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.HoaDon", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.LoaiSanPham", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.SanPham", b =>
                {
                    b.Navigation("ChiTietHoaDons");

                    b.Navigation("DanhGiaSanPhams");

                    b.Navigation("GioHangs");
                });

            modelBuilder.Entity("_0306191062_vohoangphuc.Areas.Admin.Models.TaiKhoan", b =>
                {
                    b.Navigation("DanhGiaKhachHangs");

                    b.Navigation("DanhGiaSanPhams");

                    b.Navigation("GioHangs");

                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}
