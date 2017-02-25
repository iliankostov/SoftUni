function findMostFreqNum(arr) {
    var frequentNumber = arr[0];
    var counter = 1;
    var maxCounter = 0;

    for (var i = 0; i < arr.length - 1; i++) {
        for (var j = i + 1; j < arr.length; j++) {
            if (arr[i] === arr[j]) {
                counter++;
            }
        }
        if (counter > maxCounter) {
            maxCounter = counter;
            frequentNumber = arr[i];
        }
        counter = 1;
    }
    console.log('%d (%d times)', frequentNumber, maxCounter);
}

findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]);
findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]);
findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]);