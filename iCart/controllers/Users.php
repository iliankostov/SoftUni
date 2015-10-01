<?php

namespace Controllers;

use Framework\DefaultController;

class Users extends DefaultController
{
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
        $this->view->appendToLayout('main', 'profile');
        $this->view->display('layouts.default');
    }

    public function logout()
    {
        header("Location: /");
    }
}