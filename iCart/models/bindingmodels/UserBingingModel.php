<?php

namespace Models\BindingModels;

class UserBingingModel
{
    /**
     * @REQUIRED
     */
    private $username;

    /**
     * @REQUIRED
     */
    private $email;

    /**
     * @REQUIRED
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

    public function getEmail()
    {
        return $this->email;
    }

    public function setEmail($email)
    {
        $this->email = $email;
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