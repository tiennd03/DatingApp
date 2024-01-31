-- Tạo bảng NguoiVay
CREATE TABLE NguoiVay (
    MaNV INT PRIMARY KEY IDENTITY(1, 1),
    Ho NVARCHAR(27) NOT NULL,
    Ten NVARCHAR(27) NOT NULL,
    NgaySinh DATE NOT NULL,
    DienThoai NVARCHAR(17) NOT NULL,
    DiaChi NVARCHAR(252) NOT NULL,
    GioiTinh BIT,
    SoTienNo REAL NOT NULL DEFAULT 0
);

-- Tạo bảng TaiSanDamBao
CREATE TABLE TaiSanDamBao (
    MaTS INT PRIMARY KEY IDENTITY(1, 1),
    MaNV INT NOT NULL,
    Ten NVARCHAR(202) NOT NULL,
    GiaTri REAL NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES NguoiVay(MaNV)
);

-- Tạo bảng DeNghiVay
CREATE TABLE DeNghiVay (
    MaDN INT PRIMARY KEY IDENTITY(1, 1),
    MaNV INT NOT NULL,
    SoTienVay REAL NOT NULL,
    LaiSuat REAL NOT NULL,
    SoNgayVay INT NOT NULL,
    TrangThai INT NOT NULL DEFAULT 0,
    FOREIGN KEY (MaNV) REFERENCES NguoiVay(MaNV)
);

-- Tạo bảng KhoanVay
CREATE TABLE KhoanVay (
    MaKV INT PRIMARY KEY IDENTITY(1, 1),
    MaNV INT NOT NULL,
    NgayVay DATE NOT NULL DEFAULT GETDATE(),
    NgayDenHan DATE NOT NULL,
    SoTienVay REAL NOT NULL,
    LaiSuat REAL NOT NULL,
    SoTienPhaiTra REAL NOT NULL,
    SoTienDaTra REAL NOT NULL DEFAULT 0,
    SoTienPhat REAL NOT NULL DEFAULT 0,
    HoanThanh BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (MaNV) REFERENCES NguoiVay(MaNV)
);

-- Tạo bảng ThanhToan
CREATE TABLE ThanhToan (
    MaTT INT PRIMARY KEY IDENTITY(1, 1),
    MaKV INT NOT NULL,
    NgayTT DATE NOT NULL,
    SoTienTT REAL NOT NULL,
    SoTienPhat REAL NOT NULL
);
-- Chèn dữ liệu mẫu vào bảng NguoiVay
INSERT INTO NguoiVay (Ho, Ten, NgaySinh, DienThoai, DiaChi, GioiTinh, SoTienNo)
VALUES
    (N'Nguyễn', N'Thị Hà', '1995-07-15', '0901234567', N'123 Đường ABC', 0, 5000000),
    (N'Trần', N'Văn Bình', '1988-03-20', '0912345678', N'456 Đường XYZ', 1, 3000000),
    (N'Lê', N'Thị Cúc', '1990-05-10', '0987654321', N'789 Đường LMN', 0, 8000000),
    (N'Phạm', N'Văn Đông', '1992-11-28', '0901111222', N'987 Đường KLM', 1, 6000000),
    (N'Hồ', N'Thị Lan', '1998-12-05', '0933334444', N'654 Đường GHI', 0, 3500000);

-- Chèn dữ liệu mẫu vào bảng TaiSanDamBao
INSERT INTO TaiSanDamBao (MaNV, Ten, GiaTri)
VALUES
    (1, N'Xe ô tô', 20000000),
    (2, N'Căn hộ chung cư', 50000000),
    (3, N'Laptop', 5000000),
    (4, N'Smartphone', 2000000),
    (5, N'Xe máy', 6000000);

-- Chèn dữ liệu mẫu vào bảng DeNghiVay
INSERT INTO DeNghiVay (MaNV, SoTienVay, LaiSuat, SoNgayVay)
VALUES
    (1, 10000000, 0.05, 30),
    (2, 15000000, 0.04, 45),
    (3, 8000000, 0.06, 60),
    (4, 12000000, 0.07, 15),
    (5, 9000000, 0.05, 30);

-- Chèn dữ liệu mẫu vào bảng KhoanVay
INSERT INTO KhoanVay (MaNV, NgayDenHan, SoTienVay, LaiSuat, SoTienPhaiTra)
VALUES
    (1, '2023-11-30', 10000000, 0.05, 10250000),
    (2, '2023-12-15', 15000000, 0.04, 15750000),
    (3, '2023-11-25', 8000000, 0.06, 8480000),
    (4, '2023-12-10', 12000000, 0.07, 12600000),
    (5, '2023-12-05', 9000000, 0.05, 9450000);

-- Chèn dữ liệu mẫu vào bảng ThanhToan
INSERT INTO ThanhToan (MaKV, NgayTT, SoTienTT, SoTienPhat)
VALUES
    (1, '2023-11-25', 2000000, 0),
    (2, '2023-12-10', 6000000, 0),
    (3, '2023-11-20', 800000, 0),
    (4, '2023-11-30', 2000000, 0),
    (5, '2023-12-01', 1000000, 0);
--Cau 2
SELECT 
    MaNV,
    Ho,
    Ten,
    NgaySinh,
    DienThoai,
    DiaChi,
    CASE
        WHEN GioiTinh = 1 THEN N'Nam'
        WHEN GioiTinh = 0 THEN N'Nữ'
        ELSE 'Không biết'
    END AS GioiTinh,
    SoTienNo
FROM NguoiVay;

--Cau 3
SELECT NV.MaNV, NV.Ho, NV.Ten
FROM NguoiVay NV
WHERE NV.MaNV IN (
    SELECT MaNV
    FROM KhoanVay
    GROUP BY MaNV
    HAVING COUNT(*) >= 2
);
--Cau 4
--Trigger sau khi thêm
CREATE TRIGGER trg_KhoanVay_Insert
ON KhoanVay
AFTER INSERT
AS
BEGIN
    UPDATE NV
    SET SoTienNo = NV.SoTienNo + i.SoTienVay
    FROM NguoiVay NV
    JOIN inserted i ON NV.MaNV = i.MaNV;
END;
--Trigger sau khi sửa 
CREATE TRIGGER trg_KhoanVay_Update
ON KhoanVay
AFTER UPDATE
AS
BEGIN
    UPDATE NV
    SET SoTienNo = NV.SoTienNo + (i.SoTienVay - d.SoTienVay)
    FROM NguoiVay NV
    JOIN inserted i ON NV.MaNV = i.MaNV
    JOIN deleted d ON NV.MaNV = d.MaNV;
END;
--Trigger sau khi xóa
CREATE TRIGGER trg_KhoanVay_Delete
ON KhoanVay
AFTER DELETE
AS
BEGIN
    UPDATE NV
    SET SoTienNo = NV.SoTienNo - d.SoTienVay
    FROM NguoiVay NV
    JOIN deleted d ON NV.MaNV = d.MaNV;
END;
--Cau 5
CREATE PROCEDURE spDuyetDeNghi
    @MaDN INT
AS
BEGIN
    DECLARE @SoTienVay DECIMAL(18, 2)
    DECLARE @LaiSuat DECIMAL(5, 2)
    DECLARE @SoKhoanVayChuaThanhToan INT
    DECLARE @SoTienNo DECIMAL(18, 2)
    DECLARE @GiaTriTaiSan DECIMAL(18, 2)

    -- Lấy thông tin từ bảng DeNghiVay
    SELECT @SoTienVay = SoTienVay, @LaiSuat = LaiSuat
    FROM DeNghiVay
    WHERE MaDN = @MaDN;

    -- Lấy số lượng khoản vay chưa thanh toán
    SELECT @SoKhoanVayChuaThanhToan = COUNT(*)
    FROM KhoanVay
    WHERE MaNV = (SELECT MaNV FROM DeNghiVay WHERE MaDN = @MaDN) AND HoanThanh = 0;

    -- Lấy số tiền nợ của người vay
    SELECT @SoTienNo = SoTienNo
    FROM NguoiVay
    WHERE MaNV = (SELECT MaNV FROM DeNghiVay WHERE MaDN = @MaDN);

    -- Lấy giá trị tài sản đảm bảo
    SELECT @GiaTriTaiSan = GiaTri
    FROM TaiSanDamBao
    WHERE MaNV = (SELECT MaNV FROM DeNghiVay WHERE MaDN = @MaDN);

    -- Kiểm tra các điều kiện
    IF (@SoTienNo < 0.6 * @GiaTriTaiSan AND @LaiSuat >= 0.03 AND @SoKhoanVayChuaThanhToan <= 2)
    BEGIN
        -- Thêm dữ liệu vào bảng KhoanVay
        INSERT INTO KhoanVay (MaNV, NgayDenHan, SoTienVay, LaiSuat, SoTienPhaiTra)
        VALUES ((SELECT MaNV FROM DeNghiVay WHERE MaDN = @MaDN), GETDATE(), @SoTienVay, @LaiSuat, @SoTienVay);

        -- Cập nhật trạng thái của đề nghị vay
        UPDATE DeNghiVay
        SET TrangThai = 1
        WHERE MaDN = @MaDN;

        -- Thông báo thành công
        PRINT 'Duyệt đề nghị vay thành công';
    END
    ELSE
    BEGIN
        -- Thông báo lỗi
        PRINT 'Không thể duyệt đề nghị vay. Kiểm tra lại điều kiện.';
    END
END;
--Cau 6
CREATE TRIGGER tg_themThanhToan
ON ThanhToan
AFTER INSERT
AS
BEGIN
    DECLARE @MaKV INT, @SoTienTT DECIMAL(18, 2), @SoTienPhat DECIMAL(18, 2);
    
    -- Lấy thông tin từ bảng ThanhToan
    SELECT @MaKV = MaKV, @SoTienTT = SoTienTT, @SoTienPhat = SoTienPhat
    FROM inserted;

    -- Cập nhật thông tin khoản vay
    UPDATE KhoanVay
    SET 
        SoTienDaTra = SoTienDaTra + @SoTienTT,
        SoTienPhat = SoTienPhat + @SoTienPhat
    WHERE MaKV = @MaKV;

    -- Cập nhật trạng thái khoản vay
    UPDATE KhoanVay
    SET
        HoanThanh = CASE
            WHEN SoTienDaTra >= SoTienPhaiTra THEN 1
            ELSE 0
        END
    WHERE MaKV = @MaKV;
END;

--Cau 7
CREATE PROCEDURE spThanhToan
    @MaKV INT,
    @TongSoTien DECIMAL(18, 2)
AS
BEGIN
    DECLARE @SoTienTT DECIMAL(18, 2);
    DECLARE @SoTienPhat DECIMAL(18, 2);
    DECLARE @SoNgayTre INT;

    -- Tìm ngày vay
    SELECT @SoNgayTre = DATEDIFF(DAY, NgayVay, GETDATE())
    FROM KhoanVay
    WHERE MaKV = @MaKV;

    -- Lấy thông tin về khoản vay
    DECLARE @SoTienDaTra DECIMAL(18, 2);
    DECLARE @SoTienPhaiTra DECIMAL(18, 2);
    
    SELECT @SoTienDaTra = SoTienDaTra, @SoTienPhaiTra = SoTienPhaiTra
    FROM KhoanVay
    WHERE MaKV = @MaKV;

    -- Tính số tiền phạt
    IF @SoNgayTre > 0
    BEGIN
        SET @SoTienPhat = (@SoTienPhaiTra * 0.02 / 365) * @SoNgayTre;
        IF @SoTienPhat > (@SoTienDaTra * 0.2)
        BEGIN
            SET @SoTienPhat = @SoTienDaTra * 0.2;
        END;
    END
    ELSE
    BEGIN
        SET @SoTienPhat = 0;
    END;
    
    -- Tính số tiền thực tế thanh toán
    SET @SoTienTT = @TongSoTien - @SoTienPhat;
    
    -- Kiểm tra số tiền thanh toán không được vượt quá số tiền còn nợ
    IF @SoTienTT > (@SoTienPhaiTra - @SoTienDaTra)
    BEGIN
        SET @SoTienTT = @SoTienPhaiTra - @SoTienDaTra;
    END;
    
    -- Thêm dữ liệu vào bảng ThanhToan
    INSERT INTO ThanhToan (MaKV, NgayTT, SoTienTT, SoTienPhat)
    VALUES (@MaKV, GETDATE(), @SoTienTT, @SoTienPhat);
    
    -- Cập nhật thông tin khoản vay
    UPDATE KhoanVay
    SET
        SoTienDaTra = SoTienDaTra + @SoTienTT,
        SoTienPhat = SoTienPhat + @SoTienPhat,
        HoanThanh = CASE
            WHEN SoTienDaTra >= SoTienPhaiTra THEN 1
            ELSE 0
        END
    WHERE MaKV = @MaKV;

    -- Thông báo thành công
    PRINT 'Thanh toán thành công';
END;


