function checkDigit(number) {
    var isThree = false;
    var digits = number.toString().split('').reverse();
    if (+digits[2] == 3) {
        isThree = true;
    }
    return console.log(isThree);
}

checkDigit(1235);
checkDigit(25368);
checkDigit(123456);