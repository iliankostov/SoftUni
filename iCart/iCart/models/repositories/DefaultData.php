<?php

namespace Models\Repositories;

use Framework\Database\DefaultDatabase;

abstract class DefaultData
{
    protected $db;

    public function __construct()
    {
        $this->db = new DefaultDatabase();
    }
}