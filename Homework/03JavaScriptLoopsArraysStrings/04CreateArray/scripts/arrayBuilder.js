function createArray() {
    var arr = [];
    arr.length = 21;
    for (var i = 0; i < arr.length; i++) {
        arr[i] = i*5;
    }
    return console.log(arr.join(' '));
}
createArray();