<?php
namespace SoftUni\Models;


use SoftUni\BindingModels\UserBindingModel;
use SoftUni\Core\Database;

class User
{
    private $id;
    private $username;
    private $password;
    private $gold;
    private $food;

    const GOLD_DEFAULT = 1500;
    const FOOD_DEFAULT = 1500;

    public function __construct($id = null, $gold = null, $food = null)
    {
        $this->setId($id)
            ->setGold($gold)
            ->setFood($food);
    }

    public function getId()
    {
        return $this->id;
    }

    public function setId($id)
    {
        $this->id = $id;
        return $this;
    }

    public function getUsername()
    {
        return $this->username;
    }

    public function setUsername($username)
    {
        $this->username = $username;
        return $this;
    }

    public function setPassword($password)
    {
        $this->password = $password;
        return $this;
    }

    public function getPassword()
    {
        return $this->password;

    }

    public function getGold()
    {
        return $this->gold;
    }

    public function setGold($gold)
    {
        $this->gold = $gold;
        return $this;
    }

    public function getFood()
    {
        return $this->food;
    }

    public function setFood($food)
    {
        $this->food = $food;
        return $this;
    }

    public function exists($username)
    {
        $db = Database::getInstance('mvc_app');

        $findUserQuery = "SELECT id FROM users WHERE username = ?";
        $result = $db->prepare($findUserQuery);
        $result->execute([$username]);

        return $result->rowCount() > 0;
    }

    public function register($username, $password)
    {
        $db = Database::getInstance('mvc_app');

        if ($this->exists($username)) {
            throw new \Exception("User already registered");
        }

        $query = "
            INSERT INTO users(username, password, gold, food)
            VALUES(?, ?, ?, ?)
        ";

        $result = $db->prepare($query);

        $result->execute([
            $username,
            password_hash($password, PASSWORD_DEFAULT),
            User::GOLD_DEFAULT,
            User::FOOD_DEFAULT
        ]);

        if ($result->rowCount() > 0) {
            $userId = $db->lastId();

            $db->query("
                INSERT INTO users_buildings_levels (user_id, building_id, level_id)
                SELECT $userId, id, 0
                FROM buildings
            ");

            return true;
        }

        throw new \Exception("Cannot register user");
    }

    public function login($username, $password)
    {
        $db = Database::getInstance('mvc_app');

        $query = "
            SELECT id, password
            FROM users
            WHERE username = ?
        ";

        $result = $db->prepare($query);

        $result->execute([$username]);

        if ($result->rowCount() > 0) {
            $userRow = $result->fetch();

            if (password_verify($password, $userRow['password'])) {
                return $userRow['id'];
            }

            throw new \Exception('Invalid login data');
        }

        throw new \Exception('Invalid login data');
    }

    public function getInfo($userId)
    {
        $db = Database::getInstance('mvc_app');

        $query = "
            SELECT id, username, password, gold, food
            FROM users
            WHERE id = ?
        ";

        $result = $db->prepare($query);

        $result->execute([$userId]);

        return $result->fetch();
    }

    public function edit(UserBindingModel $newData)
    {
        $db = Database::getInstance('mvc_app');

        $updateQuery = "
            UPDATE users
            SET password = ?, username = ?
            WHERE id = ?
        ";

        $result = $db->prepare($updateQuery);

        $result->execute([
            password_hash($newData->getPassword(), PASSWORD_DEFAULT),
            $newData->getUsername(),
            $newData->getId()
        ]);

        return $result->rowCount() > 0;
    }

    public function getBuildings(){
        $db = Database::getInstance('mvc_app');

        $query = "
            SELECT
                ubl.building_id AS 'Id',
                b.name AS 'Name',
                ubl.level AS 'Level',
                CASE ubl.level WHEN 3 THEN 'None' ELSE bl.gold END AS 'Gold',
                CASE ubl.level WHEN 3 THEN 'None' ELSE bl.food END AS 'Food'
            FROM user_buildings_level ubl
            LEFT JOIN buildings b
                ON b.id = ubl.building_id
            LEFT JOIN building_levels bl
                ON bl.building_id = ubl.building_id AND bl.level = ubl.level + 1
            WHERE ubl.user_id = ?
        ";

        $result = $db->prepare($query);

        $result->execute([$_SESSION['id']]);

        return $result->fetchAll();
    }
}