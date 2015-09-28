<?php

namespace Models;

use Framework\Database\DefaultDatabase;

class User
{
    public function getAdmin()
    {
        $db = new DefaultDatabase();

        return $db->prepare("SELECT * FROM users WHERE id= ?")->execute([1])->fetchRowAssoc();
    }
}