--Bùi Xuân Tiến_0206266_66PM3
CREATE TABLE Tours (
  TourID int PRIMARY KEY IDENTITY(1,1),
  TourName nvarchar(255) NOT NULL,
  StartDate datetime NOT NULL,
  EndDate datetime NOT NULL,
  Price money NOT NULL,
  [Status] nvarchar(50) NOT NULL,
  MinParticipants int NOT NULL,
  MaxParticipants int NOT NULL,
  Participants int NOT NULL,
);
go
CREATE TABLE Customers (
  CustomerID int PRIMARY KEY IDENTITY(1,1),
  FirstName nvarchar(50) NOT NULL,
  LastName nvarchar(50) NOT NULL,
  Email nvarchar(100) NOT NULL,
  PhoneNumber nvarchar(20) NOT NULL,
);
go
CREATE TABLE Bookings (
  BookingID int PRIMARY KEY IDENTITY(1,1),
  CustomerID int,
  TourID int,
  BookingDate datetime NOT NULL,
  [Status] nvarchar(50) NOT NULL,
  FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
  FOREIGN KEY (TourID) REFERENCES Tours(TourID),
);
go
CREATE TABLE Payments (
  PaymentID int PRIMARY KEY IDENTITY(1,1),
  BookingID int,
  Amount money NOT NULL,
  PaymentDate datetime NOT NULL,
  FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
);
--Câu 3
INSERT INTO Tours (TourName, StartDate, EndDate, Price, [Status], MinParticipants, MaxParticipants, Participants)
VALUES 
(N'Du lịch Hạ Long', '2023-07-01', '2023-07-15', 1500000.00, N'Đang tiến hành', 5, 20, 10),
(N'Du lịch Đà Nẵng', '2023-12-01', '2023-12-10', 1200000.00, N'Đã đầy', 8, 25, 15),
(N'Du lịch Nam Định', '2023-09-15', '2023-09-25', 1800000.00, N'Hủy bỏ', 10, 30, 20),
(N'Điều dưỡng Thanh Hóa', '2023-08-01', '2023-08-20', 2000000.00, N'Đang tiến hành', 6, 18, 12),
(N'Nghỉ dưỡng biển Cửa Lò', '2023-06-10', '2023-06-20', 1300000.00, N'Đã đầy', 7, 22, 18);

INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber)
VALUES 
(N'Nguyễn Văn', 'A', 'nguyenvan.@gmail.com', '0987654321'),
(N'Trần Thị', 'B', 'tranthi.@gmail.com', '0901234567'),
(N'Lê Minh', 'C', 'leminh.@gmail.com', '0978123456'),
(N'Phạm Hoàng', 'D', 'phamhoang.@gmail.com', '0912345678'),
(N'Vũ Thị', 'E', 'vuthi.@gmail.com', '0987876543');

INSERT INTO Bookings (CustomerID, TourID, BookingDate, [Status])
VALUES 
(1, 2, '2023-05-20', N'Đã thanh toán'),
(3, 4, '2023-07-05', N'Đang xử lý'),
(2, 1, '2023-06-10', N'Đã thanh toán'),
(4, 3, '2023-08-15', N'Đã thanh toán'),
(5, 5, '2023-04-25', N'Đang xử lý');

INSERT INTO Payments (BookingID, Amount, PaymentDate)
VALUES 
(1, 1200000.00, '2023-06-01'),
(3, 800000.00, '2023-06-20'),
(2, 1500000.00, '2023-05-25'),
(4, 1800000.00, '2023-08-20'),
(5, 1300000.00, '2023-05-01');
--Câu 4
SELECT TourName, StartDate, EndDate, Price
FROM Tours
WHERE Price > (SELECT AVG(Price) FROM Tours);
--Câu 5
SELECT
    C.FirstName,
    C.LastName,
    SUM(P.Amount) AS TotalPayment
FROM
    Customers AS C
JOIN
    Bookings AS B ON C.CustomerID = B.CustomerID
JOIN
    Payments AS P ON B.BookingID = P.BookingID
WHERE
    YEAR(P.PaymentDate) = 2023
GROUP BY
    C.FirstName, C.LastName;
--Câu 6
SELECT
    C.FirstName,
    C.LastName
FROM
    Customers AS C
JOIN
    Bookings AS B ON C.CustomerID = B.CustomerID
GROUP BY
    C.FirstName, C.LastName
HAVING
    COUNT(DISTINCT B.TourID) > 1;
--Câu 7
CREATE PROCEDURE spCalculateDiscount
    @TourID int,
    @DiscountRate decimal
AS
BEGIN
    IF @DiscountRate >= 0 AND @DiscountRate <= 100
    BEGIN
        IF EXISTS (SELECT 1 FROM Tours WHERE TourID = @TourID)
        BEGIN
            IF EXISTS (SELECT 1 FROM Tours WHERE TourID = @TourID AND [Status] <> 'Hủy bỏ')
            BEGIN
                UPDATE Tours
                SET Price = Price * (1 - @DiscountRate / 100)
                WHERE TourID = @TourID;

                PRINT 'Cập nhật giảm giá thành công.';
            END
            ELSE
            BEGIN
                PRINT 'Tour đã bị hủy bỏ.';
            END
        END
        ELSE
        BEGIN
            PRINT 'Tour không tồn tại.';
        END
    END
    ELSE
    BEGIN
        PRINT 'Tỉ lệ giảm giá không hợp lệ.';
    END
END;
--Câu 8 
CREATE PROCEDURE spBookAndPayForTour
    @CustomerID int,
    @TourID int,
    @Amount money
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Tours WHERE TourID = @TourID AND [Status] = 'Mở cửa' AND GETDATE() < DATEADD(HOUR, -24, StartDate) AND Participants < MaxParticipants)
    BEGIN
        INSERT INTO Bookings (CustomerID, TourID, BookingDate, [Status])
        VALUES (@CustomerID, @TourID, GETDATE(), 'Đang xử lý');

        DECLARE @BookingID int = SCOPE_IDENTITY();

        INSERT INTO Payments (BookingID, Amount, PaymentDate)
        VALUES (@BookingID, @Amount, GETDATE());

        PRINT 'Đã đặt và thanh toán thành công.';
    END
    ELSE
    BEGIN
        PRINT 'Không thể đặt do không đủ điều kiện.';
    END
END;
--Câu 9
CREATE TRIGGER tgUpdateTourStatusAfterBooking
ON Bookings
AFTER INSERT
AS
BEGIN
    DECLARE @TourID int;
    DECLARE @Participants int;
    DECLARE @MaxParticipants int;
    DECLARE @CurrentParticipants int;

    SELECT
        @TourID = i.TourID,
        @Participants = t.Participants,
        @MaxParticipants = t.MaxParticipants,
        @CurrentParticipants = t.Participants + COUNT(i.CustomerID)
    FROM
        inserted i
    JOIN
        Tours t ON i.TourID = t.TourID
    GROUP BY
        i.TourID, t.Participants, t.MaxParticipants;

    IF @CurrentParticipants >= @MaxParticipants
    BEGIN
        UPDATE Tours
        SET [Status] = 'Đã đầy'
        WHERE TourID = @TourID;
    END
END;
--Câu 10
CREATE TRIGGER tgUpdateTourParticipants
ON Bookings
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @TourID int;

    IF (SELECT COUNT(*) FROM inserted) > 0
    BEGIN
        SELECT @TourID = TourID FROM inserted;
    END
    ELSE
    BEGIN
        SELECT @TourID = TourID FROM deleted;
    END

    IF EXISTS (SELECT 1 FROM Tours WHERE TourID = @TourID AND [Status] = 'Đã thanh toán')
    BEGIN
        UPDATE Tours
        SET Participants = Participants + 1
        WHERE TourID = @TourID;
    END
END;
--Câu 11 
CREATE TABLE BookingChangeLog (
    BookingID int,
    Action nvarchar(100),
    ChangeDate datetime
);
CREATE TRIGGER tgLogBookingChanges
ON Bookings
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action nvarchar(100);

    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        SET @Action = 'Create';
    END
    ELSE IF EXISTS (SELECT 1 FROM deleted)
    BEGIN
        SET @Action = 'Delete';
    END
    ELSE
    BEGIN
        SET @Action = 'Update';
    END

    INSERT INTO BookingChangeLog (BookingID, Action, ChangeDate)
    SELECT
        COALESCE(i.BookingID, d.BookingID),
        @Action,
        GETDATE()
    FROM
        inserted i
    FULL JOIN
        deleted d ON i.BookingID = d.BookingID;
END;
--Câu 12
CREATE NONCLUSTERED INDEX IX_BookingDate
ON Bookings (BookingDate);


