<?php
$svr_name = "localhost";
$username = "root";
$pass = "123456";
$db = "66pm34";

//tạo đối tượng connection kết nối đến DB
$conn = new mysqli($svr_name, $username, $pass, $db);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully <br>";

//$rs = $conn->query("select * from tbl_SinhVien");
//
//if ($rs->num_rows > 0)
//{
////    while($row = $rs->fetch_assoc()) {
////        echo "MSSV: " . $row["MSSV"] . "; Họ tên: " . $row["HoTen"] . "<br>";
////    }
//
//    while($r = $rs->fetch_array())
//    {
//        echo "MSSV: " . $r[0] . "; Họ tên: " . $r[1] . " <br>";
//    }
//}
//else
//{
//    //trường hợp không có dữ liệu
//    echo "Dữ liệu hiện tại đang trống";
//}

$rs = $conn->query("insert into tbl_SinhVien values ('321','Nguyễn Đình C', 'Nam')");

if ($rs === TRUE)
{
    echo "Thêm mới sinh viên thành công";
}
else
{
    //trường hợp không có dữ liệu
    echo "Thêm mới dữ liệu thất bại. Chi tiết lỗi: " . $conn->error;
}