<?php

namespace Controllers;

use Framework\DefaultController;
use Models\User;

class Users extends DefaultController
{
    public function index()
    {
        $user = new User();
        $admin = $user->getAdmin();
        var_dump($admin);
    }

    public function register()
    {
        $this->view->appendToLayout('body', 'register');
        $this->view->display('layouts.default');
    }

    public function login()
    {
        $this->view->appendToLayout('body', 'login');
        $this->view->display('layouts.default');
    }

    public function logout()
    {
        $this->view->appendToLayout('body', 'index');
        $this->view->display('layouts.default');
    }
}