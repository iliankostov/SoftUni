<?php

namespace Areas\Admin\Controllers;

use Framework\DefaultController;
use Framework\View;

class Index extends DefaultController
{
    /**
     * @Route "/admin/test/opa"
     */
    public function index()
    {
        $this->view->setViewDirectory("../areas/admin/views");

        $data['admin'] = "Administration";

        $this->view->display('layouts.default', $data);
    }
}