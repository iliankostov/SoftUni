<?php
date_default_timezone_set('Europe/Sofia');

$numbersString = htmlentities($_GET['numbersString']);
$dateString = htmlentities($_GET['dateString']);

$patternNum = '/[^A-Za-z0-9]?(\d*)[^A-Za-z0-9]?/';
preg_match_all($patternNum, $numbersString, $numbers, PREG_SPLIT_NO_EMPTY);

$sum = 0;

foreach ($numbers[1] as $number) {
    $sum += $number;
}

$backwards_sum = strrev($sum);

$patternDate = '/(\d{4})-(\d{2})-(\d{2})/';
preg_match_all($patternDate, $dateString, $dates);

if ($dates[0]) {

    echo "<ul>";
    foreach ($dates[0] as $date) {
        echo "<li>" . date('Y-m-d', strtotime("+$backwards_sum day", strtotime($date))) . "</li>";
    }
    echo "</ul>";

} else {
    echo "<p>No dates</p>";
}