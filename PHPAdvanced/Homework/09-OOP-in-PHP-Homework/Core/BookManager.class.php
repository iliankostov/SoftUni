<?php
namespace Core;

use Exceptions\ReservationException;
use Models\Reservation;
use Models\Room;

class BookManager {
    public static function bookRoom(Room $room, Reservation $reservation) {
        try {
            $room->addReservation($reservation);
            echo "Room <strong>" . $room->getRoomNumber() . "</strong>"
                . " successfully booked for guest <strong>"
                . $reservation->getGuest() . "</strong>"
                . " from <time>" . $reservation->getStartDate() . "</time>"
                . " to <time>" . $reservation->getEndDate() . "</time>" . "!<br>";
        } catch (ReservationException $reservationException) {
            echo $reservationException->getMessage();
        }
    }
}