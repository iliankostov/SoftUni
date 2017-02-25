console.log('Problem 4. Bigger Than Neighbors\n');

function biggerThanNeighbors(index, arr) {

    var index = Number(index);
    var numbers = arr.map(function (number) {
        return Number(number);
    });
    var output;

    if (index < 0 || index >= numbers.length) {
        output = 'invalid index';
    }
    else if (index === 0 || index === numbers.length - 1) {
        output = 'only one neighbour';
    }
    else if (numbers[index] > numbers[index - 1] && numbers[index] > numbers[index + 1]) {
        output = 'bigger';
    }
    else {
        output = 'not bigger';
    }

    // Printing output
    console.log(numbers);
    console.log('index: ' + index);
    console.log(output);
    console.log(); // an empty row
}

// SAMPLE INPUT
var number1 = 2;
var array1 = [1, 2, 3, 3, 5];

var number2 = 2;
var array2 = [1, 2, 5, 3, 4];

var number3 = 5;
var array3 = [1, 2, 5, 3, 4];

var number4 = 0;
var array4 = [1, 2, 5, 3, 4];

// OUTPUT
biggerThanNeighbors(number1, array1);
biggerThanNeighbors(number2, array2);
biggerThanNeighbors(number3, array3);
biggerThanNeighbors(number4, array4);

// EXIT CONSOLE
var exit = require('readline');
var prompt = exit.createInterface(process.stdin, process.stdout);

prompt.question('Press Enter to exit ...', function () {
    process.exit();
});