<?php

$error_log = $_GET['errorLog'];

$regex = "/Exception in thread \".*\" java.*\.(.*):.*\n.*?\.(.*?)\((.*?):(\d+)/";

preg_match_all($regex, $error_log, $matches, PREG_SPLIT_NO_EMPTY);

echo "<ul>";
for ( $a = 0; $a < sizeof($matches[0]); $a++ ) {
    $exception = htmlspecialchars($matches[1][$a]);
    $class_str = htmlspecialchars($matches[2][$a]);
    $method_str = htmlspecialchars($matches[3][$a]);
    $line = htmlspecialchars($matches[4][$a]);
    echo "<li>line <strong>$line</strong> - <strong>$exception</strong> in <em>$method_str:$class_str</em></li>";
}
echo "</ul>";