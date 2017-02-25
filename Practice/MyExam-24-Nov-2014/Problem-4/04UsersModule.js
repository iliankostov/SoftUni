function concerts(input) {
    var concertInfo = { };
    for (var i in input) {
        var tokens = input[i].split('|');
        var band = tokens[0].trim();
        var town = tokens[1].trim();
        var date = tokens[2].trim();
        var venue = tokens[3].trim();

        if (!concertInfo[town]) {
            concertInfo[town] = { };
        }
        if (!concertInfo[town][venue]) {
            concertInfo[town][venue] = [];
        }
        if (concertInfo[town][venue].indexOf(band) == -1) {
            concertInfo[town][venue].push(band);
        }
    }


    concertInfo = sortObjectProperties(concertInfo);
    for (var town in concertInfo) {
        concertInfo[town] = sortObjectProperties(concertInfo[town]);
        for (var venue in concertInfo[town]) {
            concertInfo[town][venue].sort();
        }
    }

    console.log(JSON.stringify(concertInfo));

    function sortObjectProperties(obj) {
        var keysSorted = Object.keys(obj).sort();
        var sortedObj = {};
        for (var i = 0; i < keysSorted.length; i++) {
            var key = keysSorted[i];
            sortedObj[key] = obj[key];
        }
        return sortedObj;
    }
}

concerts([
    'level^courses',
    '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
    '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
    '{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
    '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
    '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}'
]);