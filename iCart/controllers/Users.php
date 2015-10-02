<?php

namespace Controllers;

use Framework\DefaultController;
use Models\BindingModels\RegisterUserBingingModel;
use Models\Repositories\UsersData;
use Models\User;
use Models\ViewModels\UserViewModel;

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

        $this->view->appendToLayout('main', 'register');
        $this->view->display('layouts.default');
    }

    /**
     * @BingingModel LoginUserBingingModel
     */
    public function login($userBindingModel)
    {
        if($userBindingModel) {
            //TODO login user
        }

        $this->view->appendToLayout('main', 'login');
        $this->view->display('layouts.default', new UserViewModel());
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
}