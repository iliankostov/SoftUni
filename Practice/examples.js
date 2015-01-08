var tom = {
    firstName: 'Tom',
    lastName: 'Miller',
    toString: function () {
        return this.firstName + " " + this.lastName;
    }
};
//console.log(tom.firstName);
//console.log(tom.lastName);
//console.log(tom.toString());

var marks = [
    { subject : 'Java', score : 6.00 },
    { subject : 'HTML5', score : 5.90 },
    { subject : 'JavaScript', score : 6.00 },
    { subject : 'PHP', score : 6.00 }];
var student = { name: 'Deyan Dachev', marks: marks };
marks[1].score = 5.50;
//console.log(student.marks[1]); // logs 5.50 for HTML5 score

function calculateAverageAge(studentsArr) {
    var sum = 0;
    for (var key in studentsArr) {                // key = 0, 1, 2
        if (studentsArr.hasOwnProperty(key)) {
            sum += studentsArr[key].age;          // studentsArr[key].age = 17, 15, 22
        }
    }
    console.log("Average age = " + sum / studentsArr.length);        // studentsArr.length = 3
}
//calculateAverageAge([
//    {name: 'Ivan', age: 17, gender: 'male'},
//    {name: 'George', age: 15, sex: 'male'},
//    {name: 'Maria', age: 22, gender: 'female'}
//]);

// Shared object – two variables holding the same object:
var peter = { name: 'Peter', age: 21};
var maria = peter;          // here you say maria = peter && peter = maria !!!
maria.name = 'Maria';
//console.log(peter);
//console.log(maria);

// Cloned objects – two variables holding separate objects:
var ivan = { name: 'Ivan', age: 31};
var viki = JSON.parse(JSON.stringify(ivan)); // here you say copy ivan to viki !!!
viki.name = 'Victoria';
//console.log(ivan);
//console.log(viki);

// Converting Object to JSON string
var obj1 = { town: 'Sofia', gps: {lat: 42.70, lng: 23.32} };
var str1 = JSON.stringify(obj1);
//console.log(str1);

// Converting JSON string to Object
var str2 = '{"town":"Sofia","gps":{"lat":42.70,"lng":23.32}}';
var obj2 = JSON.parse(str2);
//console.log(obj2);

// JSON building function
function BuildPerson(fname, lname) {
    return {
        fname: fname,
        lname: lname,
        toString: function () { return this.fname + ' ' + this.lname; }
    }
}
var dichov = BuildPerson('Dicho', 'Dichov');
var georgiev = BuildPerson('Georgi', 'Georgiev');

// Counting words example
function getWords(text) {
    var words = text.split(/[\s\.,-?!)(]/);
    for (var i = 0; i < words.length; i++) {
        if (words[i] == "") {
            words.splice(i, 1);
        }
    }
    return words;
}

function countWords(words) {
    var wordsCount = {};
    var word = {};
    for (var i in words) {
        if (words.hasOwnProperty(i)) {
            word = words[i].toLowerCase();
        }
        if (wordsCount[word]) {
            wordsCount[word]++;
        }
        else {
            wordsCount[word] = 1;
        }
    }
    return wordsCount;
}

var text = 'When I was born my parents named me Pesho Ivanov, and still my name is Pesho Ivanov and now I am 102 years old. Two years ago my first name was Pesho, and my last name was Ivanov. ';
var words = getWords(text);
var wordsCount = countWords(words);

for (var word in wordsCount) {
    if (wordsCount.hasOwnProperty(word)) {
        console.log(word + ' -> ' + wordsCount[word]);
    }
}