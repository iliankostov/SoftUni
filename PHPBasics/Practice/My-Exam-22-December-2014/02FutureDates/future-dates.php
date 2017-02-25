<?php
$numbersString = htmlentities($_GET['numbersString']);
$dateString = htmlentities($_GET['dateString']);

$patternNum = '/[^A-Za-z0-9]+?(\d+)[^A-Za-z0-9]+?/';
preg_match_all($patternNum, $numbersString, $numbers, PREG_SPLIT_NO_EMPTY);

$sum = 0;

foreach ($numbers[1] as $number) {
    $sum += $number;
}

$backward_sum = strrev($sum);

$patternDate = '/(\d{4})-(\d{2})-(\d{2})/';
preg_match_all($patternDate, $dateString, $dates);

if (!empty($dates[0])) {
    $newDates = [];

    foreach ($dates[0] as $date) {
        $tempDate = date_create($date, timezone_open("Europe/Sofia"));
        date_add($tempDate, date_interval_create_from_date_string("$backward_sum days"));
        array_push($newDates, $tempDate);
    }

    echo "<ul>";
    foreach ($newDates as $newDate) {
        echo "<li>" . date_format($newDate, "Y-m-d") . "</li>";
    }
    echo "</ul>";

} else {
    echo "<p>No dates</p>";
}