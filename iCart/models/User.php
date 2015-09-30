<?php

namespace Models;

use Framework\Database\DefaultDatabase;

class User
{
    private $id;
    private $username;
    private $email;
    private $password;
    private $cash;

    public function __construct($username, $email, $password, $cash)
    {
        $this->username = $username;
        $this->email = $email;
        $this->password = $password;
        $this->cash = $cash;
    }
}