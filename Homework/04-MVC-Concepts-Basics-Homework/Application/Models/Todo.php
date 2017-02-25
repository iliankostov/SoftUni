<?php


namespace Models;


use Framework\DB\SimpleDB;

class Todo
{
    public function getTodoItems($userId){
        $db = new SimpleDB();
        $result = $db->prepare("SELECT * FROM todos WHERE user_id = ?")->execute([$userId])->fetchAllAssoc();
        return $result;
    }

    public function addTodoItem($userId, $text){
        $db = new SimpleDB();
        $db->prepare("INSERT INTO todos (user_id, item) VALUES (?, ?)")->execute([$userId, $text])->getAffectedRows();
        return true;
    }

    public function deleteTodoItem($userId, $todoId){
        $db = new SimpleDB();
        $db->prepare("DELETE FROM todos WHERE user_id = ? AND id = ?")->execute([$userId, $todoId])->getAffectedRows();
        return true;
    }
}