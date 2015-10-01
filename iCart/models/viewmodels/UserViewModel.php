<?php

namespace Models\ViewModels;

class UserViewModel
{
    private $username;

    public function getUsername()
    {
        return $this->username;
    }

    public function setUsername($username)
    {
        $this->username = $username;
    }
}