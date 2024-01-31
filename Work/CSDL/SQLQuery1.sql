/*1*/
Create View cau1 AS
SELECT HoSV, TenSV, MaKH, NoiSinh, HocBong FROM SinhVien
WHERE HocBong > 100000 AND NoiSinh = 'Tp. HCM';
/*2*/
Create View cau2 AS
SELECT MaSV, MaKH, Phai FROM SinhVien
WHERE MaKH = 'AV' OR MaKH = 'TR';
/*3*/
Create View cau3 AS
SELECT MaSV, NgaySinh, NoiSinh, HocBong FROM SinhVien
WHERE NgaySinh BETWEEN '1986-01-01' AND '1992-06-05';
/*4*/
Create View cau4 AS
SELECT MaSV, NgaySinh, Phai, MaKH FROM SinhVien
WHERE HocBong BETWEEN 200000 AND 800000;
/*5*/
Create View cau5 AS
SELECT MaMH, TenMH, SoTiet FROM MonHoc
WHERE SoTiet > 40 AND SoTiet < 60;
/*6*/
Create View cau6 AS
SELECT MaSV, TenSV, Phai FROM SinhVien
WHERE Phai = 'False' AND MaKH = 'AV';
/*7*/
Create View cau7 AS
SELECT HoSV, TenSV, NoiSinh, NgaySinh FROM SinhVien
WHERE NoiSinh = N'Hà Nội' AND NgaySinh > '1990-01-01';
/*8*/
Create View cau8 AS
SELECT MaSV, TenSV FROM SinhVien
WHERE Phai = 'True' AND TenSV LIKE '%N%';
/*9*/
Create View cau9 AS
SELECT MaSV, HoSV, TenSV, NgaySinh, NoiSinh FROM SinhVien
WHERE Phai = 'False' AND MaKH = 'TH' AND NgaySinh > '1986-05-30';
/*10*/
Create View cau10 AS
SELECT
    HoSV AS 'Họ và tên sinh viên',
    CASE
        WHEN Phai = 'False' THEN N'Nam'
        WHEN Phai = 'True' THEN N'Nữ'
        ELSE 'Không xác định'
    END AS 'Giới tính',
    NgaySinh AS 'Ngày sinh'
FROM SinhVien;
/*11*/
Create View cau11 AS
SELECT MaSV,
       (YEAR(GETDATE()) - YEAR(NgaySinh)) AS Tuoi,
       NoiSinh,
       MaKH
FROM SinhVien;
/*12*/
Create View cau12 AS
SELECT 
    HoSV AS 'Họ sinh viên',
	TenSV AS 'Tên sinh viên',
    (YEAR(GETDATE()) - YEAR(NgaySinh)) AS 'Tuổi',
    TenKH AS 'Tên khoa'
FROM SinhVien
JOIN Khoa ON SinhVien.MaKH = Khoa.MaKH
WHERE (YEAR(GETDATE()) - YEAR(NgaySinh)) BETWEEN 20 AND 30;
/*13*/
Create View cau13 AS
SELECT MaSV,
       Phai,
       MaKH,
       CASE
           WHEN HocBong > 500000 THEN N'Học bổng cao'
           ELSE N'Mức trung bình'
       END AS N'Mức học bổng'
FROM SinhVien;
/*14*/
Create View cau14 AS
SELECT 
    HoSV AS 'Họ sinh viên',
	TenSV AS 'Tên sinh viên',
    CASE
        WHEN Phai = 'False' THEN N'Nam'
        WHEN Phai = 'True' THEN N'Nữ'
        ELSE 'Không xác định'
    END AS 'Giới tính',
    N'Anh văn' AS 'Tên khoa'
FROM SinhVien
WHERE MaKH = 'AV';
/*15*/
Create View cau15 AS
SELECT Khoa.TenKH AS N'Tên khoa',
       SinhVien.HoSV AS N'Họ tên sinh viên',
	   SinhVien.TenSV AS N'Tên sinh viên',
       MonHoc.TenMH AS N'Tên môn học',
       MonHoc.SoTiet AS N'Số tiết',
       Ketqua.Diem AS N'Điểm'
FROM Ketqua
JOIN SinhVien ON Ketqua.MaSV = SinhVien.MaSV
JOIN MonHoc ON Ketqua.MaMH = MonHoc.MaMH
JOIN Khoa ON SinhVien.MaKH = Khoa.MaKH
WHERE Khoa.TenKH = N'Tin học';
/*16*/
Create View cau16 AS
SELECT SinhVien.HoSV AS N'Họ sinh viên',
       SinhVien.TenSV AS N'Tên sinh viên',   
       Khoa.MaKH,
       MonHoc.TenMH AS N'Tên môn học',
       Ketqua.Diem AS N'Điểm thi',
       CASE
           WHEN Ketqua.Diem > 8 THEN N'Giỏi'
           WHEN Ketqua.Diem BETWEEN 6 AND 8 THEN N'Khá'
           ELSE N'Trung Bình'
       END AS N'Loại'
FROM Ketqua
JOIN SinhVien ON Ketqua.MaSV = SinhVien.MaSV
JOIN MonHoc ON Ketqua.MaMH = MonHoc.MaMH
JOIN Khoa ON SinhVien.MaKH = Khoa.MaKH;

/*17*/
Create View cau17 AS
WITH MaxHocBong AS (
    SELECT Khoa.MaKH, Khoa.TenKH, MAX(SinhVien.HocBong) AS MaxHocBong
    FROM SinhVien
    JOIN Khoa ON SinhVien.MaKH = Khoa.MaKH
    GROUP BY Khoa.MaKH, Khoa.TenKH
)
SELECT MaxHocBong.MaKH, MaxHocBong.TenKH, MaxHocBong.MaxHocBong AS 'Học bổng cao nhất'
FROM MaxHocBong;
/*18*/
Create View cau18 AS
SELECT MonHoc.MaMH AS 'Mã môn',
       MonHoc.TenMH AS 'Tên môn',
       COUNT(DISTINCT Ketqua.MaSV) AS 'Số sinh viên đang học'
FROM MonHoc
LEFT JOIN Ketqua ON MonHoc.MaMH = Ketqua.MaMH
GROUP BY MonHoc.MaMH, MonHoc.TenMH;
/*19*/
Create View cau19 AS
WITH MaxDiem AS (
    SELECT MonHoc.TenMH AS N'Tên môn',
           MonHoc.SoTiet AS N'Số tiết',
           SinhVien.TenSV AS N'Tên sinh viên',
           Ketqua.Diem AS N'Điểm'
    FROM Ketqua
    JOIN MonHoc ON Ketqua.MaMH = MonHoc.MaMH
    JOIN SinhVien ON Ketqua.MaSV = SinhVien.MaSV
    WHERE Ketqua.Diem = (SELECT MAX(Diem) FROM Ketqua)
)
SELECT *
FROM MaxDiem;

/*20*/
Create View cau20 AS
WITH CountSinhVien AS (
    SELECT Khoa.MaKH AS N'Mã khoa',
           Khoa.TenKH AS N'Số tiết',
           Count(Sinhvien.MaSV) AS N'Tổng số sinh viên'
    FROM Khoa
    LEFT JOIN SinhVien ON Khoa.MaKH = SinhVien.MaKH
    GROUP BY Khoa.MaKH, Khoa.TenKH
)
SELECT *
FROM CountSinhVien
WHERE 'Tổng số sinh viên' = (SELECT MAX('Tổng số sinh viên') FROM CountSinhVien);

/*21*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
/*12*/
