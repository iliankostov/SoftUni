<?php

namespace Controllers;

use Framework\DefaultController;
use Models\BindingModels\LoginUserBingingModel;
use Models\BindingModels\RegisterUserBingingModel;
use Models\BindingModels\UpdateUserBingingModel;
use Models\Repositories\UsersData;
use Models\User;

class Users extends DefaultController
{
    /**
     * @var UsersData
     */
    private $data;

    public function __construct()
    {
        parent::__construct();
        $this->data = UsersData::getInstance();
    }

    /**
     * @GET
     */
    public function index()
    {
        header("Location: /");
        $this->session->token = uniqid();
    }

    /**
     * @GET
     */
    public function register()
    {
        $this->session->token = uniqid();

        if($this->isLogged()) {
            header("Location: /users/profile");
        }

        $data["isLogged"] = $this->isLogged();

        $this->view->appendToLayout('main', 'register');
        $this->view->display('layouts.default', $data);
    }

    /**
     * @GET
     */
    public function login()
    {
        $this->session->token = uniqid();

        if($this->isLogged()) {
            header("Location: /users/profile");
        }

        $data["isLogged"] = $this->isLogged();

        $this->view->appendToLayout('main', 'login');
        $this->view->display('layouts.default', $data);
    }

    /**
     * @GET
     */
    public function profile()
    {
        $this->session->token = uniqid();

        if(!$this->isLogged()) {
            header("Location: /users/login");
        }

        $userView = $this->data->getUser($this->session->userid);
        $userView->setToken($this->session->token);

        $this->view->appendToLayout('main', 'profile');
        $this->view->display('profile', $userView);
    }

    /**
     * @GET
     * @Authorize
     */
    public function cart()
    {
        $this->session->token = uniqid();

        if(!$this->isLogged()) {
            header("Location: /users/profile");
        }

        $data["isLogged"] = $this->isLogged();

        $this->view->appendToLayout('main', 'cart');
        $this->view->display('layouts.default', $data);
    }

    /**
     * @GET
     */
    public function logout()
    {
        $this->session->token = uniqid();

        if(!$this->isLogged()) {
            header("Location: /users/login");
            exit;
        }

        $this->session->destroySession();

        header("Location: /");
        $this->session->token = uniqid();
    }

    /**
     * @POST
     * @BindingModel RegisterUserBingingModel
     */
    public function postregister(RegisterUserBingingModel $userBindingModel)
    {
        if($userBindingModel) {
            $user = new User();
            $user->setUsername($userBindingModel->getUsername());
            $user->setPassword($userBindingModel->getPassword());
            $user->setRoleId($this->app->getConfig()->app['default_role']);
            $user->setCash($this->app->getConfig()->app['default_cash']);

            $response = $this->data->register($user);

            if($response) {
                header("Location: /users/login");
                $this->session->token = uniqid();
            } else {
                throw new \Exception("Cannot register user");
            }
        }
    }

    /**
     * @POST
     * @BindingModel LoginUserBingingModel
     */
    public function postlogin(LoginUserBingingModel $userBindingModel)
    {
        if($userBindingModel) {
            $user = new User();
            $user->setUsername($userBindingModel->getUsername());
            $user->setPassword($userBindingModel->getPassword());

            $userId = $this->data->login($user);

            if($userId) {
                $this->session->userid = $userId;
                $this->session->token = uniqid();
                header("Location: /users/profile");
            } else {
                throw new \Exception("Cannot login user");
            }
        }
    }

    /**
     * @POST
     * @BindingModel UpdateUserBingingModel
     */
    public function update(UpdateUserBingingModel $userBindingModel)
    {
        if($userBindingModel) {
            if($this->input->post()['csrf'] !== $this->session->token) {
                throw new \Exception("Invalid token");
            }
            $user = new User();
            $user->setId($this->session->userid);
            $user->setPassword($userBindingModel->getNewPassword());
            $user->setCash($userBindingModel->getCash());

            $response = $this->data->update($user, $userBindingModel->getOldPassword());

            if($response) {
                header("Location: /users/profile");
                $this->session->token = uniqid();
            } else {
                throw new \Exception("Cannot update user");
            }
        }
    }
}