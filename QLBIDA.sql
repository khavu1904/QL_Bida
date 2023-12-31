USE [master]
GO
/****** Object:  Database [QLBIDA]    Script Date: 21/11/2022 09:31:24 ******/
CREATE DATABASE [QLBIDA1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLBIDA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLBIDA.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLBIDA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLBIDA_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLBIDA] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLBIDA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLBIDA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLBIDA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLBIDA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLBIDA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLBIDA] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLBIDA] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLBIDA] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLBIDA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLBIDA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLBIDA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLBIDA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLBIDA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLBIDA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLBIDA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLBIDA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLBIDA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLBIDA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLBIDA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLBIDA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLBIDA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLBIDA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLBIDA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLBIDA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLBIDA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLBIDA] SET  MULTI_USER 
GO
ALTER DATABASE [QLBIDA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLBIDA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLBIDA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLBIDA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLBIDA]
GO
/****** Object:  Table [dbo].[BAN]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BAN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenBan] [nvarchar](50) NOT NULL,
	[TrangThai] [tinyint] NULL,
	[IDLoaiBan] [int] NULL,
	[SucChua] [int] NULL,
	[isDeleted] [tinyint] NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [varchar](50) NULL,
	[NgayCapNhat] [datetime] NULL,
	[NguoiCapNhat] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CauHinh]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CauHinh](
	[TuKhoa] [varchar](20) NULL,
	[giatri] [nvarchar](150) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChiTietHoaDonBan]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonBan](
	[IDHoaDon] [bigint] NOT NULL,
	[IDMatHang] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC,
	[IDMatHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDonNhap]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonNhap](
	[IDHoaDon] [bigint] NOT NULL,
	[IDMatHang] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC,
	[IDMatHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonViTinh]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DonViTinh](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDVT] [nvarchar](50) NULL,
	[NgayTao] [datetime] NULL,
	[isDeleted] [tinyint] NULL,
	[NguoiTao] [varchar](50) NULL,
	[NgayCapNhat] [datetime] NULL,
	[NguoiCapNhat] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HoaDonBanHang]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDonBanHang](
	[IDHoaDon] [bigint] IDENTITY(1,1) NOT NULL,
	[IDBan] [int] NULL,
	[ThoiGianBatDau] [datetime] NULL,
	[ThoiGianKetThuc] [datetime] NULL,
	[DonGiaBan] [int] NULL,
	[NguoiBan] [varchar](50) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [varchar](50) NULL,
	[NgayCapNhat] [datetime] NULL,
	[NguoiCapNhat] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDonNhap](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[NhanVienNhap] [varchar](50) NOT NULL,
	[TienThanhToan] [int] NULL,
	[DaNhap] [tinyint] NULL,
	[IDNhaCC] [int] NULL,
	[NgayNhap] [datetime] NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[NguoiTao] [varchar](50) NULL,
	[NgayCapNhat] [datetime] NULL,
	[NguoiCapNhat] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiBan]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiBan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiBan] [nvarchar](50) NOT NULL,
	[DonGia] [int] NULL,
	[isDeleted] [tinyint] NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [varchar](50) NULL,
	[NgayCapNhat] [datetime] NULL,
	[NguoiCapNhat] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MatHang]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MatHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenMatHang] [nvarchar](50) NOT NULL,
	[isDichVu] [tinyint] NULL,
	[IDDVT] [int] NULL,
	[DonGiaBan] [int] NOT NULL,
	[IDCha] [int] NULL,
	[Tile] [int] NULL,
	[isDeleted] [tinyint] NULL,
	[NguoiTao] [varchar](50) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiCapNhat] [varchar](50) NULL,
	[NgayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](150) NULL,
	[DienThoai] [varchar](50) NULL,
	[DiaChi] [nvarchar](150) NULL,
	[Email] [varchar](50) NULL,
	[isDeleted] [tinyint] NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [varchar](50) NULL,
	[NgayCapNhat] [datetime] NULL,
	[NguoiCapNhat] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 21/11/2022 09:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[UserName] [varchar](50) NOT NULL,
	[PassWord] [varchar](250) NOT NULL,
	[HoVaTen] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](50) NULL,
	[DiaChi] [varchar](150) NULL,
	[isDeleted] [tinyint] NULL,
	[isAdmin] [tinyint] NULL,
	[NguoiTao] [varchar](50) NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
	[NguoiCapNhat] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[BAN] ADD  CONSTRAINT [DF_BAN_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[BAN] ADD  CONSTRAINT [DF_BAN_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[BAN] ADD  CONSTRAINT [DF_BAN_NguoiTao]  DEFAULT ('admin') FOR [NguoiTao]
GO
ALTER TABLE [dbo].[BAN] ADD  CONSTRAINT [DF_BAN_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[BAN] ADD  CONSTRAINT [DF_BAN_NguoiCapNhat]  DEFAULT ('admin') FOR [NguoiCapNhat]
GO
ALTER TABLE [dbo].[DonViTinh] ADD  CONSTRAINT [DF_DonViTinh_NguoiTao]  DEFAULT ('admin') FOR [NguoiTao]
GO
ALTER TABLE [dbo].[DonViTinh] ADD  CONSTRAINT [DF_DonViTinh_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[DonViTinh] ADD  CONSTRAINT [DF_DonViTinh_NguoiCapNhat]  DEFAULT ('admin') FOR [NguoiCapNhat]
GO
ALTER TABLE [dbo].[HoaDonBanHang] ADD  CONSTRAINT [DF_HoaDonBanHang_ThoiGianBatDau]  DEFAULT (getdate()) FOR [ThoiGianBatDau]
GO
ALTER TABLE [dbo].[HoaDonBanHang] ADD  CONSTRAINT [DF_HoaDonBanHang_ThoiGianKetThuc]  DEFAULT (getdate()) FOR [ThoiGianKetThuc]
GO
ALTER TABLE [dbo].[HoaDonBanHang] ADD  CONSTRAINT [DF_HoaDonBanHang_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[HoaDonBanHang] ADD  CONSTRAINT [DF_HoaDonBanHang_NguoiTao]  DEFAULT ('admin') FOR [NguoiTao]
GO
ALTER TABLE [dbo].[HoaDonBanHang] ADD  CONSTRAINT [DF_HoaDonBanHang_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[HoaDonBanHang] ADD  CONSTRAINT [DF_HoaDonBanHang_NguoiCapNhat]  DEFAULT ('admin') FOR [NguoiCapNhat]
GO
ALTER TABLE [dbo].[HoaDonNhap] ADD  CONSTRAINT [DF_HoaDonNhap_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[HoaDonNhap] ADD  CONSTRAINT [DF_HoaDonNhap_NguoiTao]  DEFAULT ('admin') FOR [NguoiTao]
GO
ALTER TABLE [dbo].[HoaDonNhap] ADD  CONSTRAINT [DF_HoaDonNhap_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[HoaDonNhap] ADD  CONSTRAINT [DF_HoaDonNhap_NguoiCapNhat]  DEFAULT ('admin') FOR [NguoiCapNhat]
GO
ALTER TABLE [dbo].[LoaiBan] ADD  CONSTRAINT [DF_LoaiBan_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[LoaiBan] ADD  CONSTRAINT [DF_LoaiBan_NguoiTao]  DEFAULT ('admin') FOR [NguoiTao]
GO
ALTER TABLE [dbo].[LoaiBan] ADD  CONSTRAINT [DF_LoaiBan_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[LoaiBan] ADD  CONSTRAINT [DF_LoaiBan_NguoiCapNhat]  DEFAULT ('admin') FOR [NguoiCapNhat]
GO
ALTER TABLE [dbo].[MatHang] ADD  CONSTRAINT [DF_MatHang_NguoiTao]  DEFAULT ('admin') FOR [NguoiTao]
GO
ALTER TABLE [dbo].[MatHang] ADD  CONSTRAINT [DF_MatHang_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[MatHang] ADD  CONSTRAINT [DF_MatHang_NguoiCapNhat]  DEFAULT ('admin') FOR [NguoiCapNhat]
GO
ALTER TABLE [dbo].[MatHang] ADD  CONSTRAINT [DF_MatHang_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [DF_NhaCungCap_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [DF_NhaCungCap_NguoiTao]  DEFAULT ('admin') FOR [NguoiTao]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [DF_NhaCungCap_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [DF_NhaCungCap_NguoiCapNhat]  DEFAULT ('admin') FOR [NguoiCapNhat]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [DF_NhanVien_NguoiTao]  DEFAULT ('admin') FOR [NguoiTao]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [DF_NhanVien_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [DF_NhanVien_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [DF_NhanVien_NguoiCapNhat]  DEFAULT ('admin') FOR [NguoiCapNhat]
GO
ALTER TABLE [dbo].[BAN]  WITH CHECK ADD  CONSTRAINT [FK_BAN_LoaiBan] FOREIGN KEY([IDLoaiBan])
REFERENCES [dbo].[LoaiBan] ([ID])
GO
ALTER TABLE [dbo].[BAN] CHECK CONSTRAINT [FK_BAN_LoaiBan]
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDonBan_HoaDonBanHang] FOREIGN KEY([IDHoaDon])
REFERENCES [dbo].[HoaDonBanHang] ([IDHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan] CHECK CONSTRAINT [FK_ChiTietHoaDonBan_HoaDonBanHang]
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDonBan_MatHang] FOREIGN KEY([IDMatHang])
REFERENCES [dbo].[MatHang] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan] CHECK CONSTRAINT [FK_ChiTietHoaDonBan_MatHang]
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDonNhap_HoaDonNhap] FOREIGN KEY([IDHoaDon])
REFERENCES [dbo].[HoaDonNhap] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap] CHECK CONSTRAINT [FK_ChiTietHoaDonNhap_HoaDonNhap]
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDonNhap_MatHang] FOREIGN KEY([IDMatHang])
REFERENCES [dbo].[MatHang] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap] CHECK CONSTRAINT [FK_ChiTietHoaDonNhap_MatHang]
GO
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBanHang_BAN] FOREIGN KEY([IDBan])
REFERENCES [dbo].[BAN] ([ID])
GO
ALTER TABLE [dbo].[HoaDonBanHang] CHECK CONSTRAINT [FK_HoaDonBanHang_BAN]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhap_NhaCungCap] FOREIGN KEY([IDNhaCC])
REFERENCES [dbo].[NhaCungCap] ([ID])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK_HoaDonNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[MatHang]  WITH CHECK ADD  CONSTRAINT [FK_MatHang_DonViTinh] FOREIGN KEY([IDDVT])
REFERENCES [dbo].[DonViTinh] ([ID])
GO
ALTER TABLE [dbo].[MatHang] CHECK CONSTRAINT [FK_MatHang_DonViTinh]
GO
USE [master]
GO
ALTER DATABASE [QLBIDA] SET  READ_WRITE 
GO
