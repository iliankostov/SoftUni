function findMostFreqWord(str) {
    str = str.toLowerCase().replace(/[^a-z]+/g, ' ');
    var words = str.split(/[^a-z]/).filter(Boolean);

    words = words.reverse().filter(function (e, i, arr) {
        return arr.indexOf(e, i + 1) === -1;
    }).reverse();

    words = words.sort(function (a, b) {
        return a > b;
    });

    var mostFrequent = [];
    var maxCount = 0;

    for (var i = 0; i < words.length; i++) {
        var pattern = new RegExp('\\b' + words[i] + '\\b', 'g');
        var count = (str.match(pattern)).length;

        if (count == maxCount) {
            mostFrequent.push(words[i]);
        }
        if (count > maxCount) {
            mostFrequent = [words[i]];
            maxCount = count;
        }
    }

    for (var j = 0; j < mostFrequent.length; j++) {
        mostFrequent[j] = mostFrequent[j] + ' -> ' + maxCount + ' times';
    }

    console.log(mostFrequent.join('\n'));
}

findMostFreqWord('in the middle of the night');
findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.');
findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.');