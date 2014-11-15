function compareChars(arr1, arr2) {
    var isEqual = 'Not Equal';
    var counter = 0;
    for (var i = 0, j = 0; i < arr1.length, j < arr2.length; i++, j++) {
        if (arr1[i] === arr2[j]) {
            counter += 1;
            if (2*counter == arr1.length + arr2.length ) {
                isEqual = 'Equal';
            }
        }
    }
    return console.log(isEqual);
}

compareChars(['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'],
    ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']);
compareChars(['3', '5', 'g', 'd'],
    ['5', '3', 'g', 'd']);
compareChars(['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'],
    ['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r']);