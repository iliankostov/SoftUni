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
}