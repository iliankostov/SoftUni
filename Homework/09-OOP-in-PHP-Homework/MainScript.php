<?php
define('CLASS_DIR', 'class/');
set_include_path(get_include_path() . PATH_SEPARATOR . CLASS_DIR);
spl_autoload_extensions('.class.php');
spl_autoload_register();

use Core\BookManager;
use Exceptions\ReservationException;
use Models\Guest;
use Models\Reservation;
use Models\Room;
use Models\Rooms\Apartment;
use Models\Rooms\Bedroom;
use Models\Rooms\SingleRoom;

$firstGuest = new Guest("Williams", "Harris", 681218);
$secondGuest = new Guest("Lee", "Green", 780925);
$thirdGuest = new Guest("Martin", "Rodriguez", 650830);
$fourthGuest = new Guest("Taylor", "Nelson", 810412);
$fifthGuest = new Guest("Jones", "Parker", 730120);

$firstReservation = new Reservation("19-10-2014", "21-10-2014", $fifthGuest);
$secondReservation = new Reservation("17-10-2014", "19-10-2014", $fourthGuest);
$thirdReservation = new Reservation("18-10-2014", "26-10-2014", $thirdGuest);
$fourthReservation = new Reservation("01-10-2014", "17-10-2014", $secondGuest);
$fifthReservation = new Reservation("01-10-2014", "17-10-2014", $firstGuest);

$rooms[201] = new SingleRoom(201, 40);
$rooms[305] = new SingleRoom(305, 60);
$rooms[412] = new Bedroom(412, 70);
$rooms[302] = new Bedroom(302, 80);
$rooms[202] = new Bedroom(202, 70);
$rooms[410] = new Bedroom(410, 80);
$rooms[501] = new Apartment(501, 200);
$rooms[401] = new SingleRoom(401, 40);
$rooms[502] = new Apartment(502, 300);
$rooms[601] = new Apartment(601, 350);

BookManager::bookRoom($rooms[201], $firstReservation);
BookManager::bookRoom($rooms[201], $fourthReservation);
BookManager::bookRoom($rooms[305], $firstReservation);
BookManager::bookRoom($rooms[305], $secondReservation);
BookManager::bookRoom($rooms[501], $secondReservation);


echo "<br>";
echo "Filtered array by bedrooms and apartments with a price less or equal to 250.<br>";

$filteredRooms = array_filter($rooms, "getBedroomsAndApartmentsByPrice");
function getBedroomsAndApartmentsByPrice(Room $room) {
    if (($room instanceof Bedroom) || ($room instanceof Apartment)) {
        if ($room->getPrice() <= 250) {
            return true;
        }
    }
    return false;
}

foreach ($filteredRooms as $room) {
    echo "Room " . $room->getRoomNumber() . ", type - " . $room->getRoomType() . ", cost: " . $room->getPrice() . " USD<br>";
}

echo "<br>";
echo "Filtered array by all rooms with a balcony<br>";

$filteredRooms = array_filter($rooms, "getAllRoomsWithBalcony");
function getAllRoomsWithBalcony(Room $room) {
    if ($room->getHasBalcony()) {
        return true;
    }
    return false;
}

foreach ($filteredRooms as $room) {
    echo "Room " . $room->getRoomNumber() . ", type - " . $room->getRoomType() . "<br>";
}

echo "<br>";
echo "Room numbers of all rooms which have a bathtub in their extras<br>";

$filteredRooms = array_filter($rooms, "getAllRoomsWithBathtub");
function getAllRoomsWithBathtub(Room $room) {
    if (in_array("bathtub", $room->getExtras())) {
        return true;
    } else {
        return false;
    }
}

foreach ($filteredRooms as $room) {
    echo "Room " . $room->getRoomNumber() . ", type - " . $room->getRoomType() . "<br>";
}

echo "<br>";
echo "Filtered array by all apartments which are not booked between 17.10.2014 and 19.10.2014.<br>";

$filteredRooms = array_filter($rooms, "getAllNonBookedApartments");
function getAllNonBookedApartments(Room $room) {
    $guest = new Guest("classified", "classified", 831126);
    $reservation = new Reservation("17-10-2014", "19-10-2014", $guest);

    try {
        if ($room instanceof Apartment && !$room->checkForValidReservation($reservation)) {

            return true;
        }
    } catch (ReservationException $reservationException) {
        return false;
    }
}

foreach ($filteredRooms as $room) {
    echo "Room " . $room->getRoomNumber() . ", type - " . $room->getRoomType() . "<br>";
}