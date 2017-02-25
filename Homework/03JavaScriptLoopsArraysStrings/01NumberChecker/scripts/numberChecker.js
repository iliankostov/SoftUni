function printNumbers(number) {
    if (number < 1) {
        return console.log('no');
    }
    var digits = [];
    for (var i = 1; i <= number; i++) {
        if ((i % 4 == 0) || (i % 5 == 0))  {
            continue;
        } else {
            digits.push(i);
        }
    }
    console.log(digits.join(', '));
}

printNumbers(20);
printNumbers(-5);
printNumbers(13);