<html>
<head></head>
<body>
<?php

    function Add($a, $b)
    {
        if (is_numeric($a) && is_numeric($b))
        {
            return $a +$b;
        }
        else
        {
            return "Vui lòng điền vào dạng số";
        }

    }

?>
    <form>
        <table>
            <caption>Tính toán</caption>
            <tr>
                <td>a = </td>
                <td>
                    <input type="text" name="txt_a" value="<?php if (isset($_REQUEST['txt_a'])) echo $_REQUEST['txt_a'] ?>" />
                </td>
            </tr>
            <tr>
                <td>b = </td>
                <td>
                    <input type="text" name="txt_b" value="<?php if (isset($_REQUEST['txt_b'])) echo $_REQUEST['txt_b'] ?>"  />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input  type="submit" value="Thực hiện" />
                    <?php
                        $txt_a = $_REQUEST["txt_a"];
                        $txt_b = $_REQUEST["txt_b"];
                        if ($txt_a != "" && $txt_b != "" )
                        {
                            echo "Kết quả: " . Add($txt_a, $txt_b);
                        }
                        else
                        {
                            echo "Vui lòng nhập vào a và b";
                        }
                    ?>
                </td>
            </tr>
        </table>
    </form>

</body>
</html>

<?php
