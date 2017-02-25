console.log('Problem 5. Reverse Every Word in a String\n');

function reverseWordsInString(str) {

    var string = str.slice();

    var stringArray = string.split(' '); // extracting the words in the string in a string array
    var reversedString = [];

    for (var w in stringArray) {

        var word = stringArray[w];
        word = word.split(''); // splitting each word into characters
        word.reverse(); // reversing characters
        word = word.join(''); // putting word back together with reversed characters
        reversedString.push(word); // adding reversed words to new array
    }

    var output = reversedString.join(' '); // assembling new string with reversed words

    console.log('Before: ' + string);
    console.log('After: ' + output);
    console.log(); // an empty row
}

// SAMPLE INPUT
var string1 = 'Hello, how are you.';
var string2 = 'Life is pretty good, isn’t it?';

// OUTPUT
reverseWordsInString(string1);
reverseWordsInString(string2);

// EXIT CONSOLE
var exit = require('readline');
var prompt = exit.createInterface(process.stdin, process.stdout);

prompt.question('Press Enter to exit ...', function () {
    process.exit();
});