<?php


namespace Framework;


class View
{
    private static $_instance;
    private $___viewPath = null;
    private $___data = [];
    private $___viewDir = null;
    private $___extension = '.php';
    private $___layoutParts = [];
    private $___layoutData = [];

    private function __construct(){
        $this->___viewPath = App::getInstance()->getConfig()->app['viewsDirectory'];
        if($this->___viewPath == null){
            $this->___viewPath = realpath('../Views/');
        }
    }

    public function setViewDirectory($path){
        $path = trim($path);
        if($path){
            $path = realpath($path) . DIRECTORY_SEPARATOR;
            if(is_dir($path) && is_readable($path)){
                $this->___viewDir = $path;
            } else {
                //TODO
                throw new \Exception('view path', 500);
            }
        } else {
            //TODO
            throw new \Exception('view path', 500);
        }
    }

    public function display($name, $data = [], $returnAsString = false){
        if(is_array($data)){
            $this->___data = array_merge($this->___data, $data);
        }

        if(count($this->___layoutParts) > 0){
            foreach ($this->___layoutParts as $k => $v) {
                $r = $this->_includeFile($v);
                if($r){
                    $this->___layoutData[$k] = $r;
                }
            }

        }

        if($returnAsString){
            return $this->_includeFile($name);
        } else {
            echo $this->_includeFile($name);
        }
    }

    public function getLayoutData($name){
        return $this->___layoutData[$name];
    }

    private function _includeFile($file){
        if($this->___viewDir == null){
            $this->setViewDirectory($this->___viewPath);
        }
        $___fullPath = $this->___viewDir . str_replace('.', DIRECTORY_SEPARATOR, $file) . $this->___extension;
        if(file_exists($___fullPath) && is_readable($___fullPath)){
            ob_start();
            include $___fullPath;
            return ob_get_clean();
        } else {
            throw new \Exception('View ' . $file . ' cannot be included', 500);
        }
    }

    public function appendToLayout($key, $template){
        if($key && $template){
            $this->___layoutParts[$key] = $template;
        } else {
            throw new \Exception('Layout requires valid key and template', 500);
        }
    }

    public function __get($name){
        return $this->___data[$name];
    }

    public function __set($name, $value){
        $this->___data[$name] = $value;
    }

    public static function getInstance(){
        if (self::$_instance == null) {
            self::$_instance = new View();
        }

        return self::$_instance;
    }
}