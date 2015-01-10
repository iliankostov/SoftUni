<?php

$luggage_string = htmlspecialchars($_GET['luggage']);
$typeLuggage = [];
if (isset($_GET['typeLuggage'])) {
    $typeLuggage = $_GET['typeLuggage'];
}
$room = htmlspecialchars($_GET['room']);
$minWeight = (int)htmlspecialchars($_GET['minWeight']);
$maxWeight = (int)htmlspecialchars($_GET['maxWeight']);
$types_weight = ['furniture' => 0, 'boxes' => 0, 'bags' => 0];

$all_luggage_strings = preg_split('/C\|_\|/', $luggage_string, -1, PREG_SPLIT_NO_EMPTY);

foreach ($all_luggage_strings as $all_luggage_string) {
    $all_luggage[] = explode(';', $all_luggage_string);
}

//Filter by type
foreach ($all_luggage as $key => $filter_type) {
    if (!in_array($filter_type[0], $typeLuggage)) {
        unset($all_luggage[$key]);
    }
}

//Filter by room
foreach ($all_luggage as $key => $filter_room) {
    if ($filter_room[1] != $room) {
        unset($all_luggage[$key]);
    }
}

//Filter by weight
foreach ($all_luggage as $key => $value) {
    $types_weight[$value[0]] += (int)$value[3];
}
$types = [];
foreach ($all_luggage as $luggage) {
    $type = html_entity_decode($luggage[0]);
    $items = [
        'room' => html_entity_decode($luggage[1]),
        'name' => html_entity_decode($luggage[2]),
        'weight' => html_entity_decode($luggage[3])
    ];

    if (!isset($types[$type])) {
        $types[$type] = [];
    }
    array_push($types[$type], $items);
}

if ($types_weight['furniture'] < $minWeight || $types_weight['furniture'] > $maxWeight) {
    unset($types['furniture']);
}

if ($types_weight['boxes'] < $minWeight || $types_weight['boxes'] > $maxWeight) {
    unset($types['boxes']);
}

if ($types_weight['bags'] < $minWeight || $types_weight['bags'] > $maxWeight) {
    unset($types['bags']);
}

foreach ($types as $key => $value) {
    echo "<ul><li>" . $key . "</li></ul>";
    foreach ($value as $a => $b) {
        echo "<ul><li>" . $a . "</li></ul>";
    }
}