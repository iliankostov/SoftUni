<?php

namespace Controllers;

use Framework\DefaultController;
use Models\BindingModels\LoginUserBingingModel;
use Models\BindingModels\RegisterUserBingingModel;
use Models\Repositories\UsersData;
use Models\User;

class Users extends DefaultController
{
    /**
     * @var UsersData
     */
    private $data;

    public function __construct()
    {
        parent::__construct();
        $this->data = UsersData::getInstance();
    }

    public function index()
    {

        header("Location: /users/profile");
    }

    public function register()
    {
        $this->view->appendToLayout('main', 'register');
        $this->view->display('layouts.default');
    }

    public function login()
    {
        $this->view->appendToLayout('main', 'login');
        $this->view->display('layouts.default');
    }

    public function profile()
    {
        $user = $this->data->getUser($this->session->userid);

        $this->view->appendToLayout('main', 'profile');
        $this->view->display('layouts.default');
    }

    public function logout()
    {
        $this->session->destroySession();
        header("Location: /");
    }

    /**
     * @BindingModel RegisterUserBingingModel
     */
    public function postregister(RegisterUserBingingModel $userBindingModel)
    {
        if($userBindingModel) {
            $user = new User();
            $user->setUsername($userBindingModel->getUsername());
            $user->setPassword($userBindingModel->getPassword());
            $user->setRoleId($this->app->getConfig()->app['default_role']);
            $user->setCash($this->app->getConfig()->app['default_cash']);

            $response = $this->data->register($user);

            if($response) {
                header("Location: /users/login");
            } else {
                throw new \Exception("Cannot register user");
            }
        }
    }

    /**
     * @BindingModel LoginUserBingingModel
     */
    public function postlogin(LoginUserBingingModel $userBindingModel)
    {
        if($userBindingModel) {
            $user = new User();
            $user->setUsername($userBindingModel->getUsername());
            $user->setPassword($userBindingModel->getPassword());

            $response = $this->data->login($user);

            if($response) {
                $this->session->userid = $response;
                header("Location: /users/profile");
            } else {
                throw new \Exception("Cannot login user");
            }
        }
    }
}