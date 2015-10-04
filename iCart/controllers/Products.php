<?php

namespace Controllers;

class Products extends Base
{
    public function index()
    {
        header("Location: /");
        $this->session->token = uniqid();
    }

    public function category()
    {
        $this->session->csrf = uniqid();
        $categoryName = $this->input->get()[0];

        $data["isLogged"] = $this->isLogged();
        $data["categories"] = $this->shopData->loadCategories();
        $data["products"] = $this->shopData->loadProductsByCategory($categoryName);
        $data["csrf"] = $this->session->csrf;

        $this->view->appendToLayout('main', 'category');
        $this->view->display('layouts.default', $data);
    }

    public function buy(){
        if($this->input->get()[1] !== $this->session->csrf){
            throw new \Exception('Token invalid');
        }
        $productId = $this->input->get()[0];
        $userId = $this->session->userid;
        $success = $this->shopData->buyProduct($userId, $productId);
        if($success){
            header('Location: /');
            $this->session->csrf = uniqid();
        } else {
            throw new \Exception('Cannot buy product');
        }
    }
}