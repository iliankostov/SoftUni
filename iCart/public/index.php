<?php
error_reporting(E_ALL ^ E_NOTICE);
ini_set('display_errors', 1);

use Framework\App;
use Framework\Database\DefaultDatabase;

include '../../framework/App.php';

$app = App::getInstance();

$db = new DefaultDatabase();

var_dump($db->prepare("SELECT * FROM users WHERE id= ?")->execute([1])->fetchRowAssoc());

$app->run();