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
                    SELECT p.id, p.name AS name, p.model, p.price, p.quantity, (p.price - p.price * ap.discount / 100) AS newprice
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
                    SELECT p.id, p.name, p.model, (p.price - p.price * ap.discount / 100) AS price
                    FROM user_cart_products AS ucp
                    INNER JOIN products AS p ON p.id = ucp.product_id
                    INNER JOIN available_products AS ap ON p.id = ap.product_id
                    WHERE ucp.user_id = ?
                ")
            ->execute([$userId])
            ->fetchAllAssoc();

        return $cart;
    }

    public function buyProduct($userId, $productId){
        $sameProducts = $this->db
            ->prepare("SELECT * FROM user_cart_products WHERE user_id = ? AND product_id = ?")
            ->execute([$userId, $productId])
            ->fetchAllAssoc();

        $hasDiscount = $this->db->prepare("SELECT discount FROM available_products WHERE product_id = ?")
            ->execute([$productId])->fetchRowAssoc();
        $price = $this->db->prepare("SELECT price FROM products WHERE id = ?")->execute([$productId])->fetchRowAssoc();
        $price = $price['price'];

        if($hasDiscount['discount']){
            $price -= $price * $hasDiscount['discount'] / 100;
        }

        if(count($sameProducts) > 0) {
            $this->db
                ->prepare("UPDATE user_cart_products SET totalprice = totalprice + ?, quantiry = quantiry + 1 WHERE product_id = ? AND user_id = ?")
                ->execute([$price, $productId, $userId]);

            return $this->db->getAffectedRows() > 0;
        } else {
            $this->db
                ->prepare("INSERT INTO
                                user_cart_products (user_id, product_id, totalprice, quantiry)
                            VALUES
                                (?, ?, ?, 1)")
                ->execute([$userId, $productId, $price]);
            return $this->db->getAffectedRows() > 0;
        }
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