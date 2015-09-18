<?php
require_once 'Db.php';
require_once 'Localization.php';
require_once 'config.php';

Db::setInstance($user, $pass, $dbName, $host);
$db = Db::getInstance();
$db->query("SHOW COLUMNS FROM translations");
$columns = $db->fetchAll();

$possibleLanguages = [];
foreach ($columns as $column) {
    if (strpos($column['Field'], "text_") === 0) {
        $lang = substr($column['Field'], 5, strlen($column['Field'] - 5));
        array_push($possibleLanguages, $lang);
    }
}

if (!in_array($lang, $possibleLanguages)) {
    throw new Exception("Wrong language");
}

Localization::$LANG_DEFAULT = $possibleLanguages[0];


if (isset($_GET['lang'])) {
    $lang = $_GET['lang'];

    setcookie('lang', $lang);
    $_COOKIE['lang'] = $lang;
}

function __($tag)
{
    $lang = isset($_COOKIE['lang'])
        ? $_COOKIE['lang']
        : Localization::$LANG_DEFAULT;

    $db = Db::getInstance();
    $db->query("
        SELECT
            text_{$lang}
        FROM
          translations
        WHERE
          tag = '$tag';
    ");

    $row = $db->row();

    return $row[0];
}

$db->query("SET NAMES 'utf8'"); // Think about alternative!

$db->query(`SELECT id, tag, text_en, text_bg FROM translations`);
$translations = $db->fetchAll();

if(isset($_POST['text_bg'])) {
    $input = $_POST['text_bg'];

    for ($i = 0; $i < sizeof($input); $i++) {
        $db->query(`UPDATE translations SET text_bg = '` . $input[$i] . `' WHERE id = ` . ($i + 1));
    }
}