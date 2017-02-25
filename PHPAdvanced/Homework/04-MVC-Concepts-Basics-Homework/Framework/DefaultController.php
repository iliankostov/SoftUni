<?php


namespace Framework;


use Models\User;

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

    public function __construct()
    {
        $this->app = App::getInstance();
        $this->view = View::getInstance();
        $this->config = $this->app->getConfig();
        $this->input = InputData::getInstance();
    }

    public function isLoggedIn(){
        return isset($_SESSION['id']);
    }

    public function initLogin($user, $pass)
    {
        $userModel = new User();
        $userId = $userModel->login($user, $pass);
        $_SESSION['id'] = $userId;
        $_SESSION['username'] = $user;
        header('Location: \todos');
    }
}