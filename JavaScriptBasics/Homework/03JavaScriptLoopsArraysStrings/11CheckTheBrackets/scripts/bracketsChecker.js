function checkBrackets(str) {
    var openBrackets = 0;
    var closeBrackets = 0;

    for (var i = 0; i < str.length; i++) {
        if (str.charAt(i) == '(') {
            openBrackets++;
        } else if (str.charAt(i) == ')') {
            closeBrackets++;
        }
    }
    if (openBrackets == closeBrackets) {
        console.log('correct');
    } else {
        console.log('incorrect');
    }
}

checkBrackets('( ( a + b ) / 5 – d )');
checkBrackets(') ( a + b ) )');
checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )');