<?php
require_once 'Db.php';
require_once 'Localization.php';

$db = Db::getInstance();

$result = $db->query("SHOW COLUMNS FROM translations");

$columns = $result->fetchAll(PDO::FETCH_ASSOC);

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

    $sth = Db::getInstance()->prepare("
            SELECT text_{$lang}
            FROM translations
            WHERE tag = ?;
        ");

    $data = array($tag);

    $sth -> execute($data);

    $row = $sth -> fetch(PDO::FETCH_NUM);

    return $row[0];
}

if(isset($_POST['text_bg'])) {
    foreach($_POST['text_bg'] as $key => $value) {

        $updateTranslations = $db->prepare("UPDATE translations SET text_bg = ? WHERE id = ?");

        $data = array($value, $key);

        $updateTranslations->execute($data);
    }
}

$resultTranslations = $db->query("SELECT id, tag, text_en, text_bg FROM translations");

$translations = $resultTranslations->fetchAll(PDO::FETCH_ASSOC);