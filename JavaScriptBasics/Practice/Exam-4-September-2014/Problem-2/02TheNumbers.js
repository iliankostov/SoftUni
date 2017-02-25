function solve(arr) {
    var numbers = arr[0].split(/[^\d+]/g);
    var output = [];
    for (var number in numbers) {
        if (numbers[number] !== '' && numbers.hasOwnProperty(number)) {
            var num = parseInt(numbers[number]);
            var hex = num.toString(16).toUpperCase();
            hex = '0x' + '0000'.substring(0, 4 - hex.length) + hex;
            output.push(hex);
        }
    }
    console.log(output.join('-'));
}

solve(['5tffwj(//*7837xzc2---34rlxXP%$”.']);
solve(['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312']);
solve(['20']);