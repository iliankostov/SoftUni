<?php

namespace Controllers;

class Products extends Base
{
    public function category()
    {
        $categoryName = $this->input->get()[0];

        $data["isLogged"] = $this->isLogged();
        $data["categories"] = $this->shopData->loadCategories();
        $data["products"] = $this->shopData->loadProductsByCategory($categoryName);

        $this->view->appendToLayout('main', 'category');
        $this->view->display('layouts.default', $data);
    }
}