<?php
namespace SoftUni\ViewModels;


class ProfileInformation
{
    /**
     * @var /SoftUni/ViewModels/User
     */
    private $user = null;
    public $error = false;
    public $success = false;

    public function getUser()
    {
        return $this->user;
    }

    public function setUser(UserViewModel $user)
    {
        $this->user = $user;
    }
}