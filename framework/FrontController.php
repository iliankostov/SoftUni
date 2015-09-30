<?php
namespace Framework;

use Framework\Routers\IRouter;
use ReflectionClass;

class FrontController
{
    private static $_instance = null;
    private $namespace = null;
    private $controller = null;
    private $method = null;
    private $params = array();
    /**
     * @var IRouter
     */
    private $router = null;

    private function __construct()
    {

    }

    public function getRouter()
    {
        return $this->router;
    }

    public function setRouter(IRouter $router)
    {
        $this->router = $router;
    }

    public function dispatch()
    {
        if ($this->router == null) {
            throw new \Exception('No valid router found', 500);
        }

        $configParams = null;

        $_uri = $this->router->getUri();
        $routes = App::getInstance()->getConfig()->routes;
        $areas = App::getInstance()->getConfig()->areas;

        if (is_array($areas) && count($areas) > 0) {
            $routes = array_merge($areas, $routes);
        }

        if (is_array($routes) && count($routes) > 0) {
            foreach ($routes as $key => $value) {
                if (stripos($_uri, $key) === 0 && ($_uri == $key || stripos($_uri, $key . '/') === 0) && $value['namespace']) {
                    $this->namespace = $value['namespace'];
                    $_uri = substr($_uri, strlen($key) + 1);
                    $configParams = $value;
                    break;
                }
            }
        } else {
            throw new \Exception('Default route missing', 500);
        }

        if ($this->namespace == null && $routes['*']['namespace']) {
            $this->namespace = $routes['*']['namespace'];
            $configParams = $routes['*'];
        } else if ($this->namespace == null && !$routes['*']['namespace']) {
            throw new \Exception('Default route missing', 500);
        }

        $input = InputData::getInstance();
        $_params = explode('/', $_uri);
        if ($_params[0]) {
            $this->controller = strtolower($_params[0]);

            if ($_params[1]) {
                $this->method = strtolower($_params[1]);
                unset($_params[0], $_params[1]);
                $this->params = array_values($_params);
                $input->setGet($this->params);
            } else {
                $this->method = $this->getDefaultMethod();
            }
        } else {
            $this->controller = $this->getDefaultController();
            $this->method = $this->getDefaultMethod();
        }

        if (is_array($configParams) && $configParams['controllers']) {
            if ($configParams['controllers'][$this->controller]['methods'][$this->method]) {
                $this->method = strtolower($configParams['controllers'][$this->controller]['methods'][$this->method]);
            }
            if (isset($configParams['controllers'][$this->controller]['to'])) {
                $this->controller = strtolower($configParams['controllers'][$this->controller]['to']);
            }
        }

        $input->setPost($this->router->getPost());
        $controller = $this->namespace . '\\' . ucfirst($this->controller);
        $newController = new $controller();
        $this->loadMethod($newController);
    }

    public function getDefaultController()
    {
        $controller = App::getInstance()->getConfig()->app['default_controller'];
        if ($controller) {
            return strtolower($controller);
        }
        return 'index';
    }

    public function getDefaultMethod()
    {
        $method = App::getInstance()->getConfig()->app['default_method'];
        if ($method) {
            return strtolower($method);
        }
        return 'index';
    }

    public static function getInstance()
    {
        if (self::$_instance == null) {
            self::$_instance = new FrontController();
        }

        return self::$_instance;
    }

    private function loadMethod($newController)
    {
        $isMethodExists = false;

        $reflectionController = new ReflectionClass($newController);
        $reflectionMethods = $reflectionController->getMethods();

        $roles = App::getInstance()->getInstance()->getConfig()->roles;

        foreach ($reflectionMethods as $reflectionMethod) {
            if ($this->method === $reflectionMethod->getName()) {
                $doc = $reflectionMethod->getDocComment();

                $annotations = array();
                preg_match_all('#@(.*?)\n#s', $doc, $annotations);

                foreach ($annotations[1] as $annotation) {
                    foreach ($roles as $role) {
                        if ($role === $annotation) {
                            // TODO if user in role -> pass him
                            throw new \Exception("You are not " . strtolower($role) . " to do this", 401);
                        }
                    }
                }

                $isMethodExists = true;
            }
        }

        if ($isMethodExists) {
            $newController->{$this->method}();
        } else {
            throw new \Exception("This action do not exists", 404);
        }
    }
}