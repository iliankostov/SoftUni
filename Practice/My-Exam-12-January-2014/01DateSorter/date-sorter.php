<?php
date_default_timezone_set("Europe/Sofia");

$list = $_GET['list'];
$currDate = date_create($_GET['currDate']);

$dates = preg_split('/\n/', $list);
$int_dates = [];

foreach ($dates as $date) {
    $date = date_create($date);

    if ($date != "" && $date) {
        $int_dates[] = $date;
    }
}

sort($int_dates);

$output_str = "<ul>";

foreach ($int_dates as $int_date) {

    $post_date = date_format($int_date, "d/m/Y");

    if ($int_date < $currDate) {
        $output_str .= "<li><em>$post_date</em></li>";

    } else {
        $output_str .= "<li>$post_date</li>";
    }

}

$output_str .= "</ul>";

echo $output_str;