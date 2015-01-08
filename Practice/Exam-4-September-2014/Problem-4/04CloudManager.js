function solve(arr) {

    var collection = [];

    for (var i = 0; i < arr.length; i++) {
        var elements = arr[i].split(" ");
        var pro = elements[0];
        var ext = elements[1];
        var siz = parseFloat(elements[2].substring(0, elements[2].length - 2));

        if (!collection[ext]) {
            collection[ext] = { 'files': [], 'memory': [] }
        }
        collection[ext].files.push(pro);
        collection[ext].memory.push(siz);
    }

    for (var key in collection) {
        if (collection.hasOwnProperty(key)) {
            collection[key].files.sort();
            collection[key].memory = average(collection[key].memory);
        }
    }

    var output = { };
    var keys = Object.keys(collection);
    keys.sort();

    for (var j = 0; j < keys.length; j++) {
        output[keys[j]] = collection[keys[j]];
    }
    console.log(JSON.stringify(output));

    function average(arr) {
        var sum = 0;
        for (var i = 0; i < arr.length; i++) {
            sum += arr[i];
        }
        return sum.toFixed(2);
    }

}

solve([
    'sentinel .exe 15MB',
    'zoomIt .msi 3MB',
    'skype .exe 45MB',
    'trojanStopper .bat 23MB',
    'kindleInstaller .exe 120MB',
    'setup .msi 33.4MB',
    'winBlock .bat 1MB'
]);