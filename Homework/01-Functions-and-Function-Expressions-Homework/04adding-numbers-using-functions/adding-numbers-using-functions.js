var add = function (a) {
    var sum = a;
    var funct = function (b) {
        sum += b;
        return funct;
    };

    Object.defineProperty(funct, 'valueOf', {
        value: function () {
            return sum;
        }
    });
    return funct;
};

console.log("The correct answer is in the console of the browser!");
console.log(add(1));
console.log(add(2)(3));
console.log(add(1)(1)(1)(1)(1));
console.log(add(1)(0)(-1)(-1));
var addTwo = add(2);
console.log(addTwo);
addTwo = add(2);
console.log(addTwo(3));
addTwo = add(2);
console.log(addTwo(3)(5));