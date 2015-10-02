<?php

namespace Framework;

use Framework\Sessions\ISession;
use Framework\Sessions\NativeSession;

abstract class DefaultController
{
    /**
     * @var App
     */
    protected $app;

    /**
     * @var View
     */
    protected $view;

    /**
     * @var Config
     */
    protected $config;

    /**
     * @var InputData|null
     */
    protected $input;

    /**
     * @var ISession
     */
    protected $session;

    public function __construct()
    {
        $this->app = App::getInstance();
        $this->view = View::getInstance();
        $this->config = $this->app->getConfig();
        $this->input = InputData::getInstance();
        $this->session = new NativeSession("session");
    }

    public function notFound()
    {
        throw new \Exception("Not Found", 404);
    }
}