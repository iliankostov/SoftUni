<?php

$lists = preg_split("/\r\n/", $_GET['list'], -1, PREG_SPLIT_NO_EMPTY);
$min_price = floatval($_GET['minPrice']);
$max_price = floatval($_GET['maxPrice']);
$filter = $_GET['filter'];
$order = $_GET['order'];

$id = 1;
$products = [];

foreach ($lists as $list) {
    $elements = preg_split("/\|/", $list, -1, PREG_SPLIT_NO_EMPTY);

    $product_id = $id;
    $model = trim($elements[0]);
    $type = trim($elements[1]);
    $info = explode(", ", trim($elements[2]));;
    $price = floatval($elements[3]);

    if ($price >= $min_price && $price <= $max_price) {
        $products[] = [$model, $type, $info, $price, $id];
    }

    $id++;
}

$resultProducts = array_filter($products, function($pr) use ($filter) {
    return $filter == $pr[1] ? true : ($filter == "all" ? true : false);
});

usort($resultProducts, function($p1, $p2) use ($order) {
    if ($p1[3] == $p2[3]) {
        return $p1[4] - $p2[4];
    }
    return ($order == "ascending" ^ $p1[3] > $p2[3]) ? -1 : 1;
});

foreach ($resultProducts as $pr) {
    $result = "";
    $result .= "<div class=\"product\" id=\"product" . $pr[4] . "\">";
    $result .= "<h2>" . htmlspecialchars($pr[0]) . "</h2>";
    $result .= "<ul>";
    foreach ($pr[2] as $cmp) {
        $result .= "<li class=\"component\">" . htmlspecialchars($cmp). "</li>";
    }
    $result .= "</ul>";
    $result .= "<span class=\"price\">" . number_format($pr[3], 2, '.', '') . "</span>";
    $result .= "</div>";
    echo $result;
}