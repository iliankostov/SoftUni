<?php

namespace Areas\Admin\Controllers;

use Areas\Admin\Models\AdminData;
use Areas\Admin\Models\Product;
use Framework\DefaultController;
use Models\BindingModels\AddProductBindingModel;
use Models\BindingModels\EditProductBindingModel;

class Products extends DefaultController
{
    /**
     * @BindingModel AddProductBindingModel
     */
    public function add(AddProductBindingModel $bindingModel)
    {
        if (!$this->isAdmin()) {
            header('Location: /admin');
        }
        if ($bindingModel) {
            if (!is_numeric($bindingModel->getProductprice()) ||
                $bindingModel->getProductquantity() < 0 ||
                $bindingModel->getProductprice() < 0
            ) {
                throw new \Exception('Invalid price or quantity');
            }
            $product = new Product();
            $product->setProductname($bindingModel->getProductname());
            $product->setProductmodel($bindingModel->getProductmodel());
            $product->setCategory($bindingModel->getCategory());
            $product->setProductprice($bindingModel->getProductprice());
            $product->setProductquantity($bindingModel->getProductquantity());
            $data = new AdminData();
            $success = $data->addProduct($product, $this->session->adminId);
            if ($success) {
                header('Location: /admin/index/home');
            } else {
                throw new \Exception('Cannot add product');
            }
        }
    }

    public function edit()
    {
        if (!$this->isAdmin()) {
            header('Location: /admin');
            exit;
        }
        if (!is_numeric($this->input->get()[0])) {
            throw new \Exception('Product id must be a number');
        }
        $data = new AdminData();
        $id = $this->input->get()[0];
        $product = $data->loadProduct($id);
        $this->view->setViewDirectory('../areas/admin/views');
        $this->view->appendToLayout("admin", "editproduct");
        $this->view->display('layouts.default', $product);
    }

    /**
     * @BindingModel EditProductBindingModel
     */
    public function editpost(EditProductBindingModel $bindingModel)
    {
        if (!$this->isAdmin()) {
            header('Location: /admin');
        }
        if ($bindingModel) {
            if (!is_numeric($bindingModel->getProductprice()) ||
                $bindingModel->getProductquantity() < 0 ||
                $bindingModel->getProductprice() < 0
            ) {
                throw new \Exception('Invalid price or quantity');
            }
            $product = new Product();
            $product->setId($bindingModel->getId());
            $product->setProductname($bindingModel->getProductname());
            $product->setProductmodel($bindingModel->getProductmodel());
            $product->setCategory($bindingModel->getCategory());
            $product->setProductprice($bindingModel->getProductprice());
            $product->setProductquantity($bindingModel->getProductquantity());
            $data = new AdminData();
            $success = $data->editProduct($product);
            if ($success) {
                header('Location: /admin/index/home');
            } else {
                throw new \Exception('Cannot edit product');
            }
        }
    }

    public function delete()
    {
        if (!$this->isAdmin()) {
            header('Location: /admin');
            exit;
        }
        if (!is_numeric($this->input->get()[0])) {
            throw new \Exception('Product id must be a number');
        }
        $data = new AdminData();
        $id = $this->input->get()[0];
        $success = $data->deleteProduct($id);
        if ($success) {
            header('Location: /admin/index/home');
            exit;
        } else {
            throw new \Exception('Cannot delete product');
        }
    }
}