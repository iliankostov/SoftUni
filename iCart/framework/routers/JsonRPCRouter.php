<?php

namespace Framework\Routers;

use Framework\App;

class JsonRPCRouter implements IRouter
{
    private $_map = [];
    private $_requestId;
    private $_post;

    public function __construct()
    {
        if ($_SERVER['REQUEST_METHOD'] != 'POST' || empty($_SERVER['CONTENT_TYPE']) || $_SERVER['CONTENT_TYPE'] != 'application/json') {
            throw new \Exception('Required json request', 400);
        }
    }

    public function setMethodsMap($ar)
    {
        if (is_array($ar)) {
            $this->_map = $ar;
        }
    }

    public function getUri()
    {
        if (!is_array($this->_map) || count($this->_map) == 0) {
            $ar = App::getInstance()->getConfig()->rpcRoutes;
            if (is_array($ar) && count($ar) > 0) {
                $this->_map = $ar;
            } else {
                throw new \Exception('Router requires method map', 400);
            }
        }

        $request = json_decode(file_get_contents('php://input'), true);
        if (!is_array($request) || !isset($request['method'])) {
            throw new \Exception('Required json request', 400);
        } else {
            if ($this->_map[$request['method']]) {
                $this->_requestId = $request['id'];
                $this->_post = $request['params'];
                return $this->_map[$request['method']];
            } else {
                throw new \Exception('Method not found', 501);
            }
        }
    }

    public function getRequestId()
    {
        return $this->_requestId;
    }

    public function getPost()
    {
        return $this->_post;
    }
}