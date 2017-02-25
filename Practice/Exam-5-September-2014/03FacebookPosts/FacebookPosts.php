<?php
date_default_timezone_set("Europe/Sofia");

$text = $_GET['text'];

$pattern = "/(.*);.*?(\d+-\d+-\d+).*?;(.*?);.*?(\d+).*?;.*?(.*)?/";

preg_match_all($pattern, $text, $matches, PREG_SPLIT_NO_EMPTY);

$outputs = [];

for ( $a = 0; $a < count($matches[0]); $a++ ) {
    $name = trim($matches[1][$a]);
    $date = strtotime($matches[2][$a]);
    $post = trim($matches[3][$a]);
    $likes = trim($matches[4][$a]);
    $comments = preg_split("/\//", $matches[5][$a]);

    $outputs[$date] = [$name, $post, $likes, $comments];
}

krsort($outputs);

foreach ($outputs as $key => $output) {
    $date_str = date("j F Y", $key);
    echo "<article>";
    echo "<header><span>" . htmlspecialchars($output[0]) . "</span><time>$date_str</time></header>";
    echo "<main><p>" . htmlspecialchars($output[1]) . "</p></main>";
    echo "<footer><div class=\"likes\">$output[2] people like this</div>";

    if ($output[3][0] != '') {
        echo "<div class=\"comments\">";
        foreach ($output[3] as $comment) {

            echo "<p>" . htmlspecialchars(trim($comment)) . "</p>";
        }
        echo "</div>";
    }

    echo "</footer>";
    echo "</article>";
}