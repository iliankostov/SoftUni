function sortArray(arr) {
    var resultArr = arr;
    var minIndex;
    var tempNumber;

    for (var j = 0; j < resultArr.length - 1; j++) {
        minIndex = j;
        for (var i = j + 1; i < resultArr.length; i++) {
            if (resultArr[i] < resultArr[minIndex]) {
                minIndex = i;
            }
        }

        if(minIndex != j) {
            tempNumber = resultArr[j];
            resultArr[j] = resultArr[minIndex];
            resultArr[minIndex] = tempNumber;
        }
    }

    console.log(resultArr.join(', '));
}

sortArray([5, 4, 3, 2, 1]);
sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]);