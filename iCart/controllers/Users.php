<?php

namespace Controllers;

use Models\User;

class Users
{
    public function index()
    {
        $user = new User();
        $admin = $user->getAdmin();
        var_dump($admin);
    }
}