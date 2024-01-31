<?php
include  "../Shareds/_Before_Content.php";
include "../../Controllers/Calculator_ctrl.php";

$c = Add();
?>

    <div class="div-content">
        <form action="./" method="post">
            <table>
                <tr>
                    <td>a = </td>
                    <td><input  type="text" name="txt_a" value="<?php if(isset($_REQUEST["txt_a"])) echo $_REQUEST["txt_a"]?>" /> </td>
                </tr>
                <tr>
                    <td>b = </td>
                    <td><input  type="text" name="txt_b" value="<?php if(isset($_REQUEST["txt_b"])) echo $_REQUEST["txt_b"]?>" /> </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="submit" value="Cộng"/>
                        <p> <?php if (isset($c)) echo $c; ?> </p>
                    </td>
                </tr>
            </table>
        </form>
    </div>

<?php
include "../Shareds/_After_Content.php";
?>