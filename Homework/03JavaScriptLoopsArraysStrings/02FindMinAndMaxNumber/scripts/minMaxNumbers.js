function findMinAndMax(arr) {
    var min = Math.min.apply(null, arr),
        max = Math.max.apply(null, arr);
    return console.log('Min -> %d\nMax -> %d', min, max)
}

findMinAndMax([1, 2, 1, 15, 20, 5, 7, 31]);
findMinAndMax([2, 2, 2, 2, 2]);
findMinAndMax([500, 1, -23, 0, -300, 28, 35, 12]);