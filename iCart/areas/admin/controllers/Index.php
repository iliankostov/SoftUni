<?php

namespace Areas\Admin\Controllers;

use Framework\DefaultController;

class Index extends DefaultController
{
    public function index()
    {
        $this->view->setViewDirectory("../areas/admin/views");

        $data['admin'] = "Administration";

        $this->view->display('layouts.default', $data);
    }
}