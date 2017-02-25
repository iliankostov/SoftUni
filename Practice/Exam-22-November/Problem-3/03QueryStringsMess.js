function solve(arr) {
    var output = [];

    for (var i = 0; i < arr.length; i++) {
        var data = [];
        var elements = arr[i].split('&');
        for (var key in elements) {
            if (elements.hasOwnProperty(key)) {
                var element = elements[key].split('%20').join(' ');
                element = element.replace(/.+?(?=\?)(\?)+/g, '');
                element = element.replace(/[+]+/g, ' ');
                element = element.replace(/\s+/g, ' ');
                var splittedElement = element.split('=');
                var property = splittedElement[0].trim();
                var value = splittedElement[1].trim();

                if(!data[property]) {
                    data[property] = [];
                }
                data[property].push(value);
            }
        }
        output.push(data);
    }
    for (var a in output) {
        var row = '';
        if (output.hasOwnProperty(a)) {
            for (var b in output[a]) {
                if (output[a].hasOwnProperty(b)) {
                    var key2 = b;
                    var value2 = output[a][b].join(", ");
                    row += key2 + "=[" + value2 + "]";
                }
            }
            console.log(row);
        }
    }
}

//solve(['login=student&password=student']);

//solve(['field=value1&field=value2&field=value3',
//    'http://example.com/over/there?name=ferret'
//]);

solve([
    'foo=%20foo&value=+val&foo+=5+%20+203',
    'foo=poo%20&value=valley&dog=wow+',
    'url=https://softuni.bg/trainings/coursesinstances/details/1070',
    'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php'
]);