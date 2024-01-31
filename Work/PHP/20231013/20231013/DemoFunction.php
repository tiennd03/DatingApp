<?php
//hàm không có tham số
function Helloworld()
{
    echo "Hello world <br>";
}

Helloworld();

//hàm có tham số
function Print_str($str)
{
    echo $str;
}

Print_str("Hello world from Print_str funct <br>");

//Hàm có trả ra kết quả
function Add($a, $b)
{
    return $a + $b;
}

echo ("Kết quả thực hiện phép tính cộng: " . Add(5,7) . "<br>");
echo ("Kết quả thực hiện phép tính cộng: " . Add("5","7"). "<br>");
echo ("Kết quả thực hiện phép tính cộng: " . Add("5",7). "<br>");
//echo ("Kết quả thực hiện phép tính cộng: " . Add("a","b"). "<br>");
//echo ("Kết quả thực hiện phép tính cộng: " . Add(5,"b"). "<br>");


//hàm có validate input
function Add2($a,$b)
{
    if (is_numeric($a) && is_numeric($b))
    {
        $c = $a + $b;
    }
    else
    {
        $c = "Vui lòng truyền vào dạng số";
    }

    return $c;
}

echo (Add2("5", 7) . "<br>");


//hàm có tham số nhận giá trị mặc định. Hàm có tham số tùy chọn
function Add3 ($a = 3, $b = 5)
{
    return $a+$b;
}

echo (Add3(5,8) . "<br>");

echo (Add2(1,5). "<br>");
echo (Add2(2,5). "<br>");
echo (Add2(3,5). "<br>");
echo (Add2(4,5). "<br>");


echo (Add3(1). "<br>");
echo (Add3(2). "<br>");
echo (Add3(3). "<br>");
echo (Add3(4). "<br>");

?>



