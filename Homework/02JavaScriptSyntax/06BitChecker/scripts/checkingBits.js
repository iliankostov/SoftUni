function bitChecker(number) {
    var isOne = false;
    var mask = 1 << 3;
    if (number & mask){
        isOne = true;
    }
    return console.log(isOne);
}

bitChecker(333);
bitChecker(425);
bitChecker(2567564754);