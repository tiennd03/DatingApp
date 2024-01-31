CREATE TABLE Student (
  StudentID int PRIMARY KEY IDENTITY(1,1),
  Name nvarchar(50) NOT NULL,
  DOB datetime NOT NULL,
  Gender bit NULL
);
CREATE TABLE Class (
  ClassID int PRIMARY KEY IDENTITY(1,1),
  Name nvarchar(50) NOT NULL,
  MaxCapacity int NOT NULL,
  NumberOfAttendants int DEFAULT 0
);
CREATE TABLE ClassStudent (
  ClassID int,
  StudentID int,
  AttendDate datetime NOT NULL,
  PRIMARY KEY (ClassID, StudentID),
  FOREIGN KEY (ClassID) REFERENCES Class(ClassID),
  FOREIGN KEY (StudentID) REFERENCES Student(StudentID)
);
ALTER TABLE Student
ADD CONSTRAINT CHK_Student_DOB CHECK (DOB < GETDATE());
ALTER TABLE ClassStudent
ADD CONSTRAINT DF_ClassStudent_AttendDate DEFAULT GETDATE() FOR AttendDate;
INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Nguyễn Văn A', '2000-01-01', 1);

INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Trần Thị B', '2001-02-02', 0);

INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Nguyễn Văn C', '2002-03-03', 1);

INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Trần Thị D', '2003-04-04', 0);

INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Nguyễn Văn E', '2004-05-05', 1);

INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Trần Thị F', '2005-06-06', 0);

INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Nguyễn Văn G', '2006-07-07', 1);

INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Trần Thị H', '2007-08-08', 0);

INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Nguyễn Văn I', '2008-09-09', 1);

INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Trần Thị K', '2009-10-10', 0);
INSERT INTO Student (Name, DOB, Gender)
VALUES (N'Trần Văn L', '2010-11-11', NULL);

INSERT INTO Class (Name, MaxCapacity, NumberOfAttendants)
VALUES (N'Toán', 30, 0);

INSERT INTO Class (Name, MaxCapacity, NumberOfAttendants)
VALUES (N'Anh Văn', 25, 0);

INSERT INTO ClassStudent (ClassID, StudentID, AttendDate)
VALUES (1, 1, GETDATE());

INSERT INTO ClassStudent (ClassID, StudentID, AttendDate)
VALUES (1, 2, GETDATE());

INSERT INTO ClassStudent (ClassID, StudentID, AttendDate)
VALUES (2, 3, GETDATE());

INSERT INTO ClassStudent (ClassID, StudentID, AttendDate)
VALUES (2, 4, GETDATE());

INSERT INTO ClassStudent (ClassID, StudentID, AttendDate)
VALUES (1, 5, GETDATE());

INSERT INTO ClassStudent (ClassID, StudentID, AttendDate)
VALUES (1, 6, GETDATE());

INSERT INTO ClassStudent (ClassID, StudentID, AttendDate)
VALUES (2, 7, GETDATE());

INSERT INTO ClassStudent (ClassID, StudentID, AttendDate)
VALUES (2, 8, GETDATE());

INSERT INTO ClassStudent (ClassID, StudentID, AttendDate)
VALUES (1, 9, GETDATE());

INSERT INTO ClassStudent (ClassID, StudentID, AttendDate)
VALUES (1, 10, GETDATE());
--Câu 3 hiển thị ra danh sách các sinh viên chưa tham gia lớp nào bao gồm: StudentID, Name, DOB, Student Gender để hiển thị là Male/Fermale/Unknown tương ứng với các giá trị 1/0/Null trong cột 
SELECT
    S.StudentID,
    S.Name,
    S.DOB,
    CASE
        WHEN S.Gender = 1 THEN 'Male'
        WHEN S.Gender = 0 THEN 'Female'
        ELSE 'Unknown'
    END AS StudentGender
FROM
    Student S
WHERE
    S.StudentID NOT IN (
        SELECT CS.StudentID
        FROM ClassStudent CS
    );

--Câu 4 hiển thị danh sách sinh viên đi học trong ngày hôm  nay
SELECT
    S.StudentID,
    S.Name,
    S.DOB,
    CASE
        WHEN S.Gender = 1 THEN 'Male'
        WHEN S.Gender = 0 THEN 'Female'
        ELSE 'Unknown'
    END AS StudentGender
FROM
    Student S
JOIN
    ClassStudent CS ON S.StudentID = CS.StudentID
WHERE
    CONVERT(DATE, CS.AttendDate) = CONVERT(DATE, GETDATE());

--Câu 5 hiển thị tên các lớp mà có nhiều sinh viên nhất bao gồm : Class Name, Number of Students
SELECT
    C.Name AS ClassName,
    COUNT(CS.StudentID) AS NumberOfStudents
FROM
    Class C
JOIN
    ClassStudent CS ON C.ClassID = CS.ClassID
GROUP BY
    C.Name
ORDER BY
    NumberOfStudents DESC;

--Câu 6 tạo 1 khung nhìn với tên "vwClassListWithMaleStudent" hiển thị tất cả lớp và số lượng sinh viên nam của lớp đó
CREATE VIEW vwClassListWithMaleStudent AS
SELECT
    C.ClassID,
    C.Name AS ClassName,
    COUNT(CASE WHEN S.Gender = 1 THEN 1 ELSE NULL END) AS NumberOfMaleStudents
FROM
    Class C
LEFT JOIN
    ClassStudent CS ON C.ClassID = CS.ClassID
LEFT JOIN
    Student S ON CS.StudentID = S.StudentID
GROUP BY
    C.ClassID, C.Name;
SELECT * FROM vwClassListWithMaleStudent;

--Câu 7 tạo 1 khung nhìn "vwStudentList" hiển thị tất cả thông tin của bảng sinh viên gồm :Student ID, Student Name, Student Name, Student Age, Student Gender. Trong đó Student Age tính bằng năm hiện tại trừ đi năm sinh, Student Gender hiển thị là Male/Fermale/Unknown tương ứng với các giá trị 1/0/Null trong cột 
CREATE VIEW vwStudentList AS
SELECT
    StudentID,
    Name AS StudentName,
    YEAR(GETDATE()) - YEAR(DOB) AS StudentAge,
    CASE
        WHEN Gender = 1 THEN 'Male'
        WHEN Gender = 0 THEN 'Female'
        ELSE 'Unknown'
    END AS StudentGender
FROM
    Student;
SELECT * FROM vwStudentList;

--Câu 8 tạo 1 stored procedure đưa ra danh sách những lớp đã đạt đủ chỉ tiêu ( số sinh viên của lớp đó lớn hơn 2 và nhỏ hơn hoặc bằng maxCapacity của lớp đó)
CREATE PROCEDURE GetClassesMeetingCriteria
AS
BEGIN
    SELECT
        C.ClassID,
        C.Name AS ClassName,
        C.MaxCapacity,
        COUNT(CS.StudentID) AS NumberOfStudents
    FROM
        Class C
    LEFT JOIN
        ClassStudent CS ON C.ClassID = CS.ClassID
    GROUP BY
        C.ClassID, C.Name, C.MaxCapacity
    HAVING
        COUNT(CS.StudentID) > 2 AND COUNT(CS.StudentID) <= C.MaxCapacity;
END;
EXEC GetClassesMeetingCriteria;

--Câu 9 tạo 1 stored procedure tên "spAttendantsInDate" nhận vào hai tham số AttendDate và ClassID sau đó đưa ra tổng số sinh viên tham gia vào lớp ClassID vào ngày AttendDate
CREATE PROCEDURE spAttendantsInDate
    @AttendDate datetime,
    @ClassID int
AS
BEGIN
    DECLARE @TotalStudents int;

    SELECT
        @TotalStudents = COUNT(StudentID)
    FROM
        ClassStudent
    WHERE
        ClassID = @ClassID
        AND CONVERT(DATE, AttendDate) = CONVERT(DATE, @AttendDate);

    -- Trả về tổng số sinh viên
    SELECT @TotalStudents AS TotalStudents;
END;
EXEC spAttendantsInDate '2023-12-12', 2; -- Thay đổi giá trị cho AttendDate và ClassID theo nhu cầu

--Câu 10 tạo 1 stored procedure tên "spDropOutStudent" nhận vào tên sinh viên là tham số đầu vào. Nếu tên sinh viên đó có trong bảng Student thì xóa tất cả thông tin của sinh viên đó trong cơ sở dữ liệu đi. Nếu sinh viên đó không có thì đưa ra thông báo


CREATE PROCEDURE spDropOutStudent
    @StudentName nvarchar(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Student WHERE Name = @StudentName)
    BEGIN
        -- Xóa thông tin sinh viên
        DELETE FROM Student WHERE Name = @StudentName;

        PRINT N'Đã xóa thông tin của sinh viên ' + @StudentName;
    END
    ELSE
    BEGIN
        -- Sinh viên không tồn tại
        PRINT N'Sinh viên ' + @StudentName + N' không tồn tại trong cơ sở dữ liệu.';
    END
END;
EXEC spDropOutStudent N'Nguyễn Văn M';


--Câu 11 tạo các trigger cho sự kiện thêm sửa xóa của bảng ClassStudent để cập nhật lại sĩ số (NumberOfAttendants) trong bảng Class. Với sự kiện thêm phải đảm bảo chỉ thêm thành công nếu số lượng sinh viên của lớp chưa vượt quá MaxCapacity
--thêm
CREATE TRIGGER trgAfterInsertClassStudent
ON ClassStudent
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Class
    SET NumberOfAttendants = NumberOfAttendants + 1
    FROM Class C
    INNER JOIN inserted I ON C.ClassID = I.ClassID
    WHERE C.NumberOfAttendants + 1 <= C.MaxCapacity;
END;
--sửa 
CREATE TRIGGER trgAfterUpdateClassStudent
ON ClassStudent
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Class
    SET NumberOfAttendants = (
        SELECT COUNT(*)
        FROM ClassStudent
        WHERE ClassID = (SELECT ClassID FROM inserted)
    )
    WHERE ClassID IN (SELECT ClassID FROM inserted);
END;
--Xóa
CREATE TRIGGER trgAfterDeleteClassStudent
ON ClassStudent
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Class
    SET NumberOfAttendants = NumberOfAttendants - 1
    FROM Class C
    INNER JOIN deleted D ON C.ClassID = D.ClassID
    WHERE C.NumberOfAttendants - 1 >= 0;
END;

