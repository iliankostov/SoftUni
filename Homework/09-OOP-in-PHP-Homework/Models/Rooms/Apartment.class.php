<?php
namespace Models\Rooms;

use Models\Room;
use Enumerables\RoomType;

class Apartment extends Room {
    function __construct($roomNumber, $price) {
        parent::__construct(
            $roomNumber,
            $price,
            RoomType::DIAMOND,
            true,
            true,
            4,
            ["TV", "air-conditioner", "refrigerator", "mini-bar", "bathtub", "kitchen box", "free Wi-Fi"]);
    }
}