<?php


namespace Models;


use Framework\DB\SimpleDB;

class User
{
    public function exists($username){
        $db = new SimpleDB();
        $result = $db->prepare('SELECT id FROM users WHERE username = ?');
        $result->execute([$username]);
        return $result->getAffectedRows() > 0;
    }

    public function register($username, $password){
        $db = new SimpleDB();
        if($this->exists($username)){
            throw new \Exception("User already registered");
        }

        $password = password_hash($password, PASSWORD_DEFAULT);

        $db->prepare("
            INSERT INTO users (username, password)
            VALUES (?, ?);
        ")->execute([$username, $password]);

        return true;
    }

    public function login($username, $password){
        $db = new SimpleDB();
        $result = $db->prepare("SELECT * FROM users WHERE username = ?")->execute([$username]);
        if($result->getAffectedRows() == 0){
            throw new \Exception("Invalid username");
        }
        $user = $result->fetchRowAssoc();
        $passwordsEqual = password_verify($password, $user['password']);
        if($passwordsEqual){
            return $user['id'];
        }
        throw new \Exception("Passwords do not match");
    }

    public function edit($username, $password, $id){
        $db = new SimpleDB();
        $hashed = password_hash($password, PASSWORD_DEFAULT);
        $result = $db->prepare("UPDATE users SET username = ?, password = ? WHERE id = ?");
        $result->execute([
            $username, $hashed, $id
        ]);
        return $result->getAffectedRows() > 0;
    }
}