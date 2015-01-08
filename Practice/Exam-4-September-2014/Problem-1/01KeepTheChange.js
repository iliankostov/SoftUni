function solve(arr) {
    var bill = arr[0];
    var mood = arr[1];
    var tip = 0;

    switch(mood) {
        case "happy":
            tip = 0.1*bill;
            break;
        case "married":
            tip = 0.0005*bill;
            break;
        case "drunk":
            tip = 0.15*bill;
            var firstDigit = parseInt(tip.toString().charAt(0));
            tip = Math.pow(tip, firstDigit);
            break;
        default:
            tip = 0.05*bill;
            break;
    }
    console.log(tip.toFixed(2));

}

solve([
    120.44,
    'happy'
]);
solve([
    1230.83,
    'drunk'
]);
solve([
    716.00,
    'bored'
]);