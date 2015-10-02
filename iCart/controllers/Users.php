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

    public function register($error = null)
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
        $this->view->appendToLayout('main', 'profile');
        $this->view->display('layouts.default');
    }

    public function logout()
    {
        header("Location: /");
    }

    /**
     * @BingingModel RegisterUserBingingModel
     */
    public function postregister(RegisterUserBingingModel $userBindingModel)
    {
        if($userBindingModel) {
            $user = new User();
            $user->setUsername($userBindingModel->getUsername());
            $user->setPassword($userBindingModel->getPassword());
            $user->setCash(10000);

            $this->data->register($user);
        }

        $this->register("dfgfh");
    }

    /**
     * @BingingModel LoginUserBingingModel
     */
    public function postlogin(LoginUserBingingModel $userBindingModel)
    {
        if($userBindingModel) {
            $user = new User();
            $user->setUsername($userBindingModel->getUsername());
            $user->setPassword($userBindingModel->getPassword());
            $user->setCash(10000);

            $this->data->login($user);
        }

        header("Location: /users/login");
    }
}