<?php

namespace Models\Repositories;

class ShopData extends DefaultData
{
    private static $_instance;

    public function loadCategories() {
        $categories = $this->db
            ->prepare("SELECT * FROM categories")
            ->execute([])
            ->fetchAllAssoc();

        return $categories;
    }

    public function loadProductsByCategory($categoryName)
    {
        $products = $this->db
            ->prepare("
                    SELECT p.name AS name, p.model, p.price, p.quantity, (p.price * ap.discount / 100) AS newprice
                    FROM available_products AS ap
                    INNER JOIN products AS p ON p.id = ap.product_id
                    INNER JOIN categories AS c ON p.category_id = c.id
                    WHERE c.name = ?
                ")
            ->execute([$categoryName])
            ->fetchAllAssoc();

        return $products;
    }

    public function loadCart($userId)
    {
        $cart = $this->db
            ->prepare("
                    SELECT p.name, p.model, (p.price * ap.discount / 100) AS price
                    FROM user_cart_products AS ucp
                    INNER JOIN products AS p ON p.id = ucp.product_id
                    INNER JOIN available_products AS ap ON p.id = ap.product_id
                    WHERE ucp.user_id = ?
                ")
            ->execute([$userId])
            ->fetchAllAssoc();

        return $cart;
    }

    /**
     * @return ShopData
     */
    public static function getInstance()
    {
        if (self::$_instance == null) {
            self::$_instance = new ShopData();
        }

        return self::$_instance;
    }
}