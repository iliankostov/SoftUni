<?php

namespace Models\Repositories;

use Models\User;
use Models\ViewModels\UserViewModel;

class UsersData extends DefaultData
{
    private static $_instance;

    public function getUser($userId)
    {
        $response = $this->db
            ->prepare("SELECT username, role_id, cash FROM users WHERE id = ?")
            ->execute([$userId])
            ->fetchRowAssoc();

        $userView = new UserViewModel();
        $userView->setUsername($response['username']);
        $userView->setRoleId($response['role_id']);
        $userView->setCash($response['cash']);

        return $userView;
    }

    public function register(User $user)
    {
        if ($this->exists($user)) {
            throw new \Exception("Username is taken", 406);
        }

        $password = password_hash($user->getPassword(), PASSWORD_DEFAULT);

        $response = $this->db
            ->prepare("INSERT INTO users (username, password, role_id, cash) VALUES (?, ?, ?, ?)")
            ->execute([$user->getUsername(), $password, $user->getRoleId(), $user->getCash()]);

        return $response->getAffectedRows() > 0;
    }

    public function login(User $user)
    {
        $response = $this->db
            ->prepare("SELECT id, username, password FROM users WHERE username = ?")
            ->execute([$user->getUsername()])
            ->fetchRowAssoc();

        if (password_verify($user->getPassword(), $response['password'])) {
            return $response['id'];
        }

        return false;
    }

    public function exists(User $user)
    {
        $response = $this->db
            ->prepare("SELECT username FROM users WHERE username = ?")
            ->execute([$user->getUsername()]);

        return $response->getAffectedRows() > 0;
    }

    public function update(User $user, $oldPassword)
    {
        $currentUser = $this->db
            ->prepare("SELECT username, password FROM users WHERE id = ?")
            ->execute([$user->getId()])
            ->fetchRowAssoc();

        if(!password_verify($oldPassword, $currentUser['password'])) {
            throw new \Exception("Invalid password");
        }

        $password = password_hash($user->getPassword(), PASSWORD_DEFAULT);

        $response = $this->db
            ->prepare("UPDATE users SET password = ?, cash = ?  WHERE id = ?")
            ->execute([
                $password,
                $user->getCash(),
                $user->getId()
            ]);

        return $response->getAffectedRows() > 0;
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