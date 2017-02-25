<?php
namespace Models;

use Exceptions\ReservationException;
use Contracts\iReservable;

abstract class Room implements iReservable {
    private $roomNumber;
    private $price;
    private $roomType;
    private $hasRestroom;
    private $hasBalcony;
    private $bedCount;
    private $extras = array();
    private $reservations = array();

    protected function __construct($roomNumber, $price, $roomType, $hasRestroom, $hasBalcony, $bedCount, $extras) {
        $this->setRoomNumber($roomNumber);
        $this->setPrice($price);
        $this->setRoomType($roomType);
        $this->setHasRestroom($hasRestroom);
        $this->setHasBalcony($hasBalcony);
        $this->setBedCount($bedCount);
        $this->setExtras($extras);
    }

    public function getRoomNumber() {
        return $this->roomNumber;
    }

    public function setRoomNumber($roomNumber) {
        if (intval($roomNumber) < 100 || intval($roomNumber) > 999) {
            throw new \OutOfRangeException("The room number value should be a whole positive integer in the range between 100 and 999.");
        }

        $this->roomNumber = floor($roomNumber);
    }

    public function getPrice() {
        return $this->price;
    }

    public function setPrice($price) {
        if (floatval($price) <= 0) {
            throw new \OutOfRangeException("The price should be a positive floating-point number bigger than 0.");
        }

        $this->price = $price;
    }

    public function getRoomType() {
        return $this->roomType;
    }

    public function setRoomType($roomType) {
        $this->roomType = $roomType;
    }

    public function getHasRestroom() {
        return $this->hasRestroom;
    }

    public function setHasRestroom($hasRestroom) {
        $this->hasRestroom = $hasRestroom;
    }

    public function getHasBalcony() {
        return $this->hasBalcony;
    }

    public function setHasBalcony($hasBalcony) {
        $this->hasBalcony = $hasBalcony;
    }

    public function getBedCount() {
        return $this->bedCount;
    }

    public function setBedCount($bedCount) {
        $this->bedCount = floor($bedCount);
    }

    public function getExtras() {
        return $this->extras;
    }

    public function setExtras($extras) {
        $this->extras = $extras;
    }

    public function addReservation($reservation) {
        $this->checkForValidReservation($reservation);
        array_push($this->reservations, $reservation);
    }

    public function  checkForValidReservation(Reservation $reservation) {
        foreach ($this->reservations as $existingReservation) {

            if ($reservation->getStartDate() >= $existingReservation->getStartDate() &&
                $reservation->getStartDate() <= $existingReservation->getEndDate() ||
                $reservation->getEndDate() >= $existingReservation->getStartDate() &&
                $reservation->getEndDate() <= $existingReservation->getEndDate()) {

                throw new ReservationException($this->roomNumber, $reservation);
            }
        }
    }

    public function removeReservation($reservation) {
        $existingReservation = array_search($reservation, $this->reservations);

        if ($existingReservation) {
            unset($this->reservations[$existingReservation]);
        }
    }

    public function __toString() {
        $roomInfo = "Room " . $this->roomNumber . ", type - " . $this->roomType;
        $roomInfo .= ", has " . $this->bedCount . " beds ";
        if ($this->hasRestroom === true) {
            $roomInfo .= ", with restroom";
        } else {
            $roomInfo .= ", no restroom";
        }

        if ($this->hasBalcony === true) {
            $roomInfo .= ", with balcony";
        } else {
            $roomInfo .= ", no balcony";
        }

        $roomInfo .= ", extras - " . implode(", ", $this->extras);
        $roomInfo .= ". Cost: " . $this->price . " USD.<br>";

        if (count($this->reservations) > 0) {
            $roomInfo .= "The room has been reserved:" . "<br>";

            foreach ($this->reservations as $reservation) {
                $roomInfo .= $reservation->__toString() . "<br>";
            }
        }

        return $roomInfo;
    }
}