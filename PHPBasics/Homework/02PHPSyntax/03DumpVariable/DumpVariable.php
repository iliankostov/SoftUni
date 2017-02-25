<?php
function dumpVariable($input) {
    if (is_numeric($input)){
        var_dump($input);
    } else {
        echo gettype($input) . '<br />';
    }
}
$string = "hello";
dumpVariable($string);

$int = 15;
dumpVariable($int);

$float = 1.234;
dumpVariable($float);

$array = array(1, 2, 3);
dumpVariable($array);

$object = (object)[2,34];
dumpVariable($object);