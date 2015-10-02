<?php

namespace Controllers;

use Framework\DefaultController;

class Index extends DefaultController
{
    public function index()
    {
        $this->view->appendToLayout('main', 'index');
        $this->view->display('layouts.default');
    }
}