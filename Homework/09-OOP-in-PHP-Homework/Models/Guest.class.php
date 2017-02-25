<?php
namespace Models;

class Guest {
    private $firstName;
    private $lastName;
    private $id;

    function __construct($firstName, $lastName, $id) {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
        $this->setID($id);
    }

    public function getFirstName() {
        return $this->firstName;
    }

    public function setFirstName($firstName) {
        if (!isset($firstName) || trim($firstName) === "") {
            throw new \InvalidArgumentException("The guest's first name cannot be null, empty or consist only of whitespace characters.");
        }

        $this->firstName = $firstName;
    }

    public function getLastName() {
        return $this->lastName;
    }

    public function setLastName($lastName) {
        if (!isset($lastName) || trim($lastName) === "") {
            throw new \InvalidArgumentException("The guest's last name cannot be null, empty or consist only of whitespace characters.");
        }

        $this->lastName = $lastName;
    }

    public function getID() {
        return $this->id;
    }

    public function setID($id) {
        if (intval($id) < 100000 || intval($id) > 999999) {
            throw new \OutOfRangeException("The guest's id should be in the range between 100000 and 999999.");
        }

        $this->id = floor($id);
    }

    function __toString() {
        return $this->id . " - " . $this->firstName . " " . $this->lastName;
    }
}