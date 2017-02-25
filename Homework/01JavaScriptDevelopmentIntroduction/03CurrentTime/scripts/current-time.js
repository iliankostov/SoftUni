function leadingZeroes(value) {
    if(value < 10) {
        return '0' + value;
    } else {
        return value;
    }
}

function currentTime() {
    var currentDate = new Date();
    console.log(currentDate.getHours() + ":" + leadingZeroes(currentDate.getMinutes()));
}

currentTime();