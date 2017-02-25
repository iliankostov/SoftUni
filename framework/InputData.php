<?php

namespace Framework;

class InputData
{
    private static $_instance = null;
    private $_get = array();
    private $_post = array();
    private $_cookies = array();

    private function __construct()
    {
        $this->_cookies = $_COOKIE;
    }

    public function setPost($ar)
    {
        if (is_array($ar)) {
            $this->_post = $ar;
        }
    }

    public function setGet($ar)
    {
        if (is_array($ar)) {
            $this->_get = $ar;
        }
    }

    public function hasGet()
    {
        return count($this->_get) > 0;
    }

    public function hasPost()
    {
        return count($this->_post) > 0;
    }

    public function hasCookies($name)
    {
        return array_key_exists($name, $this->_cookies);
    }

    public function get()
    {
        return $this->_get;
    }

    public function post()
    {
        return $this->_post;
    }

    public function cookies()
    {
        return $this->_cookies;
    }

    public static function getInstance()
    {
        if (self::$_instance == null) {
            self::$_instance = new InputData();
        }

        return self::$_instance;
    }
}