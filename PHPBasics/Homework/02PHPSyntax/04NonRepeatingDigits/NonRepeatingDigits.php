<?php
function nonRepeatingDigits($input)
{
    $output = [];
    if($input >= 100) {
        for($i = 100; $i <= $input; $i++) {
            if($i > 999) {
                break;
            }
            $firstDigit = (int)($i / 100);
            $secondDigit = (int)(($i / 10) % 10);
            $thirdDigit = (int)(($i % 100) % 10);

            if($firstDigit != $secondDigit && $secondDigit != $thirdDigit && $thirdDigit != $firstDigit) {
                $output[] = $i;
            } else {

            }
        }
        echo implode($output, ', ') . "<br /><br />\n";
    } else {
        echo "no <br /><br />\n";
    }
}

nonRepeatingDigits(1234);
nonRepeatingDigits(145);
nonRepeatingDigits(15);
nonRepeatingDigits(247);