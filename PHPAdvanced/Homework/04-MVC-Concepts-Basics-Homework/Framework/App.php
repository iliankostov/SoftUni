<?php

namespace Framework;

use Framework\Routers\DefaultRouter;
use Framework\Routers\IRouter;
use Framework\Sessions\ISession;
use Framework\Sessions\NativeSession;

include_once 'Loader.php';

class App
{
    private static $_instance = null;
    private $_config = null;
    private $_frontController = null;
    private $router = null;
    private $_dbConnections = [];
    private $_session = null;

    private function __construct()
    {
        set_exception_handler(array($this, '_exceptionHandler'));
        Loader::registerNamespace('Framework', dirname(__FILE__) . DIRECTORY_SEPARATOR);
        Loader::registerAutoLoad();
        $this->_config = Config::getInstance();
        if($this->_config->getConfigFolder() == null){
            $this->setConfigFolder('../Config');
        }
    }

    public function getRouter()
    {
        return $this->router;
    }

    public function setRouter($router)
    {
        $this->router = $router;
    }

    public function setConfigFolder($path) {
        $this->_config->setConfigFolder($path);
    }

    public function getConfigFolder(){
        return $this->_configFolder;
    }

    /**
     * @return Config
     */
    public function getConfig(){
        return $this->_config;
    }

    public function run(){
        if($this->_config->getConfigFolder() == null){
            $this->setConfigFolder('../Config');
        }

        $this->_frontController = FrontController::getInstance();

        if($this->router instanceof IRouter){
            $this->_frontController->setRouter($this->router);
        } else if($this->router == 'JsonRPCRouter'){
            //TODO fix it when RPC is done
            $this->_frontController->setRouter(new DefaultRouter());
        } else if($this->router == 'CLIRouter'){
            //TODO fix it when CLI is done
            $this->_frontController->setRouter(new DefaultRouter());
        } else {
            $this->_frontController->setRouter(new DefaultRouter());
        }

        $_sess = $this->_config->app['session'];
        if($_sess['autostart']){
            if($_sess['type'] == 'native'){
                $s = new NativeSession
                (
                    $_sess['name'],
                    $_sess['lifetime'],
                    $_sess['path'],
                    $_sess['domain'],
                    $_sess['secure']
                );
            }

            $this->setSession($s);
        }

        $this->_frontController->dispatch();
    }

    public function getSession(){
        return $this->_session;
    }

    public function setSession(ISession $session){
        $this->_session = $session;
    }

    public function getDbConnection($connection = null){
        if($connection == null){
            $connection = 'default';
        }

        if(!$connection){
            throw new \Exception('No connection identifier provided', 500);
        }

        if($this->_dbConnections[$connection]){
            return $this->_dbConnections[$connection];
        }

        $_cnf = $this->getConfig()->database;
        if(!$_cnf[$connection]){
            throw new \Exception('No valid connection identifier is provided', 500);
        }

        $newConnection = new \PDO(
            $_cnf[$connection]['connection_uri'],
            $_cnf[$connection]['username'],
            $_cnf[$connection]['password'],
            $_cnf[$connection]['pdo_options']
        );
        $this->_dbConnections[$connection] = $newConnection;
        return $newConnection;
    }

    public function _exceptionHandler(\Exception $ex){
        if($this->_config && $this->_config->app['displayExceptions'] == true){
            var_dump($ex);
        } else {
            $this->displayError($ex->getCode());
        }
    }

    public function displayError($error){
        try {
            $view = View::getInstance();
            $view->display('errors.' . $error);
        } catch (\Exception $ex) {
            Common::headerStatus($error);
            echo '<h1>' . $error . '</h1>';
            exit;
        }
    }

    /**
     * @return App
     */
    public static function getInstance(){
        if (self::$_instance == null) {
            self::$_instance = new App();
        }

        return self::$_instance;
    }
}