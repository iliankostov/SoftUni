<?php

namespace Controllers;

class Index extends Base
{
    public function index()
    {
        $this->session->token = uniqid();

        $data["isLogged"] = $this->session->userid;
        $data["categories"] = $this->shopData->loadCategories();
        $this->view->appendToLayout('main', 'index');
        $this->view->display('layouts.default', $data);
    }
}