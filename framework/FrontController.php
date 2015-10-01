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
     * @var InputData
     */
    private $input = null;
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

    public function dispatch()
    {
        if ($this->router == null) {
            throw new \Exception('No valid router found', 500);
        }

        $configParams = null;

        $_uri = $this->router->getUri();
        $routes = App::getInstance()->getConfig()->routes;

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

        $this->input = InputData::getInstance();
        $_params = explode('/', $_uri);
        if ($_params[0]) {
            $this->controller = strtolower($_params[0]);

            if ($_params[1]) {
                $this->method = strtolower($_params[1]);
                unset($_params[0], $_params[1]);
                $this->params = array_values($_params);
                $this->input->setGet($this->params);
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

        $this->input->setPost($this->router->getPost());
        $controller = $this->namespace . '\\' . ucfirst($this->controller);
        $newController = new $controller();
        $this->loadMethod($newController);
    }

    private function loadMethod($newController)
    {
        $isMethodExists = false;

        $reflectionController = new ReflectionClass($newController);
        $reflectionMethods = $reflectionController->getMethods();

        $roles = App::getInstance()->getInstance()->getConfig()->roles;

        $bindingModel = null;
        foreach ($reflectionMethods as $reflectionMethod) {
            if ($this->method === $reflectionMethod->getName()) {
                $doc = $reflectionMethod->getDocComment();

                $annotations = array();
                preg_match_all('#@(.*?)\n#s', $doc, $annotations);

                foreach ($annotations[1] as $annotation) {
                    $annotation = trim($annotation);

                    if ($annotation === "POST" && $this->input->hasGet(0)) {
                        throw new \Exception("Cannot access Post method with Get request", 406);
                    }

                    if ($annotation === "GET" && !$this->input->hasGet(0)) {
                        throw new \Exception("Cannot access Get method with Post request", 406);
                    }

                    foreach ($roles as $role) {
                        if ($role === $annotation) {
                            // TODO if user in role -> pass him
                            throw new \Exception("You are not " . strtolower($role) . " to do this", 401);
                        }
                    }
                }

                $bindingModel = $this->BindModel($annotations[1]);
                $isMethodExists = true;
            }
        }

        if ($isMethodExists) {
            if ($bindingModel) {
                $newController->{$this->method}($bindingModel);
            } else {
                $newController->{$this->method}();
            }

        } else {
            throw new \Exception("This action do not exists", 404);
        }
    }

    private function BindModel($annotations)
    {
        $bindingNamespace = null;
        $appConfig = App::getInstance()->getConfig()->app;
        $namespaces = $appConfig['namespaces'];
        foreach ($namespaces as $key => $value) {
            if (strpos($key, "BindingModels")) {
                $bindingNamespace = $key;
            }
        }

        $bindingModelName = null;
        foreach ($annotations as $annotation) {
            $bindingAnnotation = explode(' ', $annotation);
            if ($bindingAnnotation[0] === 'BingingModel') {
                $bindingModelName = $bindingAnnotation[1];
            }
        }

        $bindingModel = null;
        if ($bindingNamespace && $bindingModelName) {
            $bindingModelClass = $bindingNamespace . "\\" . $bindingModelName;
            $bindingModel = new $bindingModelClass;
            $reflectionModel = new ReflectionClass($bindingModel);
            $properties = $reflectionModel->getProperties();

            $post = $this->input->post();
            foreach ($properties as $property) {
                $propertyName = $property->getName();
                $propertyDoc = $property->getDocComment();

                $annotations = array();
                preg_match_all('#@(.*?)\n#s', $propertyDoc, $annotations);
                $set = 'set' . $propertyName;

                if ($annotations[1][0] === "REQUIRED" && array_key_exists($propertyName, $post)) {
                    $bindingModel->$set($post[$propertyName]);
                } else if (array_key_exists($propertyName, $post)) {
                    $bindingModel->$set($post[$propertyName]);
                } else {
                    throw new \Exception("Invalid input data");
                }
            }
        }

        return $bindingModel;
    }
}