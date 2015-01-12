<?php
date_default_timezone_set("Europe/Sofia");

$list = $_GET['list'];
$currDate = $_GET['currDate'];

$dates = preg_split('/\r\n/', $list, -1, PREG_SPLIT_NO_EMPTY);

$currDate = strtotime($currDate);

$int_dates = [];

foreach ($dates as $date) {
    $date = trim($date);
    $date = strtotime($date);

    if ($date) {
        $int_dates[] = $date;
    }
}

asort($int_dates);

$output_str = "<ul>";

foreach ($int_dates as $int_date) {

    $post_date = htmlspecialchars(date("d/m/Y", $int_date));

    if ($int_date < $currDate) {
        $output_str .= "<li><em>$post_date</em></li>";

    } elseif ($int_dates > $currDate) {
        $output_str .= "<li>$post_date</li>";
    }

}

$output_str .= "</ul>";

echo $output_str;