<?php
$childName = htmlspecialchars($_GET['childName']);
$wantedPresent = htmlspecialchars($_GET['wantedPresent']);
$riddles = htmlspecialchars($_GET['riddles']);

$childName = preg_replace('/ /', '-', $childName);
$riddles = explode(';', $riddles);

$riddles_number = count($riddles);
$riddles_index = 0;

for ($i = 0, $j = 0; $i < strlen($childName); $i++, $j++) {
    if ($j >= $riddles_number) {
        $j = 0;
    }
    $riddles_index = $j;
}

$riddle = $riddles[$riddles_index];

$output = "$" . "giftOf" . $childName . " = $[wasChildGood] ? '" . $wantedPresent . "' : '" . $riddle . "';";

echo $output;