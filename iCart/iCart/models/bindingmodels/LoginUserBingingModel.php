<?php

namespace Models\BindingModels;

class LoginUserBingingModel
{
    /**
     * @Required
     */
    private $username;

    /**
     * @Required
     */
    private $password;

    public function getUsername()
    {
        return $this->username;
    }

    public function setUsername($username)
    {
        $this->username = $username;
    }

    public function getPassword()
    {
        return $this->password;
    }

    public function setPassword($password)
    {
        $this->password = $password;
    }
}