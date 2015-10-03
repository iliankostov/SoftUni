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

        $admin = $result->fetchRowAssoc();

        if(strcmp($admin['role_id'], '1') !== 0) {
            throw new \Exception("You are not admin");
        }

        if($result->getAffectedRows() == 0){
            throw new \Exception("Invalid username");
        }

        $passwordsEqual = password_verify($password, $admin['password']);

        if($passwordsEqual){
            return $admin['id'];
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