<?php

namespace Controllers;

use Framework\DefaultController;
use Models\BindingModels\UserBingingModel;

class Users extends DefaultController
{
    public function index()
    {
        header("Location: /users/profile");
    }

    public function register()
    {
        $data = array();
        $data['isLogged'] = false;

        $this->view->appendToLayout('main', 'register');

        $this->view->display('layouts.default', $data);
    }

    public function login()
    {
        $data = array();
        $data['isLogged'] = false;

        $this->view->appendToLayout('main', 'login');

        $this->view->display('layouts.default', $data);
    }

    public function profile()
    {
        $data = array();
        $data['isLogged'] = false;

        $this->view->appendToLayout('main', 'profile');
        $this->view->display('layouts.default', $data);
    }

    public function logout()
    {
        header("Location: /");
    }
}