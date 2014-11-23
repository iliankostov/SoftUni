function solve(input) {

    var bill = Number(input[0]);
    var mood = input[1];
    var tip = 0;

    if (mood == 'happy') {
        tip = bill * 0.1;
    } else if (mood == 'married') {
        tip = bill * 0.0005;
    } else if (mood == 'drunk') {
        tip = bill * 0.15;
        var firstDigit = tip.toString().charAt(0);
        tip = Math.pow(tip, Number(firstDigit));
    } else {
        tip = bill * 0.05;
    }
    console.log(tip.toFixed(2));
}


solve(["120.44",
    "happy"
]);

solve(["1230.83",
    "drunk"
]);

solve(["716.00",
    "married"
]);
