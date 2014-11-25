function printCoordinate(input) {
    var x = input.clientX || input.pageX;
    var y = input.clientY || input.pageY;

    document.getElementById('coordinates').value += 'X:' + x + ';   Y:' + y + '   Time: ' + new Date() + '\n';
}

document.addEventListener('mousemove', printCoordinate, false);