<?php

namespace Models\ViewModels;

use Framework\Common;

class UserViewModel
{
    private $username;
    private $role_id;
    private $cash;
    private $token;
    private $data = [];


    /**
     * @return mixed
     */
    public function getToken()
    {
        return $this->token;
    }

    /**
     * @param mixed $token
     */
    public function setToken($token)
    {
        $this->token = $token;
    }

    /**
     * @return array
     */
    public function getData()
    {
        return $this->data;
    }

    /**
     * @param array $data
     */
    public function setData($data)
    {
        $this->data = $data;
    }

    /**
     * @return mixed
     */
    public function getRoleId()
    {
        return $this->role_id;
    }

    /**
     * @param mixed $role_id
     */
    public function setRoleId($role_id)
    {
        $this->role_id = $role_id;
    }

    /**
     * @return mixed
     */
    public function getCash()
    {
        return $this->cash;
    }

    /**
     * @param mixed $cash
     */
    public function setCash($cash)
    {
        $this->cash = $cash;
    }

    public function getUsername($xss = true)
    {
        if ($xss) {
            $this->username = htmlspecialchars($this->username);
        }

        return $this->username;
    }

    public function setUsername($username)
    {
        $this->username = $username;
    }
}