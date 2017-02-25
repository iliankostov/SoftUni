console.log('Problem 2. N-th Digit of Number\n');

function findNthDigit(arr) {

    var n = Number(arr[0]);
    var num = Number(arr[1]);

    // Converting number into string and extracting the digits only
    var numberToString = num.toString().match(/\d/g);
    numberToString.reverse(); // reversing digit array to assure digits are counted right to left

    // Finding the n-th digit
    var output = numberToString[n - 1];

    // Printing output
    console.log('Number: ' + num);
    console.log('n: ' + n);

    if (output == undefined) {
        console.log('The number doesn\'t have ' + n + ' digits.');
    }
    else {
        console.log('Digit ' + n + ' is: ' + output);
    }

    console.log(); // an empty row

}

// SAMPLE INPUT
var array1 = [1, 6];
var array2 = [2, -55];
var array3 = [6, 923456];
var array4 = [3, 1451.78];
var array5 = [6, 888.88];

// OUTPUT
findNthDigit(array1);
findNthDigit(array2);
findNthDigit(array3);
findNthDigit(array4);
findNthDigit(array5);

// EXIT CONSOLE
var exit = require('readline');
var prompt = exit.createInterface(process.stdin, process.stdout);

prompt.question('Press Enter to exit ...', function () {
    process.exit();
});