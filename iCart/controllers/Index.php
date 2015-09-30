<?php

namespace Controllers;

use Framework\DefaultController;

class Index extends DefaultController
{
    public function index()
    {
        $data = array();
        $data['isLogged'] = false;

        $this->view->appendToLayout('main', 'index');
        $this->view->display('layouts.default', $data);
    }
}