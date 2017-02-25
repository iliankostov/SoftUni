<?php


namespace Controllers;


use Framework\DefaultController;
use Models\Todo;

class Todos extends DefaultController
{
    public function index(){
        if(!$this->isLoggedIn()){
            header('Location: \users\login');
        }
        $userId = $_SESSION['id'];
        $todoModel = new Todo();
        $data = [
            'items' => $todoModel->getTodoItems($userId)
        ];
        $this->view->appendToLayout('main', 'todos\index');
        $this->view->display('layouts.default', $data);
    }

    public function add(){
        if(!$this->isLoggedIn()){
            header('Location: \users\login');
        }

        $data = '';

        if(isset($_POST['todo-name']) && !empty($_POST['todo-name'])){
            try {
                $userId = $_SESSION['id'];
                $itemName = $_POST['todo-name'];
                $todoModel = new Todo();
                $todoModel->addTodoItem($userId, $itemName);
                header('Location: \todos');
            } catch(\Exception $e) {
                $data = ['error' => $e->getMessage()];
            }
        }

        $this->view->appendToLayout('main', 'todos\add');
        $this->view->display('layouts.default', $data);
    }

    public function delete(){
        if(!$this->isLoggedIn()){
            header('Location: \users\login');
        }
        $id = $this->input->get(0);
        try {
            $userId = $_SESSION['id'];
            $todoModel = new Todo();
            $todoModel->deleteTodoItem($userId, $id);
            header('Location: \todos');
        } catch(\Exception $e) {
            echo $e;
        }
    }
}