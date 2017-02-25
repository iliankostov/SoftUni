function divisionBy3(number) {
    var output = '';
    if (number % 3 == 0) {
        output = console.log(number + ' - the number is divided by 3 without remainder');
    } else {
        output = console.log(number + ' - the number is not divided by 3 without remainder');
    }
    return output;
}

divisionBy3(12);
divisionBy3(188);
divisionBy3(591);