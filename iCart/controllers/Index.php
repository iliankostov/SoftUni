<?php

namespace Controllers;

use Framework\DefaultController;

class Index extends DefaultController
{
    public function index()
    {
        $this->session->token = uniqid();

        $data["isLogged"] = $this->session->userid;

        $this->view->appendToLayout('main', 'index');
        $this->view->display('layouts.default', $data);
    }
}