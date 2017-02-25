function isPrimeNumber(number) {
    if (number < 2) {
        return false;
    } else if (number == 2) {
        return true;
    } else {
        for (var i = 2; i <= Math.sqrt(number) ; i++) {
            if (number % i == 0) {
                return false;
            }
        }
        return true;
    }
}

console.log(isPrimeNumber(7));
console.log(isPrimeNumber(254));
console.log(isPrimeNumber(587));