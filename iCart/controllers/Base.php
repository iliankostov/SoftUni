<?php

namespace Controllers;

use Framework\DefaultController;
use Models\Repositories\ShopData;
use Models\Repositories\UsersData;

class Base extends DefaultController
{
    /**
     * @var UsersData
     */
    protected $userData;

    /**
     * @var ShopData
     */
    protected $shopData;

    public function __construct()
    {
        parent::__construct();
        $this->userData = UsersData::getInstance();
        $this->shopData = ShopData::getInstance();
    }
}