// ARRAYS

function dynamicArr(arr) {
    arr[1] = 'one';  // push value at given index. If any replace it.

    var elementLast = arr.pop(); // removes and returns the last element.
    arr.push(elementLast); // // push value at the end of array w/o replacing.

    var elementZero = arr.shift(); // remove and returns the element at the beginning of the array.
    arr.unshift(elementZero); // insert a new element at the beginning of the array w/o replacing.

    arr = arr.concat('six', 'seven', 'eight', 'nine'); // return array which has concat elements at the end.

    arr.reverse().reverse(); // return a new array with elements in reversed order twice.
    arr = arr.slice(0, 6); // return sliced array from start index to end index.

    var length = arr.length; // return the length of the array
    var element = 'two';                     // change the element to find its index
    var elementIndex = arr.indexOf(element); // return -1 if the element is not found

    console.log(arr.join(" ") + "\nlength = " + length + "\nelement '" + element + "' has index " + elementIndex);
}
//dynamicArr(['zero', 1, 'two', 'three', 'four', 'five']);

function filterNumArr(arr) {
    arr = arr.filter(function isBigEnough(element) {
        return element >= 10;
    });
    console.log(arr);
}
//filterNumArr([12, 5, 8, 130, 44]);

function filterStrArr(arr) {
    var filtered = arr.filter(function(item){
        return item.match(/[0-9]/g);
    });
    console.log(filtered.join(" "));
}
//filterStrArr(['apple','avocado', '6ipka', 'banana','cherry', '4ere6i']);

function forEachArray(arr) {
    arr.forEach(function(element, index) {
        element++;
        console.log('a[' + index + '] = ' + element);
    });
}
//forEachArray([2, 5, , 9]);

function sortArr(arr) {
    // Sorting arrays with simple sort as string
    arr.sort(arr); // Ascending order !!! the numbers are taken as string !!!
    console.log(arr.join(" < ") + " ---> arr.sort(arr) makes ascending string order");

    // Sorting arrays with compare function. It defines the sorting rules.
    arr.sort(function(a, b) {
        return a > b; // If you use < the order is descending. If you use > the order is ascending.
    });
    console.log(arr.join(" < ") + " ---> compare function makes (ascending || descending) (number && string) order");
}
//sortArr([0, 111,'brake', 2, 3, 'six', 'seven', 'eight', 'nine']);

// ASSOCIATED ARRAYS

function forInLoop(arr) {
    // itin loop which print ---> key : value
    arr['Location'] = 'Sofia'; // add new key with value in arr
    delete arr['Surname']; // delete key Surname with its value
    for (var key in arr) {
        if (arr.hasOwnProperty(key)) {
            var value = arr[key]; // !!! if you think that key is value you are wrong.
            console.log(key + ": " + value); // printing key: value
        }
    }
    var keysOnly = Object.keys(arr); // return array with keys
    console.log("Array with keys -> " + keysOnly.join(" "));
}
//forInLoop( { Name: 'Ilian', Surname: 'Kostov'});

function sortObj(obj) {
    obj.sort(function (a, b) {
        if (a.name > b.name) { // If the name of a is greater than the name of b
            return 1; // The compare function sort descending;
        }
        if (a.name < b.name) { // If the name of a is less than the name of b
            return -1; // The compare function sort ascending;
        }
        // a must be equal to b
        return 0;
    });
    var check = typeof obj;
    console.log("The output is sorted " + check + ":");
    console.log(obj);


}
//sortObj([
//    { name: 'Edward', value: 21 },
//    { name: 'Sharpe', value: 37 },
//    { name: 'And', value: 45 },
//    { name: 'The', value: -12 },
//    { name: 'Magnetic' },
//    { name: 'Zeros', value: 37 }
//]);

// STRINGS

function stringTests(str) {
    var length = str.length;
    var index = 16; // change to test
    var strIndex = str[index];
    var charAtIndex = str.charAt(index);
    console.log("Length = " + length);
    console.log("String at index " + index + " = " + strIndex); // if index < 0 || index >= length output is undefined.
    console.log("Char at index " + index + " = " + charAtIndex); // // if index < 0 || index >= length output is empty.

    console.log(str.concat("Iamatail")); // concat string at the end of str.
    console.log(str.replace(str, str)); // replace str with new string.
    console.log("The first symbol 4 is positioned at index -> " + str.search(/[4]/g)); // find the index of 4 with regex.

    var startIndex = 6;
    console.log("If we start from index " + startIndex + " the first left symbol 4 is positioned at index -> " + str.indexOf("4", startIndex)); // find the index of 4 from left to right.
    console.log("If we start from index " + startIndex + " the first right symbol 4 is positioned at index -> " + str.lastIndexOf("4",startIndex)); // find the index of 4 from right to left.
    console.log("String was cut from index " + startIndex + " with total length 4 -> " + str.substr(startIndex, 4)); // cut the string from start index for given length.
    console.log("String was cut from index " + startIndex + " to index 10 -> " + str.substring(startIndex, 10)); // cut the string from start index to end index.
    console.log("This is primitive value of the object string -> " + str.valueOf()); // return primitive value.
    console.log("This is text with white spaces beside -> " + ("      ").concat(str).concat("       "));
    console.log("This is text w/o white spaces beside -> " + ("      ").concat(str).concat("       ").trim()); // trim() cut whitespaces beside.
    console.log("This is string split -> " + str.split(/\d+/g).join(" ")); // split string with regex.
    console.log("Number parse is simple Number(44) = " + Number(str.split(/[a-zA-Z]+/g).join(""))); // number parse string
}
stringTests("azobi4amma4iboza");