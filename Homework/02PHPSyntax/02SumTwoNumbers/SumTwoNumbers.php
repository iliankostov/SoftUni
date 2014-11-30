<?php
function sumTwoNumbers($number1, $number2)
{
    $result = $number1 + $number2;
    echo '$firstNumber + $secondNumber = ' . $number1 . ' + ' . $number2 . ' = ' . number_format($result, 2, ',', '') . "<br />\n";
}

sumTwoNumbers(2, 5);
sumTwoNumbers(1.567808, 0.356);
sumTwoNumbers(1234.5678, 333);