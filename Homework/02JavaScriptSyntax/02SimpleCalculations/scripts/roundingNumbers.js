var roundNumbers = function roundNumber(number) {
    var flooredNumber = Math.floor(number);
    var roundedNumber = Math.round(number);
    return {
        flooredNumber: flooredNumber,
        roundedNumber: roundedNumber
    };
};

var numberOne = roundNumbers(22.7);
console.log(numberOne.flooredNumber);
console.log(numberOne.roundedNumber);

    console.log('');

var numberTwo = roundNumbers(12.3);
console.log(numberTwo.flooredNumber);
console.log(numberTwo.roundedNumber);

    console.log('');

var numberThree = roundNumbers(58.7);
console.log(numberThree.flooredNumber);
console.log(numberThree.roundedNumber);