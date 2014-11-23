function solve(input) {

    var str = input[0];
    var numbers = str.match(/\d+/g);

    var hexValues = [];

    for (var i = 0; i < numbers.length; i++) {
        hexValues.push(Number(numbers[i]).toString(16).toUpperCase());
    }

    for (var j = 0; j < hexValues.length; j++) {
        hexValues[j] = '0x' + Array(4 - hexValues[j].length + 1).join('0') + hexValues[j];
    }
    console.log(hexValues.join('-'));
}

solve(['5tffwj(//*7837xzc2---34rlxXP%$”.']);
solve(['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312']);
solve(['20']);