<?php

$numbersString = $_GET['numbersString'];

$regex = '/.*?([a-zA-Z]+)+[^A-Za-z]*?([+()\/.\-\s\d]*\d{2}+)/';

preg_match_all($regex, $numbersString, $matches, PREG_SPLIT_NO_EMPTY);

if (empty($matches[0])) {
    echo "<p>No matches!</p>";
} else {
    echo "<ol>";
    for ( $a = 0; $a < count($matches[0]); $a++ ) {
        $temp_name = trim($matches[1][$a]);
        $temp_phone = trim($matches[2][$a]);

        $name_match = preg_match("/([A-Z{1}]+)/", $temp_name, $name);

        $phone = preg_split("/[^\d\+]+/", $temp_phone);
        $phone = implode("", $phone);

        if (strlen($phone) >= 2 && $name_match) {
            echo "<li><b>$name[0]:</b> $phone</li>";
        }
    }
    echo "</ol>";
}