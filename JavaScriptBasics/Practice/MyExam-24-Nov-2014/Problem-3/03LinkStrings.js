function solve(input) {
    var arr = [];
    var pattern = /[A-Za-z0-9]+[=%20+]+[:/.+%A-Za-z0-9]+/g;
    var i = 0;
    var j = 0;
    var k = 0;
    var key = '';
    var value = '';

    for (i = 0; i < input.length; i++) {
        arr.push(input[i].match(pattern));
    }

    for (i = 0; i < arr.length; i++) {
        for (j = 0; j < arr[i].length; j++) {
            arr[i][j] = arr[i][j].replace('%20', '').replace('+', '').replace('+', '').replace('+', ' ').split('=');
        }
    }

    for (i = 0; i < arr.length; i++) {
        var obj = {};

        for (j = 0; j < arr[i].length; j++) {
            for (k = 0; k < arr[i][j].length; k+=2) {
                if (k % 2 == 0) {
                    key = arr[i][j][k];
                    value = arr[i][j][k+1];
                    if (obj.hasOwnProperty(key)) {
                        obj[key] += ', ' + value;
                    } else {
                        obj[key] = value;
                    }

                }
            }
        }
        console.log(printObject(obj));
        function printObject(o) {
            var out = '';
            for (var p in o) {
                out += p + '=[' + o[p] + ']';
            }
            return out;
        }
    }
}

solve(['login=student&password=student']);
solve([
    'field=value1&field=value2&field=value3',
    'http://example.com/over/there?name=ferret'
]);
solve([
    'foo=%20foo&value=+val&foo+=5+%20+203',
    'foo=poo%20&value=valley&dog=wow+',
    'url=https://softuni.bg/trainings/coursesinstances/details/1070',
    'https://softuni.bg/trainings?trainer=nakov&course=oop&course=php'
]);