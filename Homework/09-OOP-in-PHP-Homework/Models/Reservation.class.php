<?php
namespace Models;

class Reservation {
    private $startDate;
    private $endDate;
    private $guest;

    function __construct($startDate, $endDate, Guest $guest) {
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
        $this->guest = $guest;
    }

    public function getStartDate() {
        return $this->startDate;
    }

    public function setStartDate($startDate) {
        $newDate = date("d-m-Y", strtotime($startDate));
        if (!$newDate) {
            throw new \InvalidArgumentException("The reservation start date did not contain a valid string representation of a date and time.");
        }

        $this->startDate = $newDate;
    }

    public function getEndDate() {
        return $this->endDate;
    }

    public function setEndDate($endDate) {
        $newDate = date("d-m-Y", strtotime($endDate));
        if (!$newDate) {
            throw new \InvalidArgumentException("The reservation end date did not contain a valid string representation of a date and time.");
        }

        $this->endDate = $newDate;
    }

    public function getGuest() {
        return $this->guest;
    }

    public function setGuest(Guest $guest) {
        $this->guest = $guest;
    }

    function __toString() {
        return "from " . $this->startDate
        . " to " . $this->endDate
        . " for guest " . $this->guest->__toString();
    }
}