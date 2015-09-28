<?php
error_reporting(E_ALL ^ E_NOTICE);
ini_set('display_errors', 1);

use Framework\App;

include '../../framework/App.php';

$app = App::getInstance();
$app->run();