console.log('Problem 1. Last Digit of Number\n');

function lastDigitAsText(number) {

    var number = Number(number);

    var lastDigit = Math.abs(number % 10);

    var output;

    switch (lastDigit) {
        case 0: output = 'zero'; break;
        case 1: output = 'one'; break;
        case 2: output = 'two'; break;
        case 3: output = 'three'; break;
        case 4: output = 'four'; break;
        case 5: output = 'five'; break;
        case 6: output = 'six'; break;
        case 7: output = 'seven'; break;
        case 8: output = 'eight'; break;
        case 9: output = 'nine'; break;
        default: output = 'Invalid number!'; break;
    }

    // Printing output
    console.log('Number: ' + number);
    console.log('Last digit: ' + output);
    console.log(); // an empty row

}

// SAMPLE INPUT
var number1 = 6;
var number2 = -55;
var number3 = 133;
var number4 = 14567;

// OUTPUT
lastDigitAsText(number1);
lastDigitAsText(number2);
lastDigitAsText(number3);
lastDigitAsText(number4);

// EXIT CONSOLE
var exit = require('readline');
var prompt = exit.createInterface(process.stdin, process.stdout);

prompt.question('Press Enter to exit ...', function () {
    process.exit();
});