<?php

namespace Models\BindingModels;

class RegisterUserBingingModel
{
    /**
     * @Required
     */
    private $username;

    /**
     * @Required
     */
    private $password;

    private $confirm;

    public function getConfirm()
    {
        return $this->confirm;
    }

    public function setConfirm($confirm)
    {
        if($confirm !== $this->password) {
            throw new \Exception("Password do not match");
        }

        $this->confirm = $confirm;
    }

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