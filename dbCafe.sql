USE [dbQuanLyCafe]
GO
/****** Object:  Table [dbo].[tbBan]    Script Date: 17/11/2024 1:23:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbBan](
	[ban_id] [int] IDENTITY(1,1) NOT NULL,
	[ban_ten] [nvarchar](max) NULL,
	[ban_trangthai] [nvarchar](max) NULL,
	[khuvuc_id] [int] NULL,
	[khuvuc_ten] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ban_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbHoaDon]    Script Date: 17/11/2024 1:23:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbHoaDon](
	[hoadon_id] [int] IDENTITY(1,1) NOT NULL,
	[hoadon_ngaynhap] [datetime] NULL,
	[hoadon_ngayxuat] [datetime] NULL,
	[ban_id] [int] NULL,
	[hoadon_trangthai] [int] NULL,
	[hoadon_mahoadon] [nvarchar](max) NULL,
	[hoadon_tongtien] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[hoadon_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbHoaDonChiTiet]    Script Date: 17/11/2024 1:23:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbHoaDonChiTiet](
	[hoadonchitiet_id] [int] IDENTITY(1,1) NOT NULL,
	[hoadon_id] [int] NULL,
	[thanhpham_id] [int] NULL,
	[thanhpham_soluong] [int] NULL,
	[ban_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[hoadonchitiet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbKhuVuc]    Script Date: 17/11/2024 1:23:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbKhuVuc](
	[khuvuc_id] [int] IDENTITY(1,1) NOT NULL,
	[khuvuc_ten] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[khuvuc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbLoaiSanPham]    Script Date: 17/11/2024 1:23:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbLoaiSanPham](
	[loaisanpham_id] [int] IDENTITY(1,1) NOT NULL,
	[loaisanpham_ten] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[loaisanpham_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbNguyenLieu]    Script Date: 17/11/2024 1:23:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbNguyenLieu](
	[nguyenlieu_id] [int] IDENTITY(1,1) NOT NULL,
	[nguyenlieu_ten] [nvarchar](max) NULL,
	[nguyenlieu_nhacungcap] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[nguyenlieu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbNhapHang]    Script Date: 17/11/2024 1:23:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbNhapHang](
	[nhaphang_id] [nvarchar](255) NOT NULL,
	[nhaphang_ngaynhap] [datetime] NULL,
	[nhaphang_tongtien] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[nhaphang_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbNhapHangChiTiet]    Script Date: 17/11/2024 1:23:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbNhapHangChiTiet](
	[nhaphangchitiet_id] [int] IDENTITY(1,1) NOT NULL,
	[nhaphangchitiet_sanpham] [nvarchar](max) NULL,
	[nguyenlieu_nhacungcap] [nvarchar](max) NULL,
	[nhaphangchitiet_soluong] [int] NULL,
	[nhaphangchitiet_dongia] [int] NULL,
	[nhaphangchitiet_thanhtien]  AS ([nhaphangchitiet_soluong]*[nhaphangchitiet_dongia]),
	[nhaphang_id] [nvarchar](255) NULL,
	[nguyenlieu_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[nhaphangchitiet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbTaiKhoan]    Script Date: 17/11/2024 1:23:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTaiKhoan](
	[taikhoan_id] [int] IDENTITY(1,1) NOT NULL,
	[taikhoan_hoten] [nvarchar](max) NULL,
	[taikhoan_tentaikhoan] [nvarchar](255) NULL,
	[taikhoan_matkhau] [nvarchar](max) NULL,
	[taikhoan_hinhanh] [nvarchar](max) NULL,
	[taikhoan_quyen] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[taikhoan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbThanhPham]    Script Date: 17/11/2024 1:23:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbThanhPham](
	[thanhpham_id] [int] IDENTITY(1,1) NOT NULL,
	[thanhpham_ten] [nvarchar](max) NULL,
	[thanhpham_soluong] [int] NULL,
	[thanhpham_dongia] [decimal](15, 0) NULL,
	[loaisanpham_id] [int] NULL,
	[loaisanpham_ten] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[thanhpham_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbBan] ON 

INSERT [dbo].[tbBan] ([ban_id], [ban_ten], [ban_trangthai], [khuvuc_id], [khuvuc_ten]) VALUES (1, N'Bàn số 01', N'Trống', 1, N'Khu A')
INSERT [dbo].[tbBan] ([ban_id], [ban_ten], [ban_trangthai], [khuvuc_id], [khuvuc_ten]) VALUES (2, N'Bàn số 02 ', N'Trống', 1, N'Khu A')
INSERT [dbo].[tbBan] ([ban_id], [ban_ten], [ban_trangthai], [khuvuc_id], [khuvuc_ten]) VALUES (7, N'Bàn số 03', N'Có người', 1, N'Khu A')
INSERT [dbo].[tbBan] ([ban_id], [ban_ten], [ban_trangthai], [khuvuc_id], [khuvuc_ten]) VALUES (8, N'Bàn số 04', N'Trống', 2, N'Khu B')
INSERT [dbo].[tbBan] ([ban_id], [ban_ten], [ban_trangthai], [khuvuc_id], [khuvuc_ten]) VALUES (9, N'Bàn số 05', N'Trống', 2, N'Khu B')
INSERT [dbo].[tbBan] ([ban_id], [ban_ten], [ban_trangthai], [khuvuc_id], [khuvuc_ten]) VALUES (10, N'Bàn số 06', N'Trống', 2, N'Khu B')
INSERT [dbo].[tbBan] ([ban_id], [ban_ten], [ban_trangthai], [khuvuc_id], [khuvuc_ten]) VALUES (11, N'Bàn số 07', N'Trống', 3, N'Khu C')
INSERT [dbo].[tbBan] ([ban_id], [ban_ten], [ban_trangthai], [khuvuc_id], [khuvuc_ten]) VALUES (12, N'Bàn số 08', N'Trống', 3, N'Khu C')
INSERT [dbo].[tbBan] ([ban_id], [ban_ten], [ban_trangthai], [khuvuc_id], [khuvuc_ten]) VALUES (15, N'Bàn số 09', N'Trống', 3, N'Khu C')
INSERT [dbo].[tbBan] ([ban_id], [ban_ten], [ban_trangthai], [khuvuc_id], [khuvuc_ten]) VALUES (16, N'Bàn số 10', N'Trống', 1, N'Khu A')
SET IDENTITY_INSERT [dbo].[tbBan] OFF
GO
SET IDENTITY_INSERT [dbo].[tbHoaDon] ON 

INSERT [dbo].[tbHoaDon] ([hoadon_id], [hoadon_ngaynhap], [hoadon_ngayxuat], [ban_id], [hoadon_trangthai], [hoadon_mahoadon], [hoadon_tongtien]) VALUES (1154, CAST(N'2024-09-01T10:28:50.000' AS DateTime), CAST(N'2024-09-01T08:58:13.000' AS DateTime), 1, 1, N'HD0007', CAST(114000 AS Decimal(18, 0)))
INSERT [dbo].[tbHoaDon] ([hoadon_id], [hoadon_ngaynhap], [hoadon_ngayxuat], [ban_id], [hoadon_trangthai], [hoadon_mahoadon], [hoadon_tongtien]) VALUES (1156, CAST(N'2024-09-09T15:59:47.000' AS DateTime), CAST(N'2024-09-09T08:58:10.000' AS DateTime), 2, 1, N'HD0008', CAST(18000 AS Decimal(18, 0)))
INSERT [dbo].[tbHoaDon] ([hoadon_id], [hoadon_ngaynhap], [hoadon_ngayxuat], [ban_id], [hoadon_trangthai], [hoadon_mahoadon], [hoadon_tongtien]) VALUES (1157, CAST(N'2024-09-12T09:10:19.593' AS DateTime), CAST(N'2024-09-12T09:10:50.023' AS DateTime), 1, 1, N'HD0009', CAST(97000 AS Decimal(18, 0)))
INSERT [dbo].[tbHoaDon] ([hoadon_id], [hoadon_ngaynhap], [hoadon_ngayxuat], [ban_id], [hoadon_trangthai], [hoadon_mahoadon], [hoadon_tongtien]) VALUES (1160, CAST(N'2024-09-12T09:37:05.793' AS DateTime), NULL, 7, 0, N'HD0012', CAST(75000 AS Decimal(18, 0)))
INSERT [dbo].[tbHoaDon] ([hoadon_id], [hoadon_ngaynhap], [hoadon_ngayxuat], [ban_id], [hoadon_trangthai], [hoadon_mahoadon], [hoadon_tongtien]) VALUES (1164, CAST(N'2024-09-12T10:28:58.070' AS DateTime), CAST(N'2024-10-17T14:52:38.210' AS DateTime), 16, 1, N'HD0015', CAST(72000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[tbHoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[tbHoaDonChiTiet] ON 

INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1191, 1160, 3, 1, 7)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1192, 1160, 3, 1, 7)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1193, 1160, 3, 1, 7)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1204, 1176, 1, 1, 8)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1205, 1176, 1, 1, 8)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1206, 1176, 1, 1, 8)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1210, 1184, 1, 1, 8)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1211, 1184, 1, 1, 8)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1212, 1184, 1, 1, 8)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1216, 1192, 1, 1, 8)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1217, 1192, 1, 1, 8)
INSERT [dbo].[tbHoaDonChiTiet] ([hoadonchitiet_id], [hoadon_id], [thanhpham_id], [thanhpham_soluong], [ban_id]) VALUES (1218, 1192, 1, 1, 8)
SET IDENTITY_INSERT [dbo].[tbHoaDonChiTiet] OFF
GO
SET IDENTITY_INSERT [dbo].[tbKhuVuc] ON 

INSERT [dbo].[tbKhuVuc] ([khuvuc_id], [khuvuc_ten]) VALUES (1, N'Khu A')
INSERT [dbo].[tbKhuVuc] ([khuvuc_id], [khuvuc_ten]) VALUES (2, N'Khu B')
INSERT [dbo].[tbKhuVuc] ([khuvuc_id], [khuvuc_ten]) VALUES (3, N'Khu C')
INSERT [dbo].[tbKhuVuc] ([khuvuc_id], [khuvuc_ten]) VALUES (4, N'All')
SET IDENTITY_INSERT [dbo].[tbKhuVuc] OFF
GO
SET IDENTITY_INSERT [dbo].[tbLoaiSanPham] ON 

INSERT [dbo].[tbLoaiSanPham] ([loaisanpham_id], [loaisanpham_ten]) VALUES (1, N'Cà phê')
INSERT [dbo].[tbLoaiSanPham] ([loaisanpham_id], [loaisanpham_ten]) VALUES (2, N'Nước ngọt')
INSERT [dbo].[tbLoaiSanPham] ([loaisanpham_id], [loaisanpham_ten]) VALUES (3, N'Sinh tố')
INSERT [dbo].[tbLoaiSanPham] ([loaisanpham_id], [loaisanpham_ten]) VALUES (6, N'Trà sữa')
SET IDENTITY_INSERT [dbo].[tbLoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[tbNguyenLieu] ON 

INSERT [dbo].[tbNguyenLieu] ([nguyenlieu_id], [nguyenlieu_ten], [nguyenlieu_nhacungcap]) VALUES (1, N'Sữa tươi', N'Vinamilk')
INSERT [dbo].[tbNguyenLieu] ([nguyenlieu_id], [nguyenlieu_ten], [nguyenlieu_nhacungcap]) VALUES (2, N'Sữa tươi', N'TH True Milk')
INSERT [dbo].[tbNguyenLieu] ([nguyenlieu_id], [nguyenlieu_ten], [nguyenlieu_nhacungcap]) VALUES (3, N'Hạt cà phê', N'RainCoffee')
INSERT [dbo].[tbNguyenLieu] ([nguyenlieu_id], [nguyenlieu_ten], [nguyenlieu_nhacungcap]) VALUES (4, N'Bột Cacao', N'OCA Việt Nam')
INSERT [dbo].[tbNguyenLieu] ([nguyenlieu_id], [nguyenlieu_ten], [nguyenlieu_nhacungcap]) VALUES (5, N'Hạt cà phê', N'An Thái Cafe')
INSERT [dbo].[tbNguyenLieu] ([nguyenlieu_id], [nguyenlieu_ten], [nguyenlieu_nhacungcap]) VALUES (6, N'Đường', N'NMĐ Sơn Dương')
INSERT [dbo].[tbNguyenLieu] ([nguyenlieu_id], [nguyenlieu_ten], [nguyenlieu_nhacungcap]) VALUES (7, N'Sữa đặc', N'Dutch Lady')
INSERT [dbo].[tbNguyenLieu] ([nguyenlieu_id], [nguyenlieu_ten], [nguyenlieu_nhacungcap]) VALUES (8, N'Đá viên', N'ICE Cool')
SET IDENTITY_INSERT [dbo].[tbNguyenLieu] OFF
GO
INSERT [dbo].[tbNhapHang] ([nhaphang_id], [nhaphang_ngaynhap], [nhaphang_tongtien]) VALUES (N'HD240001', CAST(N'2024-09-16T10:53:40.727' AS DateTime), CAST(2720000 AS Decimal(18, 0)))
INSERT [dbo].[tbNhapHang] ([nhaphang_id], [nhaphang_ngaynhap], [nhaphang_tongtien]) VALUES (N'HD240002', CAST(N'2024-09-16T11:33:11.793' AS DateTime), CAST(558500 AS Decimal(18, 0)))
INSERT [dbo].[tbNhapHang] ([nhaphang_id], [nhaphang_ngaynhap], [nhaphang_tongtien]) VALUES (N'HD240003', CAST(N'2024-10-01T14:05:40.713' AS DateTime), CAST(150000 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[tbNhapHangChiTiet] ON 

INSERT [dbo].[tbNhapHangChiTiet] ([nhaphangchitiet_id], [nhaphangchitiet_sanpham], [nguyenlieu_nhacungcap], [nhaphangchitiet_soluong], [nhaphangchitiet_dongia], [nhaphang_id], [nguyenlieu_id]) VALUES (1, N'Sữa tươi', N'Vinamilk', 20, 35000, N'HD240001', 1)
INSERT [dbo].[tbNhapHangChiTiet] ([nhaphangchitiet_id], [nhaphangchitiet_sanpham], [nguyenlieu_nhacungcap], [nhaphangchitiet_soluong], [nhaphangchitiet_dongia], [nhaphang_id], [nguyenlieu_id]) VALUES (2, N'Hạt cà phê', N'RainCoffee', 100, 10000, N'HD240001', 3)
INSERT [dbo].[tbNhapHangChiTiet] ([nhaphangchitiet_id], [nhaphangchitiet_sanpham], [nguyenlieu_nhacungcap], [nhaphangchitiet_soluong], [nhaphangchitiet_dongia], [nhaphang_id], [nguyenlieu_id]) VALUES (3, N'Bột Cacao', N'OCA Việt Nam', 50, 12000, N'HD240001', 4)
INSERT [dbo].[tbNhapHangChiTiet] ([nhaphangchitiet_id], [nhaphangchitiet_sanpham], [nguyenlieu_nhacungcap], [nhaphangchitiet_soluong], [nhaphangchitiet_dongia], [nhaphang_id], [nguyenlieu_id]) VALUES (4, N'Đường', N'NMĐ Sơn Dương', 30, 5000, N'HD240001', 6)
INSERT [dbo].[tbNhapHangChiTiet] ([nhaphangchitiet_id], [nhaphangchitiet_sanpham], [nguyenlieu_nhacungcap], [nhaphangchitiet_soluong], [nhaphangchitiet_dongia], [nhaphang_id], [nguyenlieu_id]) VALUES (5, N'Sữa đặc', N'Dutch Lady', 10, 20000, N'HD240001', 7)
INSERT [dbo].[tbNhapHangChiTiet] ([nhaphangchitiet_id], [nhaphangchitiet_sanpham], [nguyenlieu_nhacungcap], [nhaphangchitiet_soluong], [nhaphangchitiet_dongia], [nhaphang_id], [nguyenlieu_id]) VALUES (6, N'Đá viên', N'ICE Cool', 10, 7000, N'HD240001', 8)
INSERT [dbo].[tbNhapHangChiTiet] ([nhaphangchitiet_id], [nhaphangchitiet_sanpham], [nguyenlieu_nhacungcap], [nhaphangchitiet_soluong], [nhaphangchitiet_dongia], [nhaphang_id], [nguyenlieu_id]) VALUES (7, N'Sữa tươi', N'Vinamilk', 10, 35000, N'HD240002', 1)
INSERT [dbo].[tbNhapHangChiTiet] ([nhaphangchitiet_id], [nhaphangchitiet_sanpham], [nguyenlieu_nhacungcap], [nhaphangchitiet_soluong], [nhaphangchitiet_dongia], [nhaphang_id], [nguyenlieu_id]) VALUES (8, N'Sữa tươi', N'TH True Milk', 5, 34500, N'HD240002', 2)
INSERT [dbo].[tbNhapHangChiTiet] ([nhaphangchitiet_id], [nhaphangchitiet_sanpham], [nguyenlieu_nhacungcap], [nhaphangchitiet_soluong], [nhaphangchitiet_dongia], [nhaphang_id], [nguyenlieu_id]) VALUES (9, N'Hạt cà phê', N'RainCoffee', 3, 12000, N'HD240002', 3)
INSERT [dbo].[tbNhapHangChiTiet] ([nhaphangchitiet_id], [nhaphangchitiet_sanpham], [nguyenlieu_nhacungcap], [nhaphangchitiet_soluong], [nhaphangchitiet_dongia], [nhaphang_id], [nguyenlieu_id]) VALUES (10, N'Hạt cà phê', N'RainCoffee', 10, 15000, N'HD240003', 3)
SET IDENTITY_INSERT [dbo].[tbNhapHangChiTiet] OFF
GO
SET IDENTITY_INSERT [dbo].[tbTaiKhoan] ON 

INSERT [dbo].[tbTaiKhoan] ([taikhoan_id], [taikhoan_hoten], [taikhoan_tentaikhoan], [taikhoan_matkhau], [taikhoan_hinhanh], [taikhoan_quyen]) VALUES (1, N'Duy Assmin', N'duy', N'1', N'admin.png', 1)
INSERT [dbo].[tbTaiKhoan] ([taikhoan_id], [taikhoan_hoten], [taikhoan_tentaikhoan], [taikhoan_matkhau], [taikhoan_hinhanh], [taikhoan_quyen]) VALUES (3, N'Thái Đăng Duy', N'duy2', N'2', N'tdd.jpg', 0)
SET IDENTITY_INSERT [dbo].[tbTaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[tbThanhPham] ON 

INSERT [dbo].[tbThanhPham] ([thanhpham_id], [thanhpham_ten], [thanhpham_soluong], [thanhpham_dongia], [loaisanpham_id], [loaisanpham_ten]) VALUES (1, N'Cà phê sữa', 4, CAST(18000 AS Decimal(15, 0)), 1, N'Cà phê')
INSERT [dbo].[tbThanhPham] ([thanhpham_id], [thanhpham_ten], [thanhpham_soluong], [thanhpham_dongia], [loaisanpham_id], [loaisanpham_ten]) VALUES (2, N'7 Up', 1, CAST(10000 AS Decimal(15, 0)), 2, N'Nước ngọt')
INSERT [dbo].[tbThanhPham] ([thanhpham_id], [thanhpham_ten], [thanhpham_soluong], [thanhpham_dongia], [loaisanpham_id], [loaisanpham_ten]) VALUES (3, N'Sinh tố dâu', 5, CAST(25000 AS Decimal(15, 0)), 3, N'Sinh tố')
INSERT [dbo].[tbThanhPham] ([thanhpham_id], [thanhpham_ten], [thanhpham_soluong], [thanhpham_dongia], [loaisanpham_id], [loaisanpham_ten]) VALUES (5, N'Cà phê đen', 1, CAST(20000 AS Decimal(15, 0)), 1, N'Cà phê')
INSERT [dbo].[tbThanhPham] ([thanhpham_id], [thanhpham_ten], [thanhpham_soluong], [thanhpham_dongia], [loaisanpham_id], [loaisanpham_ten]) VALUES (6, N'Cola', 2, CAST(8000 AS Decimal(15, 0)), 3, N'Sinh tố')
INSERT [dbo].[tbThanhPham] ([thanhpham_id], [thanhpham_ten], [thanhpham_soluong], [thanhpham_dongia], [loaisanpham_id], [loaisanpham_ten]) VALUES (7, N'Sinh tố trái cây', 4, CAST(25000 AS Decimal(15, 0)), 3, N'Sinh tố')
INSERT [dbo].[tbThanhPham] ([thanhpham_id], [thanhpham_ten], [thanhpham_soluong], [thanhpham_dongia], [loaisanpham_id], [loaisanpham_ten]) VALUES (8, N'Trà sữa truyền thống', 1, CAST(28000 AS Decimal(15, 0)), 6, N'Trà sữa')
SET IDENTITY_INSERT [dbo].[tbThanhPham] OFF
GO
ALTER TABLE [dbo].[tbBan] ADD  DEFAULT (N'Trống') FOR [ban_trangthai]
GO
ALTER TABLE [dbo].[tbHoaDon] ADD  DEFAULT ((0)) FOR [hoadon_trangthai]
GO
