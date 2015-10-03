<?php

namespace Areas\Admin\Controllers;

use Areas\Admin\Models\AdminData;
use Framework\DefaultController;
use Models\BindingModels\AdminLoginBindingModel;

class Index extends DefaultController
{
    /**
     * @var AdminData
     */
    private $data;

    public function __construct()
    {
        parent::__construct();
        $this->data = AdminData::getInstance();
    }

    public function index(){
        $this->view->setViewDirectory('../areas/admin/views');
        $this->view->appendToLayout("admin", "index");
        $this->view->display('layouts.default');
    }

    public function home(){
        $this->

        $this->view->setViewDirectory('../areas/admin/views');
        $this->view->appendToLayout("admin", "home");
        $this->view->display('layouts.default');
    }

    public function logout()
    {
        header("Location: /admin/");
    }

    /**
     * @BindingModel AdminLoginBindingModel
     */
    public function login(AdminLoginBindingModel $bindingModel){
        if($bindingModel){
            $data = new AdminData();
            $adminId = $data->login($bindingModel->getUsername(), $bindingModel->getPassword());

            if($adminId){
                $this->session->adminId = $adminId;
            } else {
                throw new \Exception('Cannot login user');
            }

            header('Location: /admin/index/home');
        }
    }
}