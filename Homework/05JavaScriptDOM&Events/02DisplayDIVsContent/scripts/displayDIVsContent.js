function printUL() {
    var contents = document.getElementsByTagName('div');
    var result = document.getElementById('result');

    for (var i = 0; i < contents.length; i++) {
        if (contents[i].innerHTML == '') {
            continue;
        }
        var li = document.createElement('li');
        var text = document.createTextNode(contents[i].innerText);
        li.appendChild(text);
        result.appendChild(li);
    }
}
printUL();