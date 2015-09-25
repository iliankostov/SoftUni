<?php
ini_set('display_errors', 1);

use SoftUni\Application;
use SoftUni\Autoloader;
use SoftUni\Config\DatabaseConfig;
use SoftUni\Core\Database;

session_start();
require_once 'Autoloader.php';
Autoloader::init();

$uri = $_SERVER['REQUEST_URI'];
$self = $_SERVER['PHP_SELF'];
$index = basename($self);
$directories = str_replace($index, '', $self);
$requestString = str_replace($directories, '', $uri);
$requestParams = explode("/", $requestString);

$controller = array_shift($requestParams);
$action = array_shift($requestParams);

$fullQualifiedController = '\\SoftUni\\Controllers\\' . ucfirst($controller) . 'Controller';
$controllerInstance = new $fullQualifiedController();

Database::setInstance(
    DatabaseConfig::DB_INSTANCE_NAME,
    DatabaseConfig::DB_DRIVER,
    DatabaseConfig::DB_USERNAME,
    DatabaseConfig::DB_PASSWORD,
    DatabaseConfig::DB_NAME,
    DatabaseConfig::DB_HOST
);

$app = new Application($controller, $action, $requestParams);
$app->start();