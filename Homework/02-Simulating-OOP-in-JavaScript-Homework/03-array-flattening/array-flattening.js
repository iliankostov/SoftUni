Array.prototype.flatten = function () {
    var thisArray = this;
    var newArray  = [];
    recursive(thisArray);

    function recursive (arr) {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] instanceof Array) {
                recursive(arr[i]);
            } else {
                newArray.push(arr[i]);
            }
        }
    }
    return newArray;
};

var array = [1, 2, 3, 4];
console.log(array.flatten());

var array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed

var array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());
