function reverseString(str) {
    var reversedString = str.split('').reverse().join('').replace(',', '');
    console.log(reversedString);
}

reverseString('sample');
reverseString('softUni');
reverseString('java script');