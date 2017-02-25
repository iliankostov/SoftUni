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

        if (!password_verify($oldPassword, $currentUser['password'])) {
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

    public function removeProductFromCart($productId, $userId)
    {
        $quantity = $this->db->prepare("SELECT quantiry FROM user_cart_products WHERE user_id = ? AND product_id = ?")
            ->execute([$userId, $productId])->fetchRowAssoc();
        $result = null;
        if ($quantity['quantiry'] > 1) {
            $result = $this->db->prepare("UPDATE user_cart_products SET quantiry = quantiry - 1 WHERE user_id = ? AND product_id = ?")
                ->execute([$userId, $productId]);
        } else {
            $result = $this->db->prepare("DELETE FROM user_cart_products WHERE user_id = ? AND product_id = ?")
                ->execute([$userId, $productId]);
        }

        if ($result->getAffectedRows() > 0) {
            return true;
        } else {
            return false;
        }
    }

    public function checkout($userId)
    {
        $userCash = $this->db->prepare("SELECT cash FROM users WHERE id = ?")
            ->execute([$userId])->fetchRowAssoc();
        $totalMoneyCart = $this->db->prepare("SELECT sum(totalprice) as sum FROM user_cart_products WHERE user_id = ?")->execute([$userId])->fetchRowAssoc();

        if ($userCash['cash'] < $totalMoneyCart['sum']) {
            throw new \Exception('You do not have enough money');
        }

        $userCart = $this->db->prepare("SELECT * FROM user_cart_products WHERE user_id = ?")
            ->execute([$userId])->fetchAllAssoc();

        foreach ($userCart as $product) {
            for ($i = 0; $i < $product['quantiry']; $i++) {
                $this->db->prepare("INSERT INTO users_products (user_id, product_id) VALUES (?, ?)")
                    ->execute([$product['user_id'], $product['product_id']]);
            }
            $this->db->prepare("UPDATE products SET quantity = quantity - ? WHERE id = ?")
                ->execute([$product['quantiry'], $product['product_id']]);
            $this->db->prepare("UPDATE users SET cash = cash - ? WHERE id = ?")
                ->execute([$product['totalprice'], $product['user_id']]);
            $remainingQuantities = $this->db->prepare("SELECT quantity FROM products WHERE id = ?")
                ->execute([$product['product_id']]);
            if ($remainingQuantities === 0) {
                $this->db->prepare("DELETE FROM available_products WHERE product_id = ?")
                    ->execute([$product['product_id']]);
            }
        }

        $result = $this->db->prepare("DELETE FROM user_cart_products WHERE user_id = ?")
            ->execute([$userId])->getAffectedRows();

        if ($result) {
            return true;
        } else {
            return false;
        }
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