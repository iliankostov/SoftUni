function solve(input) {

    var numbers = [];
    var sum = 0;
    var maxSum = Number.NEGATIVE_INFINITY;
    var output;

    for (var i = 2; i < input.length - 1; i++) {

        numbers.push(input[i].match(/([-]?([0-9]*\.[0-9]+|[0-9]+))/g));

    }

    if (numbers[0] == null ) {
        output = 'no data';
    } else {

        for (var j = 0; j < numbers.length; j++) {

            if(numbers[j] == null) {
                continue;
            }
            for (var k = 0; k < numbers[j].length; k++) {

                sum += Number(numbers[j][k]);

            }
            if (sum > maxSum ) {
                maxSum = sum;
                var contents = numbers[j].slice();
            }
            sum = 0;
        }

        output = maxSum + ' = ' + contents.join(' + ');

    }

    console.log(output);

}

solve([
    "<table>",
    "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>",
    "<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>",
    "<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>",
    "<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>",
    "<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>",
    "</table>"
]);

solve([
    "<table>",
    "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>",
    "<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>",
    "</table>"
]);

solve([
    "<table>",
    "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>",
    "<tr><td>Sofia</td><td>12850</td><td>-560</td><td>20833</td></tr>",
    "<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>",
    "<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>",
    "</table>"
]);