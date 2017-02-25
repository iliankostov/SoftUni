<?php

$numbersString = $_GET['numbersString'];

$regex = '/([A-Z][A-Za-z]*)[^0-9A-Za-z+]*([+]?[0-9]+[0-9\- \.\/\)\(]*[0-9]+)/';

preg_match_all($regex, $numbersString, $matches, PREG_SPLIT_NO_EMPTY);

if (empty($matches[0])) {
    echo "<p>No matches!</p>";
} else {
    echo "<ol>";
    for ( $a = 0; $a < count($matches[0]); $a++ ) {
        $name = trim($matches[1][$a]);
        $temp_phone = trim($matches[2][$a]);

        $phone = preg_split("/[^\d\+]+/", $temp_phone);
        $phone = implode("", $phone);

        if (strlen($phone) >= 2) {
            echo "<li><b>$name:</b> $phone</li>";
        }
    }
    echo "</ol>";
}