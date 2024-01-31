<html>
<head>

</head>
<body>
    <form action="" method="post">
        <table align="center">
            <caption>Thêm mới sinh viên</caption>
            <tr>
                <td>MSSV<span style="color:red">*</span>: </td>
                <td><input  type="text" name="txt_mssv" /> </td>
            </tr>
            <tr>
                <td>Họ tên<span style="color:red">*</span>: </td>
                <td><input  type="text" name="txt_hoten" /> </td>
            </tr>
            <tr>
                <td>Giới tính</td>
                <td><input  type="text" name="txt_gioitinh" /> </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <input type="submit" value="Thêm" />
                </td>
            </tr>
        </table>
    </form>
<?php
    if (isset($_REQUEST["txt_mssv"]))
    {
        $mssv = $_REQUEST["txt_mssv"];
        $hoten = $_REQUEST["txt_hoten"];
        $gioitinh = $_REQUEST["txt_gioitinh"];

        if ($mssv == "" && $hoten == "")
        {
            echo "Vui lòng điền đầy đủ dữ liệu bắt buộc";
        }
        else
        {
            $svr_name = "localhost";
            $username = "root";
            $pass = "123456";
            $db = "66pm34";

//tạo đối tượng connection kết nối đến DB
            $conn = new mysqli($svr_name, $username, $pass, $db);

// Check connection
            if ($conn->connect_error) {
                die("Lỗi kết nối cơ sở dữ liệu: " . $conn->connect_error);
            }

            $rs = $conn->query("insert into tbl_SinhVien values (\"" . $mssv. "\",\"" . $hoten ."\",\"" . $gioitinh ."\")");

            if ($rs === TRUE)
            {
                echo "Thêm mới sinh viên thành công";
            }
            else
            {
                //trường hợp không có dữ liệu
                echo "Thêm mới dữ liệu thất bại. Chi tiết lỗi: " . $conn->error;
            }
        }

    }

?>
</body>
</html>