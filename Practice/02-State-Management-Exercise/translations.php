<?php
if(isset($_GET['lang'])) {
    $lang = $_GET['lang'];
    if($lang != Localization::LANG_BG && $lang != Localization::LANG_EN) {
        throw new Exception("Wrong language");
    }
    setcookie('lang', $lang);
    $_COOKIE['lang'] = $lang;
}

class Localization
{
    const LANG_EN = 'en';
    const LANG_BG = 'bg';

    const LANG_DEFAULT = self::LANG_EN;

    public static $string = [
        "greetings_header_hello" => [
            self::LANG_EN => "Hello",
            self::LANG_BG => "Здравейте"
        ],
        "informal_hello" => [
            self::LANG_EN => "Hi",
            self::LANG_BG => "Здрасти"
        ],
        "welcome_message" => [
            self::LANG_EN => "Welcome to our site",
            self::LANG_BG => "Добре дошли в нашият сайт"
        ]
    ];
}

function __($tag){
    $lang = isset($_COOKIE['lang'])
        ? $_COOKIE['lang']
        :Localization::LANG_DEFAULT;

    return Localization::$string[$tag][$lang];
}