<?php
function Add()
{
    if (isset($_REQUEST["txt_a"]) &&  isset($_REQUEST["txt_b"]))
    {

        $a = $_REQUEST["txt_a"];
        $b = $_REQUEST["txt_b"];

        $c = $a + $b;
        return $c;
    }

}