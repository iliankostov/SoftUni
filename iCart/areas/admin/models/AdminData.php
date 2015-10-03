<?php

namespace Areas\Admin\Models;

use Framework\Database\DefaultDatabase;

class AdminData
{
    private static $_instance;

    /**
     * @var DefaultDatabase
     */
    protected $db;

    public function __construct()
    {
        $this->db = new DefaultDatabase();
    }

    public function login($username, $password){
        $result = $this->db
            ->prepare("SELECT * FROM users WHERE username = ?")
            ->execute([$username]);

        if($result->getAffectedRows() == 0){
            throw new \Exception("Invalid username");
        }

        $fetchedUser = $result->fetchRowAssoc();
        $passwordsEqual = password_verify($password, $fetchedUser['password']);

        if($passwordsEqual){
            return $fetchedUser['id'];
        }

        throw new \Exception("Passwords do not match");
    }

    public function loadData()
    {
        $categories = $this->db
            ->prepare("SELECT * FROM categories")
            ->execute([])
            ->fetchAllAssoc();

        $products = $this->db
            ->prepare("SELECT * FROM products")
            ->execute([])
            ->fetchAllAssoc();

        $data['categories'] = $categories;
        $data['products'] = $products;

        return $data;
    }

    /**
     * @return AdminData
     */
    public static function getInstance()
    {
        if (self::$_instance == null) {
            self::$_instance = new AdminData();
        }

        return self::$_instance;
    }
}