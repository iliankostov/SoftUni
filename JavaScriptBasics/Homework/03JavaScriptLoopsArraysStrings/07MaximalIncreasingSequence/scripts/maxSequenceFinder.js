function findMaxSequence(arr) {
    var seqLength = 1;
    var maxLength = 0;
    var arrSeq = [arr[0]];
    var maxSeq;
    var counter = 1;
    var isFind = false;

    for (var i = 0; i < arr.length; i++) {
        if (arr[i] < arr[i + 1]) {
            seqLength++;
            arrSeq[counter] = arr[i + 1];
            counter++;
            isFind = true;
        }
        else {
            if (seqLength > maxLength) {
                maxLength = seqLength;
                maxSeq = arrSeq;
            }
            seqLength = 1;
            arrSeq = [arr[i +1]];
            counter = 1;
        }
    }
    if (isFind) {
        console.log(maxSeq);
    }
    else{
        console.log('no');
    }
}

findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);
findMaxSequence([3, 2, 1]);