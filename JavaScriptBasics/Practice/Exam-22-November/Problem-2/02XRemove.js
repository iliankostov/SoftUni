function solve(input) {

    // Initialize the output as char[][], holding the input chars
    var output = []; // тук ще се търсят триъгълниците

    for (var row = 0; row < input.length; row++) {
        output[row] = input[row].split('');
    }

    // Replace all triangles with '*' (with overlapping)
    for (row = 1; row < input.length - 1; row++) {

        var maxCol = Math.min(
            input[row - 1].length - 1,
            input[row].length);

        for (var col = 0; col <= maxCol; col++) {
            var a = input[row][col + 1]; // middle of X
            var b = input[row - 1][col]; // top left
            var c = input[row - 1][col + 2]; // top right
            var d = input[row + 1][col]; // bottom left
            var e = input[row + 1][col + 2]; // bottom right

            if (a !== undefined && b !== undefined && c !== undefined && d !== undefined && e !== undefined) {
                a = a.toLowerCase();
                b = b.toLowerCase();
                c = c.toLowerCase();
                d = d.toLowerCase();
                e = e.toLowerCase();

                if (a == b && b == c && c == d && d == e) {
                    // X found --> fill it with '*'
                    output[row][col + 1] = '';
                    output[row - 1][col] = '';
                    output[row - 1][col + 2] = '';
                    output[row + 1][col] = '';
                    output[row + 1][col + 2] = '';
                }
            }
        }
    }

    for (row = 0; row < input.length; row++) {
        console.log(output[row].join(''));
    }

}

//solve([
//    'abnbjs',
//    'xoBab',
//    'Abmbh',
//    'aabab',
//    'ababvvvv'
//]);

//solve([
//    '8888888',
//    '08*8*80',
//    '808*888',
//    '0**8*8?'
//]);

//solve([
//    '^u^',
//    'j^l^a',
//    '^w^WoWl',
//    'adw1w6',
//    '(WdWoWgPoop)'
//]);

solve([
    'puoUdai',
    'miU',
    'ausupirina',
    '8n8i8',
    'm8o8a',
    '8l8o860',
    'M8i8',
    '8e8!8?!'
]);