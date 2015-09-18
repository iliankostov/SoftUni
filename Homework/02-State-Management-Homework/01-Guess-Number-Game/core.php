<?php
if (isset($_POST['name'])) {
    $name = $_POST['name'];
    $number = rand(1, 100);

    setcookie('name', $name);
    $_COOKIE['name'] = $name;

    setcookie('number', $number);
    $_COOKIE['number'] = $number;
}

function check($number, $guess_number, $name)
{
    if ($number > $guess_number) {
        return "Down";
    }

    if ($number < $guess_number) {
        return "Up";
    }

    return "Congratulations, " . $name . ". " . '<a href="index.php">Play Again</a>';
}

function __()
{
    $output = "";

    if (isset($_GET['number'])) {
        if (isset($_COOKIE['number'])) {
            $str_number = $_GET['number'];

            $number = ctype_digit($str_number) ? intval($str_number) : null;

            if ($number >= 1 && $number <= 100 && $number !== null) {
                isset($_COOKIE['name'])
                    ? $name = $_COOKIE['name']
                    : $name = "guest";

                isset($_COOKIE['number'])
                    ? $guess_number = $_COOKIE['number']
                    : $guess_number = 1;

                $output .= check($number, $guess_number, $name);
            } else {
                $output .= "Invalid Number";
            }
        }
    }

    return $output;
}

;
