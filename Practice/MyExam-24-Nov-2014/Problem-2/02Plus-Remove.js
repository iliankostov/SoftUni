function solve(input) {

    var output = [];
    var row = 0;
    for (row = 0; row < input.length; row++) {
        output[row] = input[row].split('');
    }

    for (row = 1; row < input.length - 1; row++) {
        var maxCol = Math.min(
            input[row - 1].length - 1,
            input[row].length - 2);
        for (var col = 1; col <= maxCol; col++) {
            var a = input[row][col];
            var b = input[row-1][col];
            var c = input[row+1][col];
            var d = input[row][col - 1];
            var e = input[row][col + 1];
            if (a.toLowerCase() == b.toLowerCase() &&
                b.toLowerCase() == c.toLowerCase() &&
                c.toLowerCase() == d.toLowerCase() &&
                d.toLowerCase() == e.toLowerCase()) {
                output[row][col] = '';
                output[row-1][col] = '';
                output[row+1][col] = '';
                output[row][col - 1] = '';
                output[row][col + 1] = '';
            }
        }
    }

    for (row = 0; row < input.length; row++) {
        console.log(output[row].join(''));
    }
}

solve([
    'ab**l5',
    'bBb*555',
    'absh*5',
    'ttHHH',
    'ttth'
]);


