<?php
namespace SoftUni\ViewModels;


class BuildingsInformation
{
    /**
     * @var /SoftUni/ViewModels/User
     */
    private $user = null;
    private $buildings = null;
    public $error = false;
    public $success = false;

    public function __construct(UserViewModel $user)
    {
        $this->user = $user;
    }

    public function getUser()
    {
        return $this->user;
    }

    public function setUser(User $user)
    {
        $this->user = $user;
    }

    public function getBuildings()
    {
        return $this->buildings;
    }

    public function setBuildings($buildings)
    {
        $this->buildings = $buildings;
    }
}