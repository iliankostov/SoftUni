<?php

namespace Models\Repositories;

class UsersData extends DefaultData
{
    private static $_instance;

    public function getUser($user)
    {

    }

    public function register($user)
    {
        $response = $this->db
            ->prepare("INSERT INTO users (username, password, cash) VALUES ?, ?, ? ")
            ->execute($user)
            ->fetchRowAssoc();
        var_dump($response);
    }

    public function exists($user)
    {
        $response = $this->db
            ->prepare("SELECT FROM users (username, password, cash) VALUES ?, ?, ? ")
            ->execute($user)
            ->fetchRowAssoc();
        var_dump($response);
    }

    /**
     * @return UsersData
     */
    public static function getInstance()
    {
        if (self::$_instance == null) {
            self::$_instance = new UsersData();
        }

        return self::$_instance;
    }
}