console.log('Problem 7. Find Youngest Person\n');

function findYoungestPerson(persons) {

    var people = persons.slice();

    var youngestPersonAge = Number.MAX_VALUE;
    var youngestPersonIndex = 0; // this will store the index of the youngest person

    for (var index in people) {

        if (people[index].age < youngestPersonAge) { // if the current person's age is smaller ...

            youngestPersonAge = people[index].age; // ... the current person's age becomes the smallest ...
            youngestPersonIndex = index; // .. and the current person's index becomes the index of the youngest person
        }
    }

    // Assembling output
    var youngestPerson = people[youngestPersonIndex].firstName + ' ' + people[youngestPersonIndex].lastName;
    var output = 'The youngest person is ' + youngestPerson + '.';

    // Printing output
	for (var person in people) {
		console.log('First Name: ' + people[person].firstName + '; Last Name: ' + people[person].lastName + '; Age: ' + people[person].age + ';');
	}
	console.log(); // an empty row
    console.log(output);
    console.log(); // an empty row
}

// SAMPLE INPUT
var persons = [
    {firstName: 'George', lastName: 'Kolev', age: 32},
    {firstName: 'Bay', lastName: 'Ivan', age: 81},
    {firstName: 'Baba', lastName: 'Ginka', age: 14}];

// OUTPUT
findYoungestPerson(persons);

// EXIT CONSOLE
var exit = require('readline');
var prompt = exit.createInterface(process.stdin, process.stdout);

prompt.question('Press Enter to exit ...', function () {
    process.exit();
});