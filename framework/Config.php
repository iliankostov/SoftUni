<?php

namespace Framework;

class Config
{
    private static $_instance = null;
    private $_configFolder = null;
    private $_configArray = array();

    private function __construct()
    {
    }

    public function setConfigFolder($configFolder)
    {
        if (!$configFolder) {
            throw new \Exception('Empty config folder path', 500);
        }

        $_configFolder = realpath($configFolder);

        if ($_configFolder != false && is_dir($_configFolder) && is_readable($_configFolder)) {
            $this->_configArray = array();
            $this->_configFolder = $_configFolder . DIRECTORY_SEPARATOR;
            $ns = $this->app['namespaces'];
            if (is_array($ns)) {
                Loader::registerNamespaces($ns);
            }
        } else {
            throw new \Exception('Config directory read error: ' . $configFolder, 500);
        }
    }

    public function getConfigFolder()
    {
        return $this->_configFolder;
    }

    public static function getInstance()
    {
        if (self::$_instance == null) {
            self::$_instance = new Config();
        }

        return self::$_instance;
    }

    public function __get($name)
    {
        if (!$this->_configArray[$name]) {
            $this->includeConfigFile($this->_configFolder . $name . '.php');
        }
        if (array_key_exists($name, $this->_configArray)) {
            return $this->_configArray[$name];
        }
        return null;
    }

    private function includeConfigFile($path)
    {
        if (!$path) {
            throw new \Exception;
        }

        $_file = realpath($path);

        if ($_file != false && is_file($_file) && is_readable($_file)) {
            $_arr = explode('.php', basename($_file));
            $_basename = $_arr[0];
            $this->_configArray[$_basename] = include $_file;
        } else {
            throw new \Exception('Config file read error: ' . $path, 500);
        }
    }
}