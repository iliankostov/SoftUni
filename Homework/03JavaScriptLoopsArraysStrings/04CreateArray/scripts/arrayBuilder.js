function createArray() {
    var arr = [];
    for (var i = 0; i <= 20; i++) {
        arr[i] = i*5;
    }
    return console.log(arr.join(' '));
}
createArray();