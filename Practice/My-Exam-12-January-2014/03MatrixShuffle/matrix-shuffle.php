<?php

$size = intval($_GET['size']);
$text = $_GET['text'];

$ma3x = [];
$n = $size;

for($y = 0; $y<$n; $y++){
    for($x = 0; $x<$n; $x++)

        $ma3x[] = f($n, $n, $x, $y);

    echo "\n";
}

function f($w, $h, $x, $y){
    return ($y)
        ?$w + f($h - 1, $w, $y - 1, $w - $x - 1) //strip-off first row and "rotate"
        :$x;
}

$chars = [];

for ( $a = 0; $a < strlen($text); $a++ ) {
    array_push($chars, $text[$a]);
}
for ( $j = 0; $j < count($ma3x) - strlen($text); $j++ ) {
    $empty_char = " ";
    array_push($chars, $empty_char);
}

$color = 'white';
$colors = [];

for ( $c = 0, $d = 1; $c < count($ma3x); $c++, $d++ ) {
    if ($d > $size) {
        //change color
        if ($size % 2 == 0) {
            $color = reverseColor($color);
        }
        $d = 1;
    }
    if ($c % 2 == 0) {
        array_push($colors, $color);
        $color = reverseColor($color);
    } else {
        array_push($colors, $color);
        $color = reverseColor($color);
    }

}

$white_text = "";
$black_text = "";

for ( $h = 0; $h < count($ma3x); $h++ ) {
    if ($colors[$h] == "white") {
        $white_text .= $chars[$ma3x[$h]];
    } elseif ($colors[$h] == "black") {
        $black_text .= $chars[$ma3x[$h]];
    }
}

$print_text = $white_text . $black_text;

$new_text = $white_text . $black_text;
$new_text = strtolower($new_text);
$new_text = preg_replace("/[^A-Za-z]+/", '', $new_text);

if (strrev($new_text) === $new_text) {
    echo "<div style='background-color:#4FE000'>$print_text</div>";
} else {
    echo "<div style='background-color:#E0000F'>$print_text</div>";
}

function reverseColor($str) {
    if ($str == 'white') {
        $str = 'black';
    } elseif ($str == 'black') {
        $str = 'white';
    }
    return $str;
}