console.log('Problem 6. Count Number of DIVs\n');

function countDivs(html) {

    var text = html;
    var pattern = '<div';

    var count = text.split(pattern).length - 1;

    // Printing output
    console.log(text);
    console.log(); // an empty row
    console.log('Number of DIVs: ' + count);
    console.log(); // an empty row

}

// SAMPLE INPUT
var html = '<!DOCTYPE html>' + '\n' +
            '<html>' + '\n' +
            '<head lang="en">' + '\n' +
            '   <meta charset="UTF-8">' + '\n' +
            '   <title>index</title>' + '\n' +
            '   <script src="/yourScript.js" defer></script>' + '\n' +
            '</head>' + '\n' +
            '<body>' + '\n' +
            '   <div id="outerDiv">' + '\n' +
            '      <div class="first">' + '\n' +
            '         <div><div>hello</div></div>' + '\n' +
            '      </div>' + '\n' +
            '      <div>hi<div></div></div>' + '\n' +
            '      <div>I am a div</div>' + '\n' +
            '   </div>' + '\n' +
            '</body>' + '\n' +
            '</html>';

// OUTPUT
countDivs(html);

// EXIT CONSOLE
var exit = require('readline');
var prompt = exit.createInterface(process.stdin, process.stdout);

prompt.question('Press Enter to exit ...', function () {
    process.exit();
});