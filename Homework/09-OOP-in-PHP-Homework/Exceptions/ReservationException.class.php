<?php
namespace Exceptions;

use Models\Reservation;

class ReservationException extends \Exception {
    function __construct($roomNumber, Reservation $reservation) {
        $this->message = "Room ". $roomNumber . " has already been booked from "
            . $reservation->getStartDate() . " to "
            . $reservation->getEndDate() . ".<br>";
    }
}