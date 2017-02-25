var progLangId = 0;
var langId = 0;

function addProgLang() {
    progLangId++;
    var divToAdd = document.getElementById('progLang').cloneNode(true);
    divToAdd.setAttribute('id', 'progLang' + progLangId);
    var parent = document.getElementById('computerSkills');
    var childBefore = document.getElementById('remProgLang');
    parent.insertBefore(divToAdd, childBefore);
}

function removeProgLang() {
    var parent = document.getElementById('computerSkills');
    var divs = parent.getElementsByTagName('div');
    if (divs.length > 1) {
        parent.removeChild(divs[divs.length - 1]);
    }
}

function addLang() {
    langId++;
    var divToAdd = document.getElementById('lang').cloneNode(true);
    divToAdd.setAttribute('id', 'lang' + langId);
    var parent = document.getElementById('otherSkills');
    var childBefore = document.getElementById('remLang');
    parent.insertBefore(divToAdd, childBefore);
}

function removeLang() {
    var parent = document.getElementById('otherSkills');
    var divs = parent.getElementsByTagName('div');
    if (divs.length > 1) {
        parent.removeChild(divs[divs.length - 1]);
    }
}