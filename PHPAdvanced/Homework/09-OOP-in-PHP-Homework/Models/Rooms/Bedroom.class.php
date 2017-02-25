<?php
namespace Models\Rooms;

use Models\Room;
use Enumerables\RoomType;

class Bedroom extends Room {
    function __construct($roomNumber, $price) {
        parent::__construct(
            $roomNumber,
            $price,
            RoomType::GOLD,
            true,
            true,
            2,
            ["TV", "air-conditioner", "refrigerator", "mini-bar", "bathtub"]);
    }
}