<?php
namespace Models\Rooms;

use Models\Room;
use Enumerables\RoomType;

class SingleRoom extends Room {
    function __construct($roomNumber, $price) {
        parent::__construct($roomNumber, $price, RoomType::STANDARD, true, false, 1, ["TV", "air-conditioner"]);
    }
}