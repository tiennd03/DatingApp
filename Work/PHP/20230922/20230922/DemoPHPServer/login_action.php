<?php
    //nhận dữ liệu từ view
    $tk = $_REQUEST["txt_tk"];
    $mk = $_REQUEST["txt_mk"];

    //validate input
    if (empty($tk) || empty($mk))
    {
        echo "Vui lòng nhập tài khoản và mật khẩu";
    }
    else
    {
        //đã nhập đủ tài khoản và mật khẩu.
        //kiểm tra xem mk có lớn hơn hoặc = 6 ký tự không
        if (strlen($mk) >= 6)
        {
            //kiểm tra đăng nhập
            if ($tk == "duongnh" && $mk=="123456")
            {
                header("Location: ./index.php");
            }
            else
            {
                echo "Đăng nhập thất bại";
            }
        }
        else
        {
            echo "Mật khẩu không được nhỏ hơn 6 ký tự";
        }

    }
    //echo $tk.";".$mk;
?>
