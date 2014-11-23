console.log('Problem 3. Number with Largest Sum of Digits\n');

function findLargestBySumOfDigits(arr) {

    var numbers = arr.map(function (number) {
        return Number(number);
    });

    var largestSum = 0;
    var output;

    for (var number in numbers) {

        // Excluding non-numeric values and float-point numbers
        if (typeof(numbers[number]) === 'number' && numbers[number] % 1 === 0) {

            // Finding the sum of digits for each number
            var temporarySum = sumOfDigits(Math.abs(numbers[number]));

            // Comparing the sum of digits of each number and populating the output
            if (temporarySum > largestSum) {
                largestSum = temporarySum;
                output = numbers[number];
            }
        }
        else {
            output = undefined;
        }
    }

    // This function calculates the sum of digits for each number in the array
    function sumOfDigits(number) {

        var numberToString = number.toString();
        var sum = 0;

        for (var a = 0; a < numberToString.length; a++) {
            sum += parseInt(numberToString.charAt(a), 10);
        }

        return sum;
    }

    // Printing output
    console.log(arr);
    console.log(output);
    console.log(); // an empty row

}

// SAMPLE INPUT
var array1 = [5, 10, 15, 111];
var array2 = [33, 44, -99, 0, 20];
var array3 = ['hello'];
var array4 = [5, 3.3];

// OUTPUT
findLargestBySumOfDigits(array1);
findLargestBySumOfDigits(array2);
findLargestBySumOfDigits(array3);
findLargestBySumOfDigits(array4);

// EXIT CONSOLE
var exit = require('readline');
var prompt = exit.createInterface(process.stdin, process.stdout);

prompt.question('Press Enter to exit ...', function () {
    process.exit();
});