function findMaxSequence(arr) {
    var symbol = arr[0];
    var counter = 1;
    var maxSymbol = undefined;
    var maxCounter = 0;
    var maxSequence = [];

    for (var i = 0; i < arr.length; i++) {
        if (arr[i] === arr[i + 1]) {
            counter++;
            symbol = arr[i];
        } else {
            if (counter >= maxCounter) {
                maxCounter = counter;
                maxSymbol = symbol;
            }
            counter = 1;
            symbol = undefined;
        }
    }
    for (var j = 0; j < maxCounter; j++) {
        maxSequence[j] = maxSymbol;
    }
    console.log(maxSequence)
}

findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
findMaxSequence(['happy']);
findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']);