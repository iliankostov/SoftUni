<?php


namespace Controllers;


use Framework\DefaultController;
use Models\User;

class Users extends DefaultController
{
    public function login(){
        $data = '';
            if(isset($_POST['username']) && isset($_POST['pass']) && !empty($_POST['username']) && !empty($_POST['pass'])){
            try {
                $user = $_POST['username'];
                $pass = $_POST['pass'];
                $this->initLogin($user, $pass);
            } catch (\Exception $e) {
                $data = ['error' => $e->getMessage()];
            }
        }

        $this->view->appendToLayout('main', 'users/login');
        $this->view->display('layouts.default', $data);
    }

    public function register(){
        $data = '';

        if(isset($_POST['username']) && isset($_POST['pass']) && !empty($_POST['username']) && !empty($_POST['pass'])){
            try{
                $user = new User();
                $username = $_POST['username'];
                $password = $_POST['pass'];
                $user->register($username, $password);
                $this->initLogin($username, $password);
                $data = ['asda'];
            }catch(\Exception $e){
                $data = ['error' => $e->getMessage()];
            }
        }

        $this->view->appendToLayout('main', 'users/register');
        $this->view->display('layouts.default', $data);
    }

    public function logout(){
        session_destroy();
        header('Location: \\');
    }
}