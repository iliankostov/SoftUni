<?php

class Db
{
    const hostname = "localhost";
    const username = "user";
    const password = "qwerty123";
    const db_name = "todo_list";

    private static $instance;

    public static function getInstance()
    {
        if (static::$instance === null) {
            $hostname = self::hostname;
            $db_name = self::db_name;

            static::$instance = new PDO("mysql:host=$hostname;dbname=$db_name", static::username, static::password,
                array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8"));
        }

        return static::$instance;
    }

    public static function createUser($username, $password)
    {
        $hashPassword = password_hash($password, PASSWORD_DEFAULT);

        $row = self::getUser($username);

        if ($row[0] === $username) {
            return "User already exists";
        }

        $newUser = self::getInstance()->prepare("
            INSERT INTO users (username, passwordHash) VALUES (?, ?)
        ");

        $data = array($username, $hashPassword);

        $newUser->execute($data);

        return "Successful registration";
    }

    public static function isUserValid($username, $password)
    {
        $row = self::getUser($username);

        if ($username === $row[1] && password_verify($password, $row[2])) {
            return $row[0];
        }

        return false;
    }

    public static function getTodoItems($user_id)
    {
        $allTodos = self::getInstance()->prepare("
            SELECT id, user_id, todo_item FROM todos WHERE user_id = ?;
        ");

        $data = array($user_id);

        $allTodos->execute($data);

        $rows = $allTodos->fetchAll(PDO::FETCH_ASSOC);

        return array_reverse($rows);
    }

    public static function addTodoItem($user_id, $todo_text)
    {
        $newTodo = self::getInstance()->prepare("
            INSERT INTO todos (user_id, todo_item) VALUES (?, ?)
        ");

        $data = array($user_id, $todo_text);

        $newTodo->execute($data);
    }

    public static function deleteTodoItem($user_id, $todo_id)
    {
        $deleteTodo = self::getInstance()->prepare("
            DELETE FROM todos WHERE user_id = ? AND id = ?
        ");

        $data = array($user_id, $todo_id);

        $deleteTodo->execute($data);
    }

    public static function getUser($username)
    {
        $getUser = self::getInstance()->prepare("
            SELECT id, username, passwordHash FROM users WHERE username = ?;
        ");

        $data = array($username);

        $getUser->execute($data);

        $row = $getUser->fetch(PDO::FETCH_NUM);
        return $row;
    }
}
