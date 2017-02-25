<?php
namespace SoftUni\Controllers;

use SoftUni\BindingModels\UserBindingModel;
use SoftUni\Core\BuildingsRepository;
use SoftUni\Models\User;
use SoftUni\View;
use SoftUni\ViewModels\BuildingsInformation;
use SoftUni\ViewModels\LoginInformation;
use SoftUni\ViewModels\ProfileInformation;
use SoftUni\ViewModels\RegisterInformation;
use SoftUni\ViewModels\UserViewModel;

class UserController extends Controller
{
    private function initLogin($username, $password)
    {
        $userModel = new User();
        $userId = $userModel->login($username, $password);
        $_SESSION['id'] = $userId;
        header('Location: profile');
    }

    public function register()
    {
        $viewModel = new RegisterInformation();

        if (isset($_POST['username']) && isset($_POST['password'])) {
            try {
                $username = $_POST['username'];
                $password = $_POST['password'];

                $userModel = new User();
                $userModel->register($username, $password);

                $this->initLogin($username, $password);

            } catch (\Exception $exception) {
                $viewModel->error = $exception->getMessage();
                return new View($viewModel);
            }
        }

        return new View($viewModel);
    }

    public function login()
    {
        $viewModel = new LoginInformation();

        if (isset($_POST['username']) && isset($_POST['password'])) {
            try {
                $username = $_POST['username'];
                $password = $_POST['password'];

                $this->initLogin($username, $password);

            } catch (\Exception $exception) {
                $viewModel->error = $exception->getMessage();
                return new View($viewModel);
            }
        }

        return new View($viewModel);
    }

    public function profile()
    {
        if (!$this->isLogged()) {
            header('Location: login');
        }

        $viewModel = new ProfileInformation();
        $userModel = new User();

        try {
            if (isset($_POST['edit'])) {
                if (isset($_POST['username'], $_POST['password'], $_POST['confirmPassword']) && $_POST['password'] === $_POST['confirmPassword']) {
                    $id = $_SESSION['id'];
                    $username = $_POST['username'];
                    $password = $_POST['password'];

                    $updatedUser = new UserBindingModel($username, $password, $id);

                    if ($userModel->edit($updatedUser)) {
                        header("Location: profile");
                        exit;
                    }
                }
            }

            $userRow = $userModel->getInfo($_SESSION['id']);

            $user = new UserViewModel(
                $userRow['username'],
                $userRow['password'],
                $userRow['id'],
                $userRow['gold'],
                $userRow['food']
            );

            $viewModel->setUser($user);

        } catch (\Exception $exception) {
            $viewModel->error = $exception->getMessage();
            return new View($viewModel);
        }

        return new View($viewModel);
    }

    public function buildings(){
        if (!$this->isLogged()) {
            header('Location: login');
        }

        $userModel = new User();
        $userRow = $userModel->getInfo($_SESSION['id']);

        $user = new UserViewModel(
            $userRow['username'],
            $userRow['password'],
            $userRow['id'],
            $userRow['gold'],
            $userRow['food']
        );

        $viewModel = new BuildingsInformation($user);

        try {
            $buildingsRows = $userModel->getBuildings();
            $viewModel->setBuildings($buildingsRows);

        } catch (\Exception $exception) {
            $viewModel->error = $exception->getMessage();
            return new View($viewModel);
        }

        return new View($viewModel);
    }
}