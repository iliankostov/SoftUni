<?php

$text = $_GET['text'];
$red = fill_with_zeroes(dechex($_GET['red']));
$green = fill_with_zeroes(dechex($_GET['green']));
$blue = fill_with_zeroes(dechex($_GET['blue']));
$nth = intval($_GET['nth']);

function fill_with_zeroes($str) {
    if (strlen($str) < 2) {
        $str = '0' . $str;
        return $str;
    } else {
        return $str;
    }
}

$rgb_color = "#" . $red . $green . $blue;

$output_str = "<p>";

for ( $a = 0; $a < strlen($text); $a++ ) {
    $symbol = htmlspecialchars($text[$a]);
    if (($a + 1) % $nth == 0) {
        $output_str .= "<span style=\"color: $rgb_color\">$symbol</span>";
    } else {
        $output_str .= $symbol;
    }
}
$output_str .= "</p>";

echo $output_str;