function solve(input) {
    var oldStr = '01.01.1900';
    var newStr = '01.01.2015';
    var midStr = '25.05.1973';
    var tempStr = '24.05.1973';
    var pattern = /(\d{2})\.(\d{2})\.(\d{4})/;
    var oldDate = new Date(oldStr.replace(pattern,'$3-$2-$1'));
    var newDate = new Date(newStr.replace(pattern,'$3-$2-$1'));
    var midDate = new Date(midStr.replace(pattern,'$3-$2-$1'));
    var tempDate = new Date(tempStr.replace(pattern,'$3-$2-$1'));
    var haterDate = tempDate;
    var fanDate = tempDate;
    var isHasResult = false;

    for (var i = 0; i < input.length; i++) {
        var testDate = new Date(input[i].replace(pattern,'$3-$2-$1'));
        if (testDate <= oldDate || testDate >= newDate ) {
            continue;
        }
        if (testDate > midDate && testDate >= fanDate) {
            fanDate = testDate;
            isHasResult = true;
        }
        if (testDate <= midDate && testDate <= haterDate) {
            haterDate = testDate;
            isHasResult = true;
        }
    }
    if (isHasResult) {
        if (fanDate != tempDate) {
            console.log('The biggest fan of ewoks was born on %s', fanDate.toDateString());
        }
        if (haterDate != tempDate) {
            console.log('The biggest hater of ewoks was born on %s', haterDate.toDateString());
        }
    } else {
        console.log('No result');
    }
}

solve([
    '22.03.2014',
    '17.05.1933',
    '10.10.1954'
]);
solve([
    '22.03.2000'
]);
solve([
    '22.03.1700',
    '01.07.2020'
]);