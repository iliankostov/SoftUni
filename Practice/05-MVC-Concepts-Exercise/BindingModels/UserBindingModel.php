<?php
namespace SoftUni\BindingModels;


class UserBindingModel
{
    private $id;
    private $username;
    private $password;

    public function __construct($username, $password, $id = null)
    {
        $this->setId($id)
            ->setUsername($username)
            ->setPassword($password);
    }

    public function getId()
    {
        return $this->id;
    }

    public function setId($id)
    {
        $this->id = $id;
        return $this;
    }

    public function getUsername()
    {
        return $this->username;
    }

    public function setUsername($username)
    {
        $this->username = $username;
        return $this;
    }

    public function setPassword($password)
    {
        $this->password = $password;
        return $this;
    }

    public function getPassword()
    {
        return $this->password;

    }
}